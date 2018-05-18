using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float timer = 0f;
    public float timer1 = 0f;

    public GameObject FireBall;
    public float shootDistance = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timer1 += Time.deltaTime;

        Vector3 spawnPosition = transform.position;
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 shootDir = playerPos - spawnPosition;


        if (timer >= 2 && shootDir.magnitude < shootDistance)
        {

            GameObject GoonBoss = (GameObject)Instantiate(FireBall, spawnPosition, Quaternion.identity);
            //	GoonBoss.GetComponent<EnemyMove> ().player = GameObject.FindGameObjectWithTag ("Player").transform;
            Destroy(GoonBoss, 5.0f);
            timer = 0;

        }
        if (timer1 >= 5 && gameObject.name == "Sphere(Clone)") {
            Destroy(gameObject);
        }
    }
}
