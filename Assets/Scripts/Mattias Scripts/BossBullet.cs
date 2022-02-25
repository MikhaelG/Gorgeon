using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 3;
    public Rigidbody2D rb;
    public int damage = 1;

    public float timer;
    public float Deathcountdown = 15;
    public Transform player;
    void Start()
    {//Makes sure the bullet is actually shot. Mattias
        rb.velocity = transform.up * speed;
    }

 void Update()
    {//Destroys this object after four seconds to make sure they don't start stacking up. Mattias
        Destroy(this.gameObject, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {// Destroys this object after in collides with an object. Mattias
        Destroy(gameObject);
    }


}

