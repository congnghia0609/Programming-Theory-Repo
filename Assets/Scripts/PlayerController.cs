using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float zRange = 22.0f;
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private float horizontalInput;
    private Rigidbody boxRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            // transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
            boxRb.MovePosition(boxRb.position + Vector3.forward * horizontalInput * Time.deltaTime * speed);
            if (transform.position.z < -zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            }
            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }
        }
    }
}
