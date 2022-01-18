using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject camPoint;
    public GameObject currentRoom;
    public GameObject formerRoom;
    public GameObject player;


    private void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Camera.main.transform.position = camPoint.transform.position;
            currentRoom.SetActive(true);
            player.transform.position = player.transform.position + new Vector3(2, 0,0);
            formerRoom.SetActive(false);
        }
    }
}
