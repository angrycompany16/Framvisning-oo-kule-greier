using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] GameObject[] objectList = new GameObject[1];
 
    [SerializeField] float spawnDelay;
    [SerializeField] float radius;
    [SerializeField] float difficultyWaitTime;
    public float timeSinceLastKill;

    public List<GameObject> spawnedObjects = new List<GameObject>();

    float time;

    void Awake() {
        timeSinceLastKill = spawnDelay - 2;
    }

    void Update()
    {
        time += Time.deltaTime;
        timeSinceLastKill += Time.deltaTime;

        if (timeSinceLastKill > difficultyWaitTime) {
            timeSinceLastKill = 0;
            spawnDelay /= 2;
        }

        if (time > spawnDelay) {
            time = 0;
            SpawnObject();
        }
    }

    void SpawnObject() {
        Vector2 spawnPos = FindSpawnPos();
        GameObject obj = objectList[Random.Range(0, objectList.Length)];
        GameObject newObj = Instantiate(obj, spawnPos, Quaternion.identity);
        newObj.GetComponent<Damageable>().spawner = this;
        spawnedObjects.Add(newObj);
    }

    Vector2 FindSpawnPos() {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;

        Vector2 randomPos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

        return randomPos;
    }
}
