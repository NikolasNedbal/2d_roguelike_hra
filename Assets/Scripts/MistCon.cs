using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCon : MonoBehaviour
{
    public GameObject[] fogPrefabs;
    public float spawnInterval = 3f;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnFog();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnFog()
    {
        GameObject fogPrefab = fogPrefabs[Random.Range(0, fogPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(Random.Range(-70f, 70f), Random.Range(-70f, 70f), 0f);
        GameObject fogInstance = Instantiate(fogPrefab, spawnPosition, Quaternion.identity);

        Destroy(fogInstance, 3.5f);
    }
}
