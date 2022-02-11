using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoor : MonoBehaviour
{

    //OBS:Detta script anv�nds inte
    //Det h�r scriptet ska sitta p� Spelaren

    public GameObject currentDoor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//Om man trycker p� E
        {
            if (currentDoor != null)//Och st�r framf�r en d�rr
            {
                transform.position = currentDoor.GetComponent<Door>().GetDestination().position;//S� f�rflyttas man till en annan d�rr
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))//Kollar om den kolliderar med en d�rr
        {
            currentDoor = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))//Kollar om den kolliderar med den andra d�rren
        {
            if (collision.gameObject == currentDoor)
            {
                currentDoor = null;
            }
        }
    }

}
