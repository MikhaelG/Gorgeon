using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //OBS: Denna kod anv�nds inte

    public GameObject Player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//N�r kollision med en gameobject som har tagen "Player"
        {
            Destroy(Player);//F�rst�r Playern
            Debug.Log("Colliding with Player");
        }
    }
}
