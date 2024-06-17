using PruebaBabelAPI.Models;
using PruebaBabelAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBabelAPI.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo countryRepo;

        public CountryService(ICountryRepo _countryRepo)
        {
            countryRepo = _countryRepo;
        }
        public IList<Country> GetCountries(int PageNumber, int RowsPerPage, string keyword)
        {
            return countryRepo.GetCountries(PageNumber, RowsPerPage, keyword);
        }
    }
}
