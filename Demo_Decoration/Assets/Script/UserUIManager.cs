using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserUIManager : MonoBehaviour
{
    public void OnClickReturn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickReturnUserScene()
    {
        SceneManager.LoadScene("UserScene");
    }
}
