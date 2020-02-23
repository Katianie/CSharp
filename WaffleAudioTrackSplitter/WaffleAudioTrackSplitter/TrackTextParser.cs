using System;
using System.Collections.Generic;

namespace WaffleAudioTrackSplitter
{
    /// <summary>
    /// This class is responsible for reading in the user inputed track names and start times
    /// and putting them into usable data structures.
    /// </summary>
    public class TrackTextParser
    {
        private List<string> myParsedTrackNames;
        private List<string> myParsedTrackStartTimes;

        /// <summary>
        /// Constructor kicks off the parsing process using the provided <c>rawText</c>.
        /// </summary>
        /// <param name="rawText">The full raw user input to parse.</param>
        public TrackTextParser(string rawText)
        {
            ProcessText(rawText);
        }

        /// <summary>
        /// A list of the parsed track names.
        /// </summary>
        public List<string> ParsedTrackNames
        {
            get
            {
                return myParsedTrackNames;
            }
        }

        /// <summary>
        /// A list of the parsed start times.
        /// </summary>
        public List<string> ParsedTrackStartTimes
        {
            get
            {
                return myParsedTrackStartTimes;
            }
        }

        /// <summary>
        /// Starts the parsing process using the <c>rawText</c> to generate
        /// two lists containing the track names and their corresponding start times.
        /// </summary>
        /// <param name="rawText"></param>
        private void ProcessText(string rawText)
        {
            int endIndex;
            string trackName;
            string trackStartTime;
            string previousTrackStartTime = string.Empty;
            List<string> lines = new List<string>();
            
            //Process the main block of text and split it into individual lines.
            while (string.IsNullOrEmpty(rawText) == false)
            {
                //Get the index of the end of line character so we know where it ends.
                endIndex = rawText.IndexOf(Environment.NewLine) + Environment.NewLine.Length;

                //Copy the first line from the main block of text.
                lines.Add(rawText.Substring(0, endIndex));

                //Move past the line we just copied in the main string to get to the next one.
                rawText = rawText.Substring(endIndex);
            }

            if(lines.Count > 0)
            {
                myParsedTrackNames = new List<string>();
                myParsedTrackStartTimes = new List<string>();

                //Process each individual line to get the start time and track name.
                foreach (string currLine in lines)
                {
                    //Separate the start time and the track name.
                    endIndex = currLine.IndexOf(' ') + 1;
                    trackStartTime = currLine.Substring(0, endIndex);
                    trackName = currLine.Substring(endIndex);

                    if(string.IsNullOrEmpty(trackStartTime) == false)
                    {
                        myParsedTrackStartTimes.Add(trackStartTime);
                    }
                    if(string.IsNullOrEmpty(trackName) == false)
                    {
                        myParsedTrackNames.Add(trackName.Trim());
                    }
                }
            }
        }
    }
}
