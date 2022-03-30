using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{

    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button retryButton;
    [SerializeField] Button winMainMenu;
    [SerializeField] Button loseMainMenu;

    private void Awake()
    {
        
    }

    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
        nextLevelButton.onClick.AddListener(GameManager.Instance.NextLevel);
        winMainMenu.onClick.AddListener(GameManager.Instance.LoadMainMenu);
    }

    public void ShowLoseMenu()
    {
        loseMenu.SetActive(true);
        retryButton.onClick.AddListener(GameManager.Instance.NextLevel);
        loseMainMenu.onClick.AddListener(GameManager.Instance.LoadMainMenu);
    }
}
