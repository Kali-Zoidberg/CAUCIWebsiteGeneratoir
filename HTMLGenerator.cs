using System;

public class HTMLGenerator
{
	public HTMLGenerator()
	{

    }

    /// <summary>
    /// Adds a tab to the beginning of a string. Used for nesting.
    /// </summary>
    /// <param name="str">The str to add a tab to. Modified by reference</param>

    public String incrementTabInString(String str)
    {
        //Split the lines in the contents and then rejoin later.
        String[] line_list = str.Split("\r\n");
        //Adds a tab to each line in the content string.
        foreach (String line in line_list)
            line.Insert(0, "\t");

        return String.Join("", line_list);

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
        string divEnd = "</div>";
        String buf = divBeg + divClass + "\">\r\n";
        buf += this.incrementTabInString(content) + "\r\n" + divEnd;  
        return buf;
    }
}
