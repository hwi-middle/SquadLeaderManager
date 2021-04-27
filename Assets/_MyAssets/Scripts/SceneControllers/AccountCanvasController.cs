using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public enum EAccountCanvasType
{
    ViewData,
    AddData,
    DeleteData
    //EditData
}

public class AccountCanvasController : MonoBehaviour
{
    #region Data_View
    public Canvas dataViewCanvas;
    public Canvas dataAddCanvas;
    public Canvas dataDeleteCanvas;

    public GameObject dataPrefab;
    public GameObject dataPrefabParent;
    public Text moneyText;
    public Text test;

    private List<AccountData> data = new List<AccountData>();
    #endregion
    #region Data_Add
    public GameObject incomeButton;
    public GameObject expenditureButton;

    public Sprite darkRect;
    public Sprite lightRect;

    public InputField exampleText;
    public Text errorText;
    public InputField dateInputField;
    public InputField amountInputField;
    public InputField memoInputField;

    private EAccountDataType curType = EAccountDataType.Income;
    #endregion
    #region Data_Delete
    public GameObject deleteButton;
    private List<GameObject> recentlyAdded = new List<GameObject>();
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //분지비 잔액 불러오기
        RefreshBalance();
        loadData();

        if (data.Count > 0)
        {
            deleteButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ScreenCapture.CaptureScreenshot("ScreenShot" + DateTime.Now.Second + DateTime.Now.Millisecond + ".png");
            Debug.Log("스크린샷저장");
        }
    }
