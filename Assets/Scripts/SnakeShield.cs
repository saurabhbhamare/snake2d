using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeShield : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject ShieldObject;
    public float spawnTime = 6f; // The time interval between spawns
    GameObject instantiatedObject;
    void Start()
    {
        // Invoke the Spawn function every spawnTime seconds
        InvokeRepeating("Spawn", 2f, 6f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SnakeSegment")
        {
            Spawn();
        }
        else if (other.gameObject.tag == "Shield")
        {
            Spawn();
        }
        
    }
    public void Spawn()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        instantiatedObject = Instantiate(ShieldObject, new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f), Quaternion.identity);
        Destroy(instantiatedObject, 4f);
    }
}
