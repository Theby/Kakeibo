using System;

public class ExpenseData
{
    public DateTime Date { get; set; }
    public DateTime BillingDate { get; set; }
    public TypeData Type { get; set; }
    public CategoryData Category { get; set; }
    public decimal Amount { get; set; }
    public CurrencyData Currency { get; set; }
    public string Description { get; set; }
    public bool Paid { get; set; }

    ExpenseSQLData _sqlData;

    public ExpenseData()
    {
        _sqlData = null;
    }

    public ExpenseData(ExpenseSQLData sqlData)
    {
        _sqlData = sqlData;

        Date = new DateTime(_sqlData.Date);
        BillingDate = new DateTime(_sqlData.BillingYear, _sqlData.BillingMonth, 1);
        Type = GameManager.KakeiboManager.GetTypeById(_sqlData.TypeId);
        Category = GameManager.KakeiboManager.GetCategoryById(_sqlData.CategoryId);
        Amount = _sqlData.Amount;
        Currency = GameManager.KakeiboManager.GetCurrencyById(_sqlData.CurrencyId);
        Description = _sqlData.Description;
        Paid = _sqlData.Paid;
    }

    public ExpenseSQLData ToSQLData()
    {
        _sqlData = new ExpenseSQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Date.Ticks,
            Date.Year,
            Date.Month,
            BillingDate.Year,
            BillingDate.Month,
            Type.SQLId,
            Category.SQLId,
            Amount,
            Currency.SQLId,
            Description,
            Paid
        );

        return _sqlData;
    }
}