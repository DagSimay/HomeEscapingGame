using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyCatch : MonoBehaviour
{
    public Hiding hiding;
    public Transform player;
    public NavMeshAgent agent;
    public EnemyRoute enemyRoute;
    private float fieldOfView = 120f;
    private float catchDistance = 1f;
    private float cantHideDistance = 2.5f;
    private bool playerSpotted = false;
    public static bool isCatched= false;
    private EscapedFail escapedFail;


    void Start()
    {
        escapedFail = new EscapedFail();
    }

    void Update()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (hiding.isHide==true)
        {
            playerSpotted = false;
            enemyRoute.enabled = true;
            agent.speed = 1.5f;
        }
        
        if (playerSpotted == false)
        {
            if (angleToPlayer <= fieldOfView/2 && Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit))
            {
                if (hit.transform == player)
                {
                    playerSpotted = true;
                }
            }
        }
        
        else 
        {
            gameObject.GetComponent<EnemyRoute>().enabled = false;
            agent.speed = 2.2f;
            agent.SetDestination(player.position);
            
            if (Vector3.Distance(transform.position, player.position) < cantHideDistance)
            {
                hiding.enabled = false;
                hiding.hideText.gameObject.SetActive(false);
            }
            
            else
            {
                hiding.enabled = true;
            }
            
            if (Vector3.Distance(transform.position, player.position) <= catchDistance)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("FailedScene", LoadSceneMode.Single);
            }
        }
    }
    
    
}
