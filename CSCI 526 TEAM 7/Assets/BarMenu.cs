using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarMenu : MonoBehaviour
{
    public void newWindow(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}


