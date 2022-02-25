using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;

public class MainMenu : MonoBehaviour
{
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

    void Awake(){

        System.Random rnd = new System.Random();
        int currID = rnd.Next(0, GameData.customerIDRange);
        GameData.currCustomer = GameData.customers[currID];

        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.dialogue;


        GameObject.Find("CustomerName").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.name;
    }
    
}
