//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class testforarray : MonoBehaviour
//{
//    public BoxCollider2D gridArea2;
//    public GameObject[] spawnObjects;
    
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(SpawnObjectsAtRandom());

//    }
//    private void RandomizePosition()
//    {
//        Bounds bounds = this.gridArea2.bounds;
//        float x = Random.Range(bounds.min.x, bounds.max.x);
//        float y = Random.Range(bounds.min.y, bounds.max.y);
//        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
//    }
//    IEnumerator SpawnObjectsAtRandom()
//    {
//        for(int i = 0; i<spawnObjects.Length;i++ )
//        {
//            int randomIndex = Random.Range(0, spawnObjects.Length);
//            GameObject objectToSpawn = spawnObjects[randomIndex];
//            Vector3 randomPOstition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);

//        }



//    }
        
  

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
