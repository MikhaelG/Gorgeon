using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Melker
public class EnemyBullet2 : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D bulletRD;

    void Start()
    {
        bulletRD = GetComponent<Rigidbody2D>();//Kallar p� bulletens rigidbody
        Destroy(this.gameObject, 7);//F�rst�r bullet efter 7 sekunder
    }
}
