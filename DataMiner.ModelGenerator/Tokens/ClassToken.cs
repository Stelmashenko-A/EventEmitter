using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMiner.ModelGenerator.Tokens
{
    public class ClassToken
    {
        public string Descriptor { get; set; }
        public string Name { get; set; }

        public IList<AttributeToken> Attributes { get; set; }
        public IList<PropertyToken> Properties { get; set; }

        protected string[] Descriptors = { "public", "protected", "private", "internal" };

        public ClassToken(string classStr)
        {
            classStr = classStr.Trim();
            var attEnd = classStr.IndexOf("]", StringComparison.Ordinal);
            var classEnd = classStr.IndexOf("class", StringComparison.Ordinal);
            if (attEnd < classEnd)
            {
                var strTmp = classStr.Substring(0, attEnd + 1);
                var strs = strTmp.Split(new string[']'],StringSplitOptions.RemoveEmptyEntries);
                Attributes=new List<AttributeToken>();
                foreach (var str in strs)
                {
                    Attributes.Add(new AttributeToken(str));
                }
                classStr = classStr.Substring(attEnd + 1);
            }
            var index = classStr.IndexOf('{');
            var signature = classStr.Substring(0, index).Trim().Split(' ').ToList();
            var body = classStr.Substring(index+1).Trim();
            body = body.Substring(0, body.Length - 1);
            if (Descriptors.Contains(signature[0]))
            {
                Descriptor = signature[0];
                signature.RemoveAt(0);
            }
            Name = signature[1];
            index = body.IndexOf('}');
            Properties =new List<PropertyToken>();
            var g = 0;
            while (index>0)
            {
                
                var strtmp = body.Substring(0, index + 1).Trim();
                Properties.Add(new PropertyToken(strtmp));
                if (index == classStr.Length - 1)
                {
                    break;
                }
                body = body.Substring(index + 1).Trim();
                index = body.IndexOf('}');
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var attributeToken in Attributes)
            {
                sb.Append(attributeToken);
            }
            sb.Append($"{Descriptor} class {Name}");
            sb.Append("{");
            foreach (var propertyToken in Properties)
            {
                sb.Append(propertyToken);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}