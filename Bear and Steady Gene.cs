using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'steadyGene' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING gene as parameter.
     */

    public static int steadyGene(string gene)
    {
        int n = gene.Length;
        int target = n / 4;
        var freq = new Dictionary<char, int>() { {'A',0}, {'C',0}, {'G',0}, {'T',0} };

        // Count total occurrences of each nucleotide
        foreach (char c in gene)
            freq[c]++;

        int minLen = n;
        int left = 0;

        // Sliding window approach
        for (int right = 0; right < n; right++)
        {
            freq[gene[right]]--;

            // Check if remaining outside the window are all <= target
            while (left < n && freq['A'] <= target && freq['C'] <= target &&
                   freq['G'] <= target && freq['T'] <= target)
            {
                minLen = Math.Min(minLen, right - left + 1);
                freq[gene[left]]++;
                left++;
            }
        }

        return minLen;
    }


    }

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string gene = Console.ReadLine();

        int result = Result.steadyGene(gene);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
