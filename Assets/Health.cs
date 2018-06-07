using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health;

	void Start () {
        if (gameObject.tag == "GreenEnemy") health = StaticController.instance.ENEMY_GREEN_HEALTH;
        else
        if (gameObject.tag == "PurpleEnemy") health = StaticController.instance.ENEMY_PURPLE_HEALTH;
        else
        if (gameObject.tag == "Box") health = StaticController.instance.BOX_HEALTH;
        else
        if (gameObject.tag == "IronBox") health = StaticController.instance.IRON_BOX_HEALTH;
        else
        if (gameObject.tag == "Crossbow") health = StaticController.instance.CROSSBOW_HEALTH;
    }

    void Update()
    {
        Debug.Log(health);
       if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        Debug.Log(health);
        health -= damage;
    }
}
