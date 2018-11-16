using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchLevel : MonoBehaviour {

    public string NextLevel;
    public bool EndGame;
	

    public void NextScene()
    {
        SceneManager.LoadScene(NextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            NextScene();
            if (EndGame == true)
            {
                QuitGame();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
