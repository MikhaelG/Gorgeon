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

    

    public void Attack()
    {
        // animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, attackRange, enemyLayer);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(hitbox.position, attackRange, bossLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name); 
            Patrol enemyHealth = enemy.GetComponent<Patrol>();
            enemyHealth.TakeDamage(damage);
        }
        foreach (Collider2D boss in hitBoss)
        {
            Debug.Log("We hit " + boss.name);
            Boss thisBoss = boss.GetComponent<Boss>();

            if (thisBoss.cantTouchThis == true)
            {
                print("nothing happens");
            }

            if (thisBoss.cantTouchThis == false)
            {
                print("Take That");
                thisBoss.TakeDamage(damage);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitbox == null)
            return;

        Gizmos.DrawWireSphere(hitbox.position, attackRange);
    }
}
