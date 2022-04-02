using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{

    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] Button retryButtonWin;
    [SerializeField] Button retryButtonLose;
    [SerializeField] Button winMainMenu;
    [SerializeField] Button loseMainMenu;

    private void Awake()
    {

    }

    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
        retryButtonWin.onClick.AddListener(GameManager.Instance.RetryLevel);
        winMainMenu.onClick.AddListener(GameManager.Instance.LoadHubWorld);
    }

    public void ShowLoseMenu()
    {
        loseMenu.SetActive(true);
        retryButtonLose.onClick.AddListener(GameManager.Instance.RetryLevel);
        loseMainMenu.onClick.AddListener(GameManager.Instance.LoadHubWorld);
    }
}
