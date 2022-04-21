using BenefitsCalculator.Models;
using BenefitsCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace BenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenefitsCalculatorController : ControllerBase
    {
        
        private readonly ILogger<BenefitsCalculatorController> _logger;
        BenefitsCalculationService benefitsCalculationService;

        public BenefitsCalculatorController(ILogger<BenefitsCalculatorController> logger)
        {
            _logger = logger;
            benefitsCalculationService = new BenefitsCalculationService();
        }

        [HttpGet]
        //public IActionResult Get(int members)
        public IActionResult Get(string data)
        {
            string[] beneficiaries = data.Split(new string[] { "," },
                                              StringSplitOptions.None);

            var something = benefitsCalculationService.CalculateBenefits(beneficiaries);


            var someData = new
            {
                cost = 6.66
            };
            return Ok(someData);
        }
    }
}