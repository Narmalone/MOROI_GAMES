using UnityEngine;

public class PlayerControllerScript : MonoBehaviour, ICharacter
{
    //Player Controller Variables//

    private Rigidbody m_playerRigidBody;

    private Vector3 m_playerMovementInput;
    private Vector2 m_playerMouseInput;

    //Var en rapport avec le sol//
    [SerializeField] private LayerMask m_groundMask;
    [SerializeField] private float m_groundDistance;
    [SerializeField] private Transform m_groundCheck;
    private bool isGrounded;

    private float m_xRotation;
    [SerializeField] private float m_sensibility;
    [SerializeField, Tooltip("Vitesse en m/s")] private float m_speed;
    [SerializeField, Tooltip("Puissance en ")] private float m_jumpForce;

    private float m_life;

    //Camera//
    //Drag & drop the Transform//
    [SerializeField, Tooltip("Drag & drop le transform de la caméra du joueur")] private Transform m_playerCamera;

    public float Speed { get => m_speed; 
        set 
        { 
            if (value <= 0) 
            {
                m_speed = value;
            } 
        } 
    }
    public float Life { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Awake()
    {
        m_playerRigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        m_playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();

        isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);
        Debug.Log(isGrounded);
    }

    public void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(m_playerMovementInput) * m_speed * Time.deltaTime;
        m_playerRigidBody.velocity = new Vector3(moveVector.x, m_playerRigidBody.velocity.y, moveVector.z);

        Debug.Log(m_playerRigidBody.velocity);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            m_playerRigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }

    public void MovePlayerCamera()
    {
        m_xRotation -= m_playerMouseInput.y * m_sensibility;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);
        transform.Rotate(0f, m_playerMouseInput.x * m_sensibility, 0f);
        m_playerCamera.transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
    }
}
