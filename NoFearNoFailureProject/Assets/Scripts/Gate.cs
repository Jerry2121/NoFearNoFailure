using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    Animator anim;
    public bool Open;
    public bool left;
    public bool right;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if (Open == true)
        {
            if (left == true)
            {
                transform.Rotate(0, 85, 0);
            }
            if (right == true)
            {
                transform.Rotate(0, -85, 0);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Open == true) {
           // anim.SetBool("isOpen", true);
        }

    }
}
