using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp {
    public class Program {

        public static void Main(string[] args) {
            try {
                CalculatorLoop();
            }
            catch(ExitException) {
            }
        }


        static void CalculatorLoop() {

            while (true) {

                Console.WriteLine("Enter numbers separated by a space, then hit Enter");

                string input = ExitCheckReadLine();

                //()split and validate user input, and return individual doubles; return to beginning if input invalid
                double[] numbers = ExtractAndValidate(input);
                if (numbers == null) {
                    continue;
                }

                //()check which operations are valid based on the number of inputs
                List<Operation> validOperations = GetValidOperations(numbers.Length);
                if (validOperations.Count == 0) {
                    Console.WriteLine("There are no valid operations for this number of entries");
                    continue;
                }

                //Ask user to pick a valid option, looping until success
                Operation chosenOperation = ChooseOperation(validOperations);

                //()perform operation and WriteLine answer
                CalculateAndPrint(numbers, chosenOperation);

                //Writeline "Press Enter to begin again"
                Console.WriteLine();
                Console.WriteLine("Press Enter to begin again, or type 'Exit' to end the program");
                ExitCheckReadLine();
            }
        }


        public static double[] ExtractAndValidate(string input) {
            string[] pieces = input.Split(' ', ',');
            double a;
            List<double> numbers = new List<double>();
            foreach (string element in pieces) {
                bool ok = double.TryParse(element, out a);
                if (ok == true) {
                    numbers.Add(a);
                } else {
                    Console.WriteLine("Not a valid entry: " + element);
                    return null;
                }
            }
            return numbers.ToArray();
        }

        public static List<Operation> GetValidOperations(int elementsCount) {
            List<Operation> validOperations = new List<Operation>();

            foreach (Operation operation in Operation.ALL_OPERATIONS) {
                if (operation.IsValid(elementsCount)) {
                    validOperations.Add(operation);
                }
            }
            return validOperations;
        }

        public static Operation ChooseOperation(List<Operation> validOperations) {
            while (true) {
                Console.WriteLine("Choose from the following valid operatons: ");
                foreach (Operation operation in validOperations) {
                    Console.Write(operation.operationName + ", ");
                }
                Console.WriteLine();
                Console.WriteLine("Type in the name of an operation and press 'Enter'");
                string input = ExitCheckReadLine();

                foreach (Operation operation in validOperations) {
                    if (input == operation.operationName) {
                        return operation;
                    }
                }
                Console.WriteLine("Not a valid entry; please choose a valid operation");
            }
        }

        private static void CalculateAndPrint(double[] numbers, Operation chosenOperation) {
            Console.WriteLine("Soluton:");
            double solution = chosenOperation.Calculate(numbers.ToList());
            if(double.IsNegativeInfinity(solution)) {
                Console.WriteLine("-infinity");
            }
            else if (double.IsPositiveInfinity(solution)) {
                Console.WriteLine("infinity");
            } 
            else
                Console.WriteLine(solution);
            //Console.WriteLine(chosenOperation.Calculate(numbers.ToList()));
        }

        public static string ExitCheckReadLine() {
            string input = Console.ReadLine();
            if (input == "Exit") {
                throw new ExitException();
            }
            return input;
        }

        private class ExitException : Exception { }
    }
}
