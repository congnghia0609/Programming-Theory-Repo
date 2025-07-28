using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    private int Count = 0;
    private Collider boxCollider; // Collider của thùng
    // private List<GameObject> ballsInside = new List<GameObject>();
    private Rigidbody boxRb;
    private String tagBall = "Ball";
    private GameManager gameManager;

    private void Start()
    {
        Count = 0;
        boxCollider = GetComponent<Collider>();
        boxRb = GetComponent<Rigidbody>();
        // Điều này nghĩa là thùng có collider để va chạm, nhưng không chịu tác động của vật lý.
        boxRb.isKinematic = true;
        // Để bóng không bay xuyên qua thùng khi di chuyển qua trái qua phải.
        boxRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        //==> Tăng tần suất physics bằng cách chỉnh:
        // Edit > Project Settings > Time > Fixed Timestep → từ 0.02 → xuống 0.01 (hoặc thấp hơn)
        // Càng thấp thì càng tốn CPU → dùng hợp lý.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive && other.CompareTag(tagBall))
        {
            // Vector3 ballPos = other.transform.position;
            // // Kiểm tra tâm (center) của quả bóng có nằm bên trong bounds của thùng hay không.
            // if (IsPointInsideBox(boxCollider, ballPos))
            // {
            //     ballsInside.Add(other.gameObject);
            // }
            CountBall();
            UpdateCounter();
        }
    }

    void CountBall()
    {
        // ballsInside.Clear();
        int counter = 0;
        // Tất cả các quả bóng có tag "Ball"
        GameObject[] balls = GameObject.FindGameObjectsWithTag(tagBall);
        foreach (GameObject ball in balls)
        {
            Vector3 ballPos = ball.transform.position;
            // Kiểm tra tâm (center) của quả bóng có nằm bên trong bounds của thùng hay không.
            if (IsPointInsideBox(boxCollider, ballPos))
            {
                // ballsInside.Add(ball);
                counter++;
                // Đảm bảo bóng nằm trong thùng.
                // ball.transform.SetParent(transform);
                // // Để bóng không bay xuyên qua thùng khi di chuyển qua trái qua phải.
                // Rigidbody ballRb = ball.GetComponent<Rigidbody>();
                // ballRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                // ballRb.interpolation = RigidbodyInterpolation.Interpolate;
            }
        }
        Count = counter;
    }

    // Kiểm tra tâm (center) của quả bóng có nằm bên trong bounds của thùng hay không.
    bool IsPointInsideBox(Collider box, Vector3 point)
    {
        // Nếu là BoxCollider
        if (box is BoxCollider boxCol)
        {
            // local point
            Vector3 localPoint = box.transform.InverseTransformPoint(point) - boxCol.center;
            Vector3 halfSize = boxCol.size * 0.5f;
            return Mathf.Abs(localPoint.x) <= halfSize.x &&
                   Mathf.Abs(localPoint.y) <= halfSize.y &&
                   Mathf.Abs(localPoint.z) <= halfSize.z;
        }
        // Nếu là MeshCollider có thể khác, cần kiểm tra phức tạp hơn.
        return false;
    }

    void UpdateCounter()
    {
        // Count = ballsInside.Count;
        CounterText.text = "Count : " + Count;
    }

    void OnTriggerExit(Collider other)
    {
        if (gameManager.isGameActive && other.CompareTag(tagBall))
        {
            // ballsInside.Remove(other.gameObject);
            CountBall();
            UpdateCounter();
        }
    }
}
