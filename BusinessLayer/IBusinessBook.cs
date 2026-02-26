using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessBook
    {
        string InsertBook(Book book);  // uvek
        List<Book> GetBooksWith50();
        List<Car> GetCarsSortedByPriceDesc();   // sortirano opadajuće
        List<Car> GetCarsNewerThan(int year);   // filter po godini
        List<Car> GetCarsUnderPrice(decimal max); // filter po ceni
        string InsertCar(Car car);              // insert sa validacijom
        bool DeleteCar(int id);                 // brisanje
        bool UpdateCar(Car car);                // update
        Car? GetCarById(int id);                // jedan auto
    }
    
}
