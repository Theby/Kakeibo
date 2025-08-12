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
        _sqlData = new IncomeSQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Date.Ticks,
            Date.Year,
            Amount,
            Currency.SQLId,
            Description
        );

        return _sqlData;
    }
}
