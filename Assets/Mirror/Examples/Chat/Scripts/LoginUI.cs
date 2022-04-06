using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror.Examples.Chat
{
    public class LoginUI : MonoBehaviour
    {
        [Header("UI Elements")]
        public TMP_InputField usernameInput;
        public TMP_InputField passwordInput;
        public Button hostButton;
        public Button clientButton;
        public TextMeshProUGUI errorText;

        public static LoginUI instance;

        void Awake()
        {
            instance = this;
        }

        // Called by UI element UsernameInput.OnValueChanged
        public void ToggleButtons(string username)
        {
            hostButton.interactable = !string.IsNullOrWhiteSpace(username);
            clientButton.interactable = !string.IsNullOrWhiteSpace(username);
            Debug.Log(username);
        }
    }
}
