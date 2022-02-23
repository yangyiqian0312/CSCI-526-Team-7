using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;
    public float tips;
    public int tipBoosterLevel;

    void Awake(){
        if(Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Instance.tips = 6;
            Debug.Log("Here 1");
        }

        else if (Instance != this){
            Debug.Log("Here 2");
            Destroy(gameObject);
        }else{
            Debug.Log("Here 3");
        }

        Debug.Log("DEBUGGGGG: " + Instance.tips);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
