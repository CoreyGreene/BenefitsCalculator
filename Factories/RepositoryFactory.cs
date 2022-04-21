using BenefitsCalculator.Repositories;

namespace BenefitsCalculator.Factories
{
    public class RepositoryFactory
    {

        public RepositoryFactory()
        {

        }

        // Installing Ninject Dependency Injection was out of scope :[
        public ICostBenefitRepository CreateCostBenefitRepository()
        {
            return new CostBenefitRepository();
        }

    }
}
