using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public weapon weaponToequip;
    public GameObject weapon_pickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(weapon_pickup, transform.position, Quaternion.identity);
            collision.GetComponent<playerMove>().changeWeapon(weaponToequip);
            Destroy(gameObject);
        }
    }
}
