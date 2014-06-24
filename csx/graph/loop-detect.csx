#load graph.csx

class Finder {
	Dictionary<int, int> _visited; //not exists -- unvisited, <0 -- visited (completed), >0 -- visiting
	Graph _graph;

	public Finder(Graph graph) {
		_graph = graph;
	}

	public IEnumerable<int> FindLoop(int start) {
		_visited = new Dictionary<int, int>();

		//start finding from start. 0 - mean comming from nowhere (root)
		int c = FindLoop(start, 0);
		if( c > 0 )
		{
			// start from vertex that went to start vertex and backtrack until find the same start vertex.
			var path = new Stack<int>();
			for( int v=_visited[c]; v != c; v=_visited[v]) {
				path.Push(v);
			}
			path.Push(c);
			return path;
		}

		return Enumerable.Empty<int>(); //TODO: result
	}

	private int FindLoop(int v, int source) {
		
		_visited[v] = source;

		foreach (var w in _graph.GetOutgoingVertecies(v)) {
			//looking for w
		    if( !_visited.ContainsKey(w) ) {
		    	int c = FindLoop(w, v);
		    	if( c > 0 ) {
		    		return c; //a vertex in loop was found
		    	}

		    }
		    // check if a loop is detected. the loop is detected is source is not negative. 
		    else if( _visited[w] >= 0 ) {
		    	//cycle detected from v to w
		    	_visited[w] = v; //a loop was closed from w to v (w was visited from w)
		    	return w;		 //return start of loop - will be backtraced latter
		    }
		    else {
		    	//already visited from (-_visited[w]);
		    }
		}

		_visited[v] = -_visited[v];  // make the vertex negative as mark for completelly visited.
		return 0; // no loop was found
	}
}

var g = CreateGraph();
g.AddEdge(4, 1); //make a loop
g.Print();

var finder = new Finder(g);
var path = finder.FindLoop(2);
Console.WriteLine(string.Join("->", path));



