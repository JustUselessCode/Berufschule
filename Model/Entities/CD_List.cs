
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CDMangager.Model.Entities;

internal class CD_List : IEnumerable<CD>
{
    private List<CD> cDs { get; set; }

    private CD? CurrentElement { get; set; }

    private int Pointer { get; set; }

    public CD_List()
    {
        cDs = new();
        CurrentElement = null;
        Pointer = -1;
    }

    public void Add(CD cd)
    {
        cDs.Add(cd);
        Last();
    }

    public CD FindTitle(string title)
    {
        foreach (CD cd in cDs)
        {
            if (cd.Title == title)
            {
                return cd;
            }
        }

        throw new CDNotFoundException("No CD with the specified Title was found!");
    }

    public CD FindArtist(string ArtistName)
    {
        foreach (CD cd in cDs)
        {
            if (cd.Artist == ArtistName)
            {
                return cd;
            }
        }

        //return cDs.FirstOrDefault(cd => cd.Artist == ArtistName);

        throw new CDNotFoundException("No CD with the specified Artist was found!");
    }

    public List<CD> FindMultipleTitles(string title)
    {
        List<CD> list = new();

        foreach (CD cd in cDs)
        {
            if (cd.Title == title)
            {
                list.Add(cd);
            }
        }

        return list;
    }

    public List<CD> FindMultipleArtists(string ArtistName)
    {
        List<CD> list = new();

        foreach (CD cd in cDs)
        {
            if (cd.Artist == ArtistName)
            {
                list.Add(cd);
            }
        }

        return list;
    }

    public void First()
    {
        CurrentElement = cDs.First();
        Pointer = 0;
    }

    public CD? GetCurrentCD()
    {
        return CurrentElement;
    }

    public void Last()
    {
        CurrentElement = cDs.Last();
    }

    public void Next()
    {
        if (Pointer + 1 >= cDs.Count())
        {
            CurrentElement = cDs[Pointer];
            return;
        }

        Pointer += 1;
        CurrentElement = cDs[Pointer];
    }

    public void Previous()
    {
        Pointer -= 1;
        CurrentElement = cDs[Pointer];
    }

    public void DeleteCD()
    {
        cDs.RemoveAt(Pointer);
        First();
    }

    public void Sort()
    {
        cDs = cDs.OrderBy(cd => cd.Artist).ThenBy(cd => cd.Title).ToList();
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var cd in cDs)
        {
            sb.AppendLine(cd.ToString());
        }

        return sb.ToString();
    }

    public IEnumerator<CD> GetEnumerator()
    {
        return ((IEnumerable<CD>)cDs).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return cDs.GetEnumerator();
    }
}
