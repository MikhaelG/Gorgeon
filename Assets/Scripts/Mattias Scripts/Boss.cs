using UnityEngine;

public class Boss : MonoBehaviour
{
    public float attackcountdown = 3;
    public float attacktime;

    public float restCountdown = 5;
    public float Imdone;

    public float deathcountdown = 3;
    public float tickTock;

    public int damage = 1;
    public Transform FirePointT;
    public Transform FirePointM;
    public Transform FirePointB;
    public GameObject BossthrowPrefab;


    public float lineOfSite;
    public Transform player;
    public Transform hitbox;
    public LayerMask playerLayer;

    private float bossAttackAmount;
    public float BossHitPoints = 5;
    public float bossweakpoint = 5;

    public bool playerTooClose = false;
    public bool isConfused = false;
    public bool cantTouchThis = true;

    public GameObject newMap;

    public Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Letar efter spelaren och dess transform v�rde. Melker
    }


    void Update()
    {
        
        attacktime += Time.deltaTime;
        if (attacktime >= attackcountdown && isConfused == false && playerTooClose == false)
        {
            anim.SetTrigger("Blast");
            Shoot();
            bossAttackAmount += 1;
            attacktime = 0;

        }

        if (bossweakpoint == bossAttackAmount)
        {
            //anim.Play("Trott");
            Debug.Log("YOLO");
            isConfused = true;
            cantTouchThis = false;
            bossAttackAmount = 0;

            Imdone += Time.deltaTime;
            if (Imdone >= restCountdown) 
            {
                isConfused = false;
                cantTouchThis = true;
            }

        }

    }

    public void Attack()
    {
        // animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, lineOfSite, playerLayer);
        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log("We hit " + player.name);
            HealthTest playerHealth = player.GetComponent<HealthTest>(); //Ers�tt PlayerMovement med det skript som har take dammage funktionen
            //Animator.play attack animation
            playerHealth.TakeDamage(damage);
            player.transform.position += new Vector3(-3, 0, 0);
        }
    }

    void Shoot()
    {

        int random = Random.Range(0, 3);
        if (random == 0)
        {
            Instantiate(BossthrowPrefab, FirePointT.position, FirePointT.rotation);
        }
        else if (random == 1)
        {
            Instantiate(BossthrowPrefab, FirePointM.position, FirePointM.rotation);
        }
        else if (random == 2)
        {
            Instantiate(BossthrowPrefab, FirePointB.position, FirePointB.rotation);
        }



    }
    public void TakeDamage(int damage)
    {
        if (isConfused == true)
        {
            BossHitPoints -= damage;
            transform.position += new Vector3(3, 0, 0);
            isConfused = false;
            cantTouchThis = true;
            if (BossHitPoints <= 0)
            {
                tickTock += Time.deltaTime;
                if (tickTock >= deathcountdown)
                {
                    newMap.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite); //Skapar en cirkel runt om enemyn. Melker
    }
}
