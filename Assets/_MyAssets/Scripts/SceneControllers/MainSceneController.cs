using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public Canvas[] canvasArr = new Canvas[5];  //하단바 아이콘 순서대로 저장된 배열
    public GameObject[] iconArr = new GameObject[5];
    private int curIdx = 0;

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

    public void OnBottomBarBtnClick(int newIdx)
    {
        if (curIdx == newIdx)
        {
            ScrollRect scrollRect = canvasArr[curIdx].transform.Find("Main Scroll View").GetComponent<ScrollRect>();
            scrollRect.normalizedPosition = new Vector2(0, 1);
        }
        else
        {
            canvasArr[curIdx].gameObject.SetActive(false);
            canvasArr[newIdx].gameObject.SetActive(true);
            curIdx = newIdx;
        }
    }
}
