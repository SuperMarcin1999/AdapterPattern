using System;
using System.Collections.Generic;

namespace Demo.Clip01;

// Zrobiony po to zeby pokazac, ze element (T) w KeywordIndex musi implementowac ten interface
public interface IItemWithKeywords
{
    public IEnumerable<string> Keywords { get; }

}