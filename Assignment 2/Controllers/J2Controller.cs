using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        [HttpGet(template: "ChiliPeppers")]

        public int ChiliPeppers(string Ingredients)
        {
            int spice = 0;

            string[] ron = Ingredients.Split(",");

            for (int i = 0; i < ron.Length; i++)
            {

                if (ron[i] == "Habanero")
                {
                    spice = spice + 125000;
                }
                else if (ron[i] == "Poblano")
                {
                    spice = spice + 1500;
                }
                else if (ron[i] == "Mirasol")
                {
                    spice = spice + 6000;
                }
                else if (ron[i] == "Serrano")
                {
                    spice = spice + 15500;
                }
                else if (ron[i] == "Cayenne")
                {
                    spice = spice + 40000;
                }
                else if (ron[i] == "Thai")
                {
                    spice = spice + 75000;
                }
            }
            return spice;
        }
    }
}
