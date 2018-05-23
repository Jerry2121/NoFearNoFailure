using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavFollow : MonoBehaviour {
    public Transform player;
    NavMeshAgent agent;
    private Vector3 startPosition;
    private bool home = true;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public float chaseTriggerDistance = 3.0f;
    public float paceDistance = 3.0f;
    Animator anim;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
      
        


        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDirection = new Vector3(playerPosition.x - transform.position.x,
                                                playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            //player gets too close to the enemy
            home = false;
            chaseDirection.Normalize();
            //GetComponent<Rigidbody>().velocity = chaseDirection;
            agent.destination = player.position;
           // anim.SetFloat("Walk", Walking);
        }
        else if (home == false)
        {
            Vector3 homeDirection = new Vector3(startPosition.x - transform.position.x,
                                        startPosition.y - transform.position.y, startPosition.z - transform.position.z);
            if (homeDirection.magnitude < 0.3f)
            {
                //we've arrived home
                home = true;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
            }
            else
            {
                //go home
                //homeDirection.Normalize();
                //GetComponent<Rigidbody>().velocity = homeDirection;
                agent.destination = startPosition;
            }
        }
        else
        {
            Vector3 displacement = transform.position - startPosition;
            float distanceFromStart = displacement.magnitude;
            if (distanceFromStart >= paceDistance)
            {
                //do stuff, we've gone too far
                paceDirection = -displacement;
            }
            paceDirection.Normalize();
            GetComponent<Rigidbody>().velocity = paceDirection;
        }
    }
}
