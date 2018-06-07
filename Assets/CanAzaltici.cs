using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAzaltici : MonoBehaviour {

    public GameObject can;
    public GameObject player;
    private Health health;
	// Use this for initialization
	void Start () {
        health = player.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        can.transform.localScale = new Vector3(1,health.health / 5f , 1);
	}
}
