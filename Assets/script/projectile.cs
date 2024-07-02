using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    float lifetime = 1f;
    [SerializeField] float speed;
    [SerializeField] GameObject explosion;
    [SerializeField] int damage;
    public GameObject firesfx; 
    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        Destroy(gameObject, lifetime);
        Instantiate(firesfx, transform.position, transform.rotation);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.GetComponent<enemy>().TakeDamage(damage);
            DestroyProjectile();

        }
        if (collision.gameObject.tag == "boss")
        {
            collision.GetComponent<boss>().TakeDamage(damage);
            DestroyProjectile();

        }
    }
}
