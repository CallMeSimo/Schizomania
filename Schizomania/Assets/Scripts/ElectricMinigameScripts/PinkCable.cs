using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCable : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private GameObject bultsax;
    private GameObject light2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bultsax = GameObject.FindGameObjectWithTag("Bultsax");
        light2 = GameObject.FindGameObjectWithTag("Light3");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "bultsax1")
        {
            spriteRenderer.sprite = newSprite;
            light2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
