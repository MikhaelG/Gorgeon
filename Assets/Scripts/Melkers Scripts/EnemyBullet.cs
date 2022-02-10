using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //OBS: Denna kod används inte

    public GameObject target;
    public float speed;
    public float damage;
    Rigidbody2D bulletRD;

    void Start() //Eftersom detta är i start funktionen så kommer EnemyBullet bara behöva räkna det här en gång för att det ska gälla
    {
        bulletRD = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");//Kollar på Player
        Vector2 moveDire = (target.transform.position - transform.position).normalized * speed;//Räknar vart spelaren är
        bulletRD.velocity = new Vector2(moveDire.x, moveDire.y);//Rör sig mot spelaren
        Destroy(this.gameObject, 2);
    }
}
