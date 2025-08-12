using System;
using SQLite;

[Table("Summary")]
public record SummarySQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("year")] int Year,
    [property: Column("total_income")] decimal TotalIncome,
    [property: Column("total_expenses")] decimal TotalExpenses,
    [property: Column("credit_hold")] decimal CreditHold) : SQLiteData(Id, Enabled, InputDate)
{
    public SummarySQLData() : this(0, true, DateTime.Now.Ticks, 0, 0, 0, 0){}
}