using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.5f;
    private float xRange = 1.5f;
    private float zRange = 20.0f;
    [SerializeField] public GameObject droplet;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeOutText;
    public Button restartButton;
    private int timeRemain = 60;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame()
    {
        isGameActive = true;
        timeOutText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnDroplet());
        UpdateTimer();
        StartCoroutine(CountdownTimer());
    }

    // While game is active spawn a random target
    IEnumerator SpawnDroplet()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            if (isGameActive)
            {
                GenDroplet();
            }
        }
    }

    void GenDroplet()
    {
        float x = Random.Range(-xRange, xRange);
        float z = Random.Range(-zRange, zRange);
        GameObject ball = Instantiate(droplet, new Vector3(x, 20.0f, z), droplet.transform.rotation);
        // Để bóng không bay xuyên qua thùng khi di chuyển qua trái qua phải.
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        ballRb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    IEnumerator CountdownTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1.0f);
            if (isGameActive && timeRemain > 0)
            {
                timeRemain--;
                UpdateTimer();
            }
            else
            {
                GameOver();
            }
        }
    }
    
    public void UpdateTimer()
    {
        timerText.text = "Time: " + timeRemain;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        timeOutText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
