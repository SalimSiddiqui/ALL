using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Department
/// </summary>
public class Department
{
    private int _Id;

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _Dep;

    public string Dep
    {
        get { return _Dep; }
        set { _Dep = value; }
    }
}
// [BusinessEntityID],[PersonType],[NameStyle],[FirstName][LastName] ,[ModifiedDate]
public class Person
{
    private int _BusinessEntityID;

    public int BusinessEntityID
    {
        get { return _BusinessEntityID; }
        set { _BusinessEntityID = value; }
    }
    private string _FirstName;

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    private string _LastName;

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
    private DateTime _ModifiedDate;

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }
}

public class Company
{
    public int? companyId { get; set; }
    public string name { get; set; }
    public string ceo { get; set; }
    public string country { get; set; }
    public string foundationYear { get; set; }
    public string noOfEmployee { get; set; }
}