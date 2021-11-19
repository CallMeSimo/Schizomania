using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int Level;
    private bool inCollider;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("True");
            inCollider = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("False");
            inCollider = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& inCollider)
        {
            SceneManager.LoadScene(Level);
            // playerController.HidePlayerOnLoad();
        }
    }
}
