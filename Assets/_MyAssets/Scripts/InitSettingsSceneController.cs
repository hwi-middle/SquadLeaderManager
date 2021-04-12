using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitSettingsSceneController : MonoBehaviour
{
    public Text TitleText;
    public Text DescriptionText;
    public Text TempRank;
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
                TempRank.gameObject.SetActive(false);

                TitleText.text = "�漺!";
                DescriptionText.text = "���ݺ��� �ʱ� ������ �����ϰڽ��ϴ�.";
                PositiveButtonText.text = "��, �׷�.";
                break;
            case 1:
                TextInputField.gameObject.SetActive(true);
                NegativeButton.gameObject.SetActive(true);
                TempRank.gameObject.SetActive(true);

                TitleText.text = "����� ������� �ǰڽ��ϱ�?";
                DescriptionText.text = "�Ʒ� â�� �Է����ֽʼ�.";
                PositiveButtonText.text = "����";
                NegativeButtonText.text = "�λ� �ٽ��غ�";
                break;
            case 2:
                string name = TextInputField.text;
                if (name == "")
                {
                    TitleText.text = "�� �� ������ϴ�?";
                    DescriptionText.text = "��, ���� �Է�ĭ ���ø� �ȵ˴ϴ�.";
                    DialogPage--;
                    break;
                }

                TempRank.gameObject.SetActive(false);
                TextInputField.gameObject.SetActive(false);
                TitleText.text = "Ȯ���ϰڽ��ϴ�.";
                DescriptionText.text = name + " �д���� �����ʴϱ�?";

                PositiveButtonText.text = "�� �¾�";
                NegativeButtonText.text = "�ƴ�";
                break;
            case 3:
                TitleText.text = "������ �����ʴϱ�?";
                DescriptionText.text = "���� ���帮���� �մϴ�. ������ ������� �ǰڽ��ϱ�?";
                PositiveButtonText.text = "�����ĸ�..";
                NegativeButtonText.text = "�̸� �� �� ���ߴ�";
                break;
        }
    }
}
