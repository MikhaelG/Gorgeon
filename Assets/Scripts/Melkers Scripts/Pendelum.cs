using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Melker
public class Pendelum : MonoBehaviour
{
    Rigidbody2D rb2d;//Reference till rigidbody

    public float moveSpeed;
    public float leftAngle; //Vinkel för vänstra sidan
    public float rightAngle; //Vinkel för högra sidan

    bool movingClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Länkar den första rigidbodyn på objekten (Hand i Hierarchy)
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation.z);
        Move();
    }

    public void ChangeMoveDir ()
    {
        if (transform.rotation.z > rightAngle)// Om pendelum hamnar bakom rightAngle så kommer den att åka åt vänster
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)// Om pendelum hamnar bakom leftAngle så kommer den att åka åt höger
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed; //Rör sig åt höger
        }

        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1*moveSpeed; //Rör sig åt vänster
        }
    }

}
