using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {

    public BoxCollider2D spikesDamage;
    public BoxCollider2D spikesCollision;

    private bool activated = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Oldum");
        if(collision.CompareTag("Player")) // Player tagini yazdimki kutu vs. triggerlamasin digerleri icin trigger'da control etmeyi unuttum 
        {
            if(!activated)
                StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(0.2f);
        spikesDamage.enabled = true;
        spikesCollision.enabled = true;
        anim.SetTrigger("Trigger");

    }

}
