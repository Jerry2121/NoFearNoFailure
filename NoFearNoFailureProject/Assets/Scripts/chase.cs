using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class chase : MonoBehaviour {
    public Transform[] Waypoints;
    public Transform player;
    public GameObject Test;
    private int destPoint = 0;
    public int ownhp = 0;
    public float timer;
    public float timer2;
    public float TimeScare;
    public float TimeScareInt;
    public bool ScareAct;
    public bool ScarTrig;
    public bool closeEnough;
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
        closeEnough = false;
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
            Destroy(gameObject);
        }
        if (walking)
        {
            animator.SetBool("isWalking", true);
            attack = false;
            closeEnough = false;
        }
        if (!walking)
        {
            animator.SetBool("isWalking", false);
        }
        if (closeEnough && attack)
        {
            if (attack && timer2 >= 1)
            {
                attack = false;
                timer2 = 0;
            }
            GetComponent<NavMeshAgent>().speed = 0;
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalking", false);
        }
        if (attack)
        {

        }
        if (!attack)
        {
            animator.SetBool("isAttack", false);
            GetComponent<NavMeshAgent>().speed = 3.5f;
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
                    ScareFunction();
                    attack = true;
                    walking = false;
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
    void ScareFunction()
    {
        ScareAct = true;
        if (ScareAct == true && ScarTrig == false)
        {
            AudioSource Audio = Test.GetComponent<AudioSource>();
            Audio.Play();
            ScarTrig = true;
        }
     }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sword")
        {
            ownhp = ownhp - 2;
        }
        if (other.gameObject.tag == "Fireball")
        {
            ownhp = ownhp - 2;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Close")
        {
            closeEnough = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        closeEnough = false;
        attack = false;
    }
}
