using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public  int health;
    public StaticController.GameObjectType objectType;

    List<StaticController.GameObjectMapItem> list; 

    void Start () {
        list = new List<StaticController.GameObjectMapItem>();

        list.Add(new StaticController.GameObjectMapItem("GreenEnemy", StaticController.instance.ENEMY_GREEN_HEALTH));
        list.Add(new StaticController.GameObjectMapItem("PurpleEnemy", StaticController.instance.ENEMY_PURPLE_HEALTH));
        list.Add(new StaticController.GameObjectMapItem("Box", StaticController.instance.BOX_HEALTH));
        list.Add(new StaticController.GameObjectMapItem("Rock", StaticController.instance.ROCK_HEALTH));
        list.Add(new StaticController.GameObjectMapItem("Player", StaticController.instance.PLAYER_DARK_HEALTH));
        list.Add(new StaticController.GameObjectMapItem("IronBox", StaticController.instance.IRON_BOX_HEALTH));


        foreach (StaticController.GameObjectMapItem g in list){
            if(g.tag == gameObject.tag)
            {
                health = g.value;
                break;
            }
        }
    }

    void Update()
    {
       if(health <= 0)
        {
            Instantiate(StaticController.instance.SmokePrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

   
}
