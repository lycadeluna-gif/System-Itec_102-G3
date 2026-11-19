using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace RestaurantOrderSystem
{
    partial class Program
    {
        // ========================= INPUT HELPERS =========================
        static string ReadInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return (input ?? &quot; &quot;).Trim();
        }
        // Returns the number, or -1 if the input is blank / not a whole number / out of range.
        // NumberStyles.None rejects decimals, signs, spaces and letters. (CUR 5, SPR 3)
        static int ReadNumberInRange(string prompt, int min, int max)
        {
            string input = ReadInput(prompt);
            if (input == &quot; &quot;)
{
                Console.WriteLine(&quot; Input cannot be blank.&quot;);
                return -1;
            }
            if (!int.TryParse(input, NumberStyles.None, Inv, out int value))
            {
                Console.WriteLine(&quot; Invalid input. Enter a whole number only(no letters or decimals).& quot;);
                return -1;
            }
            if (value & lt; min || value & gt; max)
{
                Console.WriteLine(&quot; Out of range.Enter a number from & quot; +min + &quot; to & quot; +max + &quot;.&quot;);
                return -1;
            }
            return value;
        }
        // PRR 1: nonnegative amount, max two decimal places
        static bool TryParseCash(string input, out decimal cash)
        {
            cash = 0m;
            if (input == &quot; &quot;)
{
                return false;
            }
            if (!decimal.TryParse(input, NumberStyles.AllowDecimalPoint, Inv, out cash))
            {
                return false; // text, negative sign, commas, etc.
            }
            int dotIndex = input.IndexOf(&#39;.&#39;);

if (dotIndex & gt;= 0 & amp; &amp; input.Length - dotIndex - 1 & gt; 2)
{
                return false; // more than two decimal places
            }
            return true;
        }
        