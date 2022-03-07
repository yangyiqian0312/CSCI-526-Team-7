using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;

public class MainMenu : MonoBehaviour
{
    void Awake(){
        int currID;
        if(GameData.TutorialDone == 0){
            currID = 0;
        }
        else{

            GameObject.Find("DialogueTutorial").SetActive(false);
            System.Random rnd = new System.Random();
            currID = rnd.Next(1, GameData.customerIDRange);
        }
        GameData.currCustomer = GameData.customers[currID];

        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.dialogue;

        GameObject.Find("Avatars").transform.GetChild(currID).gameObject.SetActive(true);

        GameObject.Find("CustomerName").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.name;
    }

    public void newWindow(){
        SceneManager.LoadScene("Bar");
    }

    public void SendAnalyticsServeCustomer(string optionSelected)
    {
        Analytics.CustomEvent("serve_customer", new Dictionary<string, object>
        {
            { "option_selected", optionSelected }
        });
    }
    
}
