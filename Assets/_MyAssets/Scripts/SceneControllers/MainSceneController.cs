using System;
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
    public Text dDayText;
    public Text moneyText;
    public Text queueText;
    public Text squadText;

    // Start is called before the first frame update
    void Start()
    {
        //유저 이름 불러오기
        nameText.text = PlayerPrefs.GetString("UserName");

        //디데이 불러오기
        DateTime targetDay = DateTime.Parse(PlayerPrefs.GetString("DDay"));
        int totalDays = (int)((targetDay - DateTime.Today).TotalDays);
        if(totalDays>0)
        {
            dDayText.text = "D-" + totalDays.ToString();
        }
        else if (totalDays < 0)
        {
            dDayText.text = "D+" + (-totalDays).ToString();
        }
        else
        {
            dDayText.text = "D-Day";
        }

        //분지비 불러오기
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "원";

        //물품구매 희망인원 불러오기
        queueText.text = PlayerPrefs.GetInt("Queue").ToString();
        queueText.text += "명";

        //분대 총원 불러오기
        squadText.text = PlayerPrefs.GetInt("Squad").ToString();
        squadText.text += "명";
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
