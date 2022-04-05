using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Header : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    if(GameData.day > 0){
        GameObject.Find("HeaderDay").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Day " + (GameData.day).ToString();
    }else{
        GameObject.Find("HeaderDay").GetComponent<TMPro.TextMeshProUGUI>().text 
            = "Tutorial";
    }

    GameObject.Find("HeaderDate").GetComponent<TMPro.TextMeshProUGUI>().text 
        = "04/" + (GameData.firstDate + GameData.day).ToString() + "/2022";
    

    GameObject.Find("HeaderTotalTipsText").GetComponent<TMPro.TextMeshProUGUI>().text 
        = "Tips Earned / Goal : " + GameData.tips.ToString() + " / " + GameData.goals[GameData.day];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
