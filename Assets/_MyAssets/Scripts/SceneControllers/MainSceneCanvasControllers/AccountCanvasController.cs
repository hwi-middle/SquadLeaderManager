using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public enum EAccountDataType
{
    Income,
    Expenditure
}

public class AccountData
{
    public string date;
    public EAccountDataType type;
    public int amount;
    public int balance;
    public string memo;

    public AccountData(string date, EAccountDataType type, int amount, int balance, string memo)
    {
        this.date = date;
        this.type = type;
        this.amount = amount;
        this.balance = balance;
        this.memo = memo;
    }
}

public class AccountCanvasController : MonoBehaviour
{

    public Text moneyText;
    public Text test;

    private List<AccountData> data = new List<AccountData>();

    // Start is called before the first frame update
    void Start()
    {
        
        data.Add(new AccountData("201213", EAccountDataType.Income, 10000, 43000, "������1"));
        data.Add(new AccountData("210125", EAccountDataType.Income, 10000, 33000, "������2"));
        data.Add(new AccountData("210127", EAccountDataType.Income, 3000, 30000, "������3"));
        
        saveData();
        loadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //������ �ҷ�����
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "��";
    }

    private void saveData()
    {
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.persistentDataPath + "/AccountData.json", jsonData);
    }

    private void loadData()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/AccountData.json");
        test.text = jsonData;

        data = JsonConvert.DeserializeObject<List<AccountData>>(jsonData);
        Debug.Log(data[0].date);
        Debug.Log(Application.persistentDataPath);
    }


}
