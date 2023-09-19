using System;
using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
        protected override void Implementation()
        {
            var index = new KeywordIndex<Book>();

            var book = new Book("Moja super ksiazka", "long", "boring");
            var video = new Video("Moje ulubione video");
            
            index.Add(book);
            
            /* Nie mozemy dodac video, poniewaz KeywordIndex mamy juz w typie <Book>,
             dlatego powstaje tutaj motywacja do napisania adaptera, ktory pozwolilby stworzyc "wspolny code-base"
             dzięki któremu, book jak i video stały by się kompatybilne pomiędzy sobą */
            //index.Add(video);
            
            Console.WriteLine(index);
            Console.WriteLine();

            var query = "long";
            var results = index.Find(query);
            Console.WriteLine($"Szukam po '{query}': {results.ToSequenceString(", ")}");
        }
    }
}
