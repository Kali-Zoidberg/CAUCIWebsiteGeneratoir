using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAUCIWebsiteGeneratoir
{
    class Program
    {
        public static List<Person> boardList;
        private static String test_path = "C:\\Users\\Chow\\Documents\\Github\\cauciweb\\pages\\board\\";
        
        private static Person findPerson(String name, List<Person> boardList) {
            Person p = null;
            int len = boardList.Count;

            for (int i = 0; i < len; ++i) {
                if (boardList[i].getName() == name)
                    p = boardList[i];
            }
            return p;
        }

        private static List<Person> createBoardMemberList()
        {
            ExcelQAExtractor eQAExtract = new ExcelQAExtractor();
            List<Person> boardList = new List<Person>();

            //Generate board QA generic list (just parse the answers);
            boardList.Add(new Person("Jana Marie Ho See", "President", 1, "president@cauci.com"));
            boardList.Add(new Person("Amanda Lai", "Interval Vice President", 2, "internalvp@cauci.com"));
            boardList.Add(new Person("John Su", "External Vice President", 3, "externalvp@cauci.com"));
            boardList.Add(new Person("Jillian Wong", "Secretary", 4, "secretary@cauci.com"));
            boardList.Add(new Person("Eric Li", "Treasurer", 5, "treasurer@cauci.com"));
            boardList.Add(new Person("Aaron Arellano", "Social Chair", 6, "social@cauci.com"));
            boardList.Add(new Person("Joshua Xu", "Cultural Chair", 7, "culturalchair@caui.com"));
            boardList.Add(new Person("Skylar Lung", "Culture Night Producer", 8, "culturenight@cauci.com"));
            boardList.Add(new Person("Victoria Muliawan", "Publicity Coordinator", 9, "publicity@cauci.com"));
            boardList.Add(new Person("Aaron Kim", "Sports Coordinator", 10, "sports@cauci.com"));
            boardList.Add(new Person("Jerry Chen", "Historian", 11, "historian@cauci.com"));
            boardList.Add(new Person("Jonathan Le", "Historian", 12, "historian@cauci.com"));
            boardList.Add(new Person("Kevin Liang", "Fundraising Chair", 14, "fundraiser@cauci.com"));
            boardList.Add(new Person("Winnie Chang", "Head of Staff", 15, "headofstaff@cauci.com"));
            boardList.Add(new Person("Nicholas Chow", "Camp Coordinator", 16, "academicchair@cauci.com"));
            eQAExtract.parseFile(test_path + "test_response.csv", boardList);

            setImages(boardList);
                        
            return boardList;
        }

        private static void setImages(List<Person> boardList) {
            int len = boardList.Count;
            for( int i = 0; i < len; ++i) {
                Person p = boardList.ElementAt(i);
                p.setImgHeadLocation("images/board/" + 
                    p.getFirstName().ToLower() + 
                    p.getInitialLastName().ToString().ToLower() + "main.jpg");
                p.setImageLocation("./../../images/board/" +
                    p.getFirstName().ToLower() + p.getInitialLastName().ToString().ToLower() + 
                    "01.jpg");
 
            }
        }

        private static void genQA() {
            foreach (Person p in boardList) {

            }
        }
        static void Main(string[] args)
        {
            boardList = createBoardMemberList();
            FileGenerator.generateBoardFiles(boardList, test_path, ".html");
            HTMLGenerator test_gen = new HTMLGenerator();
            Console.Write(test_gen.genAlumniYearDropDown(2018, 22));
            //FileGenerator.generateBoardPage(test_path + "board.html", boardList);
        }

       
    }
}
