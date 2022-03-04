using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public void ActivateInsideMenuTutorial(){
        if (GameData.TutorialDone == 0){
            GameObject.Find("Tutorials").transform.GetChild(2).gameObject.SetActive(true);
        }
    }


    public void ActivateOutsideMenuTutorial(){
        if (GameData.TutorialDone == 0){
            GameObject.Find("Tutorials").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ActivateMenuPropertyTutorial(){
        if (GameData.TutorialDone == 0){
            GameObject.Find("Tutorials").transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void ActivateOutsideMixTutorial(){
        if (GameData.TutorialDone == 0){
            if(!GameObject.Find("Mix")){
                GameObject.Find("Tutorials").transform.GetChild(4).gameObject.SetActive(true);
            }
        }
    }

    public void ActivateMixBaseTutorial(){
        if (GameData.TutorialDone == 0){
            if(GameObject.Find("BaseWindow")){
                GameObject.Find("Tutorials").transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }


    public void ActivateMixturePropertyBarTutorial(){
        if (GameData.TutorialDone == 0){
            if(GameObject.Find("ModifierWindow")){
                GameObject.Find("Tutorials").transform.GetChild(6).gameObject.SetActive(true);
            }
        }
    }

    public void ActivateMixModifierTutorial(){
        if (GameData.TutorialDone == 0){
            if(GameObject.Find("ModifierWindow")){
                GameObject.Find("Tutorials").transform.GetChild(7).gameObject.SetActive(true);
            }
        }
    }


    public void ActivateMixturePropertyTutorial(){
        if (GameData.TutorialDone == 0){
            if(GameObject.Find("ModifierWindow")){
                GameObject.Find("Tutorials").transform.GetChild(8).gameObject.SetActive(true);
            }
        }
    }

    public void ActivateMixFlavoringTutorial(){
        if (GameData.TutorialDone == 0){
            if(GameObject.Find("FlavoringWindow")){
                GameObject.Find("Tutorials").transform.GetChild(9).gameObject.SetActive(true);
            }
        }
    }


}
