using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour {

    float timeStart;
    public float shootTime;
    
    public GameObject prefab;
   

    public bool automatic = true;

    Transform transform;

    void Start()
    {
        timeStart = Time.time;
        transform = this.gameObject.transform.GetChild(0);
    }

	void Update () {
        if (automatic)
        {

		if(Time.time > timeStart + shootTime)
        {
            Shoot();
            timeStart = Time.time;
        }

        }
    }

    public void Shoot()
    {
        GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
      
    }
}
