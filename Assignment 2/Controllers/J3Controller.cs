using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// Decodes a 5-digit numerical instruction into a direction and number of steps,based on rules left by Professor Santos to locate a secret biofuel formula.
        /// The first two digits determine the direction:
        /// - If the sum is odd, the direction is left.
        /// - If the sum is even and not zero, the direction is right.
        /// - If the sum is zero, use the direction from the previous instruction.
        /// The last three digits represent the number of steps (always 100 or greater).
        /// The sequence ends when the code is 99999 (which should not be processed).
        /// </summary>
        /// <param name="code">A 5-digit numeric instruction (e.g., 57234).</param>
        /// <returns>Returns the decoded instruction: "left/right [steps]".</returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// <example>
        /// https://localhost:7125/api/J3/Secret?code=57234 >> right 234
        /// </example>
        /// <example>
        /// https://localhost:7125/api/J3/Secret?code=00907 >> right 907
        /// </example>
        /// <example>
        /// https://localhost:7125/api/J3/Secret?code=34100 >> left 100
        /// </example>
        [HttpGet(template: "Secret")]

        public string Secret(string code)
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

///I tried this code, it did not work entirely. Keeping here to showcase my work and understand the issue.
/// public string Secret([FromForm] string code)
///{
///    string[] sush = code.Split(",");
///       string linked = "";

///for (int i = 0; i < sush.Length; i++)
///{
///string pushy = sush[i];

///int num1 = int.Parse(pushy[0].ToString());
///int num2 = int.Parse(pushy[1].ToString());
///int addition = num1 + num2;

///string direction = "";

///if (addition == 0)
///{
///direction = "Right";
///         }
///         else if (addition % 2 == 0)
///{
///direction = "Right";
///         }
///         else
///{
///direction = "Left";
///         }

///string steps = pushy.Substring(2);
///linked = direction + " " + steps;

///       }
///return linked = $"{linked},{linked}";
/// }
///  }