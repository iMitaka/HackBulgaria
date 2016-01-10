using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public interface IXmlMarkupBuilder
    {
        XmlMarkupBuilder OpenTag(String tagName);
        XmlMarkupBuilder AddAttr(String attrName, String attrValue); // valid only when you have a tag opened!
        XmlMarkupBuilder AddText(String text);
        XmlMarkupBuilder CloseTag(); //close the last opened tag.
        XmlMarkupBuilder Finish(); //close all tags and finelize your object. Any open,addAttr or other calls to your object, should throw an Exception.
        String GetResult(); //let's stay close to http://en.wikipedia.org/wiki/Builder_pattern 
    }
}
