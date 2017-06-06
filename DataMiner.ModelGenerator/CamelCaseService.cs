using System.Text;

namespace DataMiner.ModelGenerator
{
    public class CamelCaseService
    {
        public string FromUnderScore(string str)
        {
            str = str.ToLower();
            var strs = str.Split('_');
            var sb = new StringBuilder();
            foreach (var s in strs)
            {
                sb.Append(UppercaseFirst(s));
            }
            return sb.ToString();
        }

        protected string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
