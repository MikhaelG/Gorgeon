using UnityEngine;

public class Boss : MonoBehaviour
{
    public float attackcountdown = 3;
    public float attacktime;

    public float restCountdown = 5;
    public float Imdone;

    public float deathcountdown = 3;
    public float tickTock;

    public float magicCountdown = 1;
    public float Tocktick;

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
    public bool timeToFall = false;

    public GameObject newMap;

    public Animator anim;
    float forcedY;
    void Start()
    {

        //timetofall måste ändra eller avaktivera forcedY
        forcedY = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player").transform; //Letar efter spelaren och dess transform värde. Melker
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, forcedY, 0);
        attacktime += Time.deltaTime; //This code makes the boss attack the player by counting to 3 and then doing the shoot command. Naturally it does not activate if something stops it. Mattias.
        if (attacktime >= attackcountdown && isConfused == false && playerTooClose == false)
        {
            anim.SetTrigger("Blast");
            Shoot();
            bossAttackAmount += 1;
            attacktime = 0;

        }

        Attack();

        if (bossweakpoint <= bossAttackAmount)
        { // With every attack bossattackamount increases and when it becomes the same as bossweakpoint the boss activates it's vulnarable state. Mattias
            anim.SetTrigger("Trott");
            Debug.Log("YOLO");
            isConfused = true;
            cantTouchThis = false;


            Imdone += Time.deltaTime;
            if (Imdone >= restCountdown)
            {
                isConfused = false;
                cantTouchThis = true;
                bossAttackAmount = 0;
                Imdone = 0;
            }

        }

    }

    public void Attack()
    {
      
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, lineOfSite, playerLayer);
        foreach (Collider2D player in hitEnemies)
        {
            playerTooClose = true;
            HealthTest playerHealth = player.GetComponent<HealthTest>();
            anim.SetTrigger("Attack");
           if(Tocktick >= magicCountdown) 
            { 
            playerHealth.TakeDamage(damage);
            player.transform.position += new Vector3(-2, 0, 0);
                Debug.Log("We hit " + player.name);
                bossAttackAmount += 1;
                print("Attack klar");
            }
             playerTooClose = false;
         
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
            transform.position += new Vector3(5, 0, 0);
            print("kanske aj");
            isConfused = false;
            cantTouchThis = true;
            bossAttackAmount = 0;
            Imdone = 0;
            if (BossHitPoints <= 0)
            {
                timeToFall = true;
                anim.SetTrigger("Fall");
                tickTock += Time.deltaTime;
                if (tickTock >= deathcountdown)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hitbox.position, lineOfSite); //Skapar en cirkel runt om enemyn. Melker
    }
}
