using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoor : MonoBehaviour
{

    //OBS:Detta script används inte
    //Det här scriptet ska sitta på Spelaren

    public GameObject currentDoor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//Om man trycker på E
        {
            if (currentDoor != null)//Och står framför en dörr
            {
                transform.position = currentDoor.GetComponent<Door>().GetDestination().position;//Så förflyttas man till en annan dörr
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))//Kollar om den kolliderar med en dörr
        {
            currentDoor = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))//Kollar om den kolliderar med den andra dörren
        {
            if (collision.gameObject == currentDoor)
            {
                currentDoor = null;
            }
        }
    }

}
