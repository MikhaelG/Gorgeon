using UnityEngine;
using UnityEngine.SceneManagement;
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


        forcedY = transform.position.y; // Makes sure the boss don't begin to randomly float and get stuck on the ceiling. Mattias
        player = GameObject.FindGameObjectWithTag("Player").transform; //Letar efter spelaren och dess transform värde. Melker
    }


    void Update()
    {
        if (timeToFall == false)
        {// Makes sure Y is reactivated so the boss can fall. Mattias
            transform.position = new Vector3(transform.position.x, forcedY, 0);
        }
        
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
            {// This code makes the boss simply countdown until the it is time to stop being vulnarable and become invulnarable again by activating a few bools. Mattias
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
        {//This entire code uses colliders in a way i cannot remember how it works. Mattias
            playerTooClose = true;
            HealthTest playerHealth = player.GetComponent<HealthTest>();
            anim.SetTrigger("Attack");
           if(Tocktick >= magicCountdown) 
            { // another countdown. Mattias
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
        //This code makes the boss randomly select which of it's three fire points it is going to shoot from. Mattias
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
        {//If the boss is stunned from using too many attacks when he strikes he will take damage and move 5 to the right. Mattias
            BossHitPoints -= damage;
            transform.position += new Vector3(5, 0, 0);
            print("kanske aj");
            isConfused = false;
            cantTouchThis = true;
            bossAttackAmount = 0;
            Imdone = 0;
            if (BossHitPoints >= 0)
            {// If the boss runs out of hp his falling animation begins playing and he falls of a cliff.
                timeToFall = true;
                anim.SetTrigger("Fall");
                tickTock += Time.deltaTime;
                if (tickTock >= deathcountdown)
                {//Yet another Timer this one simply making sure we can see the boss begin to fall.
                    SceneManager.LoadScene(4);
                    Destroy(gameObject);
                }
            }
        }

    }

    public void OnDrawGizmosSelected()
    {//Creates the gizmo that he uses when he physicaly attacks. Mattias. 
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hitbox.position, lineOfSite); //Skapar en cirkel runt om enemyn. Melker
    }
}
