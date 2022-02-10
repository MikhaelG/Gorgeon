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

        if (Respawn)//Om respawn
        {
            if (RespawnAmount > 0) //Om RespawnAmount är större än 0
            {
                transform.position = SpawnPoint.position;//Flytta spelaren till en position, en empty gameobject i scenen
                healthAmount = maxHealth; //Ens liv resettas tillbaka till det som var tidigare
            }
            else
            {
                Destroy(gameObject);//Förstör objektet
                AudioSource.PlayClipAtPoint(deathClip, transform.position);//Spela ett audio clip
            }
            
        }

        if (Input.GetKeyDown(KeyCode.L)) //Test
        {
            TakeDamage(1);//Test
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
        healthBar.fillAmount = healthAmount / 10; //Bilden är uppdelad i ett visst antal delar. Denna måste vara samma som maxHealth
    }

}
