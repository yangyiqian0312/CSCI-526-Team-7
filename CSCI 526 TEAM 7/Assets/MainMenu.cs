using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;

public class MainMenu : MonoBehaviour
{
    public void pauseTimer(){
        GameData.pause = 1;
    }

    public void startTimer(){
        GameData.pause = 0;
    }
    
    void Awake(){
        int currID;

        // 0 means ID is valid
        // 1 means ID is invalid
        int currInvalid;
        for(int MainMenuChildID = 1; MainMenuChildID <= 4; MainMenuChildID ++){
            GameObject.Find("MainMenu").transform.GetChild(MainMenuChildID).gameObject.SetActive(true);
        }

        //Set all avatars inactive
        for(int i = 0; i <= GameData.customerIDRange; i ++){
            GameObject.Find("Avatars").transform.GetChild(i).gameObject.SetActive(false);
        }

        if(GameData.TutorialDone == 0){
            currID = 0;
            currInvalid = 0;
            GameObject.Find("YesButtonInvalidID").SetActive(false);
            GameObject.Find("RejectButtonInvalidID").SetActive(false);
        }
        else{

            if(GameObject.Find("DialogueTutorial")){
                GameObject.Find("DialogueTutorial").SetActive(false);
            }

            System.Random rnd = new System.Random();
            System.Random rndInvalid = new System.Random();

            currID = rnd.Next(1, GameData.customerIDRange);

            // 70% probability the ID is valid (Which means currValidNum >= 4)
            int currValidNum = rndInvalid.Next(1, 11);

            if(currValidNum >= 5){
                currInvalid = 0;
            }else{
                currInvalid = 1;
            }

            if(currInvalid == 0){
                GameObject.Find("YesButtonInvalidID").SetActive(false);
                GameObject.Find("RejectButtonInvalidID").SetActive(false);
            }else{
                GameObject.Find("YesButton").SetActive(false);
                GameObject.Find("RejectButton").SetActive(false);
            }
        }
        
        GameData.currCustomer = GameData.customers[currID];
        GameData.currCustomerId = currID;

        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.dialogue + " \nHere's my ID.";

        GameObject.Find("Avatars").transform.GetChild(currID).gameObject.SetActive(true);

        GameObject.Find("CustomerName").GetComponent<TMPro.TextMeshProUGUI>().text 
            = GameData.currCustomer.name;


        GameObject.Find("IDName").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Name: " + GameData.currCustomer.name;

        GameObject.Find("Gender").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Gender: " + (currInvalid == 0 ? GameData.currCustomer.gender : GameData.currCustomer.invalidGender);

        GameObject.Find("Birthday").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Date of Birth: \n" + (currInvalid == 0 ? GameData.currCustomer.birthday : GameData.currCustomer.invalidBirthday);
        
        GameObject.Find("HairColor").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Hair Color: " + (currInvalid == 0 ? GameData.currCustomer.hairColor : GameData.currCustomer.invalidHairColor);

        GameObject.Find("ExpirationDate").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Expiration Date: \n" + (currInvalid == 0 ? GameData.currCustomer.expirationDate : GameData.currCustomer.invalidExpirationDate);





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

    public void invalidIdUpdate(){
        //Set boss active
        GameObject.Find("Avatars").transform.GetChild(GameData.customerIDRange).gameObject.SetActive(true);

        //Set current customer inactive
        GameObject.Find("Avatars").transform.GetChild(GameData.currCustomerId).gameObject.SetActive(false);

        //Update the name of speaker(boss)
        GameObject.Find("CustomerName").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Boss";

        //Set the InvalidLeaveButton active
        GameObject.Find("MainMenu").transform.GetChild(5).gameObject.SetActive(true);

        
    }

    public void invalidYesButtonUpdate(){
        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "That ID was invalid! I'm deducting 10 points from your tips.";

        GameData.tips -= 10;
        GameData.tipsEarnedToday -= 10;
    }

    public void invalidRejectButtonUpdate(){
        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Good job for spotting an invalid ID! I'm giving you a 10 points bonus for this.";

        GameData.tips += 10;
        GameData.tipsEarnedToday += 10;
    }


    
}
