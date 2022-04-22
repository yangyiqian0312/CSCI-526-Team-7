using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    public GameObject customer;
    public float speed;
    private Vector2 target;
    private float appearing_speed = 3f;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameData.newDay);
        if (GameData.newDay == false && GameData.customerNumber == 1)
            transform.position = GameObject.Find("targetPos1").transform.position;
        else {
            speed = 3f;
            transform.localScale = new Vector3(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.newDay == true) {
            transform.localScale =  Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 
            appearing_speed  * Time.deltaTime);
            StartCoroutine(Sleep());
        }
        else {
            
        }
    }
    
    public void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }

    public void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OnMouseDown () {
        if (customer.name == "customer1") GameData.customerNumber = 1;
        else if (customer.name == "customer2") GameData.customerNumber = 2;
        else if (customer.name == "customer3") GameData.customerNumber = 3;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        GameObject.Find("BarDialogue").transform.GetChild(0).gameObject.SetActive(false);
        SceneManager.LoadScene("Dialogue");   
    }

    public void ActivateBarSceneTutorial(){
        if (GameData.BarSceneTutorialDone == 0){
            GameObject.Find("BarDialogue").transform.GetChild(0).gameObject.SetActive(true);
            GameData.BarSceneTutorialDone = 1;
        }
    }

    public IEnumerator Sleep() {
        // your process
        yield return new WaitForSeconds(2);
        // continue process
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos2").transform.position, step);

        yield return new WaitForSeconds(2);
        ActivateBarSceneTutorial();
    } 
}
