using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickups : MonoBehaviour
{
    public int healAmount;
    public GameObject healthPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(healthPickup, transform.position, Quaternion.identity);
            collision.GetComponent<playerMove>().heal(healAmount);
            Destroy(gameObject);

        }
    }
}
