using SieveOfEratosthenes.Core;

namespace SieveOfEratosthenes.Tests;

public class GeneratePrimesTest
{
    [Fact]
    public void TestPrimes()
    {
        int[] nullArray = GeneratePrimes.GeneratePrimeNumbers(0);
        Assert.Empty(nullArray);

        int[] minArray = GeneratePrimes.GeneratePrimeNumbers(2);
        Assert.Single(minArray);
        Assert.Equal(2, minArray[0]);

        int[] threeArray = GeneratePrimes.GeneratePrimeNumbers(3);
        Assert.Equal(2, threeArray.Length);
        Assert.Equal(2, threeArray[0]);
        Assert.Equal(3, threeArray[1]);

        int[] centArray = GeneratePrimes.GeneratePrimeNumbers(100);
        Assert.Equal(25, centArray.Length);
        Assert.Equal(97, centArray[24]);
    }
}