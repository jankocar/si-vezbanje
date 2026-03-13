using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessBook : IBusinessBook
    {
        private readonly IBookRepository bookRepository;

        public BusinessBook(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;             // dovde uvek
        }

        public List<Book> GetBooksWith50()
        {
             return bookRepository.GetAllBooks()
                   .FindAll(item => item.NumberOfPage > 50);
      
        }

        public string InsertBook(Book book)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(book, null, null);

            if (!Validator.TryValidateObject(book, validationContext, validationResults, true))
            {

                return string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
   
            }
            if (book != null)
            {
                if (bookRepository.InsertBook(book))
                {
                    return "Uspesno!";
                }
                return "Greska!";
            }
            return "Greska!";
        }

        public List<Car> GetCarsSortedByPrice()
        {
            return carRepository.GetCars()
                .OrderBy(c => c.Price)
                .ToList();
        }
        
        public List<Car> GetCarsSortedByPriceDesc()
        {
            return carRepository.GetCars()
                .OrderByDescending(c => c.Price)
                .ToList();
        }
        
        public List<Car> GetCarsNewerThan(int year)
        {
            return carRepository.GetCars()
                .Where(c => c.Year > year)
                .ToList();
        }
        
        public List<Car> GetCarsUnderPrice(decimal max)
        {
            return carRepository.GetCars()
                .Where(c => c.Price < max)
                .ToList();
        }
        
        public string InsertCar(Car car)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(car, null, null);
        
            if (!Validator.TryValidateObject(car, validationContext, validationResults, true))
            {
                return string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
            }
        
            if (carRepository.InsertCar(car))
                return "Uspesno!";
        
            return "Greska!";
        }
        
        public bool DeleteCar(int id)
        {
            return carRepository.DeleteCar(id);
        }
        
        public bool UpdateCar(Car car)
        {
            return carRepository.UpdateCar(car);
        }
        
        public Car? GetCarById(int id)
        {
            return carRepository.GetCarById(id);
        }
        public List<Perfume> GetAllPerfumesWithDiscount()
        {
            List<Perfume> perfumes = perfumeRepository.GetAllPerfumes();
        

            foreach (var p in perfumes)
            {
                p.Price = p.Price * 0.9m; 
            }
            return perfumes;
        }
            }
}
