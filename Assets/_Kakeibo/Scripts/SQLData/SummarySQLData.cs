using System;
using SQLite;

[Table("Summary")]
public class SummarySQLData : SQLiteData
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }
    [Column("enabled")]
    public override bool Enabled { get; set; } = true;
    [Column("input_date")]
    public override long InputDate { get; set; } = DateTime.Now.Ticks;
    [Column("year")]
    public int Year { get; set; }
    [Column("total_income")]
    public decimal TotalIncome { get; set; }
    [Column("total_expenses")]
    public decimal TotalExpenses { get; set; }
    [Column("credit_hold")]
    public decimal CreditHold { get; set; }
}