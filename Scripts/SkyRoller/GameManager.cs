using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EndMenu EndMenu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        FindObjectOfType<CameraFollow>().gameOver = true;
        FindObjectOfType<PlatformSpawn>().gameOver = true;
        FindObjectOfType<Score>().pointIncreasedPerSecond = 0;
        FindObjectOfType<LevelSound>().StopLevelMusic();
        EndMenu.Setup();
    }
}
