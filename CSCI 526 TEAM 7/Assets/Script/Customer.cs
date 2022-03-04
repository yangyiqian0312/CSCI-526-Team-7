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
    
    public void OnMouseDown (){
        SceneManager.LoadScene("Dialogue");
    }

    public IEnumerator Sleep() {
        // your process
        yield return new WaitForSeconds(2);
        // continue process
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    } 
}
