using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid 
{
    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        SpawnFood();
    }
    private void SpawnFood()
    {
        foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        GameObject foodGameObject = new GameObject("food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.ins.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);

    }
}
