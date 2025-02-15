/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: GenerateRandomString.cs
 *  @brief This lab shows how to generate a random number and text
 *
 *  @details: It asks the user to select one of the two options. 
 * [1] Generate a random number with a predefined boundries by the user.
 * [2] Generate a random text with combinations of letters, digits, and symbols
 * based on the user preferences.
 * 
 *****************************************************************************/

using System.Text;
namespace CSharpLabs;

[Flags]
public enum RandomString
{
  None = 0,
  Letters = 1,
  Numbers = 2,
  Symbols = 4
}
class Program
{
  public static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("Please, select an option:-");
      Console.WriteLine("[1] Generate a random number\n[2] Generate a random string");
      string option = Console.ReadLine();
      if (option == "1")
      {
        Random random = new Random();
        Console.Write("Please, enter the minimum value: ");
        int minValue = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the maximum value: ");
        int maxValue = int.Parse(Console.ReadLine());
        int randomNumber = random.Next(minValue, maxValue + 1);
        Console.WriteLine(randomNumber);
      }
      else if (option == "2")
      {
        Console.Write("Please, enter the length of the string: ");
        int stringLength = int.Parse(Console.ReadLine());

        Console.WriteLine("Please, select the buffer options:-");
        RandomString word = RandomString.None;

        Console.Write("[1] Included Letters (yes/no)?: ");
        string answer = Console.ReadLine();
        if (String.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
          word |= RandomString.Letters;

        Console.Write("[2] Included Digits (yes/no)?: ");
        answer = Console.ReadLine();
        if (String.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
          word |= RandomString.Numbers;

        Console.Write("[3] Included Symbols (yes/no)?: ");
        answer = Console.ReadLine();
        if (String.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
          word |= RandomString.Symbols;

        string randomString = GenerateRandomString(stringLength, (int)word);
        Console.WriteLine(randomString);
      }
      else
      {
        Console.WriteLine("Invalid Option!");
      }
    }
  }

  /// <summary>
  /// Generate random string 
  /// </summary>
  /// <param name="length"> string length  </param>
  /// <param name="option"> buffer option  </param>
  /// <returns> It returns <see langword="string"/> value </returns>
  public static string GenerateRandomString(int length, int option)
  {
    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    string numbers = "1234567890";
    string symbols = "!@#$%^&*()_=+";
    StringBuilder sb = new StringBuilder(length);

    switch (option)
    {
      case 1:
        GetRandomString(sb, letters, length);
        break;
      case 2:
        GetRandomString(sb, numbers, length);
        break;
      case 3:
        GetRandomString(sb, letters + numbers, length);
        break;
      case 4:
        GetRandomString(sb, symbols, length);
        break;
      case 5:
        GetRandomString(sb, letters + symbols, length);
        break;
      case 6:
        GetRandomString(sb, numbers + symbols, length);
        break;
      case 7:
        GetRandomString(sb, letters + numbers + symbols, length);
        break;
      default:
        Console.WriteLine("Invalid Option!");
        break;
    }
    return sb.ToString();
  }

  /// <summary>
  /// Generate RandomString 
  /// </summary>
  /// <param name="sb"> StringBuilder variable to store the word </param>
  /// <param name="chars"> string chars to be used to randomly </param>
  /// <param name="size"> int size of string chars </param>
  public static void GetRandomString(StringBuilder sb, string chars, int size)
  {
    Random rand = new Random();
    while (size > 0)
    {
      sb.Append(chars[rand.Next(chars.Length)]);
      size--;
    }
  }
}