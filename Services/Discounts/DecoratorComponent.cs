namespace BenefitsCalculator.Services.Discounts
{
    public abstract class DecoratorComponent
    {
        public abstract decimal ApplyDiscount(string name, decimal currentCost);
    }
}