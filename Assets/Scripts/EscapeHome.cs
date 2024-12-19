using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapeHome : MonoBehaviour
{
    public GameObject escapeDoor;
    private float detectDistance = 2f;
    private KeyCode keyCode = KeyCode.E;
    public TextMeshProUGUI escapeText;
    public TMP_InputField inputField;
    private string password = "52714";

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
        
        if (inputField.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return)) 
        {
            string input = inputField.text;

            if (input == password)
            {
                Debug.Log("Congratulations! You escaped the house!");
            }
            else
            {
                Debug.Log("Wrong password! Try again.");
            }

            inputField.text = ""; 
            inputField.gameObject.SetActive(false); 
        }
        
        
    }
}
