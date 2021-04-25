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
    private Canvas dataViewCanvas;
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

    public Text exampleText;
    public Text errorText;
    public InputField dateInputField;
    public InputField amountInputField;
    public InputField memoInputField;

    private EAccountDataType type = EAccountDataType.Income;
    #endregion
    #region Data_Delete
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        dataViewCanvas = GetComponent<Canvas>();

        //분지비 잔액 불러오기

        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "원";
        /*
        data.Add(new AccountData("20.12.13", EAccountDataType.Income, 10000, 43000, "가나다1"));
        data.Add(new AccountData("21.01.25", EAccountDataType.Income, 10000, 33000, "가나다2"));
        data.Add(new AccountData("21.01.27", EAccountDataType.Expenditure, 3000, 30000, "가나다3"));

        saveData();
        */
        loadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void addDataOnScreen(AccountData data)
    {
        GameObject dataObject = Instantiate(dataPrefab);
        dataObject.transform.SetParent(dataPrefabParent.transform, false);
        dataObject.GetComponent<AccountDataObject>().SetData(data);
    }

    private void OnEnable()
    {

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
        exampleText.text = "예: 분지비 입금";
        type = EAccountDataType.Income;
        incomeButton.transform.Find("Text").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f);
        incomeButton.GetComponent<Image>().sprite = darkRect;
        expenditureButton.transform.Find("Text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
        expenditureButton.GetComponent<Image>().sprite = lightRect;
    }

    public void OnExpenditureBtnClick()
    {
        exampleText.text = "예: 김상병 고무링 구매";
        type = EAccountDataType.Expenditure;
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
        int amountInteger = int.Parse(amount);
        int balance;
        if (data.Count != 0)
        {
            balance = data[data.Count - 1].balance - int.Parse(amount);
        }
        else
        {
            balance = amountInteger;
            if (type == EAccountDataType.Expenditure) balance *= -1;
        }

        AccountData newData = new AccountData(dateFormatted, type, amountInteger, balance, memo);
        data.Add(newData);
        addDataOnScreen(newData);
        saveData();
        ResetInputFields();
        activateCanvas(EAccountCanvasType.ViewData);
    }

    public void OnDataAddCancelBtnClick()
    {
        ResetInputFields();
        //activateCanvas(EAccountCanvasType.ViewData);
    }

    private void ResetInputFields()
    {
        amountInputField.Select();
        amountInputField.text = "";

        /*
        dateInputField.Select();
        dateInputField.text = "";

        memoInputField.Select();
        memoInputField.text = "";
        */
    }
}
