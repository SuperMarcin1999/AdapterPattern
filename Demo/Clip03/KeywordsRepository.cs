using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip03;

/// <summary>
/// Klasa symulujaca pobieranie danych, uzupelnione recznie przez uzytkownikow
/// np. z bazy danych czy czegokolwiek innego
/// </summary>
internal class KeywordsRepository
{
    public IEnumerable<string> Find(string handler)
    {
        if (handler == "sia-ba-du")
        {
            return new []{"Skubi"};
        }
        
        return Enumerable.Empty<string>();
    }
}