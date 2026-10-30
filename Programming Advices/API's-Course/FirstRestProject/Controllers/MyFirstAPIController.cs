using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstRestProject.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/MyFirstApi")]
    [ApiController]
    public class MyFirstAPIController : ControllerBase
    {
        [HttpGet("MyName", Name = "MyName")]
        public string GetMyName()
        {
            return "My name is Soufiane Boudchich";
        }

        [HttpGet("Your Name", Name = "YourName")]
        public string GetYourName()
        {
            return "Your Name is Fouad";
        }

        [HttpGet("sum/{Num1}/{Num2}")]
        public int Sum2Numbers(int Num1, int Num2)
        {
            return Num1 + Num2;
        }


        [HttpGet("multi/{Num1}/{Num2}")]
        public int Multi2Numbers(int Num1, int Num2)
        {
            return Num1 * Num2;
        }


    }
}
