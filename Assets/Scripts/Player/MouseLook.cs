using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Sensi du joueur
    public float m_sensibility;

    //Drag & drop le transform du joueur//
    [SerializeField]private Transform m_playerBody;

    //rotation en x de la souris//
    private float m_xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_sensibility * Time.deltaTime;

        m_playerBody.Rotate(Vector3.up * mouseX);

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
    }
}
