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

                titleText.text = "�ȳ��ϼ���!";
                descriptionText.text = "���ݺ��� �ʱ� ������ �����ϰڽ��ϴ�.";
                positiveButtonText.text = "����";
                break;

            case 1:
                textInputField.gameObject.SetActive(true);
                negativeButton.gameObject.SetActive(true);

                textInputField.characterLimit = 4;
                textInputField.contentType = InputField.ContentType.Name;

                titleText.text = "������ �˷��ּ���.";
                descriptionText.text = "4���ڱ��� �Է��� �� �ֽ��ϴ�.";
                positiveButtonText.text = "Ȯ��";
                negativeButtonText.text = "�ڷ�";
                break;

            case 2:
                string name = textInputField.text;
                PlayerPrefs.SetString("UserName", name);
                if (name == "")
                {
                    titleText.text = "�ٽ� �Է����ּ���.";
                    descriptionText.text = "�̸��� ����� �� �����ϴ�.";
                    dialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);
                titleText.text = "Ȯ���ϰڽ��ϴ�.";
                descriptionText.text = name + " �д���� �����Ű���?";

                positiveButtonText.text = "��";
                negativeButtonText.text = "�ƴϿ�";
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

                titleText.text = "����� �˷��ּ���.";
                descriptionText.text = "�д���� ������ ����̿�!";
                positiveButtonText.text = "����";
                negativeButtonText.text = "�ڷ�";
                break;
            case 4:
                rankPanel.SetActive(false);
                titleText.text = "Ȯ���ϰڽ��ϴ�.";
                descriptionText.text = PlayerPrefs.GetString("UserName");
                switch (rank)
                {
                    case ERanks.Ilbyung:
                        descriptionText.text += " �Ϻ�";
                        break;

                    case ERanks.Sangbyung:
                        descriptionText.text += " ��";
                        break;

                    case ERanks.Byungjang:
                        descriptionText.text += " ����";
                        break;
                }
                descriptionText.text += "�� ��������?";
                positiveButtonText.text = "��";
                negativeButtonText.text = "�ƴϿ�";
                break;
            case 5:
                textInputField.gameObject.SetActive(true);

                textInputField.Select();
                textInputField.text = "";
                textInputField.characterLimit = 6;
                textInputField.contentType = InputField.ContentType.IntegerNumber;

                titleText.text = "�������� �˷��ּ���.";
                descriptionText.text = "YYMMDD ���·� �Է����ּ���.\n<size=40>��: 220321</size>";
                positiveButtonText.text = "Ȯ��";
                negativeButtonText.text = "�ڷ�";
                break;

            case 6:
                string input = textInputField.text;
                string parse = "20" + input.Substring(0, 2) + "-" + input.Substring(2, 2) + "-" + input.Substring(4, 2);
                Debug.Log(parse);
                PlayerPrefs.SetString("DDay", parse);
                //DateTime targetDay = DateTime.Parse(parse);
                DateTime targetDay;
                if(input == "")
                {
                    titleText.text = "�ٽ� �Է����ּ���.";
                    descriptionText.text = "�������� ����� �� �����ϴ�.";
                    dialogPage--;
                    break;
                }
                else if (!DateTime.TryParse(parse, out targetDay))
                {
                    titleText.text = "�ٽ� �Է����ּ���.";
                    descriptionText.text = "��¥�� ��ȿ���� �ʽ��ϴ�.\n<size=40>YYMMDD ���·� �Է����ּ���.\n��: 220321</size>";
                    dialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);

                titleText.text = "������ Ȯ���̿���!";
                descriptionText.text = "�������� " + targetDay.Year + "�� " + targetDay.Month + "�� " + targetDay.Day + "�� �³���?";
                positiveButtonText.text = "��";
                negativeButtonText.text = "�ƴϿ�";
                break;

            case 7:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
