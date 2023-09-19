using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip02;

/* Zakładamy że nie możemy edytować klasy Video, dojść często nie możemy/nie chcemy edytować
 istniejącej klasy, więc tworzymy tą klase */
public class VideoKeywords : IWithSimpleKeywords
{
    private Video _video;

    public VideoKeywords(Video video)
    {
        _video = video;
    }

    public IEnumerable<string> Keywords =>
        _video.Title
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length > 3);

    public override string ToString()
    {
        return _video?.ToString() ?? string.Empty;
    }
}