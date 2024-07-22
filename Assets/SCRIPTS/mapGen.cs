using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGen : MonoBehaviour
{
    public GameObject[] prefabs;
    public int gridWidth;
    public int gridHeight;
    public float spacing;

    void Start()
    {
        //grid size
        float totalWidth = (gridWidth - 1) * spacing;
        float totalHeight = (gridHeight - 1) * spacing;

        
        Vector3 startPos = transform.position - new Vector3(totalWidth / 2f, totalHeight / 2f, 0f);

        // Instantiate objects randomly from the prefabs list
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                GameObject prefab = prefabs[randomIndex];

                Vector3 spawnPos = startPos + new Vector3(x * spacing, y * spacing, 0f);
                Instantiate(prefab, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}

