using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class XmlMarkupBuilder : IXmlMarkupBuilder
    {
        private List<string> openTags;
        private List<string> closeTags;
        bool isFinalize = false;
        string text;

        public XmlMarkupBuilder()
        {
            this.openTags = new List<string>();
            this.closeTags = new List<string>();
        }

        public XmlMarkupBuilder OpenTag(string tagName)
        {
            CheckIfFinalize();

            if (this.closeTags.Count >= 1)
            {
                throw new Exception("BOOOM! You need to have a root XML object, XML is not a list!");
            }
            this.openTags.Add(tagName);
            return this;
        }

        public XmlMarkupBuilder CloseTag()
        {
            CheckIfFinalize();

            if (this.closeTags.Count < this.openTags.Count)
            {
                closeTags.Add(this.openTags.LastOrDefault());
                this.openTags.Remove(this.openTags.LastOrDefault());
                return this;
            }
            else
            {
                throw new Exception("BOOOM! What the hell are we closing?!");
            }
        }

        public XmlMarkupBuilder AddAttr(string attrName, string attrValue)
        {
            CheckIfFinalize();

            if (this.openTags.Count >= 1)
            {
                var tag = this.openTags.LastOrDefault();
                var attribute = string.Format(" {0}=\"{1}\"", attrName, attrValue);
                var result = tag + attribute;
                this.openTags.Remove(this.openTags.LastOrDefault());
                this.openTags.Add(result);
                return this;
            }
            else
            {
                throw new Exception("BOOOM! What are you adding attribute to?");
            }
        }

        public XmlMarkupBuilder AddText(string text)
        {
            CheckIfFinalize();

            this.text = text;
            return this;
        }

        public XmlMarkupBuilder Finish()
        {
            CheckIfFinalize();

            if (this.openTags.Count >= 1)
            {
                for (int i = this.openTags.Count - 1; i >= 0; i--)
                {
                    this.closeTags.Add(this.openTags[i]);
                }
                this.openTags.Clear();
            }
            this.isFinalize = true;
            return this;
        }

        public string GetResult()
        {
            StringBuilder sb = new StringBuilder();
            if (this.openTags.Count >= 1)
            {
                throw new Exception("BOOOM! There is one or more unclosed tags!");
            }

            foreach (var tag in this.closeTags)
            {
                sb.Append("<" + tag + ">");
            }
            sb.Append(this.text);
            foreach (var tag in this.closeTags)
            {
                var currentTag = tag.Split(' ');
                sb.Append("</" + currentTag[0] + ">");
            }
            return sb.ToString();
        }

        private void CheckIfFinalize()
        {
            if (this.isFinalize)
            {
                throw new Exception("BOOOM! Object is finalized!");
            }
        }
    }
}
