using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTest : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 10;

    [SerializeField]
    public Transform SpawnPoint;
    public bool Respawn;

    public Text respawnsLeft;
    public int RespawnAmount;

    public AudioClip deathClip;

    void Start()
    {
        RespawnAmount = 3;
        respawnsLeft = GetComponent<Text>();
    }

    void Update()
    {
        respawnsLeft.text = RespawnAmount.ToString();

        if (healthAmount <= 0)
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Respawn = true;
            RespawnAmount -= 1;
            //Destroy(this.gameObject);
        }
        else
        {
            Respawn = false;
        }

        if (Respawn)
        {
            transform.position = SpawnPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage (float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 10;
    }

}
