using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAUCIWebsiteGeneratoir
{
    class ExcelQAExtractor
    {


       /// <summary>
       /// Removes characters from a string.
       /// </summary>
       /// <param name="str"></param>
       /// <param name="c"></param>
       /// <returns>REturns a string without the specified character.</returns>

        public String removeCharFromString(String str, char c) {
            int len = str.Length;
            String temp = "";
            int j = 0;

            for (int i = 0; i < len; ++i) {

                if (str[i] != c)
                    temp += str[i];
            }
            return temp;

        }


        /// <summary>
        /// Generates Entries from the a line of text split by commas
        /// </summary>
        /// <param name="text"></param>
        /// <param name="discardFirstString"></param>
        /// <returns></returns>

        public String[] genEntries(String text, char delimiter, int startingIndex) {
            //Set QA[i] = removeQuote(SubString);
           
            String[] subStringBuffer = text.Split(new string[] { "\",\"" }, StringSplitOptions.None);
            int len = subStringBuffer.Length;
            //Remove quotes

            for (int i = 0; i < len; ++i) 
                subStringBuffer[i] = removeCharFromString(subStringBuffer[i], '\"');
            
            return subStringBuffer;

        }

        /// <summary>
        /// Generates QA responses from a string array.
        /// </summary>
        /// <param name="questions">An array of questions which to generate  a QA list</param>
        /// <returns></returns>
        private List<QAResponse> genQAObj(String[] questions) {
            List<QAResponse> retQAList = new List<QAResponse>();
            int len = questions.Length;
            for (int i = 3; i < len; ++i) 
                retQAList.Add(new QAResponse(questions[i], "N/A"));
            
            
            return retQAList;
        }
        /// <summary>
        /// Generates a list of QAResponses from a specified file.
        /// </summary>
        /// <param name="filePath">The path to the file containing all of the responses</param>
        /// <returns>Returns a list of the questions from the csv</returns>

        public List<QAResponse> getQuestionsFromCSV(String filePath) {
            StreamReader f_open = new StreamReader(filePath);
            String[] questionStrings;
            List<QAResponse> questionList = new List<QAResponse>();
            
            //Obtain Strings from the entries
            questionStrings = genEntries(f_open.ReadLine(),',',3);

            //Generate the question list.

            f_open.Close();
            questionList = genQAObj(questionStrings);

            return questionList;

        }

        public void parseResponseString(StreamReader f_open, List<Person> personList) {
            String line;
            String[] subStringBuffer;

                line = f_open.ReadLine();
        }

        /// <summary>
        /// Formats a name string to reduce error in people adding extra white space in their name or capitlization issues.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private String formatName(String name) {
            String temp = name;
            temp.ToLower();
            temp = removeCharFromString(temp, ' ');
            return temp;
        }

        /// <summary>
        /// Finds a person in a given list using a specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personList"></param>
        /// <returns></returns>

        public Person findPersonInList(String name, List<Person> personList) {
            int len = personList.Count;
            String personName = "";
            for (int  i = 0; i < len; ++i) {
                if (formatName(personList[i].getName()) == formatName(name))
                    return personList[i];
            }
        
            return null;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StringBuffer"></param>
        /// <param name="personList"></param>
        public void parseAnswers(String line, List<Person> personList) {
            String[] answers = genEntries(line, ',', 1);
            int len = answers.Length;
          
            //Now Match person with the first answer, which will be their name.
            Person matchingPerson = findPersonInList(answers[1], personList);
            //Obtain their QA list
            if (matchingPerson != null) {
                List<QAResponse> tempQA = matchingPerson.getQAList();

                //Now copy answers from 1 -> answers.length - 1;
                Console.WriteLine("Questions for person: " + matchingPerson.getName());
                for (int i = 3; i < answers.Length; ++i) {
                    if (answers[i] != "")
                        tempQA[i - 3].setAnswer(answers[i]);
                   
                    //   Console.WriteLine("The Question: " + tempQA[i - 3].getQuestion() + " Their answer : " + tempQA[i - 3].getAnswer());
                }

            }
            else
                Console.WriteLine("did not find a person:" + answers[1]);
        }

        public void parseLines(String line, List<Person> personList) {
            
          //  f_open.ReadLine();
            //Discard first line
               // subStringBuffer = line.Split(',');
                parseAnswers(line, personList);

         }

        public void parseFile(String filePath, List<Person> personList) {
            List<QAResponse> temp_list = new List<QAResponse>();
            StreamReader f_open = new StreamReader(filePath);
            String[] subStringBuffer;
            f_open.ReadLine();
            //Discard first line

            while (!f_open.EndOfStream) {
                String line = f_open.ReadLine();
                parseAnswers(line, personList);  
            }

            f_open.Close();
        }
    }
}
