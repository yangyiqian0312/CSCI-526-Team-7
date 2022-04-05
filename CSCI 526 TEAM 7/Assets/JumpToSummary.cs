using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToSummary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Time Ended!!!!!!!!!!!!!");
        
        if(GameData.day == 0 || (GameData.tips >= GameData.goals[GameData.day])){
            SceneManager.LoadScene("EndOfDay");
        }else{
            SceneManager.LoadScene("Failure");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
