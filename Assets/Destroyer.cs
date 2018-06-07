using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private int damage;
    public StaticController.GameObjectType objectType;

    List<StaticController.GameObjectMapItem> list;

    void Start()
    {
        list = new List<StaticController.GameObjectMapItem>();

        list.Add(new StaticController.GameObjectMapItem("CrossbowArrowDamage", StaticController.instance.CROSSBOW_ARROW_DAMAGE));
        list.Add(new StaticController.GameObjectMapItem("PlayerDamage", StaticController.instance.PLAYER_DAMAGE));


        foreach (StaticController.GameObjectMapItem g in list)
        {
            if (g.tag == gameObject.tag)
            {
                damage = g.value;
                break;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "CrossbowArrowDamage" && collision.gameObject.tag == "MiddleWall")
        {

            GameObject smoke = Instantiate(StaticController.instance.SmokePrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(smoke, 0.8f);
            Destroy(gameObject);
            return;

        }

        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (health.objectType == StaticController.GameObjectType.FIRENDLY && objectType == StaticController.GameObjectType.ENEMY)
            {
                health.takeDamage(damage);
            }  
            else if (health.objectType == StaticController.GameObjectType.ENEMY && objectType == StaticController.GameObjectType.FIRENDLY)
            {
                health.takeDamage(damage);
            }
            else if (health.objectType == StaticController.GameObjectType.BOTH)
            {
                health.takeDamage(damage);
            } else if (objectType == StaticController.GameObjectType.BOTH)
            {
                health.takeDamage(damage);
            }


        }

        if(gameObject.tag == "CrossbowArrowDamage" && collision.CompareTag("IronBox"))
        {
            Vector2 temp = gameObject.transform.localScale;
            temp.x *= -1;
            gameObject.transform.localScale = temp;
            gameObject.GetComponent<Bullet>().bulletSpeed *= -1; 
        }
        
    }
}
