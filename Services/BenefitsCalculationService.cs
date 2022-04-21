using BenefitsCalculator.Factories;

namespace BenefitsCalculator.Services
{
    public class BenefitsCalculationService
    {
        RepositoryFactory repoFactory;
        public BenefitsCalculationService()
        {
            repoFactory = new RepositoryFactory();
        }


        public decimal CalculateBenefits(string[] beneficiaries)
        {
            var costBenefitRepository = repoFactory.CreateCostBenefitRepository();

            var employeeCostPerYear = costBenefitRepository.GetCostOfBenefitsForEmployeesPerYear();
            var dependentCostPerYear = costBenefitRepository.GetCostOfBenefitsForDependentsPerYear();

            return 0;

        }


    }
}
