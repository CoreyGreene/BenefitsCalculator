namespace BenefitsCalculator.Services.Discounts
{
    public class SuperSecretDiscount : Decorator
    {
        public SuperSecretDiscount(DecoratorComponent comp) : base(comp)
        {

        }

        // There are no super secret default, but this shows how a decorate pattern could be used to apply discounts
        public override decimal ApplyDiscount(string name, decimal currentCost)
        {
            return base.ApplyDiscount(name, currentCost);
        }
    }
}
