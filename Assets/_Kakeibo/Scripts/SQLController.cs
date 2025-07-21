using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using SQLite;
using UnityEngine;

public class SQLController
{
    SQLiteConnection _dataBase;
    string _dataBasePath;

    public void Initialize()
    {
        _dataBasePath = Path.Combine(Application.persistentDataPath, "Kakeibo.db");
        _dataBase = new SQLiteConnection(_dataBasePath);

        _dataBase.CreateTable<TypeSQLData>();
        _dataBase.CreateTable<CategorySectionSQLData>();
        _dataBase.CreateTable<CategorySQLData>();
        _dataBase.CreateTable<CurrencySQLData>();
        _dataBase.CreateTable<ExpenseSQLData>();
        _dataBase.CreateTable<IncomeSQLData>();
        _dataBase.CreateTable<SummarySQLData>();
    }

    public void Clear()
    {
        _dataBase.Close();
    }

    public void Insert<T>(T data) where T : SQLiteData, new()
    {
        _dataBase.Insert(data);
    }

    public List<T> GetAll<T>() where T : SQLiteData, new()
    {
        var table = _dataBase.Table<T>().ToList();
        return table;
    }

    public List<T> GetAllBy<T>(Expression<Func<T, bool>> filter) where T : SQLiteData, new()
    {
        var table = _dataBase.Table<T>().Where(filter).ToList();
        return table;
    }

    public T GetBy<T>(Expression<Func<T, bool>> filter) where T : SQLiteData, new()
    {
        var entry = _dataBase.Table<T>().FirstOrDefault(filter);
        return entry;
    }

    public T GetById<T>(int id) where T : SQLiteData, new()
    {
        var entry = _dataBase.Table<T>().FirstOrDefault(e => e.Id == id);
        return entry;
    }

    public void Update<T>(T data) where T : SQLiteData, new()
    {
        _dataBase.Update(data);
    }

    public void Destroy<T>(T data) where T : SQLiteData, new()
    {
        _dataBase.Delete<ExpenseSQLData>(data.Id);
    }

    public bool IsTableEmpty<T>() where T : SQLiteData, new()
    {
        var table = _dataBase.Table<T>();
        bool hasAny = table.Any();
        return !hasAny;
    }

    public TableQuery<T> GetTableQuery<T>() where T : SQLiteData, new()
    {
        return _dataBase.Table<T>();
    }
}