using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp {

    public abstract class Operation {

        public static List<Operation> ALL_OPERATIONS = new List<Operation>() {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division(),
        };

        public string operationName;

        public int minInputsCount;
        public int maxInputsCount;

        public bool IsValid(int elementsCount) {
            if (maxInputsCount >= elementsCount && elementsCount >= minInputsCount) {
                return true;
            }
            else return false;
        }

        public abstract double Calculate(List<double> inputs);

    }


#region OperationDefinitions

    public class Addition : Operation {
        public Addition() {
            operationName = "Add";
            minInputsCount = 1;
            maxInputsCount = int.MaxValue;
        }
        public override double Calculate(List<double> inputs) {
            return CalculateStatic(inputs);
        }

        public static double CalculateStatic(List<double> inputs) {
            double solution = 0;
            foreach(double element in inputs) {
                solution = solution + element;
            }
            return solution;
        }

    }

    public class Subtraction : Operation {
        public Subtraction() {
            operationName = "Subtract";
            minInputsCount = 1;
            maxInputsCount = int.MaxValue;
        }
        public override double Calculate(List<double> inputs) {
            int i = 0;
            while(i < inputs.Count) {
                if (i == 0) {
                    //Don't flip first element to negative
                } else {
                    inputs[i] = inputs[i] * -1;
                }
                i = i + 1;
            }
            return Addition.CalculateStatic(inputs);
        }
    }

    public class Multiplication : Operation {
        public Multiplication() {
            operationName = "Multiply";
            minInputsCount = 1;
            maxInputsCount = int.MaxValue;
        }
        public override double Calculate(List<double> inputs) {
            double solution = 1;
            foreach(double element in inputs) {
                solution = solution * element;
            }
            return solution;
        }
    }

    public class Division : Operation {
        public Division() {
            operationName = "Divide";
            minInputsCount = 2;
            maxInputsCount = 2;
        }
        public override double Calculate(List<double> inputs) {
            double numerator = inputs[0];
            double denominator = inputs[1];
            return numerator / denominator;
        }
    }
    #endregion
}
