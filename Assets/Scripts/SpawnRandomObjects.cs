using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRandomObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private GameObject[] storyImportant;

    [SerializeField] private string enemyName;

    [SerializeField] private int numberOfObjectsToSpawn = 10;
    [SerializeField] private string tagRuanMei = "tag";

    [SerializeField] public bool unlockos = false;

    private bool storyImportantSpawned = false;

    private GameObject storyEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnObjects();
    }

    private void Start()
    {
        Find();
    }

    private void Update()
    {
        UnlockLevel();
    }

    private void UnlockLevel()
    {
        if(storyEnemy != null && storyEnemy.activeInHierarchy == false)
        {
            unlockos = true;
        }
    }

    private void Find()
    {
        if(enemyName!= null)
        {
            storyEnemy = GameObject.Find(enemyName);
            Debug.Log(storyEnemy);
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            if(storyImportant != null && storyImportantSpawned == false)
            {
                for(int j = 0; j < storyImportant.Length; j++)
                {
                    GameObject storyObject = storyImportant[Random.Range(0, storyImportant.Length)];

                    SpawnRandomObj(storyObject);
                    storyImportantSpawned = true;
                }
            }
            // Choose a random object from the array
            GameObject randomObject = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            SpawnRandomObj(randomObject);

            //Debug.Log(spawnedStoryObject.activeInHierarchy);
            //Debug.Log(enemyHp != null);
        }
    }

    void SpawnRandomObj(GameObject objList)
    {
        // Get the bounds of all objects in the specified layer
        Bounds combinedBounds = GetCombinedBoundsInLayer(tagRuanMei);

        // Spawn the object at a random position within the bounds
        Vector2 spawnPosition = new Vector2(
            Random.Range(combinedBounds.min.x, combinedBounds.max.x),
            Random.Range(combinedBounds.min.y+5, combinedBounds.max.y)
        );

        // Instantiate the object at the final spawn position
        Instantiate(objList, spawnPosition, Quaternion.identity);
    }

    Bounds GetCombinedBoundsInLayer(string tag)
    {
        GameObject[] objectsInLayer = GameObject.FindGameObjectsWithTag(tag);
        Bounds combinedBounds = new Bounds(objectsInLayer[0].transform.position, Vector3.zero);

        foreach (GameObject obj in objectsInLayer)
        {
            combinedBounds.Encapsulate(obj.GetComponent<Renderer>().bounds);
        }

        return combinedBounds;
    }
}
