using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIP : MonoBehaviour {
    public float timer = 0.0f;
    public GameObject prefab;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 5) {
            Destroy(prefab);
        }
    }
}
