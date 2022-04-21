using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerInNOut : MonoBehaviour
{
    public GameObject customer;
    public float speed = 3f;
    public CursorMode cursorMode = CursorMode.Auto;
    private int wait = 2;
    public Texture2D cursorTexture;
    public Rigidbody2D rb;
    public Sprite frontsp1;
    public Sprite backsp1;
    public Sprite frontsp2;
    public Sprite backsp2;
    public Sprite frontsp3;
    public Sprite backsp3;   
    private SpriteRenderer spriteRenderer; 
    private Vector2 target;
    private bool isBack = false;
    private float waitTime;
    public float startWaitTime;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New Day: " + GameData.newDay);
        Debug.Log("Customer #: " + GameData.customerNumber);

        waitTime = startWaitTime;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>();

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

        wait = Random.Range(2, 5);
        target = GameObject.Find("exit").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.name == "customer1" && GameData.customerNumber == 1) 
            StartCoroutine(Leave("1"));        
        else if (customer.name == "customer2" && GameData.customerNumber == 2) {
            StartCoroutine(Leave("2"));
        }
        else if (customer.name == "customer3" && GameData.customerNumber == 3) {
            StartCoroutine(Leave("3"));
        }
        else {
            transform.localScale =  Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 
            speed * Time.deltaTime);
            StartCoroutine(Sleep());
        }
    }

    public IEnumerator Sleep() {
        // your process
        yield return new WaitForSeconds(wait);
        // continue process
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        if (customer.name == "customer1") {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos1").transform.position, step);
        }
        else if (customer.name == "customer2")
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos2").transform.position, step);
        else if (customer.name == "customer3") 
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos3").transform.position, step);

        yield return new WaitForSeconds(2);
        ActivateBarSceneTutorial();
    } 

    public IEnumerator Leave(string customerNum) {
        string targetPos = "targetPos" + customerNum;
        // your process
        yield return new WaitForSeconds(1);
        // continue process
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);   
        if (!isBack && Vector2.Distance(transform.position, GameObject.Find(targetPos).transform.position) < 0.2f) {        
//            spriteRenderer.sprite = frontsp1;
            animator.SetBool("Back", false);            
//            animator.SetBool("Front", true);
            Debug.Log("Going OUT");
            target = GameObject.Find("exit").transform.position;
        }
        else if (Vector2.Distance(transform.position, GameObject.Find("exit").transform.position) < 0.2f) {
            if (waitTime <= 0) {
//                spriteRenderer.sprite = backsp1;
                animator.SetBool("Back", true);
//                animator.SetBool("Front", false);
                Debug.Log("Going IN");
                target = GameObject.Find(targetPos).transform.position;
                isBack = true;
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }     
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
