using System.Collections.Generic;

namespace EventEmitter.Semantic
{
    public class EmoticonNode
    {
        public char Value;
        public IList<EmoticonNode> Children { get; set; }
        public EmoticonNode Parent;
        public bool EndOfEmoticon;
        public int Level { get; set; }
    }
}