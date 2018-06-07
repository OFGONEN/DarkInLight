using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject darkPlayer;
    public GameObject lightPlayer;

    public GroundChecker darkPlayerHandler;
    public GroundChecker lightPlayerHandler;

    private Collider2D darkCollider;
    private Collider2D lightCollider;

    public float maxSpeed = 3f;

    public float movementSpeed = 5;
    public float jumpSpeed = 5;

    private Rigidbody2D lightRigidBody;
    private Rigidbody2D darkRigidBody;
    private bool isDarkSelected = true;

    private Animator darkAnimator;
    private Animator lightAnimator;

    void Start()
    {
        lightRigidBody = lightPlayer.GetComponent<Rigidbody2D>();
        darkRigidBody = darkPlayer.GetComponent<Rigidbody2D>();

        darkAnimator = darkPlayer.GetComponent<Animator>();
        lightAnimator = lightPlayer.GetComponent<Animator>();

        darkCollider = darkPlayer.GetComponentInChildren<Collider2D>();
        lightCollider = lightPlayer.GetComponentInChildren<Collider2D>();

        darkPlayerHandler = darkPlayer.GetComponentInChildren<GroundChecker>();
        lightPlayerHandler = lightPlayer.GetComponentInChildren<GroundChecker>();
    }


    void Update()
    {

        float dX = Input.GetAxis("Horizontal");
        lightRigidBody.AddForce(new Vector2(dX * movementSpeed, 0));
        darkRigidBody.AddForce(new Vector2(dX * movementSpeed, 0));

        lightRigidBody.velocity = new Vector2(Mathf.Clamp(lightRigidBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(lightRigidBody.velocity.y, -maxSpeed * 2, maxSpeed * 2));
        darkRigidBody.velocity = new Vector2(Mathf.Clamp(darkRigidBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(darkRigidBody.velocity.y, -maxSpeed * 2, maxSpeed * 2));

        if(dX < 0)
        {
            darkPlayer.transform.localScale = new Vector3(-1, 1, 1);
            lightPlayer.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dX > 0)
        {
            darkPlayer.transform.localScale = new Vector3(1, 1, 1);
            lightPlayer.transform.localScale = new Vector3(1, 1, 1);
        }

        if (darkPlayerHandler.groundAirCount != 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                darkRigidBody.AddForce(new Vector2(0, (isDarkSelected ? jumpSpeed * 0.8f : jumpSpeed * 1.3f)), ForceMode2D.Impulse);
            }
        }



        if (lightPlayerHandler.groundAirCount != 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lightRigidBody.AddForce(new Vector2(0, (isDarkSelected ? jumpSpeed * 0.8f : jumpSpeed * 1.3f)), ForceMode2D.Impulse);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            darkAnimator.Play("Attack");
            lightAnimator.Play("Attack");
            darkCollider.enabled = true;
            lightCollider.enabled = true;
        }

    }
}
