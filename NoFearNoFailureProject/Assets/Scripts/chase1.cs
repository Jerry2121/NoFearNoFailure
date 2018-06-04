using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class chase1 : MonoBehaviour {
    public Transform[] Waypoints;
    public Transform player;
    public GameObject Test;
    private int destPoint = 0;
    public int ownhp = 0;
    public float timer;
    public float timer2;
    public float timer3;
    public float timer4;
    public float TimeScare;
    public float TimeScareInt;
    public float closedistance;
    public float attackdistance;
    public bool ScareAct;
    public bool ScarTrig;
    public bool ran;
    public bool Scare;
    public bool walking;
    public bool attack;

    private Animator animator;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.autoBraking = false;
        GotoNextPoint();
        walking = true;
        ran = false;
        timer = 6;
        ownhp = 10;
    }
	
	void Update () 
	{
        timer2 += Time.deltaTime;
        TimeScareInt += Time.deltaTime;
        TimeScare += Time.deltaTime;
        timer += Time.deltaTime;
        Vector3 tempforward = this.transform.forward;
        tempforward.y = 0;
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
		float angle = Vector3.Angle(direction,this.transform.forward);
        if (ownhp <= 0)
        {
            walking = false;
            ran = false;
            attack = false;
            GetComponent<NavMeshAgent>().speed = 0;
            GetComponent<Rigidbody>().mass = 10000;
            timer4 += Time.deltaTime;
            animator.SetBool("dead", true);
            if (timer4 >= 4.667)
            {
                Destroy(gameObject);
            }
        }
        if (walking)
        {
            animator.SetBool("idle_normal", false);
            animator.SetBool("move_forward", true);
            attack = false;
        }
        else if (!walking && !attack)
        {
            animator.SetBool("move_forward", false);
            animator.SetBool("idle_normal", true);
        }
        /*if (closeEnough && attack)
        {
            if (attack && timer2 >= 1)
            {
                attack = false;
                timer2 = 0;
            }
            GetComponent<NavMeshAgent>().speed = 0;
            animator.SetBool("idle_combat", false);
            animator.SetBool("attack_short_001", true);
        }*/
        if (attack)
        {
            animator.SetBool("move_forward", false);
            animator.SetBool("idle_combat", true);
            if (direction.magnitude < closedistance)
            {
                GetComponent<NavMeshAgent>().speed = 0;
                animator.SetBool("idle_combat", false);
                animator.SetBool("attack_short_001", true);
                if (direction.magnitude < attackdistance && direction.magnitude < closedistance)
                {
                    timer3 += Time.deltaTime;
                    if (timer3 >= 1.3)
                    {
                        SoundFunction();
                        PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 2);
                        timer3 = 0;
                    }
                }
            }
            else
            {
                if (timer2 > 1)
                {
                    attack = false;
                    walking = true;
                    ran = false;
                    animator.SetBool("attack_short_001", false);
                    animator.SetBool("idle_combat", false);
                    GetComponent<NavMeshAgent>().speed = 3.5f;
                    timer2 = 0;
                }
            }
        }
        if (!attack)
        {
            animator.SetBool("attack_short_001", false);
            animator.SetBool("idle_combat", false);
            walking = true;
        }
        
        if (TimeScareInt >= 2)
        {
            ScarTrig = false;
        }
        if (TimeScare >= 3 && TimeScareInt >= 2)
        {
            ScareAct = false;
        }
        


        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
		{
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, player.transform.position - this.transform.position, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.transform.gameObject.tag == "Player" || hit.collider.gameObject.tag == "WandBox")
                {
                    agent.destination = player.position;
                    direction.y = 0;
                    timer = 0;
                    // ScareFunction();
                    if (!ran)
                    {
                        attack = true;
                        walking = false;
                        ran = true;
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, direction * 10, Color.white);
                }
            }
        }
         if (timer <= 5)
         {
             agent.destination = player.position;
             direction.y = 0;
         }
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (Waypoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = Waypoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % Waypoints.Length;
    }
    void SoundFunction()
    {
         ScareAct = true;
         if (ScareAct == true && ScarTrig == false)
         {
             AudioSource Audio = Test.GetComponent<AudioSource>();
             Audio.Play();
             ScarTrig = true;
         }
    }
     void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Fireball")
        {
            ownhp = ownhp - 2;
        }
    }
   /* private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Foo");
            closeEnough = true;
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
       // closeEnough = false;
    }
}
