using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnManager : MonoBehaviour
{
    private float xRange = 1.5f;
    private float zRange = 20.0f;
    [SerializeField] public List<GameObject> droplets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenDroplet", 0.0f, 0.5f);
    }

    void GenDroplet()
    {
        float x = Random.Range(-xRange, xRange);
        float z = Random.Range(-zRange, zRange);
        int index = Random.Range(0, droplets.Count);
        GameObject ball = Instantiate(droplets[index], new Vector3(x, 20.0f, z), droplets[index].transform.rotation);
        // Để bóng không bay xuyên qua thùng khi di chuyển qua trái qua phải.
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        ballRb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
