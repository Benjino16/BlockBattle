using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.Instance.StartGame();
    }


    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitted application");
    }
}
