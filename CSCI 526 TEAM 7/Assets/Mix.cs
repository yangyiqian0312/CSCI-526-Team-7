using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Analytics;

public class Mix : MonoBehaviour
{

     // idx0 = spicy
    // idx1 = sweet
    // idx2 = sour
    // idx3 = aromatic
    // idx4 = strength
    // value >= 5 means have this prop
    public List<int> mixProps = new List<int>() {0, 0, 0, 0, 0};

    public void Awake(){
        updateTempPropertyText();
    }

    public int currentBaseNumber = 0;

    public int baseAdded = -1;

    public int currentModifierNumber = 0;

    public int flavoringAdded = -1;

    public void updateTempPropertyText(){
        string tempText = "Spicy: " + mixProps[0] + "\nSweet: " + mixProps[1] +"\nSour: " + mixProps[2]
            + "\nAromatic: " + mixProps[3] +"\nStrength: " + mixProps[4] + "\nFlavoring: " + (flavoringAdded+1);

        Debug.Log("Log Customer Name!!!!!!!! "+GameData.customer1.name);

        
        GameObject.Find("Temp").GetComponent<TMPro.TextMeshProUGUI>().text = tempText;

        GameObject.Find("SpicySlider").GetComponent<Slider>().value = ((float)mixProps[0] / 5);
        GameObject.Find("SweetSlider").GetComponent<Slider>().value = ((float)mixProps[1] / 5);
        GameObject.Find("SourSlider").GetComponent<Slider>().value = ((float)mixProps[2] / 5);
        GameObject.Find("AromaticSlider").GetComponent<Slider>().value = ((float)mixProps[3] / 5);
        GameObject.Find("StrengthSlider").GetComponent<Slider>().value = ((float)mixProps[4] / 5);

        string CurrentPropertyText = "Your drink is: \n";

        CurrentPropertyText += (mixProps[0] >= 5 ? "Spicy\n" : "");
        CurrentPropertyText += (mixProps[1] >= 5 ? "Sweet\n" : "");
        CurrentPropertyText += (mixProps[2] >= 5 ? "Sour\n" : "");
        CurrentPropertyText += (mixProps[3] >= 5 ? "Aromatic\n" : "");
        CurrentPropertyText += (mixProps[4] >= 5 ? "Strong\n" : "");

        CurrentPropertyText += (flavoringAdded == 0 ? "&\nTopped with Fresh Cherry\n" : "");
        CurrentPropertyText += (flavoringAdded == 1 ? "&\nTopped with Chili Flake\n" : "");
        CurrentPropertyText += (flavoringAdded == 2 ? "&\nTopped with Gold Leaves\n" : "");
        CurrentPropertyText += (flavoringAdded == 3 ? "&\nTopped with Pineapple\n" : "");
        CurrentPropertyText += (flavoringAdded == 4 ? "&\nTopped with Lemon\n" : "");
        CurrentPropertyText += (flavoringAdded == 5 ? "&\nTopped with Orange Syrup\n" : "");
        CurrentPropertyText += (flavoringAdded == 6 ? "&\nTopped with Mint\n" : "");


        

        GameObject.Find("PropertyGain").GetComponent<TMPro.TextMeshProUGUI>().text = CurrentPropertyText;

        
        
    }

    public void startOver(){

        // if(GameData.tips <= 0){
        //     GameObject.Find("Mix").transform.GetChild(8).gameObject.SetActive(true);
        //     return;
        // }

        for(int i = 0; i < 5; i++){
            mixProps[i] = 0;
        }

        currentBaseNumber = 0;
        baseAdded = -1;
        currentModifierNumber = 0;
        flavoringAdded = -1;

        //GameData.tips --;

        updateTempPropertyText();
    }

    public void addFlavoring1(){
        if (flavoringAdded == -1){
            flavoringAdded = 0;
        }

        updateTempPropertyText();
    }

