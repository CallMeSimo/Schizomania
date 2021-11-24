using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{ 
    public ReceptionistDetection receptionistScript;
    // Update is called once per frame
    void Update()
    {
        if(receptionistScript.lampaOn==false){
            gameObject.SetActive(false);
        }
        else if (receptionistScript.lampaOn==true)
        {
            gameObject.SetActive(true);
        }
    }
}
