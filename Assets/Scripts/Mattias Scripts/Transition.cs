using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject camPoint;
    public GameObject currentRoom;
    public GameObject formerRoom;
    public GameObject player;
    public Transform NewRespawn;
    


    private void Update()
    {
        //Kan jag få transition koden att overitea spawnpointen i healthscripten
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {//If the player collides with this object the camera will switch to a diffrent campoint and the active room will change to make sure no enemy from a later room can snipe the player. Mattias It also changes the respawn point now. Mattias 2.0
            Camera.main.transform.position = camPoint.transform.position;
            currentRoom.SetActive(true);
            player.transform.position = player.transform.position + new Vector3(2, 0, 0);
            formerRoom.SetActive(false);
            collision.GetComponent<HealthTest>().SpawnPoint = NewRespawn;
        }
    }
}
