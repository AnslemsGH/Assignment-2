using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Q2Controller : ControllerBase
    {
        /// <summary>
        /// Determines whether a given date is before, after, or exactly on February 18.
        /// </summary>
        /// <param name="month">The numerical month (1 to 12).</param>
        /// <param name="day">The numerical day of the month (valid for the given month).</param>
        /// <returns>
        /// Returns:
        /// - "Before" if the date is before February 18
        /// - "After" if the date is after February 18
        /// - "Special" if the date is exactly February 18
        /// </returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// <example>
        /// https://localhost:7125/api/Date/Check?month=1&day=7 >> Before
        /// </example>
        /// <example>
        /// https://localhost:7125/api/Date/Check?month=8&day=31 >> After
        /// </example>
        /// <example>
        /// https://localhost:7125/api/Date/Check?month=2&day=18 >> Special
        /// </example>
        
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
