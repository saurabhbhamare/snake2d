using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("destroyed the speed power up");
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("Shield"))
        {
            Debug.Log("Shield destroyed");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("ScoreBoost"))
        {
            Debug.Log("Score boost destroyed");
            Destroy(this.gameObject);
        }
    }
    

}
