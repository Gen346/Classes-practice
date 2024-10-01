using System;
using System.IO;
using System.Xml.Serialization;

public class Salary
{
    private string _fullName;
    private double _baseSalary;
    private int _hireYear;
    private double _bonusPercentage;
    private double _workedDays;
    private double _accruedAmount;
    private double _withheldSalary;

    public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }

    public double BaseSalary
    {
        get { return _baseSalary; }
        set { _baseSalary = value; }
    }

    public int HireYear
    {
        get { return _hireYear; }
        set { _hireYear = value; }
    }

    public double BonusPercentage
    {
        get { return _bonusPercentage; }
        set { _bonusPercentage = value; }
    }

    public double WorkedDays
    {
        get { return _workedDays; }
        set { _workedDays = value; }
    }

    public double AccruedAmount
    {
        get { return _accruedAmount; }
        set { _accruedAmount = value; }
    }

    public double WithheldSalary
    {
        get { return _withheldSalary; }
        set { _withheldSalary = value; }
    }

    public Salary() { }  // Конструктор по умолчанию

    public Salary(string fullName, double baseSalary, int hireYear, double bonusPercentage, double workedDays)
    {
        _fullName = fullName;
        _baseSalary = baseSalary;
        _hireYear = hireYear;
        _bonusPercentage = bonusPercentage;
        _workedDays = workedDays;
        CalculateAccruedAmount();
        CalculateWithheldSalary();
    }

    public double CalculateAccruedAmount()
    {
        double bonusAmount = _baseSalary * (_bonusPercentage / 100);
        _accruedAmount = (_baseSalary / 30) * _workedDays + bonusAmount;
        return _accruedAmount;
    }

    public double CalculateWithheldSalary()
    {
        _withheldSalary = _accruedAmount * 0.018 * 0.015;
        return _withheldSalary;
    }

    public double CalculateNetAmount()
    {
        return _accruedAmount - _withheldSalary;
    }

    public int CalculateExperience()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - _hireYear;
    }

    public override string ToString()
    {
        return $"{_fullName}, Experience: {CalculateExperience()} years, Accrued: {_accruedAmount}, Withheld: {_withheldSalary}, Net: {CalculateNetAmount()}";
    }
}