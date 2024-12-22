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
    
    
    public void Start()
    {
        
        if (GameStateManager.gameResult == "escaped")
        {
            escapedPanel.SetActive(true);
            
           
            
        }
        
        
        else if (GameStateManager.gameResult == "failed")
        {
            failedPanel.SetActive(true);
            
        }
    }


    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        cümle.gameObject.SetActive(true);
    }

}
