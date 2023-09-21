using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    //public GameObject gameOverScreen;
    public Button mainScreen;
    // Start is called before the first frame update
    private void Awake()
    {
        mainScreen.onClick.AddListener(HomeScreen);
    }
    public void GameOver()
    {
        this.gameObject.SetActive(true);
    }
    public void HomeScreen()
    {
        SceneManager.LoadScene("Lobby"); 
    }

}
