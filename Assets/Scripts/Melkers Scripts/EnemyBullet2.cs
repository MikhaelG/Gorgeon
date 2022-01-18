using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D bulletRD;

    void Start()
    {
        bulletRD = GetComponent<Rigidbody2D>();
        //bulletRD.velocity = new Vector2(moveDire.x, moveDire.y);
        Destroy(this.gameObject, 5);
    }
}
