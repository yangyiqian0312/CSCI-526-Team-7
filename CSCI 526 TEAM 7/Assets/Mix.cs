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


    public int currentBaseNumber = 0;

    public int baseAdded = -1;

    public int currentModifierNumber = 0;

    public int flavoringAdded = -1;

    public void updateTempPropertyText(){
        string tempText = "Spicy: " + mixProps[0] + "\nSweet: " + mixProps[1] +"\nSour: " + mixProps[2]
            + "\nAromatic: " + mixProps[3] +"\nStrength: " + mixProps[4] + "\nFlavoring: " + (flavoringAdded+1);

        Debug.Log("Log Customer Name!!!!!!!! "+GameData.customer1.name);

        
        GameObject.Find("Temp").GetComponent<TMPro.TextMeshProUGUI>().text = tempText;
    }

    public void startOver(){

        if(GameData.tips <= 0){
            GameObject.Find("Mix").transform.GetChild(9).gameObject.SetActive(true);
            return;
        }

        for(int i = 0; i < 5; i++){
            mixProps[i] = 0;
        }

        currentBaseNumber = 0;
        baseAdded = -1;
        currentModifierNumber = 0;
        flavoringAdded = -1;

        GameData.tips --;

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
            { "customer_requirements", satisfyLevel },
            { "cursomer_requirement_nums", cursomerRequirementNums },
            { "customer_flavoring", customerFlavoring },
            { "served_requirements", servedRequirements },
            { "served_requirement_nums", servedRequirementNums },
            { "served_flavoring", servedFlavoring },
            { "satisfy_level", satisfyLevel },
            { "tips_earned", tipsEarned },
            { "max_tips_custumer_affordable", maxTipsCustumerAffordable }
        });
    }
}
