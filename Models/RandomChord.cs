using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChordSpitterAPI.Models
{
    public static class RandomChord
    {
        private static Random random = new Random();
        private static string[] qualities = new string[] { "Major", "Minor", "Augmented", "Diminished" };
        private static int[] extensions = new int[] { 6, 7, 9, 11, 13 };
        public static string GenerateRandomChord()
        {
            char rootNote = (char)('A' + random.Next(0, 6)); 
            string accidental = random.Next(0, 1) == 0 ? "" : random.Next(0, 1) == 0 ? "#" : "b";
            string quality = qualities[random.Next(0, 3)];
            string extension = extensions[random.Next(0, 3)].ToString();

            string randomChord = $"{rootNote}{accidental}{quality}{extension}";

            return randomChord;
        }
    }
}
