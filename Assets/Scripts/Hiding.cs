
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public EnemyRoute enemyRoute;
    
    private float detectDistance = 2f;
    private KeyCode keyCode = KeyCode.E;
    public List<GameObject> targets;
    public List<Vector3> hidingPositions;
    private List<Vector3> exitPositions;
    public int initialTarget = -1;
    public bool isHide;
    private CharacterController characterController;
    public Light spotLight;
    public TextMeshProUGUI hideText;
    public TextMeshProUGUI exitText;
    
    
    
    
    

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, -0.272f, 0f);
        characterController = gameObject.GetComponent<CharacterController>();
        isHide = false;
        hideText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(false);
        
        hidingPositions = new List<Vector3>();
        hidingPositions.Add(new Vector3(-1.21200001f, -0.763999999f, -6.21099997f));
        hidingPositions.Add(new Vector3(-5.20599985f,-1.76199996f,-5.93300009f));
        hidingPositions.Add(new Vector3(-6.58900023f,-0.693000019f,-1.01199996f));
        hidingPositions.Add(new Vector3(1.80799997f,-0.381999999f,-2.19899988f));
        hidingPositions.Add(new Vector3(1.88900006f,-1.57799995f,0.779999971f));
        
        exitPositions = new List<Vector3>();
        exitPositions.Add(new Vector3(-0.688172221f,-0.627904117f,-6.01470947f));
        exitPositions.Add(new Vector3(-4.71099997f,-0.627904117f,-4.32600021f));
        exitPositions.Add(new Vector3(-6.16193438f,-0.627904058f,-0.712908506f));
        exitPositions.Add(new Vector3(1.2499603f,-0.627904117f,-2.25078225f));
        exitPositions.Add(new Vector3(1.32120264f,-0.627904058f,1.65872991f));
    }


    void hideToObject(int i)
    {
        characterController.enabled = false;
        gameObject.transform.position = hidingPositions[i];
        characterController.enabled = true;
        isHide = true;
        initialTarget = i;
        hideText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(true);
        if (i == 0 || i == 1)
        {
            spotLight.enabled = false;
        }
    }

    void exitToObject(int i)
    {
        characterController.enabled = false;
        gameObject.transform.position = exitPositions[i];
        characterController.enabled = true;
        isHide = false;
        initialTarget = -1;
        exitText.gameObject.SetActive(false);
        if (i == 0 || i == 1)
        {
            spotLight.enabled = true;
        }
    }

    void Update()
    {
        if (isHide == true)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                exitToObject(initialTarget);
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, detectDistance))
            {
                bool targetDetected = false;
                for (int i = 0; i < targets.Count; i++)
                {
                    if (isHide == false && hit.transform.gameObject == targets[i])
                    {
                        hideText.gameObject.SetActive(true);
                        targetDetected = true;
                        if (Input.GetKeyDown(keyCode))
                        {
                            hideToObject(i);
                        }
                    }
                }
                if (targetDetected == false)
                {
                    hideText.gameObject.SetActive(false);
                }
            }
        }
    }
}
