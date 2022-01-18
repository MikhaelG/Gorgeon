using UnityEngine;

public class Boss : MonoBehaviour
{
    public float attackcountdown = 3;
    public float attacktime;
    public Transform FirePointT;
    public Transform FirePointM;
    public Transform FirePointB;
    public GameObject BossthrowPrefab;

    public float lineOfSite;
    public Transform player;

    private float bossAttackAmount;
    public float BossHitPoints = 5;
    public float bossweakpoint = 5;

    public bool playerTooClose = false;
    public bool isConfused = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Letar efter spelaren och dess transform värde. Melker
    }


    void Update()
    {
        attacktime += Time.deltaTime;
        if (attacktime >= attackcountdown && isConfused == false && playerTooClose == false)
        {
            Shoot();
            attacktime = 0;
            bossAttackAmount = + 1;
        }

        /*  if(lineofsite GameObject.FindGameObjectWithTag("Player") = true && isConfused == false)
           {
              // Animator.play attack animation
              //Punch player
           }*/

        if (bossweakpoint == bossAttackAmount )
        {
            isConfused = true;
        }

        if(isConfused == true)
        {
           // Animator.play cornfused animation
           //Activate opportunity for player to attack
        }
        else if (isConfused == false)
        {
            //Animator.play idle animation
            //make invulnarable again
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
        BossHitPoints -= damage;
        transform.position += new Vector3(5, 0, 0);
        isConfused = false;
        if (BossHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite); //Skapar en cirkel runt om enemyn. Melker
    }
}
