using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject PMenu;
    public static bool pauseCheck;

    private void Start()
    {
        PMenu.SetActive(false);
        pauseCheck = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseCheck)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            pauseCheck = !pauseCheck;
        }
    }

    public void PauseGame ()
    {
        PMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void ResumeGame ()
    {
        PMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToStart ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame ()
    {
        Debug.Log("Sayonara~");
        Application.Quit();
    }
}
