namespace BenefitsCalculator.Repositories
{
    public interface ICostBenefitRepository
    {
        decimal GetCostOfBenefitsForEmployeesPerYear();
        decimal GetCostOfBenefitsForDependentsPerYear();
        decimal GetEmployeeSalaryPerYear();
        decimal GetEmployeePayPeriodsPerYear();
    }
}