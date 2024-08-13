using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        GameManager.Instance.StartGame();
    }

    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            SceneManager.LoadScene(3);
        }
    }

}
