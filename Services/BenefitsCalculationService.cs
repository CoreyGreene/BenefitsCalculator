using BenefitsCalculator.Factories;

namespace BenefitsCalculator.Services
{
    public class BenefitsCalculationService
    {
        RepositoryFactory repoFactory;
        DiscountService discountService;
        public BenefitsCalculationService()
        {
            repoFactory = new RepositoryFactory();
            discountService = new DiscountService();
        }

        public decimal CalculateBenefits(List<string> nameList)
        {
            var listOfBeneficiaries = SanitizeNameList(nameList);
            var costBenefitRepository = repoFactory.CreateCostBenefitRepository();
            var employeeCostPerYear = costBenefitRepository.GetCostOfBenefitsForEmployeesPerYear();
            var dependentCostPerYear = costBenefitRepository.GetCostOfBenefitsForDependentsPerYear();
            var employeeSalaryPerYear = costBenefitRepository.GetEmployeeSalaryPerYear();
            var employeePayPeriodsPerYear = costBenefitRepository.GetEmployeePayPeriodsPerYear();

            List<decimal> costPerBeneficiary = new List<decimal>();

            //In this simplistic example, 'first' will always be the employee
            costPerBeneficiary.Add(CalculateCostOfEmployee(listOfBeneficiaries.First(), employeeCostPerYear, employeePayPeriodsPerYear));
            listOfBeneficiaries.RemoveAt(0);
            listOfBeneficiaries.ForEach(beneficiaryName => costPerBeneficiary.Add(CalculateCostOfBeneficiary(beneficiaryName, dependentCostPerYear, employeePayPeriodsPerYear)));

            return costPerBeneficiary.Sum();
        }

        private List<string> SanitizeNameList(List<string> nameList)
        {
            List<string> newList = new List<string>();
            nameList.ForEach(name =>
            {
                if (!name.Trim().Equals(String.Empty))
                {
                    newList.Add(name);
                }
            });
            return newList;
        }

        private decimal CalculateCostOfEmployee(string name, decimal employeeCostPerYear, decimal employeePayPeriodsPerYear)
        {
            return discountService.CalculateDiscounts(name, employeeCostPerYear / employeePayPeriodsPerYear);
        }

        private decimal CalculateCostOfBeneficiary(string name, decimal dependentCostPerYear, decimal employeePayPeriodsPerYear)
        {
            return discountService.CalculateDiscounts(name, dependentCostPerYear / employeePayPeriodsPerYear);
        }
    }
}
