using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDetected : MonoBehaviour {

    int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(this.gameObject);

            }
        }
    }
}
