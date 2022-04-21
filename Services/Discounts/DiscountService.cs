using BenefitsCalculator.Services.Discounts;

namespace BenefitsCalculator.Services
{
    public class DiscountService
    {
        public decimal CalculateDiscounts(string name, decimal currentCost)
        {
            DefaultDiscount defaultDiscount = new DefaultDiscount();
            SuperSecretDiscount superSecretDiscount = new SuperSecretDiscount(defaultDiscount);
            NameStartsWithADiscountService nameStartsWithADiscountService = new NameStartsWithADiscountService(superSecretDiscount);

            return nameStartsWithADiscountService.ApplyDiscount(name, currentCost);
        }
    }
}
