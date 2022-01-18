using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 3;
    public Rigidbody2D rb;
    public int damage = 1;

    public float timer;
    public float Deathcountdown = 15;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

 void Update()
    {
        Destroy(this.gameObject, 4);
       
    }

    
}

