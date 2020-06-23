using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager;

    public enum GameState {  GameOver, GameStart, GameIdle};
    public static GameState CurrentState = GameState.GameIdle;

    public static int Lives = 3;
    public static int Score = 0;
    void Start()
    {
        Lives = 3;
        Score = 0;
        Time.timeScale = 0;
        CurrentState = GameState.GameIdle;

        thisManager = this;
    }
    
    void Update()
    {
        if(CurrentState == GameState.GameIdle && Input.GetKeyDown(KeyCode.Return))
        {            
            CurrentState = GameState.GameStart;
            Time.timeScale = 1;
            HUD.HUDManager.DismissMessage();
        }

        else if(CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateScoreInt()
    {
        Score++;
        HUD.HUDManager.UpdateScore();
    }

    public void UpdateLivesInt()
    {
        Lives--;
        HUD.HUDManager.UpdateLives();

        if(Lives == 0)
        {
            HUD.HUDManager.GameOver();
        }
    }
}
