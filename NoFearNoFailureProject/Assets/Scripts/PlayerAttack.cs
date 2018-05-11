using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    private Animator animator;
    public float timer;
    public bool attack;
    public GameObject HealthText;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        PlayerPrefs.SetInt("Health", 100);
    }
	
	// Update is called once per frame
	void Update () {
        HealthText.GetComponent<Text>().text = "Health: " + PlayerPrefs.GetInt("Health");
        timer += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Attack", true);
            attack = true;
        }
        if (timer >= 0.1 && attack)
        {
            animator.SetBool("Attack", false);
            attack = false;
            timer = 0;
        }
        if (PlayerPrefs.GetInt("Health") > 100)
        {
            PlayerPrefs.SetInt("Health", 100);
        }
	}
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "ESword")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 2);
        }
    }
}
