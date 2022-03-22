using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsButton : MonoBehaviour {
    public Text prompt;
    public Text moneyPrompt;

    // Start is called before the first frame update
    void Start() {
        moneyPrompt.text = "CURRENT MONEY: " + GameData.tips;
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
            tmp = "PURCHASE COMPLETE!\n CURRENT LEVEL: " + tipsLevel + "\n REMAINING MONEY: " + currMoney;
        } else {
            tmp = "INVALID PURCHASE!!!\n YOU CAN'T AFFORD THAT";
        }

        GameData.tips = currMoney;
        GameData.tipsLevel = tipsLevel;
        prompt.text = tmp;
        moneyPrompt.text = "CURRENT MONEY: " + currMoney;
    }
}
