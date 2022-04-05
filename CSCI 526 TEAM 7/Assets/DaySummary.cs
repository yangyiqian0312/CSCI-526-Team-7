using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaySummary : MonoBehaviour
{
    
    public void toNextDay(){
        
        GameData.tipsEarnedToday = 0;

        GameData.timeRemaining = 90;

        GameData.day ++;

        SceneManager.LoadScene("Bar");
    }

    void Awake(){
        GameObject.Find("TipEarnedValueText").GetComponent<TMPro.TextMeshProUGUI>().text = 
            GameData.tipsEarnedToday.ToString();

        GameObject.Find("TotalTipValueText").GetComponent<TMPro.TextMeshProUGUI>().text = 
            GameData.tips.ToString();

        GameObject.Find("TomorrowGoalValueText").GetComponent<TMPro.TextMeshProUGUI>().text = 
            GameData.goals[GameData.day + 1].ToString();


        
    }

    //Reset Timer, Customer appeared, tipsEarnedToday in GameData

    
}
