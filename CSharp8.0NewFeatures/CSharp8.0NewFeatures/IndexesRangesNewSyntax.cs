using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0NewFeatures
{
  public class IndexesRangesNewSyntax
  {
    public static void Demo()
    {
      var length = 1000;
      var array = Enumerable.Range(0, length).ToArray();
      // Indeksy
      Console.WriteLine("Prezentacja indeksów Index");

      // Składnia ta jest tłumaczona na wyrażenie Array.Length - Value,
      // także jakbyśmy przekazali tu wartość większą niż rozmiar tablicy, otrzymlibyśmy
      // indeks ujemny i wyjątek.
      Index idx = ^length;
      Console.WriteLine($"element at {idx} is {array[idx]}");

      try { idx = ^(length + 1); var item = array[idx]; }
      catch (IndexOutOfRangeException){ Console.WriteLine("Indeks poza zakresem!"); }
      // Chcąc pobrać ostatni elemnt, musimy uważać bo ^0 zostanie przetłumaczone na Array.Length, które jest poza zakresem.
      try { idx = ^0; var item = array[idx]; }
      catch (IndexOutOfRangeException) { Console.WriteLine("Indeks poza zakresem!"); }

      Console.WriteLine($"last element is {array[^1]}");

      // Zakresy
      Console.WriteLine("\nPrezentacja zakresów Range");
      // Początek włącznie, koniec jest wykluczony, zatem taki zakres do nam całą tablicę.
      Range rng = 0..array.Length;
      var rangedArray = array[rng];
      Console.WriteLine($"Ranged array length is {rangedArray.Length}, first element is {rangedArray[0]}, last is {rangedArray[^1]}");
      rangedArray = array[4..10];
      Console.WriteLine($"Range from array specified as 4..10 is: {string.Join(", ", rangedArray)}");
    }
  }
}
