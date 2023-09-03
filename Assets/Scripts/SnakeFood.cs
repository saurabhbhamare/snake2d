using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFood : MonoBehaviour
{
   // public Transform boost;

    public BoxCollider2D gridArea;
    private void Start()
    {
        RandomizePosition();
        // StartCoroutine(spawnPowerUp)
    }
    public void RandomizePosition()
    {

        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
        else if(other.tag == "SnakeSegment")
        {
            RandomizePosition();
        }
        //else if(other.tag =="SpeedBoost")
        //{
        //    IEnumerator spawnPowerUp()
        //    {
        //        yield return new WaitForSeconds(4f);
        //        RandomizePosition();
        //    }
        //}
        //}

    }
}

