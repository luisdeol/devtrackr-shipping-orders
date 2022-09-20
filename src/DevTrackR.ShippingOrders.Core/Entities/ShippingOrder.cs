namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingOrder : EntityBase
    {
        private string GenerateTrackingCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            var code = new char[10];
            var random = new Random();

            for (var i = 0; i < 5; i++) {
                code[i] = chars[random.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++) {
                code[i] = numbers[random.Next(numbers.Length)];
            }

            return new String(code);
        }
    }
}