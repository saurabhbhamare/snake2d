using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    Player1,
    Player2
}
public class SnakePlayer2 : MonoBehaviour
{
    private Vector2 _direction = Vector2.right; // for snake movement 
    private List<Transform> _segments;   // for snake body parts 
    public Transform segmentPrefab; // prefab to add segments to the snake head
    private SnakeFood snakeFood;
    public BoxCollider2D wrapWall;
    public ScoreController2 scoreController2;
    public ScoreController1 scoreController1;
    public GameOverController gameOverController;
    
    //private bool snakeShield = false;
    public PlayerType playerType;

    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
       
    }
    private void Update()
    {
        
        SnakeMovement(playerType);
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        this.transform.localEulerAngles = new Vector3(0, 0, (angle - 90));
        WrapWall();
    }
    private void SnakeMovement(PlayerType playerType)
    {
        if (playerType== PlayerType.Player1){
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
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            this.transform.localEulerAngles = new Vector3(0, 0, (angle - 90));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (_direction != Vector2.down)
                {
                    _direction = Vector2.up;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (_direction != Vector2.up)
                {
                    _direction = Vector2.down;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (_direction != Vector2.left)
                {
                    _direction = Vector2.right;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (_direction != Vector2.right)
                {
                    _direction = Vector2.left;
                }
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
    private void Grow(PlayerType playerType)
    { 
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        if (playerType == PlayerType.Player1)
        {
            scoreController1.IncreaseScore(1);
        }
        else 
        {
            scoreController2.IncreaseScore(1);
        } 
    }
    private void WinConditionCheck()
    {
        if (scoreController1.ReturnScore() > scoreController2.ReturnScore())
        {
            Debug.Log("Player 1 won");
        }
        else
        {
            Debug.Log("Player 2 won");
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow(playerType);
        }
        // if(other.tag == "SnakeSegment")
        //{ 
        //    if(scoreController1.score1>scoreController2.score2)
        //    {
        //        Debug.Log("Player1 Won");
        //    }
        //}
         if(playerType == PlayerType.Player1)
        {
            if(other.gameObject.CompareTag("Snake2"))
            {
                WinConditionCheck();
                GameOver();
            }
            else if(other.gameObject.CompareTag("Snake1"))
            {
                Debug.Log("Snake1 Attacked itself");
                GameOver();
            } 
        }
        if (playerType == PlayerType.Player2)
        {
            if (other.gameObject.CompareTag("Snake1"))
            {
                WinConditionCheck();
                GameOver();
            }
            else if (other.gameObject.CompareTag("Snake2"))
            {
                Debug.Log("Snake2 Attacked itself");
                GameOver();
            }
        }
        //if (playerType == PlayerType.Player2 || other.tag =="Snake2")
        //{
        //    Debug.Log("Player 2 Won");
        //}
        if (other.tag == "SpeedBoost")
        {
            StartCoroutine(IncreaseSpeedPowerUp());
            Debug.Log("Speed increased");
            IEnumerator IncreaseSpeedPowerUp()
            {
                IncreaseSpeed();
                yield return new WaitForSeconds(10f);
                Time.fixedDeltaTime = 0.1f;
            }
        }
    }
    private void IncreaseSpeed()
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
