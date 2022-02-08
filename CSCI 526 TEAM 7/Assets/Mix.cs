using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mix : MonoBehaviour
{
    public void backToBar(){
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
}
