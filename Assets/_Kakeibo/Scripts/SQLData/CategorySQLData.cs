using System;
using SQLite;

[Table("Categories")]
public class CategorySQLData : SQLiteData
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
    [Column("section_id")]
    [Indexed]
    public int SectionId { get; set; }
}