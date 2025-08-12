using System;

public class CurrencyData
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Symbol { get; set; }
    public string Format { get; set; }
    public int SQLId => _sqlData.Id;

    CurrencySQLData _sqlData;

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
        _sqlData = new CurrencySQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Name,
            ShortName,
            Symbol,
            Format
        );

        return _sqlData;
    }
}
