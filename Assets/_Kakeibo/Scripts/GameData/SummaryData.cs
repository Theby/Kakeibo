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