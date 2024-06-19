using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CDMangager.Model.Entities;

internal class FileSavingHelper
{
    private static readonly string _Path = "S:/Tim-Zander/1 - SWD/CD_Datenbank/CD.xml";

    internal static long FindWriteablePosition()
    {
        string FileEnd = "</CDList>";
        long character = 0;
        var reader = new StreamReader(_Path);
        while (!reader.EndOfStream)
        {
            var data = reader.ReadLine();
            character += data.Length;

            if (data.Equals(FileEnd))
            {
                reader.Close();
                return character - FileEnd.Length;
            }
        }
        reader.Close();
        throw new Exception("No Writeable Line was Found!");
    }

    internal static void WriteCDToXmlFile(CD cd)
    {
        //if (!Path.Exists(_Path))
        //{
        //    var preperationStream = File.Create(_Path);
        //    StringBuilder builder = new();
        //    builder.AppendLine("<CDList>");
        //    builder.AppendLine();
        //    builder.AppendLine("</CDList>");
        //    preperationStream.Write(Encoding.UTF8.GetBytes(builder.ToString()));
        //    preperationStream.Close();
        //}
        var FirstWriteableLine = FindWriteablePosition();
        var _File = new StreamWriter(_Path, true);
        _File.BaseStream.Seek(FirstWriteableLine, SeekOrigin.Begin);
        _File.Write(cd.ToXmlBlock());
        _File.Close();
    }
}
