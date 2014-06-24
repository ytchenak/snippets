public class Node<T> where T : IComparable<T> {
	public Node<T> Left { get; set; }
	public Node<T> Right { get; set; }
	public T 		Data { get; set; }
}

public class Tree<T> where T : IComparable<T> {
	private Node<T>	_root;

	private void TraverseRecursive(Node<T> node, Action<T> action) {
		if( node == null)
			return;
		TraverseRecursive(node.Left, action);
		action(node.Data);
		TraverseRecursive(node.Right, action);
	}

	public void Traverse( Action<T> action) {
		TraverseRecursive(_root, action);
	}

	public void Print() {
		Traverse( x => Console.WriteLine(x) );
	}

	private Node<T> CreateNode(T data ) {
		return new Node<T> { Data = data} ;
	}
	public void Insert(T data) 	{
		if( _root == null ) {
			_root = CreateNode(data);
			return;
		}
		
		Node<T> curr = _root;
		while( true ) {
			if( data.CompareTo(curr.Data) < 0 ) {
				if( curr.Left == null) {
					curr.Left = CreateNode(data);
					break;
				}
				else {
					curr = curr.Left;
				}
			}
			else {
				if( curr.Right == null ) {
					curr.Right = CreateNode(data);
					break;
				}
				else {
				    curr = curr.Right;
				}
			}
		}	
	}
}



