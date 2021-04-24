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
    public Text queueText;
    public Text squadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        nameText.text = PlayerPrefs.GetString("UserName");

        //디데이 불러오기
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
}
