using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.LoadLevel(level);
    }
}
