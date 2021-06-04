using System;

namespace Doubly_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            list.AddNode(72);
            list.AddNode(65);
            list.AddNode(34);
            list.AddNode(91);
            var findedNode = list.FindNode(72);
            var nodeByIndex = list.GetNodeByIndex(0);
            var addAfter = list.FindNode(72);
            list.AddNodeAfter(addAfter, 98);
            findedNode = list.FindNode(98);
            nodeByIndex = list.GetNodeByIndex(1);
            var count = list.GetCount();
        }
    }
}
