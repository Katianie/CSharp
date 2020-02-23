using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace WaffleAudioTrackSplitter
{
    /// <summary>
    /// This class is responsible for taking in an single audio file, track names, and track start times and
    /// produces multiple audio files with the given track names. 
    /// </summary>
    public class AudioSplitter
    {
        private int myNumTracks;
        private int myNumTracksProcessed;
        private List<string> myGeneratedCommands;

        //Used to notify the WinForm's progress bar of the current progress.
        public delegate void OnProcessCompleteCallback();
        public event OnProcessCompleteCallback OnProcessCompleted;

        /// <summary>
        /// Constructor is responsible for generating the FFMPEG commands used to split the audio file
        /// into multiple tracks.
        /// </summary>
        /// <param name="filePath">The full file path of the audio file to split.</param>
        /// <param name="parsedTrackNames">A list of track names to use for naming each audio file.</param>
        /// <param name="parsedTrackStartTimes">The start times of each track.</param>
        public AudioSplitter(string filePath, List<string> parsedTrackNames, List<string> parsedTrackStartTimes)
        {
            myGeneratedCommands = GenerateFFMPEGCommands(filePath, parsedTrackNames, parsedTrackStartTimes);
            myNumTracksProcessed = 0;

            if (myGeneratedCommands != null)
            {
                myNumTracks = myGeneratedCommands.Count;
            }
            else
            {
                myNumTracks = 0;
            }
        }

        /// <summary>
        /// Number of tracks produced by the splitting process.
        /// </summary>
        public int NumTracks
        {
            get
            {
                return myNumTracks;
            }
        }

        /// <summary>
        /// Number of tracks that have been processed thus far.
        /// </summary>
        public int NumTracksProcessed
        {
            get
            {
                return myNumTracksProcessed;
            }
        }

        /// <summary>
        /// Start the process of sending the generated commands to FFMPEG to do the actual
        /// splitting of the audio track.
        /// </summary>
        public void StartSplitting()
        {
            Thread currCMDThread;
            
            myNumTracksProcessed = 0;
            foreach (string currCommand in myGeneratedCommands)
            {
                currCMDThread = new Thread(new ParameterizedThreadStart(StartFFMPEG));
                currCMDThread.Start(currCommand);
            }
        }

        /// <summary>
        /// Generates a list of commands containing the track information, start time,
        /// and duration time of each track. This is passed to FFMPEG to generate the files.
        /// </summary>
        /// <param name="filePath">The full file path of the audio file to split.</param>
        /// <param name="parsedTrackNames">A list of track names to use for naming each audio file.</param>
        /// <param name="parsedTrackStartTimes">The start times of each track.</param>
        /// <returns>List of generated commands for FFMPEG to receive.</returns>
        private List<string> GenerateFFMPEGCommands(string filePath, List<string> parsedTrackNames, List<string> parsedTrackStartTimes)
        {
            List<string> commands = null;
            uint trackStartTimeInSeconds;
            uint trackEndTimeInSeconds;
            string currCommand;

            if(string.IsNullOrEmpty(filePath) == false)
            {
                if(parsedTrackNames != null && parsedTrackNames.Count > 0)
                {
                    if(parsedTrackStartTimes != null && parsedTrackStartTimes.Count > 0)
                    {
                        commands = new List<string>();
                        for (int currTrackIndex = 0; currTrackIndex < parsedTrackStartTimes.Count - 1; currTrackIndex++)
                        {
                            trackStartTimeInSeconds = ConvertTimeToSeconds(parsedTrackStartTimes[currTrackIndex]);
                            trackEndTimeInSeconds = ConvertTimeToSeconds(parsedTrackStartTimes[currTrackIndex + 1]) - 1;

                            currCommand = CreateCommand(filePath, trackStartTimeInSeconds, trackEndTimeInSeconds, parsedTrackNames[currTrackIndex]);

                            commands.Add(currCommand);
                        }

                        //Generate command for the last one in the list.
                        trackStartTimeInSeconds = ConvertTimeToSeconds(parsedTrackStartTimes[parsedTrackStartTimes.Count - 1]);
                        currCommand = CreateCommand(filePath, trackStartTimeInSeconds, uint.MaxValue, parsedTrackNames[parsedTrackNames.Count - 1]);
                        commands.Add(currCommand);
                    }
                }
            }

            return commands;
        }

        /// <summary>
        /// Generates a command to send to FFMPEG with the provided arguments.
        /// </summary>
        /// <param name="filePath">The full file path of the audio file to split.</param>
        /// <param name="startTimeInSeconds">The start time of the current track.</param>
        /// <param name="endTimeInSeconds">The end time of the current track.</param>
        /// <param name="trackName">The name of the current track.</param>
        /// <returns>A command used by FFMPEG containing the data from the provided arguments.</returns>
        private string CreateCommand(string filePath, uint startTimeInSeconds, uint endTimeInSeconds, string trackName)
        {
            string fileFolder;
            string trackFileName;
            string command = string.Empty;

            if (string.IsNullOrEmpty(filePath) == false && string.IsNullOrEmpty(trackName) == false)
            {
                //Get the parent folder of the file we are splitting.
                fileFolder = filePath.Substring(0, filePath.LastIndexOf('\\'));

                //Construct the current track filename (full file path + track name + .mp3).
                trackFileName = string.Format(@"{0}\{1}.mp3", fileFolder, trackName);

                //For the last track, the end time is not known.
                if(endTimeInSeconds == uint.MaxValue)
                {
                    //D:\KatianieWorkspace\WaffleAudioTrackSplitter\WaffleAudioTrackSplitter\bin\Release\ffmpeg.exe -ss 0 -t 30 -i "I:\Music\Techno\HappyHardcore\Party Animals - Good Vibrations.mp3" "I:\Music\Techno\HappyHardcore\a.mp3"
                    command = string.Format("-sseof -{0} -i \"{1}\" \"{2}\"", startTimeInSeconds, filePath, trackFileName);
                }
                else
                {
                    //D:\KatianieWorkspace\WaffleAudioTrackSplitter\WaffleAudioTrackSplitter\bin\Release\ffmpeg.exe -ss 0 -t 30 -i "I:\Music\Techno\HappyHardcore\Party Animals - Good Vibrations.mp3" "I:\Music\Techno\HappyHardcore\a.mp3"
                    command = string.Format("-ss {0} -t {1} -i \"{2}\" \"{3}\"", startTimeInSeconds, endTimeInSeconds, filePath, trackFileName);
                }
            }

            return command;
        }

        /// <summary>
        /// Launches ffmpeg.exe and sends the provided command to the application.
        /// </summary>
        /// <param name="command">The FFMPEG command to split a single audio track.</param>
        public void StartFFMPEG(object command)
        {            
            Process startedProcess;
            ProcessStartInfo processStartInfo;

            if (string.IsNullOrEmpty((string)command) == false)
            {
                processStartInfo = new ProcessStartInfo("ffmpeg.exe", (string)command);
                using (startedProcess = Process.Start(processStartInfo)) 
                {
                    startedProcess.WaitForExit();
                    myNumTracksProcessed++;

                    if (OnProcessCompleted != null)
                    {
                        OnProcessCompleted.Invoke();
                    }
                }
            } 
        }
        
        /// <summary>
        /// Converts a provided time-stamp to its seconds equivalent.
        /// For example, the time-stamp "03:41:27" (3 hours, 41 minutes, 27 seconds) 
        /// would be 13287 seconds.
        /// </summary>
        /// <param name="time">Time-stamp to convert to seconds.</param>
        /// <returns>The number of seconds.</returns>
        private uint ConvertTimeToSeconds(string time)
        {
            uint totalSeconds = 0;
            double timeComponentMultiplyer = 0.0;
            string[] timeComponents;

            if(string.IsNullOrEmpty(time) == false)
            {
                timeComponents = time.Split(':');
                for(int currComponentIndex = timeComponents.Length - 1; currComponentIndex >= 0; currComponentIndex--)
                {
                    totalSeconds += (uint)(uint.Parse(timeComponents[currComponentIndex]) * Math.Pow(60.0, timeComponentMultiplyer++)); 
                }
            }

            return totalSeconds;
        }
    }
}
