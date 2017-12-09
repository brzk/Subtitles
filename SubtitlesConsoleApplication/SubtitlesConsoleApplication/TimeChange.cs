using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SubtitlesConsoleApplication
{
    class TimeChange
    {
        static string pattern = @"(\w\w):(\w\w):(\w\w),(\w\w\w) --> (\w\w):(\w\w):(\w\w),(\w\w\w)";

        static int startHour;
        static int startMinutes;
        static int startSeconds;
        static int startMiliSeconds;

        static int endHour;
        static int endMinutes;
        static int endSeconds;
        static int endMiliSeconds;


        static int changeHour;
        static int changeMinutes;
        static int changeSeconds;
        static int changeMiliSeconds;

        public static string change(string i_Line, int i_Hour, int i_Minutes, int i_Seconds, int i_MiliSeconds, bool i_AddTime)
        {
            changeHour = i_Hour;
            changeMinutes = i_Minutes;
            changeSeconds = i_Seconds;
            changeMiliSeconds = i_MiliSeconds;
            Match match = Regex.Match(i_Line, pattern, RegexOptions.IgnoreCase);

            // Here we check the Match instance.
            if (match.Success)
            {
                string newLine;

                // Finally, we get the Group value and display it.
                startHour = Int32.Parse(match.Groups[1].Value);
                startMinutes = Int32.Parse(match.Groups[2].Value);
                startSeconds = Int32.Parse(match.Groups[3].Value);
                startMiliSeconds = Int32.Parse(match.Groups[4].Value);
                endHour = Int32.Parse(match.Groups[5].Value);
                endMinutes = Int32.Parse(match.Groups[6].Value);
                endSeconds = Int32.Parse(match.Groups[7].Value);
                endMiliSeconds = Int32.Parse(match.Groups[8].Value);

                if (i_AddTime)
                {
                    addTime(ref startHour, ref startMinutes, ref startSeconds, ref startMiliSeconds);
                    addTime(ref endHour, ref endMinutes, ref endSeconds, ref endMiliSeconds);
                }
                else
                {
                    subtractTime(ref startHour, ref startMinutes, ref startSeconds, ref startMiliSeconds);
                    subtractTime(ref endHour, ref endMinutes, ref endSeconds, ref endMiliSeconds);
                }

                string startHourText = (startHour < 10) ? "0" + startHour : "" + startHour;
                string startMinuteText = (startMinutes < 10) ? "0" + startMinutes : "" + startMinutes;
                string startSecondText = (startSeconds < 10) ? "0" + startSeconds : "" + startSeconds;
                string startMiliSecondsText = (startMiliSeconds < 100) ?
                    ((startMiliSeconds < 10) ? "00" + startMiliSeconds : "0" + startMiliSeconds) :
                    "" + startMiliSeconds;

                string endHourText = (endHour < 10) ? "0" + endHour : "" + endHour;
                string endMinuteText = (endMinutes < 10) ? "0" + endMinutes : "" + endMinutes;
                string endSecondText = (endSeconds < 10) ? "0" + endSeconds : "" + endSeconds;
                string endMiliSecondsText = (endMiliSeconds < 100) ?
                    ((endMiliSeconds < 10) ? "00" + endMiliSeconds : "0" + endMiliSeconds) :
                    "" + endMiliSeconds;

                newLine = string.Format("{0}:{1}:{2},{3} --> {4}:{5}:{6},{7}", startHourText
                    , startMinuteText, startSecondText, startMiliSecondsText
                    , endHourText, endMinuteText, endSecondText, endMiliSecondsText);

                return newLine;
            }

            return i_Line;
        }

        private static void addTime(ref int io_Hour, ref int io_Minutes, ref int io_Seconds, ref int io_MiliSeconds)
        {
            int carry = 0;
            io_MiliSeconds += changeMiliSeconds;

            if (io_MiliSeconds >= 1000)
            {
                carry = 1;
                io_MiliSeconds %= 1000;
            }

            io_Seconds += changeSeconds + carry;
            carry = 0;

            if (io_Seconds >= 60)
            {
                carry = 1;
                io_Seconds %= 60;
            }

            io_Minutes += changeMinutes + carry;
            carry = 0;

            if (io_Minutes >= 60)
            {
                carry = 1;
                io_Minutes %= 60;
            }

            io_Hour += changeHour + carry;
        }

        private static void subtractTime(ref int io_Hour, ref int io_Minutes, ref int io_Seconds, ref int io_MiliSeconds)
        {
            int carry = 0;
            io_MiliSeconds -= changeMiliSeconds;           

            if (io_MiliSeconds < 0)
            {
                carry = 1;
                io_MiliSeconds += 1000;
            }

            io_Seconds -= (changeSeconds + carry);            
            carry = 0;

            if (io_Seconds < 0)
            {
                carry = 1;
                io_Seconds += 60;
            }

            io_Minutes -=  (changeMinutes + carry);
            carry = 0;

            if (io_Minutes < 0)
            {
                carry = 1;
                io_Minutes += 60;
            }

            io_Hour -= (changeHour + carry);
        }        
    }    
}

