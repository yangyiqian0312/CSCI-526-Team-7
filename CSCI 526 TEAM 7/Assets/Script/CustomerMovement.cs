using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerMovement : MonoBehaviour
{
    private Vector3 dir;
    private Transform trans;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 target;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void FixedUpdate()
    {
    }
    
    public void OnMouseDown (){
        SceneManager.LoadScene("Dialogue");
    }
}
