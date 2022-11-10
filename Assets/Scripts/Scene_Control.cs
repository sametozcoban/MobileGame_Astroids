using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour
{
    public void StarGame()
    {
        SceneManager.LoadScene("Scene_PlayGame");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scene_PlayGame");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Scene_PlayGame");
    }
}
