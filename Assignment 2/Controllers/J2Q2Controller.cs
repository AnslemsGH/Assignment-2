using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Q2Controller : ControllerBase
    {
        /// <summary>
        /// Analyzes a text message and determines the overall mood based on emoticons.
        /// The message is scanned for happy :-) and sad :-( emoticons.
        /// - If neither is found, returns "none".
        /// - If counts are equal, returns "unsure".
        /// - If more happy emoticons, returns "happy".
        /// - If more sad emoticons, returns "sad".
        /// </summary>
        /// <param name="Message">A single line of input text.</param>
        /// <returns>The overall mood of the message: "happy", "sad", "unsure", or "none".</returns>
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// <example>
        /// https://localhost:7125/api/Mood/Analyze?message=How are you :-) doing :-( today :-)? >> happy
        /// </example>
        /// <example>
        /// https://localhost:7125/api/Mood/Analyze?message=This:-(is str:-(:-(ange te:-)xt. >> sad
        /// </example>
        /// <example>
        /// https://localhost:7125/api/Mood/Analyze?message=:) >> none
        /// </example>
        [HttpPost (template:"Mood")]

        public string Mood([FromForm] string Message)
        {
            int happy = 0;
            int sad = 0;

            int i = 0;
            while (i <= (Message.Length-3))
            {
                string characters = Message.Substring(i, 3);
                if (characters == ":-)")
                {
                    happy = happy + 1;
                }
                else if (characters == ":-(")
                {
                    sad = sad + 1;
                }
                i = i + 1;
            }

            string mood = "";

            if (happy == 0 && sad == 0)
                mood = "None";
            else if (happy == sad)
                mood = "Unsure";
            else if (happy > sad)
                mood = "Happy";
            else
                mood = "Sad";

            return mood;
        }
    }
}
