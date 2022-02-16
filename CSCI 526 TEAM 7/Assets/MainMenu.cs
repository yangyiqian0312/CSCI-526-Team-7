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



    public void SendAnalytics()
    {
        Analytics.CustomEvent("serve_customer", new Dictionary<string, object>
        {
            { "option_selected", "Yes" }
        });

        // AnalyticsEvent.Custom("secret_found", new Dictionary<string, object>
        // {
        //     { "secret_id", secretID },
        //     { "time_elapsed", Time.timeSinceLevelLoad }
        // });
    }



    
}
