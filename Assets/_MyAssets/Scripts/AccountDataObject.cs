using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountDataObject : MonoBehaviour
{
    public Text dateText;
    public Text memoText;
    public Text amountText;
    public Text balanceText;

    public Font boldFont;
    public Font lightFont;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetData(AccountData data)
    {
        dateText.text = data.date;
        memoText.text = data.memo;

        switch (data.type)
        {
            case EAccountDataType.Income:
                amountText.font = boldFont;
                amountText.text = "+" + data.amount.ToString() + "¿ø";
                break;
            case EAccountDataType.Expenditure:
                amountText.font = lightFont;
                amountText.text = "<color=#ff0000>-" + data.amount.ToString() + "¿ø</color>";
                break;
        }
        balanceText.text = data.balance.ToString() + "¿ø";
    }
}
