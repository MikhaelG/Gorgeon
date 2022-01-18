using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    public GameObject bullet;
    public GameObject bulletParent;
    public GameObject bulletParent2;

    private bool movingRight = true; //Jag berättar vad enemyn ska göra när den kommer till kanten av en platform

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Nu kommer den att gå åt höger

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance); //(origin, direction, lenght)
        if (groundInfo.collider == false) //Kollar om Raycasten kolliderar med något
        {
            if (movingRight == true) //Om vi gick åt höger, så kommer enemyn att vända sig med 180 grader
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else //Om vi gick åt vänster, så kommer enemyn att få sin vanliga rotation (0, 0, 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        ShootAtAngle();

    }

    public void ShootAtAngle ()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        Instantiate(bullet, bulletParent2.transform.position, Quaternion.identity);
    }

}
