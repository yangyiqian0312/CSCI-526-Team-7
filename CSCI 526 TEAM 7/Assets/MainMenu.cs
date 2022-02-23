using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
    public void newWindow(){
        SceneManager.LoadScene("Bar");
    }

    public void SendAnalyticsServeCustomer(string optionSelected)
    {
        Analytics.CustomEvent("serve_customer", new Dictionary<string, object>
        {
            { "option_selected", optionSelected }
        });
    }
    
}
