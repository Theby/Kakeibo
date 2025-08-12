using System;
using SQLite;

[Table("Currencies")]
public record CurrencySQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("name")] string Name,
    [property: Column("short_name")] string ShortName,
    [property: Column("symbol")] string Symbol,
    [property: Column("format")] string Format) : SQLiteData(Id, Enabled, InputDate)
{
    public CurrencySQLData() : this(0, true, DateTime.Now.Ticks, string.Empty, string.Empty, string.Empty, string.Empty){}
}