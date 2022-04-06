using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void DisableObject(GameObject p_obj)
    {
        p_obj.SetActive(false);
        Debug.Log(p_obj);
    }
    public void ActiveObject(GameObject p_obj)
    {
        p_obj.SetActive(true);
        Debug.Log(p_obj);
    }
}
