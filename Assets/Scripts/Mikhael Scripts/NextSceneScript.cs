using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Mikhaels kod
public class NextSceneScript : MonoBehaviour
{
    public void LoadScene(string MenuScene)
    {
        SceneManager.LoadScene(MenuScene); //ladda MenuScene; vi aktiverar action på knappen
    }
}
