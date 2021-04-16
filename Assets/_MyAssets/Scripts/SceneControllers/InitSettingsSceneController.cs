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

                titleText.text = "안녕하세요!";
                descriptionText.text = "지금부터 초기 설정을 시작하겠습니다.";
                positiveButtonText.text = "다음";
                break;
            case 1:
                textInputField.gameObject.SetActive(true);
                negativeButton.gameObject.SetActive(true);

                titleText.text = "성함을 알려주세요.";
                descriptionText.text = "4글자까지 입력할 수 있습니다.";
                positiveButtonText.text = "확인";
                negativeButtonText.text = "뒤로";
                break;
            case 2:
                string name = textInputField.text;
                PlayerPrefs.SetString("UserName", name);
                if (name == "")
                {
                    titleText.text = "다시 입력해주세요.";
                    descriptionText.text = "이름은 비워둘 수 없습니다.";
                    DialogPage--;
                    break;
                }

                textInputField.gameObject.SetActive(false);
                titleText.text = "확인하겠습니다.";
                descriptionText.text = name + " 분대장님 맞으신가요?";

                positiveButtonText.text = "예";
                negativeButtonText.text = "아니오";
                break;
            case 3:
                titleText.text = "전역일을 알려주세요.";
                descriptionText.text = "디데이 세드리려고 합니다 ;)";
                positiveButtonText.text = "언제냐면..";
                negativeButtonText.text = "뒤로";
                break;
            case 4:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
