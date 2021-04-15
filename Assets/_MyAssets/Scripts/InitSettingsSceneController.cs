using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitSettingsSceneController : MonoBehaviour
{
    public Text TitleText;
    public Text DescriptionText;
    public InputField TextInputField;
    public Button PositiveButton;
    public Button NegativeButton;
    private Text PositiveButtonText;
    private Text NegativeButtonText;

    private int DialogPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        PositiveButtonText = PositiveButton.transform.GetChild(0).GetComponent<Text>();
        NegativeButtonText = NegativeButton.transform.GetChild(0).GetComponent<Text>();
        SetTitleAndDescriptionText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPositiveButtonClick()
    {
        DialogPage++;
        SetTitleAndDescriptionText();
    }

    public void OnNegativeButtonClick()
    {
        DialogPage--;
        SetTitleAndDescriptionText();
    }

    private void SetTitleAndDescriptionText()
    {
        switch (DialogPage)
        {
            case 0:
                TextInputField.gameObject.SetActive(false);
                NegativeButton.gameObject.SetActive(false);

                TitleText.text = "�ȳ��ϼ���!";
                DescriptionText.text = "���ݺ��� �ʱ� ������ �����ϰڽ��ϴ�.";
                PositiveButtonText.text = "����";
                break;
            case 1:
                TextInputField.gameObject.SetActive(true);
                NegativeButton.gameObject.SetActive(true);

                TitleText.text = "������ �˷��ּ���.";
                DescriptionText.text = "4���ڱ��� �Է��� �� �ֽ��ϴ�.";
                PositiveButtonText.text = "Ȯ��";
                NegativeButtonText.text = "�ڷ�";
                break;
            case 2:
                string name = TextInputField.text;
                PlayerPrefs.SetString("UserName", name);
                if (name == "")
                {
                    TitleText.text = "�ٽ� �Է����ּ���.";
                    DescriptionText.text = "�̸��� ����� �� �����ϴ�.";
                    DialogPage--;
                    break;
                }

                TextInputField.gameObject.SetActive(false);
                TitleText.text = "Ȯ���ϰڽ��ϴ�.";
                DescriptionText.text = name + " �д���� �����Ű���?";

                PositiveButtonText.text = "��";
                NegativeButtonText.text = "�ƴϿ�";
                break;
            case 3:
                TitleText.text = "�������� �˷��ּ���.";
                DescriptionText.text = "���� ���帮���� �մϴ� ;)";
                PositiveButtonText.text = "�����ĸ�..";
                NegativeButtonText.text = "�ڷ�";
                break;
        }
    }
}
