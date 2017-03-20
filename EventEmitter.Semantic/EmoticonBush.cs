using System.Collections.Generic;
using System.Linq;

namespace EventEmitter.Semantic
{

    //optimization
    public class EmoticonBush
    {
        public IList<EmoticonNode> Nodes { get; set; }

        public EmoticonBush(List<string> emoticons)
        {
            IList<EmoticonNode> result = new List<EmoticonNode>();
            EmoticonNode parent = null;
            foreach (var emoticon in emoticons)
            {
                var nodes = result;
                var emoticonTmp = emoticon;
                
                while (emoticonTmp.Length != 0)
                {
                    var token = emoticonTmp[0];
                    
                    var node = nodes.FirstOrDefault(x => x.Value == token);
                    if (node == null)
                    {
                        node = new EmoticonNode
                        {
                            Value = token,
                            Children = new List<EmoticonNode>(),
                            Parent = parent
                        };
                        nodes.Add(node);
                    }
                    emoticonTmp = emoticonTmp.Remove(0, 1);
                    if (parent != null && emoticonTmp.Length > parent.Level)
                    {
                        parent.Level = emoticonTmp.Length;
                    }
                    parent = node;
                    nodes = node.Children;
                }
                if (parent != null) parent.EndOfEmoticon = true;
            }
            foreach (var emoticonNode in result)
            {
                Order(emoticonNode);
            }
            Nodes = result;
        }

        public void Numerate(EmoticonNode node)
        {
            if (!node.Children.Any())
            {
                node.Level = 0;
            }
        }
        public void Order(EmoticonNode node)
        {
            var nextLevel = node.Children.Where(x => !x.EndOfEmoticon);
            foreach (var emoticonNode in nextLevel)
            {
                Order(emoticonNode);
            }
            node.Children = node.Children.OrderBy(x => x.Children.Count).ToList();

        }
    }
}