using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("/Sprites/Rocks/RockLight");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
        }
    }
}
