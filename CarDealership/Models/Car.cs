using System;
using System.Collections.Generic;

namespace Dealership.Models
{
  public class Car
  {
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    private int _price;

    private static List<Car> _carList = new List<Car> {};

    public Car(string make, string model, int year, int price)
    {
      Make = make;
      Model = model;
      Year = year;
      _price = price;
      _carList.Add(new Car(make, model, year, price));
    }

    public int GetPrice()
    {
      return _price;
    }

    public void SetPrice(int newPrice)
    {
      _price = newPrice;
    }

    public List<Car> GetAllCar()
    {
      return _carList;
    }
  }
}