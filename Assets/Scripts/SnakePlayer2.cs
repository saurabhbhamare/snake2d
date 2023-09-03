using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayer2 : MonoBehaviour
{
    private Vector2 _direction = Vector2.right; // for snake movement 
    private List<Transform> _segments;   // for snake body parts 
    public Transform segmentPrefab; // prefab to add segments to the snake head
    private SnakeFood snakeFood;
    public BoxCollider2D wrapWall;
    // public SpeedIncreasePowerUp SpeedincP;
    public ScoreController scoreController;
    //  private int speedUp = 2;

    // public SpeedPowerUp speedpwrup;
    //public SnakeFood snakeFoodArea;

    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);

    }
    private void Update()
    {
        SnakeMovement();
        WrapWall();
    }
    private void SnakeMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
        }
    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y,
        0.0f
        );
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        scoreController.IncreaseScore(1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SnakeSegment")
        {

        }
        else if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "SpeedBoost")
        {
            StartCoroutine(increaseSpeedPowerUp());
            Debug.Log("Speed increased");
            scoreController.IncreaseScore(2);
            IEnumerator increaseSpeedPowerUp()
            {
                increaseSpeed();
                yield return new WaitForSeconds(10f);
                Time.fixedDeltaTime = 0.1f;
            }
        }
    }
    private void increaseSpeed()
    {
        Time.fixedDeltaTime = 0.06f;

    }
    private void WrapWall()
    {
        Bounds bounds = this.wrapWall.bounds;
        if (this.gameObject.transform.position.x > bounds.max.x)
        {
            this.transform.position = new Vector2(bounds.min.x, transform.position.y);
        }
        else if (this.transform.position.x < bounds.min.x)
        {
            this.transform.position = new Vector2(bounds.max.x, transform.position.y);
        }
        else if (this.transform.position.y > bounds.max.y)
        {
            this.transform.position = new Vector2(transform.position.x, bounds.min.y);
        }
        else if (this.transform.position.y < bounds.min.y)
        {
            this.transform.position = new Vector2(transform.position.x, bounds.max.y);
        }
    }
}
