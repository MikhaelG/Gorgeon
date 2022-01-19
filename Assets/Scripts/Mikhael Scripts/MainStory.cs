using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Mikhaels kod

public class MainStory : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
