using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp {
    class Program {
        static void Main(string[] args) {

            while (true) {

                Console.WriteLine("Enter up to 3 numbers separated by a space, then hit Enter");

                string input = Console.ReadLine();
                //()split and validate user input, and return individual doubles; return to beginning if input invalid

                double[] numbers = ExtractAndValidate(input);
                if (numbers == null) {
                    continue;
                }

                //()check which operations are valid based on the number of inputs
                List<Operation> validOperations = GetValidOperations(numbers.Length);

                //Ask user to pick one of the valid option, listing the valid operations

                //()check to see if user picked a valid operation, and if they did not ask them to pick again
                //()perform operation and WriteLine answer
                //Writeline "Press Enter to begin again"


            }
        }

        private static double[] ExtractAndValidate(string input) {
            string[] pieces = input.Split(' ', ',');
            double a;
            List<double> numbers = new List<double>();
            foreach(string element in pieces) {
                bool ok = double.TryParse(element, out a);
                if (ok == true) {
                    numbers.Add(a);
                } 
                else {
                    Console.WriteLine("Not a valid entry: " + element);
                    return null;
                }
            }
            return numbers.ToArray();
        }

        private static List<Operation> GetValidOperations(int elementsCount) {
            List<Operation> validOperations = new List<Operation>();
            foreach (Operation operation in Operation.ALL_OPERATIONS) {
                if (operation.IsValid(elementsCount)) {
                    validOperations.Add(operation);
                }
            }
            return validOperations;
        }

    }
}
