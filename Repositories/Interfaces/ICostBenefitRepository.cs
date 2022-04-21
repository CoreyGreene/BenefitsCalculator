namespace BenefitsCalculator.Repositories
{
    public interface ICostBenefitRepository
    {
        decimal GetCostOfBenefitsForEmployeesPerYear();
        decimal GetCostOfBenefitsForDependentsPerYear();
    }
}