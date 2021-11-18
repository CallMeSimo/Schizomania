using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    // GameObject m_Halo;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;

    private float timer = 0f;

    private Component halo;

    private bool insideCol = false;


    // Start is called before the first frame update

    void Start()
    {


        halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);



    }
    // Update is called once per frame
    void Update()
    {
            
        if (insideCol)
        {

            timer += Time.deltaTime;
            if (timer <= 0.5f)
            {

                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                Debug.Log(timer);
            }
            if (timer >= 1f)
            {
                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                Debug.Log("2");
            }

            if (timer >= 2f)
            {
                timer -= timer;
                Debug.Log("3");
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {
            insideCol = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
            insideCol = false;
        }
    }

}





