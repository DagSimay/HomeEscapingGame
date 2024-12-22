using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static string gameResult;


    public void PlayerEscaped()
    {
        GameStateManager.gameResult = "escaped";
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayerCaught()
    {
        GameStateManager.gameResult = "caught";
        SceneManager.LoadScene("SampleScene");
    }
}
