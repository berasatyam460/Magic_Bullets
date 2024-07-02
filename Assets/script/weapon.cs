using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float timeBTWshoots;
    [SerializeField] Transform shotpos;
    float shottime;
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle -90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shottime)
            {
                Instantiate(projectile, shotpos.position, transform.rotation);
                shottime = Time.time + timeBTWshoots;

            }
        }
    }
}
