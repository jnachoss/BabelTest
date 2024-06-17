using PruebaBabelAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBabelAPI.Repository
{
    public interface ICountryRepo
    {
        IList<Country> GetCountries(int pageNumber, int rowsPerPage, string keyword);
    }
}
