using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summoner : enemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetposition;
    private Animator anim;
    public float timebtwsummon;
    float summonTime;
    public enemy smallenemy;

   public  float maleeattackspeed;
    public float stopDistance;
    float attacktime;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetposition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetposition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime); ;
                anim.SetBool("isRunning", true);

            }
            else
            {
                anim.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timebtwsummon;
                    anim.SetTrigger("summon");

                }
            }

            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                if (Time.time >= attacktime)
                {
                    StartCoroutine(attack());
                    attacktime = Time.time + timebtwattack;
                }
            }

        }

    }

   public  void summon()
   {
        if (player != null)
        {
            Instantiate(smallenemy, transform.position, transform.rotation);
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
            percent += Time.deltaTime * maleeattackspeed;
            while (percent <= 1)
            {
                percent += Time.deltaTime * maleeattackspeed;
                float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
                transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
                yield return null;
            }
        }
    }
}
