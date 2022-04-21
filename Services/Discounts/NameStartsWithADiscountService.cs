namespace BenefitsCalculator.Services.Discounts
{
    public class NameStartsWithADiscountService : Decorator
    {

        public NameStartsWithADiscountService(DecoratorComponent comp) : base(comp) 
        {

        }

        public override decimal ApplyDiscount(string name, decimal currentCost)
        {
            var newValueWithDiscountApplied = currentCost;
            if(name.StartsWith("A") || name.StartsWith("a"))
            {
                newValueWithDiscountApplied = currentCost - (currentCost * Convert.ToDecimal(0.10));
            }

            return base.ApplyDiscount(name, newValueWithDiscountApplied);
        }
    }
}
