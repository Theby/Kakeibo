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
        ExpenseSQLData expenseSQLData = new ExpenseSQLData();
        if (_sqlData != null)
        {
            expenseSQLData = _sqlData;
        }

        expenseSQLData.Date = Date.Ticks;
        expenseSQLData.Year = Date.Year;
        expenseSQLData.Month = Date.Month;
        expenseSQLData.BillingYear = BillingDate.Year;
        expenseSQLData.BillingMonth = BillingDate.Month;
        expenseSQLData.TypeId = Type.SQLId;
        expenseSQLData.CategoryId = Category.SQLId;
        expenseSQLData.Amount = Amount;
        expenseSQLData.CurrencyId = Currency.SQLId;
        expenseSQLData.Description = Description;
        expenseSQLData.Paid = Paid;

        return expenseSQLData;
    }
}