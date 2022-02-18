using UnityEngine;
using System.Collections;
//Mikhael
public class WalkingSound : MonoBehaviour
{

    PlayerMovement cc;
    void Start()
    {
        cc = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (cc.isGrounded == true && cc.speed > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

