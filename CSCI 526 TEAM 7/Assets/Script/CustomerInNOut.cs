using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerInNOut : MonoBehaviour
{
    public GameObject customer;
    private float appearing_speed = 3f;
    public float speed = 3f;
    public CursorMode cursorMode = CursorMode.Auto;
    private int wait = 2;
    public Texture2D cursorTexture;
    public Rigidbody2D rb;
    public Sprite frontsp;
    public Sprite backsp;
    private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New Day: " + GameData.newDay);
        Debug.Log("Customer #: " + GameData.customerNumber);

        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if(GameData.newDay == false) {
            if (customer.name == "customer1") {
                transform.position =  GameObject.Find("targetPos1").transform.position;
            }
            else if (customer.name == "customer2") {
                transform.position =  GameObject.Find("targetPos2").transform.position;
            }
            else if (customer.name == "customer3") {
                transform.position =  GameObject.Find("targetPos3").transform.position;
            }
        }

        else {
            
        }   

        wait = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.name == "customer1" && GameData.customerNumber == 1) {
            StartCoroutine(Leave());
        }
        else if (customer.name == "customer2" && GameData.customerNumber == 2) {
            StartCoroutine(Leave());
        }
        else if (customer.name == "customer3" && GameData.customerNumber == 3) {
            StartCoroutine(Leave());
        }
        else {
            transform.localScale =  Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 
            appearing_speed  * Time.deltaTime);
            StartCoroutine(Sleep());
        }
    }

    public IEnumerator Sleep() {
        // your process
        yield return new WaitForSeconds(wait);
        // continue process
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        if (customer.name == "customer1")
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos1").transform.position, step);
        else if (customer.name == "customer2")
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos2").transform.position, step);
        else if (customer.name == "customer3") 
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos3").transform.position, step);

        yield return new WaitForSeconds(2);
        ActivateBarSceneTutorial();
    } 

    public IEnumerator Leave() {
        // your process
        yield return new WaitForSeconds(wait);
        // continue process
        float step = speed * Time.deltaTime;
        spriteRenderer.sprite = frontsp;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("exit").transform.position, step);
        yield return new WaitForSeconds(2);
        if (customer.name == "customer1")   transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos1").transform.position, step);
        else if (customer.name == "customer2")   transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos2").transform.position, step);
        else if (customer.name == "customer3")   transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos3").transform.position, step);
        yield return new WaitForSeconds(2);
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

    public void ActivateBarSceneTutorial() {
        
        if (GameData.BarSceneTutorialDone == 0) {
            GameObject.Find("BarDialogue").transform.GetChild(0).gameObject.SetActive(true);
            GameData.BarSceneTutorialDone = 1;
        }
    }
}
