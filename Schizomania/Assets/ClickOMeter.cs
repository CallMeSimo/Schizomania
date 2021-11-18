using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOMeter : MonoBehaviour
{
    public float speed;
    public float pullSpeed;
    public float markiplier;
    public GameObject start;
    public AudioClip fresh;
    private float calculatedSpeed;
    private float lastSteps, timeBetweenSteps = 0.05f;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        calculatedSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * pullSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.time - lastSteps > timeBetweenSteps)
            {
                lastSteps = Time.time;
                transform.Translate(Vector2.left * calculatedSpeed * Time.deltaTime);
                calculatedSpeed = speed - Vector2.Distance(start.transform.position, transform.position) * markiplier; // PEMDAS
            }
        }

        Debug.Log(calculatedSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            if (!hasPlayed)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                AudioSource.PlayClipAtPoint(fresh, transform.position, 1);
                hasPlayed = true;
            }
        }
    }
}
