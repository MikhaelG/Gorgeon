using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Mikhaels kod

public class MainMenu : MonoBehaviour
{
  public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //ladda nästa scen i build settings
    }

    public void QuitGame ()
    {
        Application.Quit();
    }


}
