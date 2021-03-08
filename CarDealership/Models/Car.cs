using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Dealership.Models
{
  public class Car
  {
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    private int _price;
    public int Id { get; set; }

    public Car(int id, string make, string model, int year, int price)
    {
      Id = id;
      Make = make;
      Model = model;
      Year = year;
      _price = price;

    }

    public int GetPrice()
    {
      return _price;
    }

    public void SetPrice(int newPrice)
    {
      _price = newPrice;
    }

    public static List<Car> GetAllCar()
    {
      List<Car> allCars = new List<Car>{};

      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM epic_cars;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string make = rdr.GetString(1);
        string model = rdr.GetString(2);
        int year = rdr.GetInt32(3);
        int price = rdr.GetInt32(4);
        Car newCar = new Car(id, make, model, year, price);
        allCars.Add(newCar);
      }

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCars;
    }

    public static List<Car> Search(int min, int max)
    {
      List<Car> priceRange = new List<Car>{};

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM epic_cars WHERE price BETWEEN @min AND @max ORDER BY price ASC;";
      MySqlParameter minPrice = new MySqlParameter();
      minPrice.ParameterName = "@min";
      minPrice.Value = min;
      MySqlParameter maxPrice = new MySqlParameter();
      maxPrice.ParameterName = "@max";
      maxPrice.Value = max;

      cmd.Parameters.Add(minPrice);
      cmd.Parameters.Add(maxPrice);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string make = rdr.GetString(1);
        string model = rdr.GetString(2);
        int year = rdr.GetInt32(3);
        int price = rdr.GetInt32(4);
        Car newCar = new Car(id, make, model, year, price);
        priceRange.Add(newCar);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }

      return priceRange;
    }
  }
}