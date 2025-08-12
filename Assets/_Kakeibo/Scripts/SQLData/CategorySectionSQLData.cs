using System;
using SQLite;

[Table("CategorySections")]
public record CategorySectionSQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("name")] string Name) : SQLiteData(Id, Enabled, InputDate)
{
    public CategorySectionSQLData() : this(0, true, DateTime.Now.Ticks, string.Empty){}
}