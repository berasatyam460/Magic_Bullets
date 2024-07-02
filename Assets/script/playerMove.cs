using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    public Transform hand_pos;
    public Image[] hp;
    public Sprite fullhp;
    public Sprite emptyhp;

    Vector2 moveamount;
    Animator animator;
    [SerializeField] Animator eye;
    [SerializeField] int health;
    [SerializeField]Animator hrtanime;
    scenetransition scenetransition;
    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator=this.GetComponent<Animator>();
        scenetransition = FindAnyObjectByType<scenetransition>();


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(blink());
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveamount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveamount * Time.fixedDeltaTime);
    }
    IEnumerator blink()
    {  
        yield return new WaitForSeconds(10f);
        eye.SetTrigger("blink");
       
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        //  camanim.SetTrigger("shake");
        hrtanime.SetTrigger("hurt");
        updateheartUI(health);
        if (health <= 0)
        { 
            scenetransition.LoadScene(2);
            Destroy(this.gameObject,0.5f);
           
        }
    }


    public void changeWeapon(weapon weaponToequip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToequip, hand_pos.position, transform.rotation,  transform);
    }
    
    void updateheartUI(int currenthealth)
    {
        for(int i = 0; i < hp.Length; i++)
        {
            if (i < currenthealth)
            {
                hp[i].sprite = fullhp;

            }
            else
            {
                hp[i].sprite = emptyhp;
            }
        }
    }

    public void heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        updateheartUI(health);
    }
    
}
