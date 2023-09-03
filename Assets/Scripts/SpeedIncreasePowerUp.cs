using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasePowerUp: MonoBehaviour
{
    public BoxCollider2D gridArea3;
    public GameObject objectToSpawn;
   // public GameObject// The object to spawn
    public float spawnTime = 5f; // The time interval between spawns
    GameObject instantiatedObject;

    //public SnakeFood snakefood;
    void Start()
    {
        // Invoke the Spawn function every spawnTime seconds
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
      
    }
  
    public void Spawn()
    {
        Bounds bounds = this.gridArea3.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        instantiatedObject = Instantiate(objectToSpawn, new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f), Quaternion.identity);  
        Destroy(instantiatedObject, 4f);  
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //        {
    //        Debug.Log("destroyed the speed power up");
    //        Destroy(instantiatedObject);
    //       }
    //}
    
}
