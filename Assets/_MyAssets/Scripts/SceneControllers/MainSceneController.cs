using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public enum ECanvasType
{
    Home,
    Account,
    Queue,
    Settings
};

public class MainSceneController : MonoBehaviour
{
    public Canvas[] canvasArr = new Canvas[5];  //�ϴܹ� ������ ������� ����� �迭
    public GameObject[] iconArr = new GameObject[5];
    private int curIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
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
