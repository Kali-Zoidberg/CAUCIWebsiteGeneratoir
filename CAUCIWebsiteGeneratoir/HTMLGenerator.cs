using System;

public class HTMLGenerator
{
	public HTMLGenerator()
	{

    }

    public String genAlumniYearDropDown(int curYear, int max) {
        String optTagBeg = "<option value=\"";
        String val = "\">";
        String finString = "";
        String content = "";
        String endTag = "</option>\r\n";
        String dropDowns ="";
        String tempRow = "";
        for (int i = 1; i < max; ++i) {
            tempRow = optTagBeg;

            tempRow += i + val;
            content = (curYear - i).ToString() + "-" + (curYear - (i- 1)).ToString();
            tempRow += content;
            tempRow += endTag;
            dropDowns += tempRow;
        }
        finString = wrapContentsInTag("<select class=\"select_year\" id=\"select_year\">\r\n", dropDowns, "</select>");
        finString = genDivClass("col-xs-12", finString);
        finString = genDivClass("row", finString);
        finString = genDivClass("year container", finString);
        return finString;
        
    }

    /// <summary>
    /// Wraps a specified tag around a string
    /// </summary>
    /// <param name="startTag">The beginning tag</param>
    /// <param name="endTag">The end tag</param>
    /// <param name="content">The contents you wish to wrap around</param>
    /// <returns>Returns a string formmated as startTag + content + endTag</returns>
    public String wrapTag(String startTag, String content, String endTag)
    {
        String buf = startTag + content + endTag + "\r\n";
        return buf; 
    }

    public String genImage(String location)
    {
        return wrapTag("<img src=\"", location, "\">");
    }

    /// <summary>
    /// Adds a tab to the beginning of a string. Used for nesting.
    /// </summary>
    /// <param name="str">The str to add a tab to. Modified by reference</param>
    ///<returns>Returns the string but with each new line being incremented by a tab</returns>
    public String incrementTabInString(String str)
    {
        if (str == null)
            return null;
        //Split the lines in the contents and then rejoin later.
        String[] line_arr = str.Split('\n');
        int line_arr_size = line_arr.Length;
        //Adds a tab to each line in the content string.

        for (int i = 0; i < line_arr_size - 1; ++i)

            line_arr[i] = "\t" + line_arr[i];

        return (String.Join("\n", line_arr));

    }
   
    /// <summary>
    /// Generates a div class properly that wraps the contents.
    /// </summary>
    /// <param name="divClass">The name of the div class you wish to generate</param>
    /// <param name="contents">The contents that be nested within the new div class</param>
    /// <returns>Returns a new content string.</returns>
    public String genDivClass(String divClass, String content)
    {
        String buf;
        string divBeg = "<div class=\"";
        string divEnd = "</div>\r\n";
        buf = divBeg + divClass + "\">\r\n";

        buf += this.incrementTabInString(content)  + divEnd;  
        return buf;
    }


    public int countChars(String str, char c) {
        int count = 0;
        int len = str.Length;
        for (int i = 0; i < len; ++i) {
            if (str[i] == c)
                ++count;
        }

        return count;
    }
    
    public String addCharsToString(String str, char c, int count) {
        String buff = "";
            for (int i = 0; i < count; ++i) 
                buff += c;
        buff += str;

        return buff;


    }

    public String allignTagWithLastLine(String tag, String content) {
        int tabAmount = countChars(content, '\t');
        return addCharsToString(tag, '\t', tabAmount - 1);

    }

    public String wrapContentsInTag(String startTag, String content, String endTag)
    {
        return (startTag + this.incrementTabInString(content) + endTag + "\r\n");
    }


    


}
