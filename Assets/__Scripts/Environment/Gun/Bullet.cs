using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    public float bulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
        rb.velocity = new Vector2(bulletSpeed ,0);
	}
}
