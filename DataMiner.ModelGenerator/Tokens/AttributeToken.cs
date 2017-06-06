using System.Collections.Generic;
using System.Text;

namespace DataMiner.ModelGenerator.Tokens
{
    public class AttributeToken
    {
        public string Name { get; set; }
        public IList<KeyValuePair<string, string>> Properties { get; set; }

        public AttributeToken(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            var strs = str.Split('(');
            Name = strs[0];
            Properties = new List<KeyValuePair<string, string>>();
            if (strs.Length == 2)
            {
                str = strs[1];
                str = str.Replace("(", "");
                str = str.Replace(")", "");
                strs = str.Split(',');

                foreach (var s in strs)
                {
                    var props = s.Split('=');
                    var pair = new KeyValuePair<string, string>(props[0], props[1]);
                    Properties.Add(pair);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(Name);
            if (Properties.Count != 0)
            {
                sb.Append("(");
                foreach (var property in Properties)
                {
                    sb.Append($"{property.Key}={property.Value}");
                }
                sb.Append(")");
            }
            sb.Append("]");
            return sb.ToString();
        }


    }
}
