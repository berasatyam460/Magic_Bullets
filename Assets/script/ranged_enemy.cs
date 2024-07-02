using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranged_enemy : enemy
{
    public float stopDistance;
     float attackTime;
    Animator anim;
    public GameObject e_bullet;
    public Transform shotposition;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); ;
            }
            else
            {
                if (Time.time >= attackTime)
                {

                    attackTime = Time.time + timebtwattack;
                    anim.SetTrigger("attack");

                }
            }
        }
    }
    public void RangeAttack()
    {
        Vector2 direction = player.position-shotposition.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        shotposition.rotation = rotation;

        Instantiate(e_bullet, shotposition.position, shotposition.rotation);

    }
}
