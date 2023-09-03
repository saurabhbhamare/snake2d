using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyScreen : MonoBehaviour
{
    public Button singlePlayer;
    public Button twoPlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        singlePlayer.onClick.AddListener(runSinglePlayer);
    }
    void runSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }


    // Update is called once per frame
 
}
