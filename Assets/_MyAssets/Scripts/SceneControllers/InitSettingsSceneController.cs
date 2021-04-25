using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitSettingsSceneController : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public InputField textInputField;
    public Button positiveButton;
    public Button negativeButton;
    private Text positiveButtonText;
    private Text negativeButtonText;
    public GameObject rankPanel;
    public Image[] rankBars;

    private string userName = "";
 
    private int dialogPage = 0;
    private ERanks rank = ERanks.Ilbyung;

    // Start is called before the first frame update
    void Start()
    {
        positiveButtonText = positiveButton.transform.GetChild(0).GetComponent<Text>();
        negativeButtonText = negativeButton.transform.GetChild(0).GetComponent<Text>();
        SetTitleAndDescriptionText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPositiveButtonClick()
    {
        dialogPage++;
        SetTitleAndDescriptionText();
    }

    public void OnNegativeButtonClick()
    {
        dialogPage--;
        SetTitleAndDescriptionText();
    }

    public void OnIncreaseRankClick()
    {
        rank++;
        SetTitleAndDescriptionText();
    }
    public void OnDecreaseRankClick()
    {
        rank--;
        SetTitleAndDescriptionText();
    }

    private void SetTitleAndDescriptionText()
    {
        switch (dialogPage)
        {
            case 0:
                textInputField.gameObject.SetActive(false);
                negativeButton.gameObject.SetActive(false);

                titleText.text = "안녕하세요!";
                descriptionText.text = "지금부터 초기 설정을 시작하겠습니다.";
                positiveButtonText.text = "다음";
                break;

            case 1:
                textInputField.gameObject.SetActive(true);
                negativeButton.gameObject.SetActive(true);

                textInputField.characterLimit = 4;
                textInputField.contentType = InputField.ContentType.Name;

                titleText.text = "성함을 알려주세요.";
                descriptionText.text = "4글자까지 입력할 수 있습니다.";
                positiveButtonText.text = "확인";
                negativeButtonText.text = "뒤로";
                break;

            case 2:
                rankPanel.SetActive(false);
                userName = textInputField.text;
                if (userName == "")
                {
                    titleText.text = "다시 입력해주세요.";
                    descriptionText.text = "이름은 비워둘 수 없습니다.";
                    dialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);
                titleText.text = "확인하겠습니다.";
                descriptionText.text = userName + " 분대장님 맞으신가요?";

                positiveButtonText.text = "예";
                negativeButtonText.text = "아니오";
                break;

            case 3:
                switch (rank)
                {
                    case ERanks.Ilbyung:
                        rankBars[0].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[1].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[2].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
                        rankBars[3].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
                        break;

                    case ERanks.Sangbyung:
                        rankBars[0].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[1].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[2].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[3].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
                        break;

                    case ERanks.Byungjang:
                        rankBars[0].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[1].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[2].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        rankBars[3].color = new Color(0.25f, 0.25f, 0.25f, 1.0f);
                        break;

                    default:
                        if (rank < ERanks.Ilbyung)
                        {
                            rank++;
                            break;
                        }
                        else
                        {
                            rank--;
                            break;
                        }
                }

                rankPanel.SetActive(true);

                titleText.text = "계급을 알려주세요.";
                descriptionText.text = "분대장님 본인의 계급이요!";
                positiveButtonText.text = "선택";
                negativeButtonText.text = "뒤로";
                break;
            case 4:
                rankPanel.SetActive(false);
                titleText.text = "확인하겠습니다.";
                descriptionText.text = userName;
                switch (rank)
                {
                    case ERanks.Ilbyung:
                        descriptionText.text += " 일병";
                        break;

                    case ERanks.Sangbyung:
                        descriptionText.text += " 상병";
                        break;

                    case ERanks.Byungjang:
                        descriptionText.text += " 병장";
                        break;
                }
                descriptionText.text += "님 맞으시죠?";
                positiveButtonText.text = "예";
                negativeButtonText.text = "아니오";
                break;
            case 5:
                textInputField.gameObject.SetActive(true);

                textInputField.Select();
                textInputField.text = "";
                textInputField.characterLimit = 6;
                textInputField.contentType = InputField.ContentType.IntegerNumber;

                titleText.text = "전역일을 알려주세요.";
                descriptionText.text = "YYMMDD 형태로 입력해주세요.\n<size=40>예: 220321</size>";
                positiveButtonText.text = "확인";
                negativeButtonText.text = "뒤로";
                break;

            case 6:
                string input = textInputField.text;
                string parse = "";

                DateTime targetDay;
                if (input == "")
                {
                    titleText.text = "다시 입력해주세요.";
                    descriptionText.text = "전역일은 비워둘 수 없습니다.";
                    dialogPage--;
                    break;
                }
                else if (input.Length == 6)
                {
                    parse = "20" + input.Substring(0, 2) + "-" + input.Substring(2, 2) + "-" + input.Substring(4, 2);
                }

                if (!DateTime.TryParse(parse, out targetDay))
                {
                    titleText.text = "다시 입력해주세요.";
                    descriptionText.text = "날짜가 유효하지 않습니다.\n<size=40>YYMMDD 형태로 입력해주세요.\n예: 220321</size>";
                    dialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);
                PlayerPrefs.SetString("DDay", parse);

                titleText.text = "마지막 확인이에요!";
                descriptionText.text = "전역일이 " + targetDay.Year + "년 " + targetDay.Month + "월 " + targetDay.Day + "일 맞나요?";
                positiveButtonText.text = "예";
                negativeButtonText.text = "아니오";
                break;

            case 7:
                PlayerPrefs.SetString("UserName", userName);
                PlayerPrefs.SetInt("SettingsCompleted", 1);
                PlayerPrefs.SetInt("Squad", 1);
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
