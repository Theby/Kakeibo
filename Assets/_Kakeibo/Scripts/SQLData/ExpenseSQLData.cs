using System;
using SQLite;

[Table("Expenses")]
public class ExpenseSQLData : SQLiteData
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }
    [Column("enabled")]
    public override bool Enabled { get; set; } = true;
    [Column("input_date")]
    public override long InputDate { get; set; } = DateTime.Now.Ticks;
    [Column("date")]
    public long Date { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("month")]
    public int Month { get; set; }
    [Column("billing_year")]
    public int BillingYear { get; set; }
    [Column("billing_month")]
    public int BillingMonth { get; set; }
    [Column("type_id")]
    [Indexed]
    public int TypeId { get; set; }
    [Column("category_id")]
    [Indexed]
    public int CategoryId { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("currency_id")]
    [Indexed]
    public int CurrencyId { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("paid")]
    public bool Paid { get; set; }
}