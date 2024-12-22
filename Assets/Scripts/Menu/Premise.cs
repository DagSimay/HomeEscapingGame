using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Premise : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject premisePanel;
    public TMP_Text cümle;
    


    public void ShowPremise()
    {
        
        premisePanel.SetActive(true);
        cümle.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
