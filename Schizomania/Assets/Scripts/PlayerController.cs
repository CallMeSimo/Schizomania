using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public List<string> completedMinigames = new List<string>();

    private float horizontalMove;
    public float speed;

    private Rigidbody2D rb2d;
    private Vector2 pos;

    private bool facingRight = true;
    private static bool exists;

    private Animator anim;

    public bool clockCompleted = false;


    private void Start()
    {

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(gameObject.transform);
        }
        else
        {
            Destroy(gameObject);
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
        else if (facingRight && horizontalMove < 0)
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

    public void AddItemToInventory(string obj)
    {
        inventory.Add(obj);
    }

    public void AddCompletedMinigame(string game)
    {
        completedMinigames.Add(game);
    }

    public bool minigameCompleted(string game)
    {
        foreach (string name in completedMinigames)
        {
            if (name == game)
            {
                return true;
            }
        }
        return false;
    }
}
