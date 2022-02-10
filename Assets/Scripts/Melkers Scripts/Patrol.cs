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

    public int damage = 1;
    public float hp = 3;

    public LayerMask mask;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Nu kommer den att gå åt höger

        RaycastHit2D groundInfo = Physics2D.BoxCast(groundDetection.position, new Vector2(0.25f, 0.25f), 0, Vector2.down, distance,mask); //(origin, direction, lenght)
        Debug.Log("Jag går på marken");
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
            nextFireTime = Time.time + fireRate;//Gör så att Löken inte spammar tårar oändligt
            Rigidbody2D leftTear = Instantiate(bullet, bulletParentLeft.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();//Skapar en bullet vid bulletParentLeft med ingen rotation
            Rigidbody2D rightTear = Instantiate(bullet, bulletParentRight.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();//Skapar en bullet vid bulletParentRight med ingen rotation
            leftTear.AddForce(new Vector3(-1, 1, 0) * 250); //Gör så att tårarna flyger i en riktning som en regnbåge åt vänster
            rightTear.AddForce(new Vector3(1, 1, 0) * 250); //Gör så att tårarna flyger i en riktning som en regnbåge åt höger
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Jag dör");
            animator.SetTrigger("Die");//Spela animationen "Die" som både gäller för Blodappelsinen och Löken
            Destroy(gameObject);
        }

    }

}
