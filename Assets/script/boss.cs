using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{

    public int health;
    public enemy[] enemies;
    public float spawndffset;

    private int halfHeatth;
    private Animator anim;

    public int damage;
    Slider bosshealth;

    public GameObject deatheffect;
  scenetransition scenetransition;
    private void Start()
    {
        bosshealth = FindAnyObjectByType<Slider>();
scenetransition = FindAnyObjectByType<scenetransition>();
        halfHeatth = health / 2;
        anim = GetComponent<Animator>();
        bosshealth.maxValue = health;
        bosshealth.value = health;


    }

    public void TakeDamage(int amount)
    {

        health -= amount;
        bosshealth.value = health;

        if (health <= 0)
        {
            Instantiate(deatheffect, transform.position, transform.rotation);
            Destroy(gameObject);
            bosshealth.gameObject.SetActive(false);
            scenetransition.LoadScene(3);

        }

       

        if (health <= halfHeatth)
        {
            anim.SetTrigger("run");
        }
        
        enemy randonEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randonEnemy, transform.position + new Vector3(spawndffset, spawndffset, 0), transform.rotation);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<playerMove>().TakeDamage(damage);
        }
    }
}
