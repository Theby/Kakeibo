using System;

public class IncomeData
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public CurrencyData Currency { get; set; }
    public string Description { get; set; }

    IncomeSQLData _sqlData;

    public IncomeData()
    {
        _sqlData = null;
    }

    public IncomeData(IncomeSQLData sqlData)
    {
        _sqlData = sqlData;

        Date = new DateTime(_sqlData.Date);
        Amount = _sqlData.Amount;
        Currency = GameManager.KakeiboManager.GetCurrencyById(_sqlData.CurrencyId);
        Description = _sqlData.Description;
    }

    public IncomeSQLData ToSQLData()
    {
        IncomeSQLData incomeSQLData = new IncomeSQLData();
        if (_sqlData != null)
        {
            incomeSQLData = _sqlData;
        }

        incomeSQLData.Date = Date.Ticks;
        incomeSQLData.Amount = Amount;
        incomeSQLData.CurrencyId = Currency.SQLId;
        incomeSQLData.Description = Description;

        return incomeSQLData;
    }
}
