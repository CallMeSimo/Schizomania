using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCable : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private GameObject bultsax;
    private GameObject light3;

    public bool blue = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bultsax = GameObject.FindGameObjectWithTag("Bultsax");
        light3 = GameObject.FindGameObjectWithTag("Light4");
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.name == "bultsax1")
        {
            spriteRenderer.sprite = newSprite;
            light3.SetActive(false);
            blue = true;
        }
    }
}
