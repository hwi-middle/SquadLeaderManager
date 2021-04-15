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

                TitleText.text = "안녕하세요!";
                DescriptionText.text = "지금부터 초기 설정을 시작하겠습니다.";
                PositiveButtonText.text = "다음";
                break;
            case 1:
                TextInputField.gameObject.SetActive(true);
                NegativeButton.gameObject.SetActive(true);

                TitleText.text = "성함을 알려주세요.";
                DescriptionText.text = "4글자까지 입력할 수 있습니다.";
                PositiveButtonText.text = "확인";
                NegativeButtonText.text = "뒤로";
                break;
            case 2:
                string name = TextInputField.text;
                PlayerPrefs.SetString("UserName", name);
                if (name == "")
                {
                    TitleText.text = "다시 입력해주세요.";
                    DescriptionText.text = "이름은 비워둘 수 없습니다.";
                    DialogPage--;
                    break;
                }

                TextInputField.gameObject.SetActive(false);
                TitleText.text = "확인하겠습니다.";
                DescriptionText.text = name + " 분대장님 맞으신가요?";

                PositiveButtonText.text = "예";
                NegativeButtonText.text = "아니오";
                break;
            case 3:
                TitleText.text = "전역일을 알려주세요.";
                DescriptionText.text = "디데이 세드리려고 합니다 ;)";
                PositiveButtonText.text = "언제냐면..";
                NegativeButtonText.text = "뒤로";
                break;
        }
    }
}
