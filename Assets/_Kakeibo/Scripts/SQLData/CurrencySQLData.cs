using System;
using SQLite;

[Table("Currencies")]
public class CurrencySQLData : SQLiteData
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }
    [Column("enabled")]
    public override bool Enabled { get; set; } = true;
    [Column("input_date")]
    public override long InputDate { get; set; } = DateTime.Now.Ticks;
    [Column("name")]
    public string Name { get; set; }
    [Column("short_name")]
    public string ShortName { get; set; }
    [Column("symbol")]
    public string Symbol { get; set; }
    [Column("format")]
    public string Format { get; set; }
}