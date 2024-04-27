using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MAINMENU : MonoBehaviour
{
  public  void play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("player start game");
    }


    public void quit()
    {
        Application.Quit();
        Debug.Log("player quit game");
    }
}
