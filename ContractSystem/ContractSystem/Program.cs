using ContractSystem.Entities;
using ContractSystem.Services;
using System.Globalization;

namespace ContractGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the contract data");

            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine());

            Console.Write("Enter the number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumber, contractDate, contractValue);
            ContractService contractService = new ContractService(new PaypalService());

            contractService.ProcessContract(myContract, installments);

            Console.WriteLine("Installments: ");

            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}