using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Cyclop : MonoBehaviour {
    public int startHealth = 25;
    public int Health = 25;
    Animator anim;
    public bool isAttacking;
    public bool isWalking;
    public bool isDead;
    public bool isHit;
    public float timer = 0.0f;
    public float timer1 = 0.0f;
    public bool TimeIt = false;
    public Image HealthBar;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        Health = startHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            anim.SetBool("isDead", true);
            GetComponent<NavMeshAgent>().speed = 0;
            timer1 += Time.deltaTime;
            GetComponent<Rigidbody>().mass = 1000.0f;
            if (timer1 >= 5)
            {
                Destroy(gameObject);
            }
        }
        if (isHit == true && timer >= 0.75f){
            isHit = false;
            anim.SetBool("isHit", false);
            isWalking = true;
            anim.SetBool("isWalking", true);
            TimeIt = false;
            timer = 0;

        }
        if (TimeIt == true) {
            timer += Time.deltaTime;

        }
        HealthBar.fillAmount = Health / startHealth;

    }
    public void ATTACK() {
        anim.SetBool("isAttacking", true);
        isAttacking = true;

    }
    public void notATTACK()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= 5;
            anim.SetBool("isHit", true);
            isHit = true;
            TimeIt = true;
            HealthBar.fillAmount = Health / startHealth;

        }
    }
}
