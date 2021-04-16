using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
