namespace BenefitsCalculator.Services.Discounts
{
    public abstract class Decorator : DecoratorComponent
    {
        protected DecoratorComponent component;

        public Decorator(DecoratorComponent component)
        {
            this.component = component;
        }

        public void SetComponent(DecoratorComponent component)
        {
            this.component = component;
        }

        // The Decorator delegates all work to the wrapped component.
        public override decimal ApplyDiscount(string name, decimal currentCost)
        {
            return (this.component != null) ? this.component.ApplyDiscount(name, currentCost) : currentCost;
        }
    }
}
