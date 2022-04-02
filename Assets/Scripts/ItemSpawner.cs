using UnityEngine;


[System.Serializable]
public class SpawnItem
{
    public float minSpawningRate;
    public float maxSpawningRate;

    public GameObject spawningObject;

    [HideInInspector] public float currentSpawningRate;
}

public class ItemSpawner : MonoBehaviour
{
    public SpawnItem[] spawnItems;

    float waitingTime = 0f;

    private void Start()
    {
        foreach (SpawnItem spawnItem in spawnItems)
        {
            spawnItem.currentSpawningRate = Random.Range(spawnItem.minSpawningRate, spawnItem.maxSpawningRate);
        }
    }

    private void Update()
    {
        waitingTime += Time.deltaTime;

        foreach (SpawnItem spawnItem in spawnItems)
        {
            if (waitingTime > spawnItem.currentSpawningRate)
            {
                Spawn(spawnItem.spawningObject);
                spawnItem.currentSpawningRate = waitingTime + Random.Range(spawnItem.minSpawningRate, spawnItem.maxSpawningRate);
            }
        }
    }

    private void Spawn(GameObject spawningObject)
    {
        Instantiate(spawningObject, RandomPosition(), transform.rotation);
    }

    private Vector2 RandomPosition()
    {
        Vector2 range = transform.localScale / 2f;
        return new Vector2(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y));
    }



    [SerializeField] Color GizmosColor = new Color(1f, 0.5f, 0.5f, 0.30f);
    [SerializeField] bool seeArea = false;
    void OnDrawGizmos()
    {
        if (seeArea)
        {
            Gizmos.color = GizmosColor;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}
