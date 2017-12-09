using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SubtitlesConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            bool addTime = true;
            string sourceFile = "D:\\Projects\\C# Project\\Subtitles\\s.srt";
            string sourceFile2 = "D:\\Projects\\C# Project\\Subtitles\\x.srt";
            string targetFileName = "s3";
            string targetFile = "";
            string pattern = @"(.*\\)([\w]+)(.[\w]+$)";

            Match match = Regex.Match(sourceFile, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                targetFile = match.Groups[1].Value + targetFileName + match.Groups[3].Value;
            }


            //CopyFile.deleteTime(sourceFile, targetFile);
            //CopyFile.copyFile3(sourceFile, sourceFile2, targetFile);
            CopyFile.copyFile(sourceFile, targetFile, 0, 0, 2, 000, addTime);


        }
    }
}
