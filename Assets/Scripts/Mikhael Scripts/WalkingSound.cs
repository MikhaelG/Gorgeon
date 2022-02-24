using UnityEngine;
using System.Collections;
//Mikhaels kod
public class WalkingSound : MonoBehaviour
{

    PlayerMovement cc;
    void Start()
    {
        cc = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (cc.isGrounded == true && cc.speed > 2f && GetComponent<AudioSource>().isPlaying == false) //ifall spelaren �r p� marken och hastigheten �r mer �n 2, s� kollar audiosource  ifall den spelas. Om inte, d� b�rjar den  
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

