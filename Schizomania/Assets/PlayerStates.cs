using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private PlayerController PlayerController;

    public enum PlayerState
    {
        Idle,
        walking,
        Dead,
        Falling
    }

    PlayerState myState;
    private Animation anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();

        myState = PlayerState.Idle;
        PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If statements, will try to fix this later.
        // This is not as efficient as I would hope for, this is a WiP.
        if (!PlayerController.groundDetection())
        {
            myState = PlayerState.Falling;
            anim.Play("Falling");
        }
        if ( PlayerController.groundDetection())
        {
            myState = PlayerState.Idle;
            anim.Play("Idle");
        }
        if (PlayerController.HorizontalMove < 0)
        {
            myState = PlayerState.walking;
            anim.Play("walk");
        }
        if (PlayerController.HorizontalMove > 0)
        {
            myState = PlayerState.walking;
            anim.Play("Walk"); //Mirror this, Mirror character?

        }
    }
}
