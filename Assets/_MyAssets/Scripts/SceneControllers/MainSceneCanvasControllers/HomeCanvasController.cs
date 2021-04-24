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
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "��";

        //�д� �ѿ� �ҷ�����
        squadText.text = PlayerPrefs.GetInt("Squad").ToString();
        squadText.text += "��";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
