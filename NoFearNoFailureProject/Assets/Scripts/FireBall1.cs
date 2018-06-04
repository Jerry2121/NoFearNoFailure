using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1 : MonoBehaviour {
   // public GameObject Fireball;
   //public bool fireball = false;
    public float timer = 0.0f;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
    }

    /*
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Walls")
         {
             //Fireball.SetActive(true);
             Vector3 spawnPosition = transform.position;
             GameObject FIREBALL = (GameObject)Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
             Debug.Log("FIRE");     
             Destroy(this.gameObject);

         }

     }
    */
    void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Walls")
       {
           //Fireball.SetActive(true);
           Vector3 spawnPosition = transform.position;
           GameObject FIREBALL = (GameObject)Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
           Destroy(this.gameObject);

       }

   }
}
