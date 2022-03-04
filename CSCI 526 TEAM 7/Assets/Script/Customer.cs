using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    private Vector3 dir;
    private Transform trans;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 target;
    private BoxCollider2D bc;
    private float appearing_speed = 3f;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3f;
        transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale =  Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 
        appearing_speed  * Time.deltaTime);
        StartCoroutine(Sleep());
    }

    void FixedUpdate()
    {

    }
    
    public void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        Debug.Log("Mouse is over GameObject.");
    }

    public void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Debug.Log("Done");
    }

    public void OnMouseDown () {
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
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("targetPos").transform.position, step);

        yield return new WaitForSeconds(2);
        ActivateBarSceneTutorial();
    } 
}
