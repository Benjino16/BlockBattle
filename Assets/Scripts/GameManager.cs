using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    [SerializeField] int currentLevel = 1;
    public int bestLevel = 1;
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
    public void LoadLevel(int Level)
    {
        if (Level > bestLevel)
        {
            Level = bestLevel;
        }
        currentLevel = Level;
        SceneManager.LoadScene("Level" + Level);
        gameState = GameState.battle;
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }

    public void LoadHubWorld()
    {
        SceneManager.LoadScene("HubWorld");
    }

    public void RetryLevel()
    {
        LoadLevel(currentLevel);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HubWorld");
    }

    public void EndGame(bool playerWin)
    {
        if (playerWin)
        {
            bestLevel += 1;
            if (bestLevel > maxLevel)
            {
                bestLevel = maxLevel;

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
