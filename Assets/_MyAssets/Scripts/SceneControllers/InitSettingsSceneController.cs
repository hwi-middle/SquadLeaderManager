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

    private int DialogPage = 0;

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
                textInputField.gameObject.SetActive(false);
                negativeButton.gameObject.SetActive(false);

                titleText.text = "�ȳ��ϼ���!";
                descriptionText.text = "���ݺ��� �ʱ� ������ �����ϰڽ��ϴ�.";
                positiveButtonText.text = "����";
                break;
            case 1:
                textInputField.gameObject.SetActive(true);
                negativeButton.gameObject.SetActive(true);

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
                    DialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);
                titleText.text = "Ȯ���ϰڽ��ϴ�.";
                descriptionText.text = name + " �д���� �����Ű���?";

                positiveButtonText.text = "��";
                negativeButtonText.text = "�ƴϿ�";
                break;
            case 3:
                titleText.text = "�������� �˷��ּ���.";
                descriptionText.text = "���� ���帮���� �մϴ� ;)";
                positiveButtonText.text = "�����ĸ�..";
                negativeButtonText.text = "�ڷ�";
                break;
            case 4:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
