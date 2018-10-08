using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAUCIWebsiteGeneratoir
{
   public class QAResponse
    {
        private String question;
        private String answer;

       public QAResponse(String question, String answer)
        {
            this.question = question;
            this.answer = answer;
        }

        public void setQuestion(String question)
        {
            this.question = question;
        }

        public void setAnswer(String answer)
        {
            this.answer = answer;
        }

        public String getQuestion()
        {
            return question;
        }
        public String getAnswer()
        {
            return answer;
        }
    }
}
