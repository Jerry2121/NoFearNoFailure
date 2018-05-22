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
        if (timer >= 2)
        {
            Fireball.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("22222");

        if (collision.gameObject.tag == "Enemy")
        {
            Fireball.SetActive(true);
            Debug.Log("dsa");
        }
    }
}
