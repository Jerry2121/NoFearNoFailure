using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float timer = 0.0f;
	public float spawntimer = 2.0f;
	public GameObject prefab;
 //   public GameObject prefab1;
  //  public GameObject prefab2;
    public int num = 0;



    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        num = Random.Range(1, 4);

        timer += Time.deltaTime;

        Vector3 spawnPosition = transform.position;

        if (timer >= spawntimer) {

			GameObject enemy = (GameObject)Instantiate (prefab, spawnPosition, Quaternion.identity);
            timer = 0;
		}
       /* if (Input.GetButton("Fire1"))
        {
            if (num >= 1 && timer >= spawntimer)
            {
                GameObject enemy = (GameObject)Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
            if (num >= 2 && timer >= spawntimer)
            {
                GameObject enemy = (GameObject)Instantiate(prefab1, spawnPosition, Quaternion.identity);
            }
            if (num >= 3 && timer >= spawntimer)
            {
                GameObject enemy = (GameObject)Instantiate(prefab2, spawnPosition, Quaternion.identity);
            }
        }*/
    }
}
