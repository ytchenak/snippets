class Node<T> {
	public Node<T> Next { get; set;}
	public T	 	Data { get; set;}
}

class List<T>
{
	private Node<T> _head;

	public void Insert(T data) {
		_head = _head == null? 
			new Node<T> { Data=data } : 
			new Node<T> { Data = data, Next = _head };
	}

	public void Print() {
		for( var item = _head; item != null; item = item.Next) {
			Console.Write("{0} ", item.Data);
		}
		Console.WriteLine();
	}

	public void Reverse() {
		Node<T> prev = null;
		var curr = _head;
		while ( curr != null ) {
			var next = curr.Next;
			curr.Next = prev;
			prev = curr;
			curr = next;
		}
		_head = prev;
	}
}

var list = new List<int>();
list.Insert(1);
list.Insert(2);
list.Insert(3);
list.Insert(4);
list.Print();
list.Reverse();
list.Print();
