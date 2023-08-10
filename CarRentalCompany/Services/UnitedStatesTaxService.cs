namespace CarRentalCompany.Services
{
    internal class UnitedStatesTaxService : ITaxService
    {
        public double Tax(double amount)
        {
            return amount * 0.10;
        }
    }
}