using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDMangager.Model.Entities;

namespace CDMangager.Model;

static class ManagerFunctionality
{
    public static List<CD> CurrentCDList { get; set; } = new ();

    public static void OpenXMLDatabase(string _Path)
    {
        FileStream stream = new(_Path, FileMode.Open, FileAccess.Read);

    }
}
