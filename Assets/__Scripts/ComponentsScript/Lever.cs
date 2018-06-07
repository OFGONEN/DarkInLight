using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public PlatformMovement platform;

    SpriteRenderer spriteRenderer;
    public Sprite back;
    public Sprite foward;
    private bool onBack = true;


    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

   




    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            if (onBack)
            {
                spriteRenderer.sprite = foward;
                onBack = false;
                if(platform.distance < 0)
                    platform.Close();
                else
                    platform.Open();

            }
            else
            {
                spriteRenderer.sprite = back;

                onBack = true; 
                if(platform.distance < 0)
                    platform.Open();
                else
                    platform.Close();

            }
        }
    }


    
}
