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

        Year = _sqlData.Year;
        TotalIncome = sqlData.TotalIncome;
        TotalExpenses = sqlData.TotalExpenses;
        CreditHold = sqlData.CreditHold;
    }

    public SummarySQLData ToSQLData()
    {
        SummarySQLData summarySQLData = new SummarySQLData();
        if (_sqlData != null)
        {
            summarySQLData = _sqlData;
        }

        summarySQLData.Year = Year;
        summarySQLData.TotalIncome = TotalIncome;
        summarySQLData.TotalExpenses = TotalExpenses;
        summarySQLData.CreditHold = CreditHold;

        return summarySQLData;
    }
}