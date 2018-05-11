using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Material>().color = GetComponent<Material>().color = Color.green;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
