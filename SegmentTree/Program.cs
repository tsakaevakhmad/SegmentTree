

using SegmentTree;

var list = new List<int>() { 1, 2, 3, 4, 3, 4, 5, 6, 7, 8, 9, };

var segment = new Tree(list);

Console.WriteLine(segment.Query(segment.Head, 4, 7));
