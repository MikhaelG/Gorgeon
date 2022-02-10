using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //OBS: Denna kod används inte

    public GameObject Player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//När kollision med en gameobject som har tagen "Player"
        {
            Destroy(Player);//Förstör Playern
            Debug.Log("Colliding with Player");
        }
    }
}
