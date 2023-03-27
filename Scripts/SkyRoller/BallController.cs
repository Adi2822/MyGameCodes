using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    
    Rigidbody rb;

    [SerializeField]
    private float speed;
    public float speedInc;

    [HideInInspector]
    public bool started = false;

    [HideInInspector]
    public bool gameOver;

    public static EndMenu Endmenu;
   
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed < 15)
        {
            speed += speedInc * Time.deltaTime;
        }

        if (!started)
        {
            GameStart();
        }
       

        if (!Physics.Raycast(transform.position, Vector3.down, 100f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -20f, 0);

            GameManager.instance.GameOver();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Switch();
        }

    }

    public void GameStart()
    {
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            //Debug.Log("Start");
            rb.velocity = new Vector3(speed, 0, 0);
            started = true;

            FindObjectOfType<LevelSound>().LevelMusic();
        }
    }

    void Switch()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }

        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

}
