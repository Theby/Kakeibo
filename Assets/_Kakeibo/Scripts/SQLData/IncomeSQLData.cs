using System;
using SQLite;

[Table("Income")]
public class IncomeSQLData : SQLiteData
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
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("currency_id")]
    [Indexed]
    public int CurrencyId { get; set; }
    [Column("description")]
    public string Description { get; set; }
}