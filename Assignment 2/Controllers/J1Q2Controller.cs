using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Q2Controller : ControllerBase
    {
        /// <summary>
        /// This code informs user if they are before, after or on the special day
        /// </summary>
        /// <param name="day">User should input the date in number format</param>
        /// <param name="month">User should input the month in number format</param>
        /// <returns>A string of text informing the status as on the input date</returns>
        /// HEADER: Content-Type: multipart/form-data
        /// <example>curl -X "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "day=28&month=1" "https://localhost:7125/api/J1Q2/Period" >> Before</example>
        [HttpPost(template: "Period")]

        public string Period([FromForm] int day, [FromForm] int month)
        {
            if (month < 2 || (day < 18 && month == 02))
            {
                return "Before";
            }
            if (day == 18 && month == 02)
            {
                return "Special Day";
            }
            return "After";
        }


    }
}
