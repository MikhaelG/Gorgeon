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

    private bool movingRight = true; //Jag ber�ttar vad enemyn ska g�ra n�r den kommer till kanten av en platform

    public Transform groundDetection;

    public float hp = 3;

    public LayerMask mask;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Nu kommer den att g� �t h�ger

        RaycastHit2D groundInfo = Physics2D.BoxCast(groundDetection.position, new Vector2(0.25f, 0.25f), 0, Vector2.down, distance,mask); //(origin, direction, lenght)
        Debug.Log("Jag g�r p� marken");
        if (groundInfo.collider == false) //Kollar om Raycasten kolliderar med n�got
        {
            if (movingRight == true) //Om vi gick �t h�ger, s� kommer enemyn att v�nda sig med 180 grader
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else //Om vi gick �t v�nster, s� kommer enemyn att f� sin vanliga rotation (0, 0, 0)
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
            leftTear.AddForce(new Vector3(-1, 1, 0) * 250);
            rightTear.AddForce(new Vector3(1, 1, 0) * 250);
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
