using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Q2Controller : ControllerBase
    {
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
