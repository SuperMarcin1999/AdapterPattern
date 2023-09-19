using System.Collections.Generic;

namespace Demo.Clip01
{
    public class Video : IItemWithKeywords
    {
        public string Title { get; }
        public IEnumerable<string> Keywords { get; }

        public Video(string title)
        {
            this.Title = title;
        }
        public override string ToString() =>
            this.Title;
    }
}
