using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // InputHandler med OnTriggerEnter?
    // Update högst upp (under start)
    // 

    public TextMeshProUGUI myText;
    private Rigidbody2D rb2;
    private Vector2 pos;


    private bool alive = true;
    private bool isGrounded = false;
    private bool HoldingorUsing = false;

    public float HorizontalMove, VerticalMove, DeathTimer = 0.0f;
    private int playerDirection = 1; // 1 = right; -1 = left;
    public float speed;

    public LayerMask playerLayerMask;



    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        playerLayerMask = ~playerLayerMask;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            alive = false;
            if (!alive)
            {
            }
        }
    }


    void moveHandler()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && groundDetection())
        {
            rb2.AddForce(Vector2.up * 250f /*Force to apply when lifting the rigidbody. */);
        }

        if (HorizontalMove > 0) playerDirection = 1; else if (HorizontalMove < 0)playerDirection = -1;
    }

    void PlayerInputHandler()
    {
        if (Input.GetKeyDown("e") && HoldingorUsing == false)
        {
            if (InteractionDetection() != null && InteractionDetection().tag == "Pickable")
            {
                InteractionDetection().transform.parent = gameObject.transform;
                HoldingorUsing = true;
                return;
            }
            else if (InteractionDetection() == null) Debug.Log("Nothing");

        }

        if (HoldingorUsing == true && Input.GetKeyDown("e"))
        {
            gameObject.transform.DetachChildren();
            HoldingorUsing = false;
            return;
        }
    }

    void aliveHandler() // Alive = can move, !Alive = cant move.
    {
        if (alive != true)  
        {
            Destroy(this.gameObject.GetComponent<MeshRenderer>());
        }
    }

    // I wonder if making this public would enable some form of cheating.
     public bool groundDetection()
    {
        float raycastDistance = 0.1f; //Distance set for raycast
        Vector3 raycastOriginOffset = new Vector3(0f, -0.8f); //Will otherwise hit itself (charactersize.y / 2 should be proper value, might need a bit more).

        // Cast a ray straight down.
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, raycastDistance);
        Debug.DrawRay(transform.position + raycastOriginOffset, -Vector2.up, Color.red, raycastDistance);

        // If it hits something...
        if (hitDown.collider != null)
        {
            //Enables isGrounded
            return true;
        }
        //Disables if grounded.
        return false;
    }

    GameObject InteractionDetection()
    {
        float raycastDistance1 = 0f;

        Vector3 raycastOriginOffset1 = playerDirection == 1 ? new Vector2(1f, 0) : new Vector2(-1f, 0); //Will otherwise hit itself, adds distance between player and raycast origin depending on direction.
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOriginOffset1, new Vector2(playerDirection, 0), raycastDistance1 /* , playerLayerMask // This should make the raycast ignore the player but it does not. */ );    // Cast a ray straight ? left : right.

        Debug.DrawRay(transform.position + raycastOriginOffset1, new Vector2(playerDirection, 0), Color.red, 1f); // Debugging purpouse.
        try
        {
            switch (hit.transform.gameObject.tag)
            {
                case "Pickable":
                    Debug.Log("helolITHIT");
                    return hit.transform.gameObject;
                default:
                    Debug.Log("ERROR:_ " + hit.transform.gameObject.name);
                    return null;
            }
        }
        catch
        {
            return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveHandler();
        PlayerInputHandler();
        aliveHandler();
    }

    void FixedUpdate()
    {
        pos = new Vector3(HorizontalMove * speed * Time.fixedDeltaTime, VerticalMove * speed * Time.fixedDeltaTime);
        rb2.position += pos;

    }
}
