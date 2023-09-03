using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject[] powerUps;
    public Vector2 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randSpawnObj;

    private void Start()
    {
        StartCoroutine(waitSpawner());
    }
    private void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait); 
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait);
        while(!stop)
        {
            randSpawnObj = Random.Range(0, 2);
        }
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, 0);
        Instantiate(powerUps[randSpawnObj], spawnPosition = transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        yield return new WaitForSeconds(spawnWait);
    }
}
