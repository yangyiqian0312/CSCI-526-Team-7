using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{
   public void playAgain(){
        
        GameData.tips = 0f;

        GameData.tipsEarnedToday = 0;

        GameData.day = 1;

        GameData.timeRemaining = 30;

        SceneManager.LoadScene("MainMenu");
    }

    void Awake(){
        GameObject.Find("FailureTotalTipValueText").GetComponent<TMPro.TextMeshProUGUI>().text = 
            GameData.tips.ToString();

        GameObject.Find("GoalValueText").GetComponent<TMPro.TextMeshProUGUI>().text = 
            GameData.goals[GameData.day].ToString();
        
    }
}
