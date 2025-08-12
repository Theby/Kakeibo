using System;

public class SummaryData
{
    public int Year { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal CreditHold { get; set; }

    SummarySQLData _sqlData;

    public SummaryData()
    {
        _sqlData = null;
    }

    public SummaryData(SummarySQLData sqlData)
    {
        _sqlData = sqlData;
        if (_sqlData == null)
        {
            return;
        }

        Year = _sqlData.Year;
        TotalIncome = _sqlData.TotalIncome;
        TotalExpenses = _sqlData.TotalExpenses;
        CreditHold = _sqlData.CreditHold;
    }

    public SummarySQLData ToSQLData()
    {
        _sqlData = new SummarySQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Year,
            TotalIncome,
            TotalExpenses,
            CreditHold
        );

        return _sqlData;
    }
}