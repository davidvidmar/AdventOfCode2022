using System.Collections;

namespace Day07
{
    public class TreeNode<TKey, TData> : IEnumerable<TreeNode<TKey, TData>>
    {

        public TData Data { get; set; }
        public TKey Key { get; set; }
        public TreeNode<TKey, TData> Parent { get; set; }
        public ICollection<TreeNode<TKey, TData>> Children { get; set; }

        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public bool IsLeaf
        {
            get { return Children.Count == 0; }
        }

        public int Level
        {
            get
            {
                if (IsRoot) return 0;
                return Parent.Level + 1;
            }
        }


        public TreeNode(TKey key, TData data)
        {
            Data = data;
            Key = key;

            Children = new LinkedList<TreeNode<TKey, TData>>();

            ElementsIndex = new LinkedList<TreeNode<TKey, TData>>();
            ElementsIndex.Add(this);
        }

        public TreeNode<TKey, TData> AddChild(TKey childKey, TData childData)
        {
            TreeNode<TKey, TData> childNode = new TreeNode<TKey, TData>(childKey, childData) { Parent = this };
            Children.Add(childNode);

            RegisterChildForSearch(childNode);

            return childNode;
        }

        public override string ToString()
        {
            //return Data != null ? Data.ToString() : "[data null]";
            return Key + " -> " + (Data != null ? Data.ToString() : "[data null]");
        }


        #region searching

        private ICollection<TreeNode<TKey, TData>> ElementsIndex { get; set; }

        private void RegisterChildForSearch(TreeNode<TKey, TData> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
                Parent.RegisterChildForSearch(node);
        }

        public TreeNode<TKey, TData> FindTreeNode(Func<TreeNode<TKey, TData>, bool> predicate)
        {
            return ElementsIndex.FirstOrDefault(predicate);
        }

        #endregion


        #region iterating

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<TKey, TData>> GetEnumerator()
        {
            yield return this;
            foreach (var directChild in Children)
            {
                foreach (var anyChild in directChild)
                    yield return anyChild;
            }
        }

        #endregion
    }
}