using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upSpeed;
    public float downspeed;
    public ParticleSystem ps;
    public GameObject MapComp;
    public GameObject Spawr;
    public GameObject Playr;
    public GameObject Panl;
    public GameObject Cam;



    private ParticleSystem.EmissionModule em;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        em = ps.emission;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
            //transform.eulerAngles = new Vector3(0, 0, 0);
            em.enabled = true;

        }
        else
        {
            rb.AddForce(new Vector2(0, downspeed * (Time.timeScale)));
            //transform.eulerAngles= new Vector3(0, 0, -15);
            em.enabled = false;

        }

     
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("YES");

        if (col.gameObject.CompareTag("Obstaclee"))
        {
            //Debug.Log("no");
            Gameover();
        }
    }



    public void Gameover()
        {
        Cam.GetComponent<CameraMove>().enabled = false;
        MapComp.SetActive(false);
        Playr.SetActive(false);
        Spawr.SetActive(false);
        Panl.SetActive(true);
        
        }
}
