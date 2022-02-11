using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float lineOfSite;
    private Transform player;

    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//Letar efter en gameobject med en tag "Player"
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < shootingRange && nextFireTime < Time.time)//Om spelaren är innanför gizmon och nextFireTime är mindre än Time.time
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);//Skapar en bullet prefab
            nextFireTime = Time.time + fireRate;//Gör så att bullets inte skuter ut konstant
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);//Skapar en cirkel runt om Turret
    }
}
