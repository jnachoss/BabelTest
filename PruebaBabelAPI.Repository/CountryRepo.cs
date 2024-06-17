using PruebaBabelAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace PruebaBabelAPI.Repository
{
    public class CountryRepo : ICountryRepo
    {
        private readonly IConfiguration _configuration;
        private SqlConnection con;


        public CountryRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private void connection()
        {
            string constring = _configuration.GetConnectionString("SqlConnection");
            con = new SqlConnection(constring);
        }
        public IList<Country> GetCountries(int pageNumber, int rowsPerPage, string keyword)
        {
            connection();
            List<Country> Countries = new List<Country>();

            try
            {
                using (SqlCommand command = new SqlCommand("GetCountries", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                    command.Parameters.AddWithValue("@keyword", keyword);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        


                        if (Countries.Count(c => c.Id == Convert.ToInt32(reader["Id"])) == 0)
                        {
                            Countries.Add(new Country
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IsoCode = reader["IsoCode"].ToString(),
                                Population = reader["Population"].ToString(),
                                Name = reader["Name"].ToString(),
                                Hotels = new List<Hotel>(),
                                Restaurants = new List<Restaurant>()
                            });
                        }

                        Country country = Countries.FirstOrDefault(c => c.Id == Convert.ToInt32(reader["Id"]));

                        if (country.Hotels.Count(h => h.Id == Convert.ToInt32(reader["IdHotel"])) == 0)
                        {
                            Countries.FirstOrDefault(c => c.Id == Convert.ToInt32(reader["Id"])).Hotels.Add(
                                 new Hotel { Id = Convert.ToInt32(reader["IdHotel"]), Name = reader["HotelName"].ToString(), Stars = reader["Stars"].ToString() }
                            );
                        }

                        if (country.Restaurants.Count(r => r.Id == Convert.ToInt32(reader["IdRestaurant"])) == 0)
                        {
                            Countries.FirstOrDefault(c => c.Id == Convert.ToInt32(reader["Id"])).Restaurants.Add(
                             new Restaurant { Id = Convert.ToInt32(reader["IdRestaurant"]), Name = reader["RestaurantName"].ToString(), Type = reader["Type"].ToString() }
                         );
                        }


                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection to SQL Server closed.");
            }
            return Countries;
        }
            
    }
}
