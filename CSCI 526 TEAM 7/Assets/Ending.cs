using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void playAgain(){
        
        GameData.tips = 0f;

        GameData.tipsEarnedToday = 0;

        GameData.day = 1;

        GameData.timeRemaining = 90;

        GameData.todayOccured = new HashSet<int>();

        SceneManager.LoadScene("MainMenu");
    }

    void Awake(){
        GameObject.Find("EndingTotalTipValueText").GetComponent<TMPro.TextMeshProUGUI>().text
            = GameData.tips.ToString();
    }
}
