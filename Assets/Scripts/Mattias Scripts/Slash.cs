using UnityEngine;

public class Slash : MonoBehaviour
{
    //public Health hp;
    public int damage = 1;

    public Transform hitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public LayerMask bossLayer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
    }
    public void TakeDamage(int damage)
    {
        /* hp -= damage;
         if (hp <= 0)
         {
             SceneManager.LoadScene("DeathScreen");
         }*/
    }

    private void OnCollisionEnter2D(Collision2D collision) // Gör så att obejektet med PlayerMovement alltså spelaren tar skada om den blir berörd av denna fiende. -Mattias
    {
        /*  if (Input.GetKeyDown(KeyCode.G))
          {
              PlayerMovement enemy = collision.transform.GetComponent<PlayerMovement>();
              if (enemy != null)
              {
                  // enemy.TakeDamage(damage);
              }
          }*/


    }

    public void Attack()
    {
        // animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, attackRange, enemyLayer);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(hitbox.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //enemy take damage
        }

        foreach (Collider2D boss in hitBoss)
        {/*
               Debug.Log("We hit " + boss.name);
               gameObject.GetComponent<Boss>().cantTouchThis= true;
               if(cantTouchThis = false)
               {
                   //nothing happens
               }

            if (cantTouchThis = true)
            {
                private void OnTriggerEnter2D(Collider2D hitInfo)
                {
                    Boss Ramses = hitInfo.transform.GetComponent<Boss>();
                    if (Ramses != null)
                    {
                        Ramses.TakeDamage(damage);
                    }
                } 
            }*/
        
        
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitbox == null)
            return;

        Gizmos.DrawWireSphere(hitbox.position, attackRange);
    }
}
