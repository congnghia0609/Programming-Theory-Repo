using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnChangeNameInput(string newname)
    {
        newname = newname.TrimStart();
        username.text = newname;
    }

    public void PlayGame()
    {
        // SceneManager.LoadScene(SceneManager.GetSceneAt(1).name);
        SceneManager.LoadScene("scene");
    }
}
