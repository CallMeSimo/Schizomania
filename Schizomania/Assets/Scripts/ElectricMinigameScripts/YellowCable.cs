using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCable : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private GameObject bultsax;
    private GameObject light1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bultsax = GameObject.FindGameObjectWithTag("Bultsax");
        light1 = GameObject.FindGameObjectWithTag("Light2");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Yellow");
        if (other.gameObject.name == "bultsax1")
        {
            spriteRenderer.sprite = newSprite;
            light1.SetActive(false);
        }
    }
}
