using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapedFail : MonoBehaviour
{
    public GameObject escapedPanel;
    public GameObject failedPanel;
    public TMP_Text cümle;


    
    public void onPlayerEscaped()
    {
        failedPanel.SetActive(true);
        SceneManager.LoadScene("Main Menu");
        
            
            
    }

    public void onPlayerFailed()
    {
        failedPanel.SetActive(true);
        SceneManager.LoadScene("Main Menu");
        
    }


    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void LoadMainMenu()
    { 
        
        SceneManager.LoadScene("Main Menu");
       
        
    }

}
