using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Melker
public class SwitchScene : MonoBehaviour
{
    public void LoadScene ()
    {
        SceneManager.LoadScene("Extra");
    }
}
