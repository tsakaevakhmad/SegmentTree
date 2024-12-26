namespace SegmentTree
{
    public class Node
    {
        public Node(int leftIndex, int rightIndex, Node left, Node right, int sum) 
        {
            SumOfSegment = sum;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
            Left = left;
            Right = right;
        }

        public int SumOfSegment { get; set; }
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public class Tree
    {
        public Node Head { get; private set; }

        public Tree(List<int> data)
        {
            Head = BuildTree(data, 0, data.Count - 1);
        }

        private Node BuildTree(List<int> data, int treeLeft, int treeRight)
        {
            if(treeLeft == treeRight)
            {
                return new Node(treeLeft, treeRight, null, null, data[treeLeft]);
            }
            else
            {
                int middle = (treeLeft + treeRight) / 2;
                var leftChild = BuildTree(data, treeLeft, middle);
                var rightChild = BuildTree(data, middle + 1, treeRight);
                int sum = leftChild.SumOfSegment + rightChild.SumOfSegment;
                return new Node(treeLeft, treeRight, leftChild, rightChild, sum);
            }
        }

        public int Query(Node head, int left, int right)
        {
            if(head.LeftIndex == left && head.RightIndex == right)
                return head.SumOfSegment;

            int middle = (head.LeftIndex + head.RightIndex) / 2;

            if(right <= middle)
                return Query(head.Left, left, right);
            else if(left > middle)
                return Query(head.Right, left, right);
            else
            {
                var leftSum = Query(head.Left, left, middle);
                var rightSum = Query(head.Right, middle + 1, right);
                return leftSum + rightSum;
            }
        }
    }
}
