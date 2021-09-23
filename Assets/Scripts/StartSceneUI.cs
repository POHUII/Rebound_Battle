using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public void StartGameButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameButtonClick()
    {
        Application.Quit();
    }
}
