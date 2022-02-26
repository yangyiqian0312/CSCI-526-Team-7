using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    public void newWindow(){
        SceneManager.LoadScene("Dialogue");
    }


    public void toSkill(){
        SceneManager.LoadScene("UpgradeSkills");
    }
}