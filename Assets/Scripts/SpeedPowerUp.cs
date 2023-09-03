using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpeedPowerUp : MonoBehaviour
{
    public BoxCollider2D gridArea;

    public void Start()
    {
        RandomizePosition();
        StartCoroutine(SpeedBoost());
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    IEnumerator SpeedBoost()
    {
        RandomizePosition();
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpeedBoost();
            StartCoroutine(SpeedBoost());
        }
    }
}


