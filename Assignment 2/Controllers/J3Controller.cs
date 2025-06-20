using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// This code converts the string input to the actual message intended.
        /// </summary>
        /// <param name="code">Input of the numerical value/code.</param>
        /// <returns>Returns the direction and the steps.</returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// <example>
        /// https://localhost:7125/api/J3/Secret code=10909 >> Left 909
        /// </example>
        /// <example>
        /// https://localhost:7125/api/J3/Secret code=73647 >> Right 647
        /// </example>
        [HttpPost (template: "Secret")]

        public string Secret([FromForm] string code)
        {
                int num1 = int.Parse(code[0].ToString());
                int num2 = int.Parse(code[1].ToString());
                int addition = num1 + num2;

                string direction = "";

                if (addition == 0)
                {
                    direction = "Right";
                }
                else if (addition % 2 == 0)
                {
                    direction = "Right";
                }
                else
                {
                    direction = "Left";
                }

                string steps = code.Substring(2);

                return direction + " " + steps;
        }
    }
}
