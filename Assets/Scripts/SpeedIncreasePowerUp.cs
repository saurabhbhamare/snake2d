using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasePowerUp: MonoBehaviour
{
    public BoxCollider2D gridArea3;
    public GameObject objectToSpawn;
    public float spawnTime = 5f; 
    GameObject instantiatedObject;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 6f);
        InvokeRepeating("Shield", 5f, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SnakeSegment") 
        {
            Spawn();
        }
        else if(other.gameObject.tag == "Shield")
        {
            Spawn();
        }
        else if(other.gameObject.tag =="Snake1")
        {
            Spawn();
        }
       else if(other.gameObject.tag == "Snake2")
        {
            Spawn();
        }
    }
  
    public void Spawn()
    {
        Bounds bounds = this.gridArea3.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        instantiatedObject = Instantiate(objectToSpawn, new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f), Quaternion.identity);  
        Destroy(instantiatedObject, 4f);  
    }
  
}
