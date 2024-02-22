using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace downloadSystem.Models
{
    public class Recording
    {
        public int RecordingId { get; set; }
        public string FileName { get; set; }
        public int DurationMinutes { get; set; }
        public int MeetingId { get; set; }

        public byte[] VideoData { get; set; }

        public Recording()
        {
            RecordingId = GeneratorId();
        }

        private int GeneratorId()
        {
            HashSet<int> generatedNumbers = new HashSet<int>();
            Random random = new Random();

            while (true)
            {
                int randomNumber = random.Next(10000000, 99999999); // Generate a random 8-digit number

                if (generatedNumbers.Add(randomNumber))
                {
                    // If the number is not in the set (i.e., it's unique), return it
                    Console.WriteLine(randomNumber);
                    return randomNumber;
                }
            }
        }

    }

}
