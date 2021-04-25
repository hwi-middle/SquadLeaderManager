using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvasController : MonoBehaviour
{
    public Text nameText;
    public Text dDayText;
    public Text moneyText;
    public Text squadText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = PlayerPrefs.GetString("UserName");

        //���� �ҷ�����
        DateTime targetDay = DateTime.Parse(PlayerPrefs.GetString("DDay"));
        int totalDays = (int)((targetDay - DateTime.Today).TotalDays);
        if (totalDays > 0)
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
        RefreshBalance();

        //�д� �ѿ� �ҷ�����
        squadText.text = PlayerPrefs.GetInt("Squad").ToString();
        squadText.text += "��";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshBalance()
    {
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "��";
    }

    public void OnNarasarangBtnClick()
    {
        Application.OpenURL("http://www.narasarang.or.kr/");
    }

    public void OnHelpCallBtnClick()
    {
        Application.OpenURL("tel:1303");
    }

    public void OnCovidBtnClick()
    {
        Application.OpenURL("https://www.korea.kr/news/visualNewsView.do?newsId=148870359");
    }
}
