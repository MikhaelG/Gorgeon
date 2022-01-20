using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    public GameObject bullet;
    public GameObject bulletParentRight;
    public GameObject bulletParentLeft;

    public float fireRate = 1f;
    private float nextFireTime;

    private bool movingRight = true; //Jag berättar vad enemyn ska göra när den kommer till kanten av en platform

    public Transform groundDetection;

    public float hp = 1000;
    

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
        if (nextFireTime < Time.time)
        {
            nextFireTime = Time.time + fireRate;
            Rigidbody2D leftTear = Instantiate(bullet, bulletParentLeft.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            Rigidbody2D rightTear = Instantiate(bullet, bulletParentRight.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            leftTear.AddForce(new Vector3(-1, 1, 0) * 400);
            rightTear.AddForce(new Vector3(1, 1, 0) * 400);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

}
