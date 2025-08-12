using System;
using SQLite;

[Table("Income")]
public record IncomeSQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("date")] long Date,
    [property: Column("year")] int Year,
    [property: Column("amount")] decimal Amount,
    [property: Column("currency_id"), Indexed] int CurrencyId,
    [property: Column("description")] string Description) : SQLiteData(Id, Enabled, InputDate)
{
    public IncomeSQLData() : this(0, true, DateTime.Now.Ticks, 0, 0, 0, 0, string.Empty){}
}