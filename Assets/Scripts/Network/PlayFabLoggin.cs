using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayFabLoggin : MonoBehaviour
{
    [SerializeField] private GameObject m_signInDisplay = default;

    [SerializeField] private TMP_InputField m_usernameInputField = default;
    [SerializeField] private TMP_InputField m_emailInputField = default;
    [SerializeField] private TMP_InputField m_passwordInputField = default;

    public static string SessionTicket;
    public static string EntityId;
    public void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = m_usernameInputField.text,
            Email = m_emailInputField.text,
            Password = m_passwordInputField.text
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            m_signInDisplay.SetActive(false);
            LoadNextScene();
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void SignIn()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = m_usernameInputField.text,
            Password = m_passwordInputField.text
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            m_signInDisplay.SetActive(false);
            LoadNextScene();
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("nextScene");
    }
}
