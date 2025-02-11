
namespace LenaLearning
{
    public class Fibonacci
    {

        //changed int to long, because I was getting overflow!
        public long GetFibonacciNumberOf(int n) //calculate the n-th Fibonacci number 
        {
            ValidateNonNegative(n);
            ValidateMaximumRange(n);

            long number1 = 0, number2 = 1, nextNumber = number2;

            if (n == 0) 
            { 
                return number1; 
            }

            
            for (int i = 1; i < n; i++) //starts at F2 
            {
            number1 = number2;
            number2 = nextNumber;
            nextNumber = number1 + number2;
            }
            
            return number2;
        }

        public long[] CalcFibonacciUpTo(int n) //returns a array of the Fibonacci numbers up to the current one
        {
            ValidateNonNegative(n);
            ValidateMaximumRange(n);

            long[] result = new long[n+1];

            for (int i = 0; i <= n; i++)
            {
                result[i] = GetFibonacciNumberOf(i); //store Fi in the index i
            }

            return result;
        }

        public long[] CalcFibonacciBetween(int a, int b)
        {
            if (b < a)
            {
                throw new MyException("The second number must be higher or equal to the first one");
            }

            ValidateNonNegative(a);
            ValidateNonNegative(b);
            ValidateMaximumRange(b);


            long[] result = new long[b-a+1];

            for (int i = a; i <= b; i++)
            {
                result[i-a] = GetFibonacciNumberOf(i);
            }

            return result;
        }

        //validation methods
        private void ValidateNonNegative(int number)
        {
            if (number < 0) //error if user input <0
            {
                throw new MyException("Number must be higher than 0");
            }
        }

        private void ValidateMaximumRange(int number)
        {
            if (number > 92)
            {
                throw new MyException("Due to calculation constrains, number must be lower than 92");
            }
        }
    }
}
