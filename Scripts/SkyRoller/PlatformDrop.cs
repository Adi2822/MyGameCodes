using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    
    void OnTriggerExit (Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Invoke("PlatformDropping", 0f);
        }
    }

    void PlatformDropping()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
    
}
