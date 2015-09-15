using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ServiceLayer
{
    public class StoreLocationService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreLocationService(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }
        
        public IEnumerable<StoreLocationViewModel> GetAllStoreLocationViewModel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreLocationViewModel> GetStoreLocationViewModelByDay(string dayOfWeek)
        {
            string validDayOfWeek = this.GetValidDayOfWeek(dayOfWeek);

            throw new NotImplementedException();
        }

        private string GetValidDayOfWeek(string inputtedDayOfWeek)
        {
            string validDayOfWeek = "";

            switch (inputtedDayOfWeek.ToLower())
            {
                case "monday":
                case "mon":
                case "mo":
                    validDayOfWeek = "Mo";
                    break;
                case "tuesday":
                case "tues":
                case "tu":
                    validDayOfWeek = "Tu";
                    break;
                case "wednesday":
                case "wed":
                case "we":
                    validDayOfWeek = "We";
                    break;
                case "thursday":
                case "thur":
                case "th":
                    validDayOfWeek = "Th";
                    break;
                case "friday":
                case "fri":
                case "fr":
                    validDayOfWeek = "Fr";
                    break;
                case "saturday":
                case "sat":
                case "sa":
                    validDayOfWeek = "Sa";
                    break;
                case "sunday":
                case "sun":
                case "su":
                    validDayOfWeek = "Su";
                    break;
                default:
                    validDayOfWeek = "XXX";
                    break;
            }

            return validDayOfWeek;
        }
    }
}
