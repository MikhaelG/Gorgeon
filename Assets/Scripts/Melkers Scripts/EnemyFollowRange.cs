using UnityEngine;

public class EnemyFollowRange : MonoBehaviour
{
    public float speed;
    public float lineOfSite; //Hur står enemyns syn är
    public Transform player; //Det som enemyn ska följa efter

    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    public float hp = 2;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; //Letar efter spelaren och dess transform värde
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);//Enemyn följer spelaren när den är i närheten
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)//Om spelaren är inanför dess syn men också är utanför shootingRange
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime); //Rör sig mot spelaren med en viss hastighet
        }
        else if (distanceFromPlayer < shootingRange && nextFireTime < Time.time)//Om spelaren är innanför shootingRange
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);//Skapar en bullet vid bulletParent. Ingen rotation
            nextFireTime = Time.time + fireRate;//Hur ofta enemyn kan skjuta
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite); //Skapar en cirkel runt om enemyn
        Gizmos.DrawWireSphere(transform.position, shootingRange); //Skapar en cirkel runt om enemyn
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}