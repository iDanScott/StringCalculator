using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        List<string> Delimiters;
        public void Initialise()
        {
            Delimiters = new List<string>() { ",", "\n" };
        }
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string[] delimited = numbers.Split(Delimiters.ToArray(), StringSplitOptions.None);
            if (delimited.Length > 0)
            {
                if (delimited[0].Length > 2)
                {
                    if (delimited[0].Substring(0, 2) == "//")
                    {
                        Delimiters.Remove(",");
                        string delimiterString = delimited[0].Substring(2, delimited[0].Length - 2);
                        if (delimiterString.Contains("["))
                        {
                            string[] regexMatch = Regex.Split(delimiterString, "\\[(.*?)\\]");
                            foreach (string match in regexMatch)
                            {
                                if (!string.IsNullOrEmpty(match))
                                {
                                    Delimiters.Add(match);
                                }
                            }
                        }
                        else
                        {
                            Delimiters.Add(delimiterString);
                        }
                        delimited = delimited.Where(x => x.Substring(0, 2) != "//").ToArray();
                    }
                }

                delimited = string.Join(Delimiters[0], delimited).Split(Delimiters.ToArray(), StringSplitOptions.None);
                List<int> negatives = new List<int>();
                int sum = 0;
                foreach (string number in delimited)
                {
                    int parsed = Int32.Parse(number);
                    if (parsed > 0)
                    {
                        if (parsed <= 1000)
                        {
                            sum += parsed;
                        }
                    }
                    else
                    {
                        negatives.Add(parsed);
                    }
                }
                if (negatives.Count > 0)
                {
                    throw new FormatException("negatives not allowed: " + string.Join(", ", negatives.ToArray()));
                }
                return sum;
            }
            throw new Exception();
        }
    }
}