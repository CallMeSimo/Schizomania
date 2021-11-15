using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            return;
        }

        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

    }
}
