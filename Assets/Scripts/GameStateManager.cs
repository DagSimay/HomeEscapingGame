using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    


    public void PlayerEscaped()
    {
        Debug.Log("PlayerEscaped method called");
        if (EscapeHome.isEscaped == true)
        {
            SceneManager.LoadScene("Main Menu");
        }

        
        
    }

    public void PlayerCaught()
    {
        if (EnemyCatch.isCatched == true)
        {
            SceneManager.LoadScene("Main Menu");
        }
        
    }
}
