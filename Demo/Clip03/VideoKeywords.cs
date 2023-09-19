using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Clip03
{
    public class VideoKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private readonly IEnumerable<string> _externalKeywords;
        private Video Target { get; }
        
        public VideoKeywords(Video target, IEnumerable<string> externalKeywords)
        {
            _externalKeywords = externalKeywords;
            this.Target = target;
        }

        private IEnumerable<string> SkipWords { get; } = new[]
        {
            "no", "by", "off", "of" // ...
        };
        
        public override string ToString() =>
            this.Target.Title;

        public IEnumerable<string> Keywords =>
            _externalKeywords.Any() ? _externalKeywords : GenerateKeywords();
            

        private IEnumerable<string> GenerateKeywords() =>
                BreakIntoWords(Target.Title)
                    .Distinct()
                    .Where(x => !SkipWords.Contains(x));
        
        
        public IEnumerable<string> BreakIntoWords(string content) =>
            Regex.Matches(content, @"[\p{L}0-9-]+")
                .Select(match => match.Value);
        
        public override bool Equals(object obj) =>
            obj is VideoKeywords keywords && this.Equals(keywords);

        public bool Equals(IWithSimpleKeywords other) =>
            other is VideoKeywords keywords && this.Equals(keywords);

        private bool Equals(VideoKeywords other) =>
            this.Target.Equals(other.Target);

        public override int GetHashCode() =>
            this.Target.GetHashCode();
    }
}