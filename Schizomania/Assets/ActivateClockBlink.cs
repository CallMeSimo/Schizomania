using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClockBlink : MonoBehaviour
{
    public PickupObjects blinka;
    private bool insideCol = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {   
        blinka.fårBlinka = true;
    }
    
}
