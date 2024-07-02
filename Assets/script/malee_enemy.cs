using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malee_enemy : enemy
{
    public float stopDistance;
    float attacktime;
   public  float attackspeed;

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); ;
            }
            else
            {
                if (Time.time >= attacktime)
                {
                    StartCoroutine(attack());
                    attacktime = Time.time + timebtwattack;
                }
            }
        }
    }

    IEnumerator attack() 
    {
        player.GetComponent<playerMove>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackspeed;
            while (percent <= 1)
            {
                percent += Time.deltaTime * attackspeed;
                float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
                transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
                yield return null;
            }
        }
    }
}