#endif


    private void addDataOnScreen(AccountData data)
    {
        GameObject dataObject = Instantiate(dataPrefab);
        dataObject.transform.SetParent(dataPrefabParent.transform, false);
        dataObject.GetComponent<AccountDataObject>().SetData(data);
        recentlyAdded.Add(dataObject);
    }

    private void removeDataOnScreen()
    {
        if (recentlyAdded.Count != 0)
        {
            Destroy(recentlyAdded[recentlyAdded.Count - 1]);
            recentlyAdded.RemoveAt(recentlyAdded.Count - 1);
        }
    }

    private void activateCanvas(EAccountCanvasType type)
    {
        switch (type)
        {
            case EAccountCanvasType.AddData:
                dataViewCanvas.enabled = false;
                dataDeleteCanvas.enabled = false;
                dataAddCanvas.enabled = true;
                break;
            case EAccountCanvasType.DeleteData:
                dataViewCanvas.enabled = false;
                dataDeleteCanvas.enabled = true;
                dataAddCanvas.enabled = false;
                break;
            case EAccountCanvasType.ViewData:
                if (data.Count > 0)
                {
                    deleteButton.gameObject.SetActive(true);
                }
                else
                {
                    deleteButton.gameObject.SetActive(false);
                }
                RefreshBalance();
                dataViewCanvas.enabled = true;
                dataDeleteCanvas.enabled = false;
                dataAddCanvas.enabled = false;
                break;
        }
    }

    private void saveData()
    {
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/AccountData.json", jsonData);
    }

    private void loadData()
    {
        string path = Application.persistentDataPath + "/AccountData.json";
        FileInfo info = new FileInfo(path);

        if (!info.Exists)
        {
            File.Create(path).Close();
            saveData();
        }

        string jsonData = File.ReadAllText(path);
        data = JsonConvert.DeserializeObject<List<AccountData>>(jsonData);

        foreach (var item in data)
        {
            addDataOnScreen(item);
        }
    }

    public void OnDataAddBtnClick()
    {
        activateCanvas(EAccountCanvasType.AddData);
    }

    public void OnDataDeleteBtnClick()
    {
        activateCanvas(EAccountCanvasType.DeleteData);
    }

    public void OnIncomeBtnClick()
    {
        exampleText.placeholder.GetComponent<Text>().text = "예: 분지비 입금";
        curType = EAccountDataType.Income;
        incomeButton.transform.Find("Text").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f);
        incomeButton.GetComponent<Image>().sprite = darkRect;
        expenditureButton.transform.Find("Text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
        expenditureButton.GetComponent<Image>().sprite = lightRect;
    }

    public void OnExpenditureBtnClick()
    {
        exampleText.placeholder.GetComponent<Text>().text = "예: 김상병 고무링 구매";
        curType = EAccountDataType.Expenditure;
        expenditureButton.transform.Find("Text").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f);
        expenditureButton.GetComponent<Image>().sprite = darkRect;
        incomeButton.transform.Find("Text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
        incomeButton.GetComponent<Image>().sprite = lightRect;
    }

    public void OnDataAddConfirmBtnClick()
    {
        string date = dateInputField.text;
        string parse = "";
        DateTime targetDay;

        if (date == "")
        {
            errorText.text = "오류: 날짜 입력되지 않음";
            return;
        }
        else if (date.Length == 6)
        {
            parse = "20" + date.Substring(0, 2) + "-" + date.Substring(2, 2) + "-" + date.Substring(4, 2);
        }

        if (!DateTime.TryParse(parse, out targetDay))
        {
            errorText.text = "오류: 날짜 유효하지 않음";
            return;
        }


        string amount = amountInputField.text;
        if (amount == "")
        {
            errorText.text = "오류: 금액 입력되지 않음";
            return;
        }

        string memo = memoInputField.text;
        if (memo == "")
        {
            errorText.text = "오류: 내용 입력되지 않음";
            return;
        }

        string dateFormatted = date.Substring(0, 2) + "." + date.Substring(2, 2) + "." + date.Substring(4, 2);

        if (data.Count != 0 && CompareParsedDate(data[data.Count - 1].date, dateFormatted) > 0)
        {
            errorText.text = "오류: 가장 최근 기록보다 이전 날짜";
            return;
        }

        int amountInteger = int.Parse(amount);

        int balance;
        if (data.Count != 0)
        {
            if (curType == EAccountDataType.Expenditure)
            {
                balance = data[data.Count - 1].balance - amountInteger;
            }
            else
            {
                balance = data[data.Count - 1].balance + amountInteger;
            }
        }
        else
        {
            balance = amountInteger;
        }

        PlayerPrefs.SetInt("Money", balance);
        AccountData newData = new AccountData(dateFormatted, curType, amountInteger, balance, memo);
        data.Add(newData);
        addDataOnScreen(newData);
        saveData();
        ResetDataAddCanvas();
        activateCanvas(EAccountCanvasType.ViewData);
    }

    public void OnDataAddCancelBtnClick()
    {
        ResetDataAddCanvas();
        activateCanvas(EAccountCanvasType.ViewData);
    }

    public void OnDataDeleteConfirmBtnClick()
    {
        if (data.Count != 0)
        {
            int balance = PlayerPrefs.GetInt("Money");
            EAccountDataType type = data[data.Count - 1].type;

            switch (type)
            {
                case EAccountDataType.Expenditure:
                    balance += data[data.Count - 1].amount;
                    break;

                case EAccountDataType.Income:
                    balance -= data[data.Count - 1].amount;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
            PlayerPrefs.SetInt("Money", balance);
            data.RemoveAt(data.Count - 1);
            removeDataOnScreen();
            saveData();
        }
        activateCanvas(EAccountCanvasType.ViewData);
    }

    public void OnDataDeleteCancelBtnClick()
    {
        activateCanvas(EAccountCanvasType.ViewData);
    }

    private void ResetDataAddCanvas()
    {
        amountInputField.text = "";
        dateInputField.text = "";
        memoInputField.text = "";
        errorText.text = "";
        OnIncomeBtnClick();
    }

    private void RefreshBalance()
    {
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "원";
    }

    private int CompareParsedDate(string t1, string t2)
    {
        int t1Year = int.Parse(t1.Substring(0, 2)) * 10000;
        int t1Month = int.Parse(t1.Substring(3, 2)) * 100;
        int t1Day = int.Parse(t1.Substring(6, 2));
        int t1Date = t1Year + t1Month + t1Day;

        int t2Year = int.Parse(t2.Substring(0, 2)) * 10000; ;
        int t2Month = int.Parse(t2.Substring(3, 2)) * 100; ;
        int t2Day = int.Parse(t2.Substring(6, 2));
        int t2Date = t2Year + t2Month + t2Day;

        return t1Date - t2Date;
    }
}
