using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] int health;
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timebtwattack;
    public int damage;
    public int pickup_chance;
    public GameObject[] pickups;
    public int health_pickup_chance;
    public GameObject healthchance;
    public GameObject deathEffect;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            int randomno = Random.Range(0, 100);
            if(randomno < pickup_chance)
            {
                GameObject randompickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randompickup, transform.position, Quaternion.identity);
            } 
            int randomnos = Random.Range(0, 100);
            if(randomnos < health_pickup_chance)
            {
               
                Instantiate(healthchance, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
