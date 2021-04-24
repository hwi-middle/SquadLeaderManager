using System;
using System.Collections.Generic;

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
