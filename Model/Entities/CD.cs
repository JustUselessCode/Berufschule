using System;
using System.Text;

namespace CDMangager.Model.Entities;

internal class CD
{
    public string Title { get; set; }

    public string Artist { get; set; }

    public TimeSpan Length { get; set; }

    public Guid ID { get; private set; }

    public CD()
    {
        Title = "Unknown";
        Artist = "Unknown Artist";
        Length = TimeSpan.Zero;
        ID = Guid.NewGuid();
    }

    public CD(string title, string artist, TimeSpan length)
    {
        Title = title;
        Artist = artist;
        Length = length;
        ID = Guid.NewGuid();
    }

    public override string ToString()
    {
        var seconds = Length.Seconds < 10 ? $"0{Length.Seconds}" : $"{Length.Seconds}";
        return $"{Artist} - {Title}" + $"   {Length.Minutes}:{seconds}";
    }


    /// <summary>
    /// Compares this Instance to a second CD and checks which cd is larger in the lexigraphical sense.
    /// </summary>
    /// <param name="toCompare"></param>
    /// <returns></returns>
    public int Compare(CD toCompare)
    {
        var resultOne = Artist.CompareTo(toCompare.Artist);
        if (resultOne == 0)
        {
            var resultTwo = Title.CompareTo(toCompare.Title);
            return resultTwo;
        }
        return resultOne;
    }

    public string ToXmlBlock()
    {
        var indentSmall = "  ";
        var indentLarge = "    ";
        var builder = new StringBuilder();
        builder.AppendLine(indentSmall + "<CD>");
        builder.AppendLine(indentLarge + $"<Title>{Title}</Title>");
        builder.AppendLine(indentLarge + $"<Artist>{Artist}</Artist>");
        builder.AppendLine(indentLarge + $"<Duration>{Length}</Duration>");
        builder.AppendLine(indentSmall + "</CD>");
        builder.AppendLine();
        return builder.ToString();
    }
}
