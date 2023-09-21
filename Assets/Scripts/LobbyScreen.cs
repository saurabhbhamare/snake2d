using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobbyScreen : MonoBehaviour
{
    public Button singlePlayer;
    public Button twoPlayer;
    void Start()
    {
        singlePlayer.onClick.AddListener(RunSinglePlayer);
        twoPlayer.onClick.AddListener(RunTwoPlayer);
  
    }
    void RunSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    void RunTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayer");
    }
}
