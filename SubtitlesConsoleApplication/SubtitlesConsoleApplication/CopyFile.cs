using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SubtitlesConsoleApplication
{
    class CopyFile
    {
        public static void copyFile(string i_SourceFile, string i_TargetFile, int i_Hour, int i_Minutes, int i_Secnods, int i_MiliSeconds, bool i_AddTime)
        {
            StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.ASCIIEncoding.Default);
            //StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.UTF8Encoding.UTF8);

            StreamWriter targetFile = new StreamWriter(i_TargetFile);
            string CurrentLine;

            while ((CurrentLine = sourceFile.ReadLine()) != null)
            {
                //targetFile.WriteLine(Change.change(CurrentLine, i_Hour,i_Minutes, i_Secnods, i_MiliSeconds,i_AddTime));
                targetFile.WriteLine(TimeChange.change(CurrentLine, i_Hour, i_Minutes, i_Secnods, i_MiliSeconds, i_AddTime));
            }

            sourceFile.Close();
            targetFile.Close();
        }


        static string patternTime = @"(\w\w):(\w\w):(\w\w),(\w\w\w) --> (\w\w):(\w\w):(\w\w),(\w\w\w)";
        static string patternNumber = @"([\d]+)";
        static string patternEmptyLine = @"(^$)";

        public static void deleteTime(string i_SourceFile, string i_TargetFile)
        {
            int number = 1;
            //StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.ASCIIEncoding.Default);
            StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.UTF8Encoding.UTF8);

            StreamWriter targetFile = new StreamWriter(i_TargetFile);
            string CurrentLine;

            while ((CurrentLine = sourceFile.ReadLine()) != null)
            {

                Match matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                Match matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                Match matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                // Here we check the Match instance.
                if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                {

                    targetFile.WriteLine(editLine(ref number, CurrentLine));
                    targetFile.WriteLine(number + " " + CurrentLine);
                    number++;
                }
            }
            sourceFile.Close();
            targetFile.Close();

        }

        //static string patternCharacters = @"(.*)([\.|\!])(\s|)(.*)";

        static string patternCharacters = @"(.*)(\w+)(.*)([\.|\!])(.*)(\w+)(.*)";


        public static void copyFile3(string i_EnSourceFile, string i_HeSourceFile, string i_TargetFile)
        {
            StreamReader HesourceFile = new StreamReader(i_HeSourceFile, System.Text.ASCIIEncoding.Default);
            StreamReader EnsourceFile = new StreamReader(i_EnSourceFile, System.Text.ASCIIEncoding.Default);
            //StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.UTF8Encoding.UTF8);

            StreamWriter targetFile = new StreamWriter(i_TargetFile);
            string CurrentLine;
            //bool isHebrewTwice = false;


            while ((CurrentLine = EnsourceFile.ReadLine()) != null)
            {
                Match matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                Match matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                Match matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                // Here we check the Match instance.
                if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                {
                    targetFile.WriteLine(CurrentLine);


                    //isHebrewTwice = twicetLine(CurrentLine);

                    //if (twicetLine(CurrentLine))

                    //{
                    //    while ((CurrentLine = HesourceFile.ReadLine()) != null)
                    //    {
                    //        matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                    //        matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                    //        matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                    //        if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                    //        {
                    //            targetFile.WriteLine(CurrentLine);
                    //            break;
                    //        }
                    //    }
                    //}


                    while ((CurrentLine = HesourceFile.ReadLine()) != null)
                    {
                        matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                        matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                        matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                        if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                        {
                            targetFile.WriteLine(CurrentLine);
                            break;
                        }
                    }




                    //targetFile.WriteLine(Change.change(CurrentLine, i_Hour,i_Minutes, i_Secnods, i_MiliSeconds,i_AddTime));
                    //targetFile.WriteLine(TimeChange.change(CurrentLine, i_Hour, i_Minutes, i_Secnods, i_MiliSeconds, i_AddTime));
                }
                else
                {
                    targetFile.WriteLine(CurrentLine);
                }
            }
            EnsourceFile.Close();
            HesourceFile.Close();
            targetFile.Close();
        }



        public static void copyFile2(string i_EnSourceFile, string i_HeSourceFile, string i_TargetFile)
        {
            StreamReader HesourceFile = new StreamReader(i_HeSourceFile, System.Text.ASCIIEncoding.Default);
            StreamReader EnsourceFile = new StreamReader(i_EnSourceFile, System.Text.ASCIIEncoding.Default);
            //StreamReader sourceFile = new StreamReader(i_SourceFile, System.Text.UTF8Encoding.UTF8);

            StreamWriter targetFile = new StreamWriter(i_TargetFile);
            string CurrentLine;
            //bool isHebrewTwice = false;


            while ((CurrentLine = EnsourceFile.ReadLine()) != null)
            {
                Match matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                Match matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                Match matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                // Here we check the Match instance.
                if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                {
                    //isHebrewTwice = twicetLine(CurrentLine);

                    if (twicetLine(CurrentLine))

                    {
                        while ((CurrentLine = HesourceFile.ReadLine()) != null)
                        {
                            matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                            matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                            matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                            if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                            {
                                targetFile.WriteLine(CurrentLine);
                                break;
                            }
                        }
                    }


                    while ((CurrentLine = HesourceFile.ReadLine()) != null)
                    {
                        matchTime = Regex.Match(CurrentLine, patternTime, RegexOptions.IgnoreCase);
                        matchNumber = Regex.Match(CurrentLine, patternNumber, RegexOptions.IgnoreCase);
                        matchEmptyLine = Regex.Match(CurrentLine, patternEmptyLine, RegexOptions.IgnoreCase);

                        if (!(matchTime.Success || matchNumber.Success || matchEmptyLine.Success))
                        {
                            targetFile.WriteLine(CurrentLine);
                            break;
                        }
                    }




                    //targetFile.WriteLine(Change.change(CurrentLine, i_Hour,i_Minutes, i_Secnods, i_MiliSeconds,i_AddTime));
                    //targetFile.WriteLine(TimeChange.change(CurrentLine, i_Hour, i_Minutes, i_Secnods, i_MiliSeconds, i_AddTime));
                }
                else
                {
                    targetFile.WriteLine(CurrentLine);
                }
            }
            EnsourceFile.Close();
            HesourceFile.Close();
            targetFile.Close();
        }

        private static bool twicetLine(string i_Line)
        {
            bool isTwiceLine = false;
            Match matchTime = Regex.Match(i_Line, patternCharacters, RegexOptions.IgnoreCase);

            if (matchTime.Success)
            {
                isTwiceLine = true;
            }

            return isTwiceLine;
        }




        private static string editLine(ref int io_Number, string i_Line)
        {
            string newLines = "";
            string currentLine = i_Line;
            Match matchTime = Regex.Match(currentLine, patternCharacters, RegexOptions.IgnoreCase);

            if (matchTime.Success)
            {
                //newLines += io_Number + " " + matchTime.Groups[1].Value + matchTime.Groups[2].Value + Environment.NewLine;

                //io_Number++;
                //currentLine = currentLine.Substring(matchTime.Groups[1].Value.Length + 1);
                //matchTime = Regex.Match(currentLine, patternCharacters, RegexOptions.IgnoreCase);

            }

            return newLines;
        }

    }
}
