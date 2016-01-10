using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class XmlBuilderTestApp
    {
        public static void Main()
        {
            var markupBuilder = new XmlMarkupBuilder();

            String validMarkup = markupBuilder.OpenTag("body").AddAttr("background", "0xFF0000").AddText("Helo HTML!").Finish().GetResult();
            Console.WriteLine(validMarkup);
            try
            {
                markupBuilder.CloseTag();
            }
            catch (Exception)
            {

                Console.WriteLine("BOOOM! Object finalized! Exception!");
            }

            XmlMarkupBuilder markupBuilder2 = new XmlMarkupBuilder();
            try
            {
                markupBuilder2.OpenTag("a").CloseTag().OpenTag("a");
            }
            catch (Exception)
            {

                Console.WriteLine("BOOOM! You need to have a root XML object, XML is not a list!");
            }

            XmlMarkupBuilder markupBuilder3 = new XmlMarkupBuilder();
            try
            {
                markupBuilder3.OpenTag("a").CloseTag().CloseTag();
            }
            catch (Exception)
            {

                Console.WriteLine("BOOOM! What the hell are we closing?!");   
            }

            XmlMarkupBuilder markupBuilder4 = new XmlMarkupBuilder();
            try
            {
                 markupBuilder4.OpenTag("a").CloseTag().AddAttr("href", "https://www.youtube.com/watch?v=P5ft_7Bcyc4");
            }
            catch (Exception)
            {

                Console.WriteLine("BOOOM! What are you adding attribute to?");
            }

            XmlMarkupBuilder markupBuilder5 = new XmlMarkupBuilder();
            try
            {
                markupBuilder5.OpenTag("body").AddAttr("background", "0xFF0000").AddText("Helo HTML!").GetResult(); 
            }
            catch (Exception)
            {

                Console.WriteLine("BOOOM! There is one or more unclosed tags!");   
            }          
        }
    }
}
