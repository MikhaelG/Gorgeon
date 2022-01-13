using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendelum : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1*moveSpeed;
        }
    }

}
