using PruebaBabelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBabelAPI.Service
{
    public interface ICountryService
    {
        IList<Country> GetCountries(int PageNumber, int RowsPerPage, string keyword);
    }
}
