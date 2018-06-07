using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour {

    public float sensitiveInterval = 0.1f;
    public bool faceleft = false;

    Rigidbody2D rb;
    Animator animator;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.x < -1 * sensitiveInterval)
        {
            faceleft = true;
            animator.SetBool("isWalking", true);
        } else if(rb.velocity.x >= -1 * sensitiveInterval && rb.velocity.x <= sensitiveInterval)
        {
            
            animator.SetBool("isWalking", false);
        } else if (rb.velocity.x > sensitiveInterval)
        {
            faceleft = false;
            animator.SetBool("isWalking", true);
        }
	}

}
