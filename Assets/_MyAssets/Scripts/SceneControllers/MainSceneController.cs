using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public Canvas[] canvasArr = new Canvas[5];  //�ϴܹ� ������ ������� ����� �迭
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
        //���� �̸� �ҷ�����
        nameText.text = PlayerPrefs.GetString("UserName");

        //���� �ҷ�����
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

        //������ �ҷ�����
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "��";

        //��ǰ���� ����ο� �ҷ�����
        queueText.text = PlayerPrefs.GetInt("Queue").ToString();
        queueText.text += "��";

        //�д� �ѿ� �ҷ�����
        squadText.text = PlayerPrefs.GetInt("Squad").ToString();
        squadText.text += "��";
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
