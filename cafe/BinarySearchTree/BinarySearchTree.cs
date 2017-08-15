using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.BinarySearchTree
{
    public class BinarySearchTree<Key, Value> where Key : IComparable<Key>
    {

        public delegate void Callback(Key value);

        private Node root;

        private int size;

        public BinarySearchTree()
        {
            root = null;
            size = 0;
        }

        public void Insert(Key key, Value value)
        {
            insert(ref root, key, value);
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public bool Find(Key key, out Value value)
        {
            return find(root, key, out value);
        }

        public void Remove(Key key)
        {
            remove(ref root, key);
        }

        private int remove(ref Node node, Key key)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                int sub = remove(ref node.left, key);
                node.children -= sub;
                return sub;
            }
            else if (compare > 0)
            {
                int sub = remove(ref node.right, key);
                node.children -= sub;
                return sub;
            }
            else
            {
                int sub = node.frequent;
                if (node.left == null)
                {
                    size -= sub;
                    node = node.right;
                }
                else if (node.right == null)
                {
                    size -= sub;
                    node = node.left;
                }
                else
                {
                    Node successor = min(node.right);
                    removeMin(ref node.right);
                    successor.right = node.right;
                    successor.left = node.left;
                    successor.children = node.children - sub;
                    node = successor;
                }
                return sub;
            }
        }

        public bool Contains(Key key)
        {
            Value value;
            return find(root, key, out value);
        }

        public void RemoveMax()
        {
            int sub = removeMax(ref root);
            root.children -= sub;
        }

        private int removeMax(ref Node node)
        {
            if (node.right == null)
            {
                int sub = node.frequent;
                node = node.left;
                size -= sub;
                return sub;
            }
            else
            {
                int sub = removeMax(ref node.right);
                node.children -= sub;
                return sub;
            }
        }


        public IEnumerator<Key> GetEnumerator()
        {
            Queue<Key> queue = new Queue<Key>();
            InOrder(key => queue.Enqueue(key));

            while (queue.Count != 0)
            {
                yield return queue.Dequeue();
            }

        }

        public Key Max()
        {
            return max(root).key;
        }

        private Node max(Node node)
        {
            if (node.right == null)
            {
                return node;
            }
            else
            {
                return max(node.right);
            }
        }

        public void RemoveMin()
        {
            int sub = removeMin(ref root);
            root.children -= sub;
        }

        private int removeMin(ref Node node)
        {
            if (node.left == null)
            {
                int sub = node.frequent;
                node = node.right;
                size -= sub;
                return sub;
            }
            else
            {
                int sub = removeMin(ref node.left);
                node.children -= sub;
                return sub;
            }
        }

        public Key Min()
        {
            return min(root).key;
        }

        private Node min(Node node)
        {
            if (node.left == null)
            {
                return node;
            }
            else
            {
                return min(node.left);
            }
        }

        public void LevelOrder(Callback callback)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();
                callback(node.key);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        public void PreOrder(Callback callback)
        {
            preOrder(root, callback);
        }

        private void preOrder(Node node, Callback callback)
        {
            if (node != null)
            {
                for (int i = 0; i < node.frequent; i++)
                {
                    callback(node.key);
                }
                preOrder(node.left, callback);
                preOrder(node.right, callback);
            }
        }

        public void InOrder(Callback callback)
        {
            inOrder(root, callback);
        }

        private void inOrder(Node node, Callback callback)
        {
            if (node != null)
            {
                inOrder(node.left, callback);
                for (int i = 0; i < node.frequent; i++)
                {
                    callback(node.key);
                }
                inOrder(node.right, callback);
            }
        }

        public void PostOrder(Callback callback)
        {
            postOrder(root, callback);
        }

        private void postOrder(Node node, Callback callback)
        {
            if (node != null)
            {
                postOrder(node.left, callback);
                postOrder(node.right, callback);
                for (int i = 0; i < node.frequent; i++)
                {
                    callback(node.key);
                }
            }
        }

        private bool find(Node node, Key key, out Value value)
        {
            if (node == null)
            {
                value = default(Value);
                return false;
            }
            int compare = key.CompareTo(node.key);
            if (compare == 0)
            {
                value = node.value;
                return true;
            }
            else if (compare < 0)
            {
                return find(node.left, key, out value);
            }
            else
            {
                return find(node.right, key, out value);
            }
        }

        private void insert(ref Node node, Key key, Value value)
        {
            if (node == null)
            {
                size++;
                node = new Node(key, value);
                return;
            }
            int compare = key.CompareTo(node.key);
            if (compare == 0)
            {
                size++;
                node.children++;
                node.frequent++;
                node.value = value;
            }
            else if (compare < 0)
            {
                insert(ref node.left, key, value);
                node.children++;
            }
            else
            {
                insert(ref node.right, key, value);
                node.children++;
            }
        }

        public bool Successor(Key key, ref Key suc)
        {
            Node node = successor(root, null, key);
            if (node != null)
            {
                suc = node.key;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node successor(Node node, Node corner, Key key)
        {
            if (node == null) return null;
            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                return successor(node.left, node, key);
            }
            else if (compare > 0)
            {
                return successor(node.right, corner, key);
            }
            else
            {
                if (node.right != null)
                {
                    return min(node.right);
                }
                else
                {
                    return corner;
                }
            }
        }

        public bool Predecessor(Key key, ref Key pre)
        {
            Node node = predecessor(root, null, key);
            if (node != null)
            {
                pre = node.key;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node predecessor(Node node, Node corner, Key key)
        {
            if (node == null) return null;
            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                return predecessor(node.left, corner, key);
            }
            else if (compare > 0)
            {
                return predecessor(node.right, node, key);
            }
            else
            {
                if (node.left != null)
                {
                    return max(node.left);
                }
                else
                {
                    return corner;
                }
            }
        }

        public bool Ceil(Key key, ref Key floor)
        {
            Node node = this.ceil(root, null, key);
            if (node != null)
            {
                floor = node.key;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Floor(Key key, ref Key floor)
        {
            Node node = this.floor(root, null, key);
            if(node != null)
            {
                floor = node.key;
                return true;
            }else
            {
                return false;
            }
        }

        private Node ceil(Node node, Node corner, Key key)
        {
            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (node.left != null)
                {
                    return ceil(node.left, node, key);
                }
                else
                {
                    return corner;
                }
            }
            else if (compare > 0)
            {
                if (node.right != null)
                {
                    return ceil(node.right, corner, key);
                }
                else
                {
                    return node;
                }
            }
            else
            {
                if (node.right != null)
                {
                    return min(node.right);
                }
                else
                {
                    return corner;
                }
            }
        }

        private Node floor(Node node, Node corner, Key key)
        {
            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if(node.left != null)
                {
                    return floor(node.left, corner, key);
                }
                else
                {
                    return corner;
                }                
            }
            else if (compare > 0)
            {
                if(node.right != null)
                {
                    return floor(node.right, node, key);
                }else
                {
                    return node;
                }                
            }
            else
            {
                if (node.left != null)
                {
                    return max(node.left);
                }
                else
                {
                    return corner;
                }
            }
        }

        private bool Rank(Node node, Key key, ref int rank)
        {
            if (node == null) return false;
            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                return Rank(node.left, key, ref rank);
            }
            else if (compare > 0)
            {
                if (node.left != null)
                {
                    rank += node.left.children;
                }
                rank += node.frequent;
                return Rank(node.right, key, ref rank);
            }
            else
            {
                rank += node.left.children + 1;
                return true;
            }
        }

        private Node select(Node node, ref int rank, int k)
        {
            if (node == null) return null;
            int begin = rank;
            if (node.left != null)
            {
                begin += node.left.children;
            }
            if (k < begin)
            {
                return select(node.left, ref rank, k);
            }
            int end = begin + node.frequent;
            if (k < end)
            {
                return node;
            }
            else
            {
                rank = end;
                return select(node.right, ref rank, k);
            }
        }

        public bool select(int k, ref Key key)
        {
            int rank = 0;
            Node node = this.select(root, ref rank, k);

            if (node != null)
            {
                key = node.key;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Rank(Key key)
        {
            int rank = 0;
            bool found = this.Rank(root, key, ref rank);
            return found ? rank : -1;
        }

        class Node
        {
            public Key key;

            public Value value;

            public Node left;

            public Node right;

            public int children;

            public int frequent;

            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                this.frequent = 1;
                this.children = 1;
            }
        }
    }
}