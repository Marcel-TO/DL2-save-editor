namespace Editor_Model.Logic
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class FileAnalizer
    {
        private static byte[] startSequence = new byte[]
        {
            0x41, 0x6E, 0x74, 0x69, 0x7A, 0x69, 0x6E, 0x43,
            0x61, 0x70, 0x61, 0x63, 0x69, 0x74, 0x79, 0x55,
            0x70, 0x67, 0x72, 0x61, 0x64, 0x65, 0x53, 0x74,
            0x61, 0x6D, 0x69, 0x6E, 0x61, 0x5F, 0x73, 0x6B,
            0x69, 0x6C, 0x6C
        };

        private static byte[] endSequence = new byte[]
        {
            0x50, 0x72, 0x6F, 0x67, 0x72, 0x65, 0x73, 0x73,
            0x69, 0x6F, 0x6E, 0x53, 0x74, 0x61, 0x74, 0x65,
            0x3A, 0x3A, 0x45, 0x45, 0x6C, 0x65, 0x6D, 0x65,
            0x6E, 0x74, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F,
            0x6E
        };

 
        public FileAnalizer()
        {

        }

        public byte[] ExtractNecessaryBytes(byte[] data)
        {
            int startIndex = this.FindSequenceIndex(data, endSequence, true);
            int endIndex = this.FindSequenceIndex(data, endSequence, false);
            
            if (startIndex < 0 || endIndex <= 0)
            {
                return null;
            }

            byte[] compactData = new byte[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++) 
            {
                compactData[i - startIndex] = data[i];
            }

            return compactData;
        }

        public string[] ConvertBytesToString(byte[] data)
        {
            List<string> matches = new List<string>();
            string stringData = Encoding.UTF8.GetString(data);
            
            string pattern = @"([A-Za-z0-9_]+_skill)(..)";
            MatchCollection matchCollection = Regex.Matches(stringData, pattern);

            foreach (Match match in matchCollection)
            {
                if (match.Success)
                {
                    matches.Add(match.Value);
                }
            }

            return matches.ToArray();
        }

        private int FindSequenceIndex(byte[] data, byte[] sequence, bool isStart)
        {
            // iterates through the data.
            for (int i = 0; i < data.Length - sequence.Length; i++)
            {   
                // resets values for each inner iteration.
                bool isValid = true;
                int lastIndex = 0;

                

                // checks if the sequence starts with the same value as the current data.
                for (int s = 0; s < sequence.Length; s++)
                {
                    lastIndex = i + s;
                    if (data[lastIndex] != sequence[s])
                    {
                        isValid = false;
                        break;
                    }
                }

                // checks if it is the start sequence or the end sequence.
                if (isValid && isStart)
                {
                    return lastIndex + 1;
                }
                else if (isValid)
                {
                    return i;
                }
            } 

            // returns negative if sequence not found.
            return -1;
        }   
    }
}