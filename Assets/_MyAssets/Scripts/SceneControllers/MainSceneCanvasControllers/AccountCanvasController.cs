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
    public Canvas[] canvasArr;
    public GameObject dataPrefab;
    public GameObject dataPrefabParent;
    public Text moneyText;
    public Text test;

    private List<AccountData> data = new List<AccountData>();
    private EAccountCanvasType curType = EAccountCanvasType.ViewData;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(dataPrefab);

        //data.Add(new AccountData("201213", EAccountDataType.Income, 10000, 43000, "가나다1"));
        //data.Add(new AccountData("210125", EAccountDataType.Income, 10000, 33000, "가나다2"));
        //data.Add(new AccountData("210127", EAccountDataType.Income, 3000, 30000, "가나다3"));

        //saveData();
        //loadData();
        addData(new AccountData("201213", EAccountDataType.Expenditure, 10000, 43000, "가나다1"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void addData(AccountData data)
    {
        GameObject dataObject = Instantiate(dataPrefab);
        dataObject.transform.SetParent(dataPrefabParent.transform, false);
        dataObject.GetComponent<AccountDataObject>().SetData(data);
    }

    private void OnEnable()
    {
        //분지비 잔액 불러오기
        moneyText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Money"));
        moneyText.text += "원";
    }

    private void activateCanvas(EAccountCanvasType type)
    {
        canvasArr[(int)curType].gameObject.SetActive(false);
        canvasArr[(int)type].gameObject.SetActive(true);
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
            Debug.Log("Write File");
            File.Create(path).Close();
        }

        string jsonData = File.ReadAllText(path);
        //test.text = jsonData;

        data = JsonConvert.DeserializeObject<List<AccountData>>(jsonData);
    }
}
