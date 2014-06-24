//path-sort.csx

struct Segment {
	private int _from;
	private int _to;

	public Segment(int from, int to) {
		_from = from;
		_to = to;
	}
	public int From { get { return _from; 	} }
	public int To 	{ get { return _to; 	} }
}


class Finder {
	
	enum Mode { Visiting, Visited };

	Dictionary<int, int> 	_outgoing;
	Dictionary<int, Mode> 	_visited;
	Stack<int> 				_path;

	void FindRecursive(int v) {
		_visited[v] = Mode.Visiting; 

		int w;
		if( _outgoing.TryGetValue(v, out w))
		{
			if( !_visited.ContainsKey(w) ) {
				FindRecursive(w);
			}
			else if( _visited[w] == Mode.Visiting) {
				Console.WriteLine("Warning: cycle was broken: {0}-{1}" , v, w);
			}
		}
		_visited[v] = Mode.Visited; 

		_path.Push(v); //post ordering
	}

	public IEnumerable<int> Find(IEnumerable<Segment> segments ) {
		
		_outgoing = segments.ToDictionary( x => x.From, x => x.To );
		
		_visited = new Dictionary<int, Mode>();
		_path = new Stack<int>();

		foreach( var s in _outgoing.Keys ) {
			if( !_visited.ContainsKey(s))
				FindRecursive(s);
		}

		return _path;
	}


}



//main
var segments = new List<Segment>() {
	new Segment (3, 4),
	new Segment (4, 1),
	new Segment (2, 3),
	new Segment (1, 1),
	//new Segment (1, 2),
};

var finder = new Finder();
var path = finder.Find(segments);
Console.WriteLine( string.Join(",", path))
