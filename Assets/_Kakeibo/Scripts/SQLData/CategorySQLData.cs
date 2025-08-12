using System;
using SQLite;

[Table("Categories")]
public record CategorySQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("name")] string Name,
    [property: Column("section_id"), Indexed] int SectionId) : SQLiteData(Id, Enabled, InputDate)
{
    public CategorySQLData() : this(0, true, DateTime.Now.Ticks, string.Empty, 0){}
}