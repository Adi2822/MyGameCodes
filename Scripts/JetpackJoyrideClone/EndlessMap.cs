using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMap : MonoBehaviour
{
    public GameObject PrevTop;
    public GameObject PrevBottom;
    public GameObject Top;
    public GameObject Bottom;

    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > Top.transform.position.x)
        {
            var temptop = PrevTop;
            var tempBottom = PrevBottom;

            PrevTop = Top;
            PrevBottom = Bottom;
            temptop.transform.position += new Vector3(85.15f, 0, 0);
            tempBottom.transform.position += new Vector3(85.15f, 0, 0);

            Top = temptop;
            Bottom = tempBottom;

        }
    }
}