    public void addFlavoring2(){
        if (flavoringAdded == -1){
            flavoringAdded = 1;
        }

        updateTempPropertyText();
    }

    public void addFlavoring3(){
        if (flavoringAdded == -1){
            flavoringAdded = 2;
        }

        updateTempPropertyText();
    }

    public void addFlavoring4(){
        if (flavoringAdded == -1){
            flavoringAdded = 3;
        }

        updateTempPropertyText();
    }

    public void addFlavoring5(){
        if (flavoringAdded == -1){
            flavoringAdded = 4;
        }

        updateTempPropertyText();
    }

    public void addFlavoring6(){
        if (flavoringAdded == -1){
            flavoringAdded = 5;
        }

        updateTempPropertyText();
    }

    public void addFlavoring7(){
        if (flavoringAdded == -1){
            flavoringAdded = 6;
        }

        updateTempPropertyText();
    }


    public void addModifier1(){
        if(currentModifierNumber < 4){
            mixProps[2] ++;
            mixProps[3] ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier2(){
        if(currentModifierNumber < 4){
            mixProps[0] ++;
            mixProps[1] ++;
            mixProps[2] ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier3(){
        if(currentModifierNumber < 4){
            mixProps[0] ++;
            mixProps[3] ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier4(){
        if(currentModifierNumber < 4){
            mixProps[1] ++;
            mixProps[2] ++;
            mixProps[4] ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }


    public void addBaseA(){
        if((baseAdded == -1 || baseAdded == 0) &&(currentBaseNumber < 3)){
            mixProps[0] += 2;
            mixProps[2] += 1;
            mixProps[4] += 2;
            baseAdded = 0;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseB(){
        if((baseAdded == -1 || baseAdded == 1)&&(currentBaseNumber < 3)){
            mixProps[0] += 1;
            mixProps[1] += 1;
            mixProps[2] += 1;
            mixProps[3] += 2;
            mixProps[4] += 1;
            baseAdded = 1;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseC(){
        if((baseAdded == -1 || baseAdded == 2)&&(currentBaseNumber < 3)){
            mixProps[1] += 2;
            mixProps[2] += 2;
            baseAdded = 2;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseD(){
        if((baseAdded == -1 || baseAdded == 3)&&(currentBaseNumber < 3)){
            mixProps[0] += 1;
            mixProps[3] += 2;
            mixProps[4] += 1;
            baseAdded = 3;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseE(){
        if((baseAdded == -1 || baseAdded == 4)&&(currentBaseNumber < 3)){
            mixProps[0] += 2;
            mixProps[1] += 2;
            mixProps[4] += 1;
            baseAdded = 4;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }
    public void addBaseF(){
        if((baseAdded == -1 || baseAdded == 5)&&(currentBaseNumber < 3)){
            mixProps[0] += 2;
            mixProps[4] += 3;
            baseAdded = 5;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void toNextScene(){
        //Debug.Log("Log after mix: "+ GameData.tips);
        GameData.date += 1;
        SceneManager.LoadScene("Bar");
    }

    public void Serve(){

        int satisfiedReqs = 0;

        int totalReqs = GameData.currCustomer.requirementNum;

        for(int i = 0; i < 5; i++){
            int currProp = GameData.currCustomer.requirments[i];
            if (currProp == 1){
                if(mixProps[i] >= 5){
                    satisfiedReqs ++;
                }
            }else if (currProp == -1){
                if(mixProps[i] < 5){
                    satisfiedReqs ++;
                }
            }
        }

        if(GameData.currCustomer.flavoring != -1){
            if(GameData.currCustomer.flavoring == flavoringAdded){
                satisfiedReqs ++;
            }
        }

        float currTip = GameData.currCustomer.customTip;
        int satisfyLevel = 2;

        if (totalReqs == 2){
            if(satisfiedReqs == 1){
                currTip /= 2;
                satisfyLevel = 1;
            }
        }else if (totalReqs == 3){
            if (satisfiedReqs == 1){
                currTip = 0;
                satisfyLevel = 0;

            }else if (satisfiedReqs == 2){
                currTip /= 2;
                satisfyLevel = 1;
            }
        }
        
        if(satisfiedReqs == 0){
            currTip = 0;
            satisfyLevel = 0;
        }
        
        GameData.tips += currTip;

        Debug.Log("New Gain: " + currTip+ "\nCurr Total Tips: " + GameData.tips);

        string customerFeedBack; //Need to be changed after midterm

        if(satisfyLevel == 2){
            customerFeedBack = "That's perfect! Here is the tip for you: $" + currTip;
        }else if (satisfyLevel == 1){
            customerFeedBack = "That's not exactly what I ordered, but I'll accept it. tip: $" + currTip;
        }else{
            customerFeedBack = "I do not like this drink. Don't expect any tip from me. tip: $0";
        }

        customerFeedBack += "\nTotal tips earned: $" + GameData.tips;

        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = customerFeedBack;

        // send serve result analytics
        this.SendAnalyticsServeSummary(
            customerRequirements: GameData.currCustomer.requirments,
            cursomerRequirementNums: totalReqs,
            customerFlavoring: GameData.currCustomer.flavoring,
            servedRequirements: mixProps,
            servedRequirementNums: satisfiedReqs,
            servedFlavoring: flavoringAdded,
            satisfyLevel: satisfyLevel,
            tipsEarned: currTip,
            maxTipsCustumerAffordable: GameData.currCustomer.customTip
        );
    }

    private int currChild = 0;

    public void setChildBase(){
        currChild = 0;
    }

    public void setChildModifier(){
        currChild = 1;
    }

    public void setChildFlavoring(){
        currChild = 2;
    }

    public void showChild(){
        this.transform.GetChild(currChild).gameObject.SetActive(true);
    }

    public void SendAnalyticsBaseSelected(string baseSelected)
    {
        Analytics.CustomEvent("base_selected", new Dictionary<string, object>
        {
            { "base_selected", baseSelected }
        });
    }

    public void SendAnalyticsModifierSelected(string modifierSelected)
    {
        Analytics.CustomEvent("modifier_selected", new Dictionary<string, object>
        {
            { "modifier_selected", modifierSelected }
        });
    }

    public void SendAnalyticsFlavoringSelected(string flavoringSelected)
    {
        Analytics.CustomEvent("flavoring_selected", new Dictionary<string, object>
        {
            { "flavoring_selected", flavoringSelected }
        });
    }

    public void SendAnalyticsServeSummary(
        List<int> customerRequirements,
        int cursomerRequirementNums,
        int customerFlavoring,
        List<int> servedRequirements,
        int servedRequirementNums,
        int servedFlavoring,
        int satisfyLevel, 
        float tipsEarned,
        float maxTipsCustumerAffordable
    )
    {
        Analytics.CustomEvent("serve_summary", new Dictionary<string, object>
        {
            { "customer_requirements", String.Format(
                "{0} {1} {2} {3} {4}", 
                customerRequirements[0],
                customerRequirements[1],
                customerRequirements[2],
                customerRequirements[3],
                customerRequirements[4])
            },
            { "cursomer_requirement_nums", cursomerRequirementNums },
            { "customer_flavoring", customerFlavoring },
            { "served_requirements", String.Format(
                "{0} {1} {2} {3} {4}", 
                servedRequirements[0],
                servedRequirements[1],
                servedRequirements[2],
                servedRequirements[3],
                servedRequirements[4])
            },
            { "served_requirement_nums", servedRequirementNums },
            { "served_flavoring", servedFlavoring },
            { "satisfy_level", satisfyLevel },
            { "tips_earned", tipsEarned },
            { "max_tips_custumer_affordable", maxTipsCustumerAffordable }
        });
    }
}
