using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    public float speed;

    private Rigidbody2D rb2d;
    private Vector2 pos;

    private bool facingRight = true;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.GetFloat("pos x") != null)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("pos x"), PlayerPrefs.GetFloat("pos y"), PlayerPrefs.GetFloat("pos z"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveHandler();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("pos x", transform.position.x);
        PlayerPrefs.SetFloat("pos y", transform.position.y);
        PlayerPrefs.SetFloat("pos z", transform.position.z);
    }

    // Update for physics
    void FixedUpdate()
    {
        pos = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, 0);
        rb2d.position += pos;

        if (horizontalMove == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        if (!facingRight && horizontalMove > 0)
        {
            Flip();
        } 
        else if(facingRight && horizontalMove < 0)
        {
            Flip();
        }
    }

    void moveHandler()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void HidePlayerOnLoad()
    {
        gameObject.SetActive(false);
        Debug.Log("Hide Player");
    }

    public void ShowPlayerOnLoad()
    {
        gameObject.SetActive(true);
        Debug.Log("Show Player");
    }
}
