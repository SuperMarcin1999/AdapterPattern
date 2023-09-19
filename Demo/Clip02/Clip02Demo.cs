using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 2;
        protected override void Implementation()
        {
            KeywordIndex<IWithSimpleKeywords> index = new KeywordIndex<IWithSimpleKeywords>();

            Book book = new Book("The Largest Book Ever", "long", "boring");
            Video video = new Video("The Longest Video Ever");

            var videoKeywords = new VideoKeywords(video);
            
            index.Add(book);
            index.Add(videoKeywords);
            Console.WriteLine(index);
            Console.WriteLine();

            string query = "long";
            Console.WriteLine("Find:");
            IEnumerable<IWithSimpleKeywords> results1 = index.Find(query);
            Console.WriteLine($"Searching for '{query}': {results1.ToSequenceString(", ")}");
            
            Console.WriteLine("Find approximate:");
            IEnumerable<IWithSimpleKeywords> results2 = index.FindApproximate(query);
            Console.WriteLine($"Searching for '{query}': {results2.ToSequenceString(", ")}");
        }
    }
}
