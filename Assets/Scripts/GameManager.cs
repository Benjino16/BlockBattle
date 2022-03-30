using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public int level = 1;
    public int maxLevel = 1;

    public GameState gameState;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + level);
        gameState = GameState.battle;


        //Mit diesem Weg kann das UI und andere elemente mehrfach geladen werden!
        /*
        SceneManager.LoadScene("leaderboard");
        SceneManager.LoadScene("menu", LoadSceneMode.Additive);
        */
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame(bool playerWin)
    {
        if(playerWin)
        {
            level += 1;
            if(level > maxLevel)
            {
                level = maxLevel;
                //All levels complete
                Debug.Log("Completed the game");
            }
            gameState = GameState.end;

            Debug.Log("The player has won the game");
            FindObjectOfType<EndMenu>().ShowWinMenu();
        }
        else
        {
            gameState = GameState.end;

            Debug.Log("The boss has won the game");
            FindObjectOfType<EndMenu>().ShowLoseMenu();
        }
    }


    public enum GameState
    {
        mainMenu,
        battle,
        end
    }

}
