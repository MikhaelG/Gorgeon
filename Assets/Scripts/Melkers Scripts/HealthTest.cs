using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTest : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 10;
    float healthAmount;

    [SerializeField]
    public Transform SpawnPoint;
    public bool Respawn;

    public Text respawnsLeft;
    public int RespawnAmount;

    public AudioClip deathClip;

    void Start()
    {
        healthAmount = maxHealth;
        RespawnAmount = 3;
    }

    void Update()
    {
        respawnsLeft.text = RespawnAmount.ToString();

        if (healthAmount <= 0) //Om healthAmount är mindre än 0
        {
            RespawnAmount -= 1; //Hur många gånger man kommer respawnas - 1
            Respawn = true; //Man kommer respawnas
        }
        else
        {
            Respawn = false; //Respawn är false, man kommer inte respawnas
        }

        if (Respawn)
        {
            if (RespawnAmount > 0)
            {
                transform.position = SpawnPoint.position;
                healthAmount = maxHealth;
            }
            else
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //Om man kolliderar med en gameobjekt som har tagen "Enemy"
        {
            TakeDamage(1); //Ta 1 skada
        }
    }

    public void TakeDamage (float Damage)
    {
        healthAmount -= Damage; //Drar -1 från healthAmount
        healthBar.fillAmount = healthAmount / 10; //
    }

}
