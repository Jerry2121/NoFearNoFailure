using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1 : MonoBehaviour {
    public GameObject Fireball;
    public bool fireball = false;
    public float timer = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (fireball == true && timer >= 2)
        {
            //Destroy(this.gameObject);

        }
    }
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Fireball.SetActive(true);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Fireball.SetActive(true);

        }

    }
}
