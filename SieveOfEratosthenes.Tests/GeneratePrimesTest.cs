using SieveOfEratosthenes.Core;

namespace SieveOfEratosthenes.Tests;

public class GeneratePrimesTest
{
    [Fact]
    public void TestPrimes()
    {
        int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
        Assert.Empty(nullArray);
        
        int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
        Assert.Single(minArray);
        Assert.Equal(2, minArray[0]);
        
        int[] threeArray = PrimeGenerator.GeneratePrimeNumbers(3);
        Assert.Equal(2, threeArray.Length);
        Assert.Equal(2, threeArray[0]);
        Assert.Equal(3, threeArray[1]);

        int[] centArray = PrimeGenerator.GeneratePrimeNumbers(100);
        Assert.Equal(25, centArray.Length);
        Assert.Equal(97, centArray[24]);
    }

    [Fact]
    public void TestExhaustive()
    {
        for (int i = 2; i < 500; i++)
            VerifyPrimeList(PrimeGenerator.GeneratePrimeNumbers(i));
    }

    private void VerifyPrimeList(int[] list)
    {
        foreach (var t in list)
            VerifyPrime(t);
    }

    private void VerifyPrime(int n)
    {
        for (int factor = 2; factor < n; factor++)
            Assert.True(n % factor != 0);
    }
}