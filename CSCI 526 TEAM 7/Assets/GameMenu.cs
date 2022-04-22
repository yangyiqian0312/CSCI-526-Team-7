using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void newWindow(){

        GameData.newDay = false;

        if(GameData.day ==0 && GameData.TutorialDone == 1){
            SceneManager.LoadScene("EndOfDay");
        }else{
            SceneManager.LoadScene("Bar");
        }
    }
}
