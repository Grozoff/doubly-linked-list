using System;
using System.Collections.Generic;
using System.Text;

namespace Doubly_linked_list
{
    public class LinkedList : ILinkedList
    {
        private int count = 0;
        private Node FirstNode;
        private Node LastNode;

        public int GetCount() => count;

        public void AddNode(int value)
        {
            if (FirstNode == null)
            {
                FirstNode = LastNode = new Node() { Value = value };
            }
            else
            {
                var newItem = new Node() { Value = value, PrevNode = LastNode };
                LastNode.NextNode = newItem;
                LastNode = newItem;
            }
            count++;
        }

        public Node GetNodeByIndex(int nodeIndex)
        {
            Node node;

            if (count - 1 >= nodeIndex)
            {
                node = FirstNode;
                for (var i = 1; i <= nodeIndex; i++)
                {
                    node = node.NextNode;
                }
            }
            else
            {
                node = LastNode;
                for (var i = count - 1; i > nodeIndex; i--)
                {
                    node = node.PrevNode;
                }
            }
            return node;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var next = node.NextNode;
            var newItem = new Node() { Value = value, NextNode = next, PrevNode = node };
            node.NextNode = newItem;
            if (next != null)
            {
                next.PrevNode = newItem;
            }
            count++;
        }

        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                if (FirstNode.NextNode is { } node)
                {
                    FirstNode = node;
                    node.PrevNode = null;
                }
                else
                {
                    FirstNode = LastNode = null;
                }
            }
            else
            {
                var del = GetNodeByIndex(index);

                if (del.NextNode != null)
                {
                    del.NextNode.PrevNode = del.PrevNode;
                }
                del.PrevNode.NextNode = del.NextNode;
                del.NextNode = del.PrevNode = null;
            }
            count--;
        }

        public void RemoveNode(Node node)
        {
            if (FirstNode == node)
            {
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    FirstNode = node.NextNode;
                    node.NextNode = null;
                    FirstNode.PrevNode = null;
                }
            }
            else
            {
                if (node.NextNode != null)
                {
                    node.NextNode.PrevNode = node.PrevNode;
                }
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode = node.PrevNode = null;
            }
            count--;
        }

        public Node FindNode(int searchValue)
        {
            var current = FirstNode;
            while (current != null)
            {
                if (current.Value == searchValue)
                {
                    return current;
                }
                current = current.NextNode;
            }
            return null;
        }
    }
}
