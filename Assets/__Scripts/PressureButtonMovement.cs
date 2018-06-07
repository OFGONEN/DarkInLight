using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButtonMovement:MonoBehaviour {
    public PlatformMovement platform;

    public float speed;
    public float distance;

    float firstPos;
    float secondPos;

    float checkValue;
    float lowPos;
    float highPos;

    float open = 1;
    float close = 1;
    float step = 1;

    private bool canMove;
    private bool goClose;
    void Start()
    {
       
            firstPos = transform.position.y;
            secondPos = firstPos + distance;

        
        
        if (distance < 0)
        {
            lowPos = secondPos;
            highPos = firstPos;
        }
        else
        {
            lowPos = firstPos;
            highPos = secondPos;
        }

        open = Mathf.Sign(distance);
        close = Mathf.Sign(distance) * -1;
    }

    private void Update()
    {
        if (canMove)
        {
            
                transform.position = transform.position + new Vector3(0, step, 0) * speed * Time.deltaTime;
                if (goClose && transform.position.y < lowPos)
                {
                    canMove = false;
                    transform.position = new Vector3(transform.position.x, lowPos, 0);
                }
                else if (!goClose && transform.position.y > highPos)
                {
                    canMove = false;
                    transform.position = new Vector3(transform.position.x, highPos, 0);
                }

            



        }
    }

    public void Open()
    {
        canMove = true;
        goClose = false;
        if (distance < 0)
            step = close;
        else
            step = open;

    }

    public void Close()
    {
        canMove = true;
        goClose = true;
        if (distance < 0)
            step = open;
        else
            step = close;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player  ' a carptim");

            if (distance < 0)
            {
                Close();
            }
            else
                Open();
            platform.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player  ' a carptim");
            if (distance < 0)
            {
                Open();
            }
            else
                Close();
            platform.Close();
        }
    }

}
