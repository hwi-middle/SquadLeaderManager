using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveToMainScene", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveToMainScene()
    {
        if (PlayerPrefs.GetInt("SettingsCompleted") == 0)
        {
            SceneManager.LoadScene("InitialSettings");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}