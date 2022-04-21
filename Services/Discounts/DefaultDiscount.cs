namespace BenefitsCalculator.Services.Discounts
{
    class DefaultDiscount : DecoratorComponent
    {
        public override decimal ApplyDiscount(string name, decimal currentCost)
        {
            return currentCost; // no default discounts, but this is where they would go
        }
    }
}
