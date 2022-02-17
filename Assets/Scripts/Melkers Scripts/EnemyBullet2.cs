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
        bulletRD = GetComponent<Rigidbody2D>();//Kallar på bulletens rigidbody
        Destroy(this.gameObject, 7);//Förstör bullet efter 7 sekunder
    }
}
