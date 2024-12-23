using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHome : MonoBehaviour
{
    public GameObject escapeDoor;
    private float detectDistance = 2f;
    private KeyCode keyCode = KeyCode.E;
    public TextMeshProUGUI escapeText;
    public TMP_InputField inputField;
    private string password = "52714";
    public bool walkable = true;
    public static bool isEscaped = false;

    void Start()
    {
        escapeText.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, detectDistance))
        {
            if (hit.transform.gameObject == escapeDoor)
            {
                escapeText.gameObject.SetActive(true);
                if (Input.GetKeyDown(keyCode))
                {
                    inputField.gameObject.SetActive(true);
                    inputField.ActivateInputField(); 
                }
            }
        }
        else
        {
            escapeText.gameObject.SetActive(false);
        }
        
        if (inputField.gameObject.activeSelf)
        {
            walkable = false;
            escapeText.gameObject.SetActive(false);
            string input = inputField.text;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (input == password)
                {
                    isEscaped = true;
                }
                else
                {
                    walkable = true;
                }
                
                inputField.text = ""; 
                inputField.gameObject.SetActive(false); 
                
            }
        }
    }
    /*public void onPlayerEscaped()
    {

        if (isEscaped == true)
        {
            SceneManager.LoadScene("Main Menu");
            

        }

    }*/
}
