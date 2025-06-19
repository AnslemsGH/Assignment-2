using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// This code returns the total score after calculating the effective delivery score after reducing the collision score.
        /// </summary>
        /// <param name="Collisions">User will input the number of collisions</param>
        /// <param name="Deliveries">User will input the number of deliveries done</param>
        /// <returns>Return a score after calculating and giving bonus of 500 if the deliveries are more than collisions</returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// <example>
        /// curl -X "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "Collisions=5&Deliveries=10" "https://localhost:7069/api/J1/Delivedroid" >> 950
        /// </example>
        /// <example>
        /// curl -X "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "Collisions=1&Deliveries=20" "https://localhost:7069/api/J1/Delivedroid" >> 1490
        /// </example>
        [HttpPost(template: "Delivedroid")]

        public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int score = ((int)Deliveries * 50) - ((int)Collisions * 10);

            if (Deliveries > Collisions)
            {
                score = score + 500;
            }

            return score;
        }
    }
}

