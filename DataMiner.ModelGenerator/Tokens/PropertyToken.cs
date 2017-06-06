using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMiner.ModelGenerator.Tokens
{
    public class PropertyToken
    {
        public string Descriptor { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string End { get; set; }

        public IList<AttributeToken> Attributes { get; set; }
        protected string[] Descriptors = {"public", "protected", "private", "internal"};

        public PropertyToken(string property)
        {
            var strs = property.Split(']').ToList();
            Attributes = new List<AttributeToken>();
            for (var i = 0; i < strs.Count - 1; i++)
            {
                Attributes.Add(new AttributeToken(strs[i]));
            }
            strs = strs[strs.Count - 1].Split(' ').ToList();
            if (Descriptors.Contains(strs[0]))
            {
                Descriptor = strs[0];
                strs.RemoveAt(0);
            }

            Type = strs[0];
            strs.RemoveAt(0);
            Name = strs[0];
            strs.RemoveAt(0);

            var sb = new StringBuilder();
            foreach (var str in strs)
            {
                sb.Append(str);
            }

            End = sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var attributeToken in Attributes)
            {
                sb.Append(attributeToken);
            }
            sb.Append($"{Descriptor} {Type} {Name} {End}");
            return sb.ToString();
        }
    }
}