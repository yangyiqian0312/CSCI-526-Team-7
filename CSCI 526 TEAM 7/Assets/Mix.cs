using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Analytics;

public class Mix : MonoBehaviour
{
    
    public int spicy = 0;
    public int sweet = 0;
    public int sour = 0;
    public int aromatic = 0;
    public int strength = 0;

    public int currentBaseNumber = 0;

    public int baseAdded = -1;

    public int currentModifierNumber = 0;

    public int flavoringAdded = -1;

    public int tips = 10;

    public void updateTempPropertyText(){
        string tempText = "Spicy: " + spicy + "\nSweet: " + sweet +"\nSour: " + sour 
            + "\nAromatic: " + aromatic +"\nStrength: " + strength + "\nFlavoring: " + (flavoringAdded+1);

        Debug.Log(GameData.tips);

        
        GameObject.Find("Temp").GetComponent<TMPro.TextMeshProUGUI>().text = tempText;


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
            sour ++;
            aromatic ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier2(){
        if(currentModifierNumber < 4){
            spicy ++;
            sweet ++;
            sour ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier3(){
        if(currentModifierNumber < 4){
            spicy ++;
            aromatic ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }

    public void addModifier4(){
        if(currentModifierNumber < 4){
            sweet ++;
            sour ++;
            strength ++;
            currentModifierNumber ++;
            updateTempPropertyText();
        }
    }


    public void addBaseA(){
        if((baseAdded == -1 || baseAdded == 0) &&(currentBaseNumber < 3)){
            spicy += 2;
            sour += 1;
            strength += 2;
            baseAdded = 0;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseB(){
        if((baseAdded == -1 || baseAdded == 1)&&(currentBaseNumber < 3)){
            spicy += 1;
            sweet += 1;
            sour += 1;
            aromatic += 2;
            strength += 1;
            baseAdded = 1;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseC(){
        if((baseAdded == -1 || baseAdded == 2)&&(currentBaseNumber < 3)){
            sweet += 2;
            sour += 2;
            baseAdded = 2;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseD(){
        if((baseAdded == -1 || baseAdded == 3)&&(currentBaseNumber < 3)){
            spicy += 1;
            aromatic += 2;
            strength += 1;
            baseAdded = 3;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }

    public void addBaseE(){
        if((baseAdded == -1 || baseAdded == 4)&&(currentBaseNumber < 3)){
            spicy += 2;
            sweet += 2;
            strength += 1;
            baseAdded = 4;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }
    public void addBaseF(){
        if((baseAdded == -1 || baseAdded == 5)&&(currentBaseNumber < 3)){
            spicy += 2;
            strength += 3;
            baseAdded = 5;
            updateTempPropertyText();
            currentBaseNumber ++;
        }
    }





    public void backToBar(){

        GameData.tips += 10;

        Debug.Log("Log after mix: "+ GameData.tips);

        SceneManager.LoadScene("Bar");
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
}
