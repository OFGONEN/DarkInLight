using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(transform.position.x < 0)
        {
           if(tag == "Box") GetComponent<SpriteRenderer>().sprite = StaticController.instance.boxDark;
           else 
           if( tag == "Rock") GetComponent<SpriteRenderer>().sprite = StaticController.instance.rockDark;
           else 
           if(tag == "Crossbow") GetComponent<SpriteRenderer>().sprite = StaticController.instance.crossbowDark;
            else
           if (tag == "IronBox") GetComponent<SpriteRenderer>().sprite = StaticController.instance.ironBoxDark;

        } else
        {
            if (tag == "Box") GetComponent<SpriteRenderer>().sprite = StaticController.instance.boxLight;
            else
           if (tag == "Rock") GetComponent<SpriteRenderer>().sprite = StaticController.instance.rockLight;
            else
            if (tag == "Crossbow") GetComponent<SpriteRenderer>().sprite = StaticController.instance.crossbowLight;
      
            else
           if (tag == "IronBox") GetComponent<SpriteRenderer>().sprite = StaticController.instance.ironBoxLight;
        }
		
	}
}
