namespace SieveOfEratosthenes.Core;

/// <remark>
/// This class Generates prime numbers up to a user specified
/// maximum. The algorithm used is the Sieve of Eratosthenes.
///
/// Eratosthenes of Cyrene, b. c. 276 BC, Cyrene, Libya --
/// d. c. 194, Alexandria. The first man to calculate the
/// circumference of the Earth. Also known for working on
/// calendars with leap years and ran the library at
/// Alexandria.
///
/// The algorithm is quite simple. Given an array of integers
/// starting at 2. Cross out all multiples of 2. Find the
/// next uncrossed integer, and cross out all of its multiples.
/// Repeat until you have passed the square root of the
/// maximum value.
///
/// Written by Robert C. Martin on 9 Dec 1999 in Java
/// Translated to C# by Micah Martin on 12 Jan 2005.
///</remark>


/// <summary>
/// author: Robert C. Martin
/// </summary>
public class GeneratePrimes
{
  private static int s;
  private static bool[] f;
  private static int[] primes;
  ///<summary>
  /// Generates an array of prime numbers.
  ///</summary>
  ///
  /// <param name="maxValue">The generation limit.</param>
  public static int[] GeneratePrimeNumbers(int maxValue)
  {
    if (maxValue >= 2) // the only valid case
    {
      InitializeSieve(maxValue);
      Sieve();
      LoadPrimes();

      return primes;
    }

    // maxValue < 2
    return Array.Empty<int>(); // return null array if bad input.
  }

  private static void LoadPrimes()
  {
    int j;
    int i;

    // how many primes are there?
    int count = 0;
    for (i = 0; i < s; i++)
    {
      if (f[i])
        count++; // bump count.
    }

    primes = new int[count];

    // move the primes into the result
    for (i = 0, j = 0; i < s; i++)
    {
      if (f[i]) // if prime
        primes[j++] = i;
    }
  }

  private static void Sieve()
  {
    // sieve
    int i;
    int j;
    for (i = 2; i < Math.Sqrt(s) + 1; i++)
    {
      if (f[i]) // if i is uncrossed, cross its multiples.
      {
        for (j = 2 * i; j < s; j += i)
          f[j] = false; // multiple is not prime
      }
    }
  }

  private static void InitializeSieve(int maxValue)
  {
    // declarations
    s = maxValue + 1;
    f = new bool[s];
    int i;

    // initialize array to true.
    for (i = 0; i < s; i++)
      f[i] = true;

    // get rid of known non-primes
    f[0] = f[1] = false;
  }
}
