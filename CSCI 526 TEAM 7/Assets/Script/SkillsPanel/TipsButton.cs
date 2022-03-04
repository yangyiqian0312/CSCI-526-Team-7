using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsButton : MonoBehaviour {
    public Text prompt;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void upgradeTips() {
        float currMoney = GameData.tips;
        int upgradeNeed = GameData.upgradeTipsNeed;
        int tipsLevel = GameData.tipsLevel;
        string tmp;

        if (currMoney >= upgradeNeed) {
            currMoney -= upgradeNeed;
            tipsLevel++;
            tmp = "-- PURCHASE COMPLETE --\n Remaining Money: " + currMoney;
        } else {
            tmp = "-- INVALID PURCHASE --\nYOU CAN'T AFFORD THAT";
        }
        // "Money Remaining:" + GameData.tips
        GameData.tips = currMoney;
        GameData.tipsLevel = tipsLevel;
        prompt.text = tmp;
    }
}
