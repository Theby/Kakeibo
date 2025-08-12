using System;
using SQLite;

[Table("Expenses")]
public record ExpenseSQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("date")] long Date,
    [property: Column("year")] int Year,
    [property: Column("month")] int Month,
    [property: Column("billing_year")] int BillingYear,
    [property: Column("billing_month")] int BillingMonth,
    [property: Column("type_id"), Indexed] int TypeId,
    [property: Column("category_id"), Indexed] int CategoryId,
    [property: Column("amount")] decimal Amount,
    [property: Column("currency_id"), Indexed] int CurrencyId,
    [property: Column("description")] string Description,
    [property: Column("paid")] bool Paid) : SQLiteData(Id, Enabled, InputDate)
{
    public ExpenseSQLData() : this(0, true, DateTime.Now.Ticks, 0, 0, 0, 0, 0, 0, 0, 0, 0, string.Empty, false){}
}