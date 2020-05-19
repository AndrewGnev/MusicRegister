using System;

namespace lab1{
    public static class check_time_format{
        
        /// <summary>
        /// Function for check is string, that must be time parameter of track, in correct format
        /// </summary>
        /// <param name="time">String that must be time parameter of track</param>
        /// <returns>true if in correct format, false - in incorrect</returns>
        public static bool Check(string time){
            String[] a = time.Split(':');
            if (a.Length != 2) return false;

            int minutes, seconds;

            return int.TryParse(a[0], out minutes) && int.TryParse(a[1], out seconds) && minutes < 60 && seconds < 60 && minutes >= 0 && seconds >= 0;
        }
    }
}