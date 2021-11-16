using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOMeter : MonoBehaviour
{
    public float speed;
    public float pullSpeed;
    public float divider;
    public GameObject start;
    public float calculatedSpeed;

    // Start is called before the first frame update
    void Start()
    {
        calculatedSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.Translate(Vector2.left * calculatedSpeed * Time.deltaTime);
            calculatedSpeed = speed - Vector3.Distance(start.transform.position, transform.position) / divider; // PEMDAS
        }

        transform.Translate(Vector2.right * pullSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
