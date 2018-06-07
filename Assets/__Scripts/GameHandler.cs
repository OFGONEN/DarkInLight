using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public GameObject darkPlayer;
    public GameObject lightPlayer;

    private Vector3 temporaryVector;

    private bool isMovingObject = false;
    private GameObject movingObject;
    private Vector3 movingObjectOffset;

    public bool objectInDarkSide = false;

    public GameObject smokePrefab;

    private IEnumerator controlByAmulet;


    private GameObject amulet;

    private void Start()
    {
        amulet = GameObject.FindGameObjectWithTag("Amulet");
    }


    public float amuletControlTime = 5f;
	
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (isObjectControlledByAmulet)
            {

                objectThatControlledByAmulet.transform.localScale = new Vector3(objectThatControlledByAmulet.transform.localScale.x * -1, 1, 1);
            } else
            {
                swapPlayers();
            }
            
          
        }

        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject.layer);

                if (hit.transform.gameObject.layer == 8)
                {
                    isMovingObject = true;
                    movingObject = hit.transform.gameObject;
                    movingObjectOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - hit.transform.position;
                    objectInDarkSide = (hit.transform.position.x) < 0;
                    movingObject.GetComponent<Collider2D>().isTrigger = true;
                    Cursor.SetCursor(StaticController.instance.cursorClicked, new Vector2(8, 32), CursorMode.Auto);
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(StaticController.instance.cursorDefault, new Vector2(8, 32), CursorMode.Auto);
            Debug.Log("Released");
            if (movingObject.CompareTag("Amulet"))
            {
                amulet.SetActive(false);
                Debug.Log("Amulet");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log("Released to : " + hit.collider.name);
                   if(hit.transform.tag == "Crossbow")
                    {
                        hit.transform.gameObject.layer = 8;
                       

                        controlByAmulet = ControlledByAmulet(hit.transform.gameObject);
                        StartCoroutine(controlByAmulet);


                    } else
                    {
                         amulet.SetActive(true);
                    }
                } else
                {
                    amulet.SetActive(true);
                }
            }

            isMovingObject = false;
            if(movingObject != null)
            {
                Collider2D col2D = movingObject.GetComponent<Collider2D>();
                if(col2D != null)
                col2D.isTrigger = false;
                movingObject = null;
            }
        }


        if (isMovingObject)
        {
            SpriteRenderer spriteRenderer = movingObject.GetComponent<SpriteRenderer>();
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - movingObjectOffset;
            mousePos.z = 0;
            string moveTag = movingObject.tag;
            if (mousePos.x < 0)
            {
                if (!objectInDarkSide)
                {

                    if (moveTag == "Box") spriteRenderer.sprite = StaticController.instance.boxDark;
                    else 
                    if (moveTag == "Rock") spriteRenderer.sprite = StaticController.instance.rockDark;
                    else
                    if (moveTag == "Crossbow") spriteRenderer.sprite = StaticController.instance.crossbowDark;
                    else
                    if (moveTag == "IronBox") spriteRenderer.sprite = StaticController.instance.ironBoxDark;

                    GameObject smoke = Instantiate(smokePrefab, new Vector3(0, movingObject.transform.position.y,0), movingObject.transform.rotation);
                    Destroy(smoke, 0.8f);
                    objectInDarkSide = true;
                }
               
            } else
            {
                if (objectInDarkSide)
                {
                    if (moveTag == "Box") spriteRenderer.sprite = StaticController.instance.boxLight;
                    else
                    if (moveTag == "Rock") spriteRenderer.sprite = StaticController.instance.rockLight;
                    else
                    if (moveTag == "Crossbow") spriteRenderer.sprite = StaticController.instance.crossbowLight;
                    else
                    if (moveTag == "IronBox") spriteRenderer.sprite = StaticController.instance.ironBoxLight;

                    objectInDarkSide = !true;
                    GameObject smoke = Instantiate(smokePrefab, new Vector3(0, movingObject.transform.position.y, 0), movingObject.transform.rotation);
                    Destroy(smoke, 0.8f);
                }
                
            }
            movingObject.transform.position = mousePos;        
        }


        
	}
    bool isObjectControlledByAmulet = false;
    GameObject objectThatControlledByAmulet = null;
    private IEnumerator ControlledByAmulet(GameObject go)
    {
        isObjectControlledByAmulet = true;
        objectThatControlledByAmulet = go;
        GameObject smoke = Instantiate(smokePrefab, new Vector3(amulet.transform.position.x, amulet.transform.position.y, 0), amulet.transform.rotation);
        Destroy(smoke, 0.8f);
        Debug.Log("Controlled By Amulet");
        yield return new WaitForSeconds(amuletControlTime);
        Debug.Log("Skipped progress");
        isObjectControlledByAmulet = false;
        amulet.transform.position = go.transform.position;
        Destroy(go);
        smoke = Instantiate(smokePrefab, new Vector3(amulet.transform.position.x, amulet.transform.position.y, 0), amulet.transform.rotation);
        Destroy(smoke, 0.8f);
        amulet.SetActive(true);
    }

    void swapPlayers()
    {
        temporaryVector = darkPlayer.transform.position;
        darkPlayer.transform.position = lightPlayer.transform.position;
        lightPlayer.transform.position = temporaryVector;
    }

}
