using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Who_is_that_Actor
{
    public class IMDBReader
    {
        //A reference to the main form window.
        private Form1 myMainForm;

        //The first page when searching is the title menu
        private string myInitialMovieOneURL;
        private string myInitialMovieTwoURL;

        //These are the specific urls 
        private ArrayList myMovieOneURLs;
        private ArrayList myMovieTwoURLs;

        //The List of actor names in string form
        private ArrayList myMovieOneActors;
        private ArrayList myMovieTwoActors;

        public IMDBReader(Form1 mainForm, string movieNameOne, string movieNameTwo) 
        {
            string imdbURL = @"http://www.imdb.com/";
            myMainForm = mainForm;

            try
            {
                //Create the title page url for the specified movie
                myInitialMovieOneURL = imdbURL + "find?q=" + WebEncodeMovieName(movieNameOne);
                myMainForm.GetLoadingBar().PerformStep();

                myInitialMovieTwoURL = imdbURL + "find?q=" + WebEncodeMovieName(movieNameTwo);
                myMainForm.GetLoadingBar().PerformStep();
            }
            catch (Exception e)
            {
                MessageBox.Show(mainForm, "Error attempting to encode movie name.");
                throw new Exception();
            }

            try
            {
                //Get the URLs to the shows requested.
                myMovieOneURLs = ParseTitlePage(myInitialMovieOneURL, movieNameOne);
                myMainForm.GetLoadingBar().PerformStep();

                myMovieTwoURLs = ParseTitlePage(myInitialMovieTwoURL, movieNameTwo);
                myMainForm.GetLoadingBar().PerformStep();
            }
            catch (Exception e)
            {
                MessageBox.Show(mainForm, "Error attempting to parse title menu");
                throw new Exception();
            }

            //Check to make sure we found title pages for the movies requested
            if(myMovieOneURLs.Count == 0)
            {
                MessageBox.Show(mainForm, "No title pages could be found for " + movieNameOne + ".");
                throw new Exception();
            }

            if (myMovieTwoURLs.Count == 0)
            {
                MessageBox.Show(mainForm, "No title pages could be found for " + movieNameTwo + ".");
                throw new Exception();
            }

            //Append the imdbURL to the other urls.
            for (int i = 0; i < myMovieOneURLs.Count; i++)
            {
                myMovieOneURLs[i] = imdbURL + myMovieOneURLs[i];
            }

            myMainForm.GetLoadingBar().PerformStep();

            //Append the imdbURL to the other urls.
            for (int i = 0; i < myMovieTwoURLs.Count; i++)
            {
                myMovieTwoURLs[i] = imdbURL + myMovieTwoURLs[i];
            }

            myMainForm.GetLoadingBar().PerformStep();

            try
            {
                //Parse the actor names from the HTML in the page
                myMovieOneActors = ParseActorsFromPages(myMovieOneURLs);
                myMainForm.GetLoadingBar().PerformStep();

                myMovieTwoActors = ParseActorsFromPages(myMovieTwoURLs);
                myMainForm.GetLoadingBar().PerformStep();
            }
            catch (Exception e)
            {
                MessageBox.Show(mainForm, "Error attempting to parse actors names from movie page");
                throw new Exception();
            }
        }

        public ArrayList GetActorsInCommon()
        {
            ArrayList actorsInCommon = new ArrayList();

            for(int i = 0; i < myMovieOneActors.Count; i++)
            {
                //Check to see if the current actor from movie one is in the list of movie two
                if(myMovieTwoActors.Contains(myMovieOneActors[i]))
                {
                    actorsInCommon.Add(myMovieOneActors[i]);
                }
            }

            return actorsInCommon;
        }

        public ArrayList ParseActorsFromPages(ArrayList movieURLs)
        {
            ArrayList actorsList = new ArrayList();
            string fullcreditsURL = "";
            string fullCreditsPage = "";
            string currChunk = "";
            string preActorsChunk = "";
            string actorsChunk = "";
            string postActorsChunk = "";
            int firstIndex = 0;
            int secondIndex = 0;
            int length = 0;

            //problem with the movie "telephone"
            for (int i = 0; i < movieURLs.Count; i++)
            {
                fullcreditsURL = movieURLs[i] + "/fullcredits";
                fullCreditsPage = RetrievePage(fullcreditsURL);

                //Skip this one if there are no actors.
                if(fullCreditsPage.IndexOf("cast_list") == -1)
                {
                    continue;
                }

                //Get the section preceding the actors.
                firstIndex = fullCreditsPage.IndexOf("fullcredits_content");
                secondIndex = fullCreditsPage.IndexOf("cast_list");
                length = secondIndex - firstIndex;
                preActorsChunk = fullCreditsPage.Substring(firstIndex, length);

                //Cut out the preActors section
                fullCreditsPage = fullCreditsPage.Substring(secondIndex);

                //Get the section with just the actors
                firstIndex = fullCreditsPage.IndexOf("cast_list");
                secondIndex = fullCreditsPage.IndexOf("</table>");
                length = secondIndex - firstIndex;
                actorsChunk = fullCreditsPage.Substring(firstIndex, length);

                //Cut out the actors section
                fullCreditsPage = fullCreditsPage.Substring(secondIndex);

                //Get the section after the actors.
                firstIndex = fullCreditsPage.IndexOf("</table>");
                secondIndex = fullCreditsPage.IndexOf("id=\"see_also\"");
                length = secondIndex - firstIndex;
                postActorsChunk = fullCreditsPage.Substring(firstIndex, length);

                //Move closer to the first name.
                firstIndex = postActorsChunk.IndexOf("<td class=\"name\">");
                postActorsChunk = postActorsChunk.Substring(firstIndex);


                //Only parse these sections if we want everyone that worked on the film, not just the actors.
                if(myMainForm.GetFilmAndProdCheckBox().Checked == true)
                {
                    //Parse the names that come before the actors section.
                    while (preActorsChunk.Contains("<a href="))
                    {
                        //Extract the line with the name.
                        firstIndex = preActorsChunk.IndexOf("<a href=");
                        secondIndex = preActorsChunk.IndexOf("</td>");
                        length = secondIndex - firstIndex;
                        currChunk = preActorsChunk.Substring(firstIndex, length);

                        //Extract the name from currChunck
                        firstIndex = currChunk.IndexOf('>') + 2;
                        secondIndex = currChunk.IndexOf("</a>") - 1;
                        length = secondIndex - firstIndex;
                        currChunk = currChunk.Substring(firstIndex, length);

                        if (!actorsList.Contains(currChunk))
                        {
                            actorsList.Add(currChunk);
                        }

                        //Move to the next name section.
                        firstIndex = preActorsChunk.IndexOf("<td class=\"name\">") + 16;
                        preActorsChunk = preActorsChunk.Substring(firstIndex);
                    }

                    //Parse the names that come after the actors section.
                    while (postActorsChunk.Contains("<a href="))
                    {
                        //Extract the line with the name.
                        firstIndex = postActorsChunk.IndexOf("<a href=");
                        secondIndex = postActorsChunk.IndexOf("</td>");
                        length = secondIndex - firstIndex;
                        currChunk = postActorsChunk.Substring(firstIndex, length);

                        //Extract the name from currChunck
                        firstIndex = currChunk.IndexOf('>') + 2;
                        secondIndex = currChunk.IndexOf("</a>") - 1;
                        length = secondIndex - firstIndex;
                        currChunk = currChunk.Substring(firstIndex, length);

                        //Add name to list if its not already in there.
                        if (!actorsList.Contains(currChunk))
                        {
                            actorsList.Add(currChunk);
                        }

                        //Move to the next name section.
                        firstIndex = postActorsChunk.IndexOf("<td class=\"name\">") + 16;
                        if (postActorsChunk.IndexOf("<td class=\"name\">") == -1)
                        {
                            break;
                        }

                        postActorsChunk = postActorsChunk.Substring(firstIndex);
                    }
                }

                //Parse the actors section.
                while (actorsChunk.Contains("itemprop=\"name\">"))
                {
                    //Grab the actor name.
                    firstIndex = actorsChunk.IndexOf("itemprop=\"name\">") + 16;
                    secondIndex = actorsChunk.IndexOf("</span>");
                    length = secondIndex - firstIndex;
                    currChunk = actorsChunk.Substring(firstIndex, length);

                    if (!actorsList.Contains(currChunk))
                    {
                        actorsList.Add(currChunk);
                    }

                    //Move over to the next actor name
                    firstIndex = actorsChunk.IndexOf("</span>") + 7;
                    actorsChunk = actorsChunk.Substring(firstIndex);
                }

            }

            return actorsList;
        }

        public ArrayList ParseTitlePage(string titlePageURL, string movieName)
        {
            ArrayList urls = new ArrayList();
            string titlePage = RetrievePage(titlePageURL);
            string currURL = "";
            string currName = "";
            bool done = false;
            int firstIndex;
            int secondIndex;
            int length;

            //Make sure we successfully retrieved the page
            if(string.IsNullOrEmpty(titlePage) == false)
            {
                //Go to the titles section.
                while(!done)
                {
                    firstIndex = titlePage.IndexOf("findSectionHeader");

                    //Cut out the text before firstIndex.
                    titlePage = titlePage.Substring(firstIndex);

                    //Extract the section name
                    firstIndex = titlePage.IndexOf("</a>") + 4;
                    secondIndex = titlePage.IndexOf("</h3>");
                    length = secondIndex - firstIndex;
                    currName = titlePage.Substring(firstIndex, length);

                    titlePage = titlePage.Substring(secondIndex + 4);

                    if (currName == "Titles")
                    {
                        //Found the titles section.
                        done = true;
                        titlePage = titlePage.Substring(secondIndex);

                        //Cut out everything else except titles section
                        firstIndex = 0;
                        secondIndex = titlePage.IndexOf("findMoreMatches");
                        length = secondIndex - firstIndex;
                        titlePage = titlePage.Substring(firstIndex, length);
                    }
                }

                //Go through each title and collect the associated links.
                done = false;
                while (!done)
                {
                    //Get the section containing the links in the titles section.
                    firstIndex = titlePage.IndexOf("result_text");
                    titlePage = titlePage.Substring(firstIndex);

                    //Get the link since that comes before the title name.
                    firstIndex = titlePage.IndexOf("<a href=") + 9;
                    secondIndex = titlePage.IndexOf("\" >");
                    length = secondIndex - firstIndex;
                    currURL = titlePage.Substring(firstIndex, length);

                    //Remove the end part of the url since it is unnecessary.
                    firstIndex = 0;
                    secondIndex = currURL.LastIndexOf('/');
                    length = secondIndex - firstIndex;
                    currURL = currURL.Substring(firstIndex, length);

                    //Move over to the name part.
                    secondIndex = titlePage.IndexOf("\" >");
                    titlePage = titlePage.Substring(secondIndex + 3);

                    //Extract the name.
                    firstIndex = 0;
                    secondIndex = titlePage.IndexOf("</a>");
                    length = secondIndex - firstIndex;
                    currName = titlePage.Substring(firstIndex, length);

                    //Move past the name to the next title.
                    titlePage = titlePage.Substring(secondIndex + 4);

                    //Make sure its not a sub episode like Honest Trailers: The Matrix, if so then skip this page.
                    if (titlePage.IndexOf("<small>") != -1 && titlePage.IndexOf("<small>") < titlePage.IndexOf("result_text"))
                    {
                        continue;
                    }

                    //Make sure the movie name is equal to the current name before we add.
                    //Convert both to all caps since we don't care about upper/lower case.
                    if (movieName.ToUpper().Equals(currName.ToUpper()))
                    {
                        urls.Add(currURL);
                    }

                    //Check to see if there are more links to go through.
                    if(titlePage.IndexOf("result_text") == -1)
                    {
                        done = true;
                    }
                }

                return urls;
            }
            else
            {
                //The page was not retrieved successfully
                return null;
            }
        }

        public string RetrievePage(string url)
        {
            string wholePage;
            Stream tempStream;
            StreamReader tempStreamReader;
            WebRequest tempWebRequest;
            WebResponse tempWebResponce;

            // Initiate the web request with specified url
            tempWebRequest = WebRequest.Create(url);

            // If required by the server, set the credentials.
            tempWebRequest.Credentials = CredentialCache.DefaultCredentials; 

            // Get the stream containing content returned by the server.
            tempWebResponce = tempWebRequest.GetResponse();
            tempStream = tempWebResponce.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            tempStreamReader = new StreamReader(tempStream);

            // Read the content.
            wholePage = tempStreamReader.ReadToEnd();

            // Clean up the streams and the response.
            tempStreamReader.Close();
            tempWebResponce.Close();

            return wholePage;
        }

        public string WebEncodeMovieName(string movieName)
        {
            string encodedMovieName = "";

            if(string.IsNullOrEmpty(movieName) == false)
            {
                for(int i = 0; i < movieName.Count(); i++)
                {
                    string currChar = movieName.ElementAt(i).ToString();

                    if(currChar.Equals(" "))//Single Space
                    {
                        currChar = "%20";
                    }
                    else if (currChar.Equals("!"))
                    {
                        currChar = "%21";
                    }
                    else if (currChar.Equals("\""))//Double Quote
                    {
                        currChar = "%22";
                    }
                    else if (currChar.Equals("#"))
                    {
                        currChar = "%23";
                    }
                    else if (currChar.Equals("$"))
                    {
                        currChar = "%24";
                    }
                    else if (currChar.Equals("%"))
                    {
                        currChar = "%25";
                    }
                    else if (currChar.Equals("&"))
                    {
                        currChar = "%26";
                    }
                    else if (currChar.Equals("\'"))//Single Quote
                    {
                        currChar = "%27";
                    }
                    else if (currChar.Equals("("))
                    {
                        currChar = "%28";
                    }
                    else if (currChar.Equals(")"))
                    {
                        currChar = "%29";
                    }
                    else if (currChar.Equals("*"))
                    {
                        currChar = "%2A";
                    }
                    else if (currChar.Equals("+"))
                    {
                        currChar = "%2B";
                    }
                    else if (currChar.Equals(","))
                    {
                        currChar = "%2C";
                    }
                    else if (currChar.Equals("-"))
                    {
                        currChar = "%2D";
                    }
                    else if (currChar.Equals("."))
                    {
                        currChar = "%2E";
                    }
                    else if (currChar.Equals("/"))
                    {
                        currChar = "%2F";
                    }
                    else if (currChar.Equals("0"))
                    {
                        currChar = "%30";
                    }
                    else if (currChar.Equals("1"))
                    {
                        currChar = "%31";
                    }
                    else if (currChar.Equals("2"))
                    {
                        currChar = "%32";
                    }
                    else if (currChar.Equals("3"))
                    {
                        currChar = "%33";
                    }
                    else if (currChar.Equals("4"))
                    {
                        currChar = "%34";
                    }
                    else if (currChar.Equals("5"))
                    {
                        currChar = "%35";
                    }
                    else if (currChar.Equals("6"))
                    {
                        currChar = "%36";
                    }
                    else if (currChar.Equals("7"))
                    {
                        currChar = "%37";
                    }
                    else if (currChar.Equals("8"))
                    {
                        currChar = "%38";
                    }
                    else if (currChar.Equals("9"))
                    {
                        currChar = "%39";
                    }
                    else if (currChar.Equals(":"))
                    {
                        currChar = "%3A";
                    }
                    else if (currChar.Equals(";"))
                    {
                        currChar = "%3B";
                    }
                    else if (currChar.Equals("<"))
                    {
                        currChar = "%3C";
                    }
                    else if (currChar.Equals("="))
                    {
                        currChar = "%3D";
                    }
                    else if (currChar.Equals(">"))
                    {
                        currChar = "%3E";
                    }
                    else if (currChar.Equals("?"))
                    {
                        currChar = "%3F";
                    }
                    else if (currChar.Equals("@"))
                    {
                        currChar = "%40";
                    }
                    else if (currChar.Equals("["))
                    {
                        currChar = "%5B";
                    }
                    else if (currChar.Equals("\\"))//Backslash
                    {
                        currChar = "%5C";
                    }
                    else if (currChar.Equals("]"))
                    {
                        currChar = "%5D";
                    }
                    else if (currChar.Equals("^"))
                    {
                        currChar = "%5E";
                    }
                    else if (currChar.Equals("_"))
                    {
                        currChar = "%5F";
                    }
                    else if (currChar.Equals("`"))//Grave
                    {
                        currChar = "%60";
                    }
                    else if (currChar.Equals("{"))
                    {
                        currChar = "%7B";
                    }
                    else if (currChar.Equals("|"))
                    {
                        currChar = "%7C";
                    }
                    else if (currChar.Equals("}"))
                    {
                        currChar = "%7D";
                    }
                    else if (currChar.Equals("~"))//Tilda
                    {
                        currChar = "%7E";
                    }

                    encodedMovieName += currChar;
                }

                return encodedMovieName;
            }
            else
            {
                return null;
            }
        }
    }
}
