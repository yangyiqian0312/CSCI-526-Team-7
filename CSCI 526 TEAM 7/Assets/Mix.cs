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

    public List<int> currentModifierProperty = new List<int>() {0,0,0,0,0};


    public void Awake(){
        updateTempPropertyText();
    }

    public int currentBaseNumber = 0;

    public int baseAdded = -1;

    public int modifierAdded = -1;

    public int currentModifierNumber = 0;

    public int flavoringAdded = -1;

    public int specificCocktailStatus = -1;

    //Remove the property of current last chosen modifier
    public void ResetPropertyByModifier(){
        for(int i = 0; i < 5; i++){
            mixProps[i] -= currentModifierProperty[i];
        }
    }

    //Add the property of the current chosen modifier
    public void UpdatePropertyByModifier(){
        for(int i = 0; i < 5; i++){
            mixProps[i] += currentModifierProperty[i];
        }
    }

    public void setTutorialDone(){
        GameData.TutorialDone = 1;
    }

    public void UpdateSpecificCocktail(){
        // LA Vacation
        if(baseAdded == 3 &&  modifierAdded == 1 && flavoringAdded == 5){
            specificCocktailStatus = 0;
        }
        else if(baseAdded == 4 &&  modifierAdded == 2 && flavoringAdded == 1){
            specificCocktailStatus = 1;
        }
        else if(baseAdded == 5 &&  modifierAdded == 2 && flavoringAdded == 3){
            specificCocktailStatus = 2;
        }
        else if(baseAdded == 2 &&  modifierAdded == 0 && flavoringAdded == 0){
            specificCocktailStatus = 3;
        }
        else{
            specificCocktailStatus = -1;
        }
    }

    public void updateTempPropertyText(){
        string tempText = "Spicy: " + mixProps[0] + "\nSweet: " + mixProps[1] +"\nSour: " + mixProps[2]
            + "\nAromatic: " + mixProps[3] +"\nStrength: " + mixProps[4] + "\nFlavoring: " + (flavoringAdded+1);

        Debug.Log("Log Customer Name!!!!!!!! "+GameData.customer1.name);

        
        // GameObject.Find("Temp").GetComponent<TMPro.TextMeshProUGUI>().text = tempText;

        GameObject.Find("SpicySlider").GetComponent<Slider>().value = ((float)mixProps[0] / 5);
        GameObject.Find("SweetSlider").GetComponent<Slider>().value = ((float)mixProps[1] / 5);
        GameObject.Find("SourSlider").GetComponent<Slider>().value = ((float)mixProps[2] / 5);
        GameObject.Find("AromaticSlider").GetComponent<Slider>().value = ((float)mixProps[3] / 5);
        GameObject.Find("StrengthSlider").GetComponent<Slider>().value = ((float)mixProps[4] / 5);

        string CurrentPropertyText = "Your drink is: \n";

        CurrentPropertyText += (mixProps[0] >= 5 ? "<b><#FF5F00>Spicy</color></b>\n" : "");
        CurrentPropertyText += (mixProps[1] >= 5 ? "<b><#FF00FD>Sweet</color></b>\n" : "");
        CurrentPropertyText += (mixProps[2] >= 5 ? "<b><#1ABC77>Sour</color></b>\n" : "");
        CurrentPropertyText += (mixProps[3] >= 5 ? "<b><#002CFF>Aromatic</color></b>\n" : "");
        CurrentPropertyText += (mixProps[4] >= 5 ? "<b><#FF0B00>Strong</color></b>\n" : "");

        CurrentPropertyText += (flavoringAdded == 0 ? "&\nTopped with Fresh Cherry\n" : "");
        CurrentPropertyText += (flavoringAdded == 1 ? "&\nTopped with Chili Flake\n" : "");
        CurrentPropertyText += (flavoringAdded == 2 ? "&\nTopped with Gold Leaves\n" : "");
        CurrentPropertyText += (flavoringAdded == 3 ? "&\nTopped with Pineapple\n" : "");
        CurrentPropertyText += (flavoringAdded == 4 ? "&\nTopped with Lemon\n" : "");
        CurrentPropertyText += (flavoringAdded == 5 ? "&\nTopped with Orange Syrup\n" : "");
        CurrentPropertyText += (flavoringAdded == 6 ? "&\nTopped with Mint\n" : "");

        UpdateSpecificCocktail();

        CurrentPropertyText += (specificCocktailStatus == 0 ? "\n<b><i><#B7950B>LA Vacation</color></i></b>\n" : "");
        CurrentPropertyText += (specificCocktailStatus == 1 ? "\n<b><i><#B7950B>Moutai</color></i></b>\n" : "");
        CurrentPropertyText += (specificCocktailStatus == 2 ? "\n<b><i><#B7950B>Solar Cocktail</color></i></b>\n" : "");
        CurrentPropertyText += (specificCocktailStatus == 3 ? "\n<b><i><#B7950B>Kindergarten</color></i></b>\n" : "");
        

        GameObject.Find("PropertyGain").GetComponent<TMPro.TextMeshProUGUI>().text = CurrentPropertyText;

        
        
    }

    public void baseStartOver(){
        startOver();
        ResetBaseColor();
    }

    public void modifierStartOver(){
        startOver();
        ResetModifierColor();
    }

    public void flavoringStartOver(){
        startOver();
        ResetFlavoringColor();
    }

    public void startOver(){

        // if(GameData.tips <= 0){
        //     GameObject.Find("Mix").transform.GetChild(8).gameObject.SetActive(true);
        //     return;
        // }

        for(int i = 0; i < 5; i++){
            mixProps[i] = 0;
        }

        for(int i = 0; i < 5; i++){
            currentModifierProperty[i] = 0;
        }

        currentBaseNumber = 0;
        baseAdded = -1;
        modifierAdded = -1;
        currentModifierNumber = 0;
        flavoringAdded = -1;
        specificCocktailStatus = -1;

        //GameData.tips --;

        updateTempPropertyText();
    }

    public void addFlavoring1(){
        flavoringAdded = 0;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring1").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring1Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        
    }

    public void addFlavoring2(){
        flavoringAdded = 1;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring2").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring2Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addFlavoring3(){
        flavoringAdded = 2;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring3").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring3Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addFlavoring4(){
        flavoringAdded = 3;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring4").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring4Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addFlavoring5(){
        flavoringAdded = 4;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring5").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring5Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addFlavoring6(){
        flavoringAdded = 5;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring6").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring6Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addFlavoring7(){
        flavoringAdded = 6;

        updateTempPropertyText();
        ResetFlavoringColor();
        GameObject.Find("Flavoring7").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Flavoring7Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }


    public void addModifier1(){

        //Update the property of mixture after add Modifier1
        ResetPropertyByModifier();
        currentModifierProperty[0] = 0;
        currentModifierProperty[1] = 0;
        currentModifierProperty[2] = 2;
        currentModifierProperty[3] = 2;
        currentModifierProperty[4] = 0;
        UpdatePropertyByModifier();

        currentModifierNumber ++;
        modifierAdded = 0;
        updateTempPropertyText();
        ResetModifierColor();
        GameObject.Find("Modifier1").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Modifier1Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    
    }

    public void addModifier2(){
        //Update the property of mixture after add Modifier1
        ResetPropertyByModifier();
        currentModifierProperty[0] = 2;
        currentModifierProperty[1] = 2;
        currentModifierProperty[2] = 2;
        currentModifierProperty[3] = 0;
        currentModifierProperty[4] = 2;
        UpdatePropertyByModifier();


        currentModifierNumber ++;
        modifierAdded = 1;
        updateTempPropertyText();
        ResetModifierColor();
        GameObject.Find("Modifier2").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Modifier2Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    
    }

    public void addModifier3(){
        //Update the property of mixture after add Modifier1
        ResetPropertyByModifier();
        currentModifierProperty[0] = 2;
        currentModifierProperty[1] = 0;
        currentModifierProperty[2] = 0;
        currentModifierProperty[3] = 2;
        currentModifierProperty[4] = 1;
        UpdatePropertyByModifier();


        currentModifierNumber ++;
        modifierAdded = 2;
        updateTempPropertyText();
        ResetModifierColor();
        GameObject.Find("Modifier3").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Modifier3Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    public void addModifier4(){

        //Update the property of mixture after add Modifier1
        ResetPropertyByModifier();
        currentModifierProperty[0] = 0;
        currentModifierProperty[1] = 3;
        currentModifierProperty[2] = 2;
        currentModifierProperty[3] = 0;
        currentModifierProperty[4] = 2;
        UpdatePropertyByModifier();


        currentModifierNumber ++;
        modifierAdded = 3;
        updateTempPropertyText();
        ResetModifierColor();
        GameObject.Find("Modifier4").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("Modifier4Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
    }

    //Reset the background color and text color after choose base buttons
    public void ResetBaseColor(){
        GameObject.Find("BaseA").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseAText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("BaseB").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseBText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("BaseC").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseCText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("BaseD").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseDText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("BaseE").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseEText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("BaseF").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("BaseFText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
    }

    //Reset the background color and text color after choose modifier buttons
    public void ResetModifierColor(){
        GameObject.Find("Modifier1").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Modifier1Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Modifier2").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Modifier2Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Modifier3").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Modifier3Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Modifier4").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Modifier4Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
    }

    //Reset the background color and text color after choose flavoring buttons
    public void ResetFlavoringColor(){
        GameObject.Find("Flavoring1").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring1Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring2").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring2Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring3").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring3Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring4").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring4Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring5").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring5Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring6").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring6Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
        GameObject.Find("Flavoring7").GetComponent<Image>().color = new Color(255,255,255);
        GameObject.Find("Flavoring7Text").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0,0,0);
    }


    public void addBaseA(){
        mixProps[0] = 3;
        mixProps[1] = 0;
        mixProps[2] = 3;
        mixProps[3] = 0;
        mixProps[4] = 2;
        baseAdded = 0;
        ResetBaseColor();
        updateTempPropertyText();
        GameObject.Find("BaseA").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseAText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }

    public void addBaseB(){
        mixProps[0] = 0;
        mixProps[1] = 3;
        mixProps[2] = 0;
        mixProps[3] = 4;
        mixProps[4] = 3;
        baseAdded = 1;
        updateTempPropertyText();
        ResetBaseColor();
        GameObject.Find("BaseB").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseBText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }

    public void addBaseC(){
        mixProps[0] = 0;
        mixProps[1] = 3;
        mixProps[2] = 3;
        mixProps[3] = 0;
        mixProps[4] = 0;
        baseAdded = 2;
        updateTempPropertyText();
        ResetBaseColor();
        GameObject.Find("BaseC").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseCText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }

    public void addBaseD(){
        mixProps[0] = 3;
        mixProps[1] = 0;
        mixProps[2] = 0;
        mixProps[3] = 3;
        mixProps[4] = 3;
        baseAdded = 3;
        updateTempPropertyText();
        ResetBaseColor();
        GameObject.Find("BaseD").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseDText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }

    public void addBaseE(){
        mixProps[0] = 3;
        mixProps[1] = 3;
        mixProps[2] = 0;
        mixProps[3] = 0;
        mixProps[4] = 2;
        baseAdded = 4;
        updateTempPropertyText();
        ResetBaseColor();
        GameObject.Find("BaseE").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseEText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }
    public void addBaseF(){
        mixProps[0] = 3;
        mixProps[1] = 0;
        mixProps[2] = 0;
        mixProps[3] = 0;
        mixProps[4] = 4;
        baseAdded = 5;
        updateTempPropertyText();
        ResetBaseColor();
        GameObject.Find("BaseF").GetComponent<Image>().color = new Color(0,0,0);
        GameObject.Find("BaseFText").GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255,255,255);
        currentBaseNumber ++;
    }

    public void toNextScene(){
        //Debug.Log("Log after mix: "+ GameData.tips);
        GameData.date += 1;
        SceneManager.LoadScene("Bar");
    }

    public void Serve(){

        ResetFlavoringColor();

        int satisfiedReqs = 0;

        int totalReqs = GameData.currCustomer.requirementNum;

        for(int i = 0; i < 5; i++){
            int currProp = GameData.currCustomer.requirements[i];
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

        if(GameData.currCustomer.specificCocktail != -1){
            if(GameData.currCustomer.specificCocktail == specificCocktailStatus){
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
        GameData.tipsEarnedToday += currTip;

        Debug.Log("New Gain: " + currTip+ "\nCurr Total Tips: " + GameData.tips);

        string customerFeedBack = "You fufilled " + satisfiedReqs + " out of " + totalReqs + " of my requests. \n"; //Need to be changed after midterm


        if(satisfyLevel == 2){
            customerFeedBack += "So that's perfect! Here is the tip for you: $" + currTip;
        }else if (satisfyLevel == 1){
            customerFeedBack += "So that's not exactly what I ordered, but I'll accept it. tip: $" + currTip;
        }else{
            customerFeedBack += "I do not like this drink. Don't expect any tip from me. tip: $0";
        }

        customerFeedBack += "\nTotal tips earned: $" + GameData.tips;

        GameObject.Find("CustomerDialogue").GetComponent<TMPro.TextMeshProUGUI>().text 
            = customerFeedBack;

        // send serve result analytics
        this.SendAnalyticsServeSummary(
            customerRequirements: GameData.currCustomer.requirements,
            cursomerRequirementNums: totalReqs,
            customerFlavoring: GameData.currCustomer.flavoring,
            servedRequirements: mixProps,
            servedRequirementNums: satisfiedReqs,
            servedBase: baseAdded,
            servedModifier: modifierAdded,
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

    public void ConfirmBaseSelect() {
        this.SendAnalyticsBaseSelected(this.baseAdded);
    }

    public void ConfirmModifierSelect() {
        this.SendAnalyticsModifierSelected(this.modifierAdded);
    }

    public void ConfirmFlavoringSelect() {
        this.SendAnalyticsFlavoringSelected(this.flavoringAdded);
    }

    public void SendAnalyticsBaseSelected(int baseSelected)
    {
        Analytics.CustomEvent("base_selected", new Dictionary<string, object>
        {
            { "base_selected", baseSelected }
        });
    }

    public void SendAnalyticsModifierSelected(int modifierSelected)
    {
        Analytics.CustomEvent("modifier_selected", new Dictionary<string, object>
        {
            { "modifier_selected", modifierSelected }
        });
    }

    public void SendAnalyticsFlavoringSelected(int flavoringSelected)
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
        int servedBase,
        int servedModifier,
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
            { "served_base_modifier_flavoring", String.Format(
                "{0} {1} {2}", servedBase, servedFlavoring, servedFlavoring)
            },
            { "satisfy_level", satisfyLevel },
            { "tips_earned", tipsEarned },
            { "extension_json", "{}" }  // max 10 keys allowed, this reserved for extension
        });
    }
}
