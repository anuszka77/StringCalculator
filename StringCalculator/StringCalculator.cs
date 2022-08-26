using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {

            if(numbers.Length == 0)
            {
                return 0;
            }
            else
            {
                string[] result = new string[3] { "\n", ",", ";" };


                if (numbers.StartsWith("//"))
                {
                    numbers = numbers.Replace("//", "");
                    string[] val = numbers.Split("\n");

                    string[] listOfDelimiter = val[0].Replace("]","").Split("[");

                    if (listOfDelimiter.Length > 1)
                    {
                        result = new string[listOfDelimiter.Length + 3];
                        listOfDelimiter.CopyTo(result, 0);
                        result[result.Length-1] = "\n";
                        result[result.Length - 2] = ",";
                        result[result.Length - 3] = ";";
                    }

                }

                string[] values = numbers.Split( result, StringSplitOptions.RemoveEmptyEntries);
                int sum = 0;
                string wrongNumbers = "";
                foreach(var number in values)
                {
                    if (number.Contains("[") || number.Contains("]"))
                    {
                        continue;
                    }
                    int val = int.Parse(number);

                    if (val< 0)
                    {
                        wrongNumbers = string.Concat(wrongNumbers, val, ";");

                    }
                    
                    else if(val<=1000)
                    {                      
                        sum += val;
                    }
                  
                }

                if (!string.IsNullOrEmpty(wrongNumbers))
                {
                    throw new Exception($"negatives not allowed: {wrongNumbers}");
                }

                return sum;
            }         
        }
    }
}
