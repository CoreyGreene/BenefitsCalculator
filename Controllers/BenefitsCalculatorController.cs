using BenefitsCalculator.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(string data)
        {
            try
            {
                string[] beneficiaries = data.Split(new string[] { "," }, StringSplitOptions.None);
                List<string> nameList = beneficiaries.ToList();
                var costPerPayPeriod = benefitsCalculationService.CalculateBenefits(nameList);
                var someData = new
                {
                    cost = Math.Round(costPerPayPeriod, 2),
                    payableAmount = Math.Round(2000 - costPerPayPeriod, 2)
                };

                return Ok(someData);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}