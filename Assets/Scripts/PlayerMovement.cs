using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : HealthBar
{
    public float speed;
    private Rigidbody2D PlayerRigidbody;
    private Vector2 shift;
    private Animator animator;

    public bool turnedRight = false;

    public GameObject healthBar;

    public int health = 10;
    public int StartHealth;
    public Text expText;
    private int EXP = 0;

    public bool isDead = false;
    public Text levelText;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        healthBar.GetComponent<HealthBar>().setMaxHealth(10);
        healthBar.GetComponent<HealthBar>().setHealth(10);
        StartHealth = health;
        levelText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shift = Vector2.zero;
        shift.x = Input.GetAxisRaw("Horizontal");
        shift.y = Input.GetAxisRaw("Vertical");
        Debug.Log(shift);
        AnimationAndMovementUpdate();
    }

    void showCompleted()
    {
        levelText.gameObject.SetActive(true);
        Invoke("hideCompleted", 2);
    }

    void hideCompleted()
    {
        levelText.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        PlayerRigidbody.velocity = new Vector2(shift.x * speed, shift.y * speed);
    }

    void AnimationAndMovementUpdate() {
        
        if (shift != Vector2.zero)
        {
            FixedUpdate();
            if (shift.x > 0)
            {
                turnedRight = true;
            } else {
                turnedRight = false;
            }
            animator.SetFloat("moveX", shift.x);
            animator.SetFloat("moveY", shift.y);
            animator.SetBool("moving", true);
            
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
			healthBar.GetComponent<HealthBar>().TakeDamage(1);
            health -= 1;
            Invoke("HidePlayerBlood", 0.25f);

            if (health <= 0) {
                isDead = true;
            }
        }
        else if (collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<SpawnerScript>().GetGateway();
        }
    }
    void HidePlayerBlood()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Heal(int heal) {
        health += heal;
        healthBar.GetComponent<HealthBar>().Heal(heal);
        if (health > 10) {
            health = 10;
        }
    }

    public void GainEXP(int amount){
        EXP += amount;
        expText.text = EXP.ToString();
        if (EXP == 100)
        {
            showCompleted();
        }
    }
}