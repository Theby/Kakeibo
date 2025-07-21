public class CurrencyData
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Symbol { get; set; }
    public string Format { get; set; }

    CurrencySQLData _sqlData;
    public int SQLId => _sqlData.Id;

    public CurrencyData()
    {
        _sqlData = null;
    }

    public CurrencyData(CurrencySQLData sqlData)
    {
        _sqlData = sqlData;

        Name = _sqlData.Name;
        ShortName = _sqlData.ShortName;
        Symbol = _sqlData.Symbol;
        Format = _sqlData.Format;
    }

    public CurrencySQLData ToSQLData()
    {
        CurrencySQLData currencySqlData = new CurrencySQLData();
        if (_sqlData != null)
        {
            currencySqlData = _sqlData;
        }

        currencySqlData.Name = Name;
        currencySqlData.ShortName = ShortName;
        currencySqlData.Symbol = Symbol;
        currencySqlData.Format = Format;

        return currencySqlData;
    }
}
