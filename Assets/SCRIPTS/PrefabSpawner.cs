using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int numPrefabsToSpawn = 15;
    public Vector2 spawnAreaSize = new Vector2(15f, 15f);

    private void Start()
    {
        for (int i = 0; i < numPrefabsToSpawn; i++)
        {
            // Calculate random position within spawn area
            float x = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            float y = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
            Vector3 spawnPos = transform.position + new Vector3(x, y, 0f);

            // Instantiate prefab at random position
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}

