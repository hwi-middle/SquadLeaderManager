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

                TitleText.text = "충성!";
                DescriptionText.text = "지금부터 초기 설정을 시작하겠습니다.";
                PositiveButtonText.text = "어, 그래.";
                break;
            case 1:
                TextInputField.gameObject.SetActive(true);
                NegativeButton.gameObject.SetActive(true);
                TempRank.gameObject.SetActive(true);

                TitleText.text = "관등성명 여쭤봐도 되겠습니까?";
                DescriptionText.text = "아래 창에 입력해주십쇼.";
                PositiveButtonText.text = "여기";
                NegativeButtonText.text = "인사 다시해봐";
                break;
            case 2:
                string name = TextInputField.text;
                if (name == "")
                {
                    TitleText.text = "잘 못 들었습니다?";
                    DescriptionText.text = "어, 여기 입력칸 비우시면 안됩니다.";
                    DialogPage--;
                    break;
                }

                TempRank.gameObject.SetActive(false);
                TextInputField.gameObject.SetActive(false);
                TitleText.text = "확인하겠습니다.";
                DescriptionText.text = name + " 분대장님 맞으십니까?";

                PositiveButtonText.text = "어 맞아";
                NegativeButtonText.text = "아니";
                break;
            case 3:
                TitleText.text = "전역일 언제십니까?";
                DescriptionText.text = "디데이 세드리려고 합니다. 전역일 여쭤봐도 되겠습니까?";
                PositiveButtonText.text = "언제냐면..";
                NegativeButtonText.text = "이름 잘 못 말했다";
                break;
        }
    }
}
