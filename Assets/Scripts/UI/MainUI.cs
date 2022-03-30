using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MainUI : MonoBehaviour
{
    [SerializeField] Text mainButtonText;
    [SerializeField] Text coinDisplayText;

    [SerializeField] Button nextLevelButton;

    void Start()
    {
        mainButtonText.text = "Level " + GameManager.Instance.level;
        UpdateCoinDisplayText();
    }
    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }


    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitted application");
    }

    public void UpdateCoinDisplayText()
    {
        coinDisplayText.text = "COINS: " + GameManager.Instance.coins;
    }
}
