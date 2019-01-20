using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaiPhaDuLieu
{
    class TreeNode
    {
        Attribute _attributes;
        TreeNode[] _childs;
        //n là thuộc tính
        int n;
        int _numberLabel;

        internal Attribute Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        internal TreeNode[] Childs
        {
            get { return _childs; }
            set { _childs = value; }
        }

        public int NumberLabel
        {
            get { return _numberLabel; }
            set { _numberLabel = value; }
        }

        public TreeNode(Attribute Attributes)
        {
            this.Attributes = Attributes;
            this.Childs = new TreeNode[Attributes.Value.Count];
            n = 0;
            for (int i = 0; i < Attributes.Value.Count; i++)
            {
                Childs[i] = null;
            }
            if (Attributes.Value.Count == 0)
                NumberLabel = 1;
            else
                NumberLabel = 0;
        }

        public void AddNode(TreeNode Child)
        {
            if (n < Childs.Length)
            {
                Childs[n] = Child;
                NumberLabel = NumberLabel + Child.NumberLabel;
            }
            n++;
        }
    }
}