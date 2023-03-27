using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform1;
    public GameObject platform2;
    public GameObject Coin;

    Vector3 lastpos1;
    float size1;

    [HideInInspector]
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lastpos1 = platform1.transform.position;
        size1 = platform1.transform.localScale.x;

        InvokeRepeating("SpawnPlatforms", 0.5f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    public void SpawnPlatforms()
    {
        int rand = Random.Range(0, 10);
        if (rand < 5)
        {
            SpawnX();
        }

        else if (rand >= 5)
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        int rand = Random.Range(0, 8);
        if (rand < 4)
        {
            Vector3 pos = lastpos1;
            pos.x += size1;
            lastpos1 = pos;
            Vector3 offset = new Vector3(0, 0.8f, 0);

            Instantiate(platform1, pos, Quaternion.identity);

            if (rand < 1)
            {
                Instantiate(Coin, pos + offset, Quaternion.identity);
            }
            
        }

        else if (rand >= 4)
        {
            Vector3 pos = lastpos1;
            pos.x += size1;
            lastpos1 = pos;
            Vector3 offset = new Vector3(0, 0.8f, 0);

            Instantiate(platform2, pos, Quaternion.identity);

            if (rand >= 6)
            {
                Instantiate(Coin, pos + offset, Quaternion.identity);
            }

        }

    }

    void SpawnZ()
    {

        int rand = Random.Range(0, 6);
        if (rand < 4)
        {
            Vector3 pos = lastpos1;
            pos.z += size1;
            lastpos1 = pos;
            Vector3 offset = new Vector3(0, 0.8f, 0);

            Instantiate(platform1, pos, Quaternion.identity);

            if (rand < 1)
            {
                Instantiate(Coin, pos + offset, Quaternion.identity);
            }
            
        }

        else if (rand >= 4)
        {
            Vector3 pos = lastpos1;
            pos.z += size1;
            lastpos1 = pos;
            Vector3 offset = new Vector3(0, 0.8f, 0);

            Instantiate(platform2, pos, Quaternion.identity);

            if (rand >= 6)
            {
                Instantiate(Coin, pos + offset, Quaternion.identity);
            }
            
        }
    }
}
