using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement: MonoBehaviour {

    public bool vertical;
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
	void Start () {
        if (vertical)
        {
            firstPos = transform.position.y;
            secondPos = firstPos + distance;
            
        }
        else
        {
            firstPos = transform.position.x;
            secondPos = firstPos + distance;
            
        }
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
            if (vertical)
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
            else
            {
                transform.position = transform.position + new Vector3(step, 0, 0) * speed * Time.deltaTime;
                if (goClose && transform.position.x < lowPos)
                {
                    canMove = false;
                    transform.position = new Vector3(lowPos, transform.position.y, 0);
                }
                else if (!goClose && transform.position.x > highPos)
                {
                    canMove = false;
                    transform.position = new Vector3(highPos, transform.position.y, 0);
                }

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

    //public void Open()
    //{
    //    canMove = true;
    //    goClose = false;
    //    step = open;
    //}

    //public void Close()
    //{
    //    canMove = true;
    //    goClose = true;
    //    step = close;
    //}
}
