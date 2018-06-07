using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    Rigidbody2D rb;
    public float force;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(collision.gameObject.transform.position.x < transform.position.x)
            rb.AddForce(new Vector2(-1 , 2) * force); // Buraya birde saldiri alma kodu yazilcak 
            else
                rb.AddForce(new Vector2(1, 2) * force); // Buraya birde saldiri alma kodu yazilcak 

            // buraya da adama hasar verme codu  yazilacak

        }
    }
}
