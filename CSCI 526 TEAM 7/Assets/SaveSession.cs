using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSession : MonoBehaviour
{
    public void saveGame(){
        
        PlayerPrefs.SetInt("playerDate", GameData.date);
        PlayerPrefs.SetFloat("tipsEarned", GameData.tips);
        Debug.Log("Game saved successully!");
        SceneManager.LoadScene("Bar");

    }
}
