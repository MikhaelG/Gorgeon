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
        if (cc.isGrounded == true && cc.speed > 2f && GetComponent<AudioSource>().isPlaying == false) //ifall spelaren är på marken och hastigheten är mer än 2, så kollar audiosource  ifall den spelas. Om inte, då börjar den  
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

