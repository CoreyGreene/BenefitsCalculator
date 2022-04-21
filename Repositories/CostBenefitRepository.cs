namespace BenefitsCalculator.Repositories
{
    public class CostBenefitRepository : ICostBenefitRepository
    {

        public CostBenefitRepository()
        {

        }

        //In a real world, this would be a DB query, it would probably contain some ID represending the employee type that the query would determine the value
        public decimal GetCostOfBenefitsForEmployeesPerYear()
        {
            return 1000;
        }

        public decimal GetCostOfBenefitsForDependentsPerYear()
        {
            return 500;
        }

        public decimal GetEmployeeSalaryPerYear()
        {
            return 52000;
        }

        public decimal GetEmployeePayPeriodsPerYear()
        {
            return 26;
        }

    }
}
