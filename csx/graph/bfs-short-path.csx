#load graph.csx

//bfs-short-path.csx

List<int> Qs(Graph g, int start, int target) {
	var pred = new Dictionary<int, int>();
	var queue = new Queue<int>();
	var visited = new Dictionary<int, bool>();
	queue.Enqueue(start);
	pred[start] = 0;
	while( queue.Count > 0 ) {
		var v = queue.Dequeue();
		if( v == target) {
			break;
		}
		var edges = g.GetOutgoing(v);
		foreach (var e in edges) {
		    if( !visited.ContainsKey(e.Target)) {
		    	visited[e.Target] = true;
		    	pred[e.Target] = v;
		    	queue.Enqueue(e.Target);
		    }
		}	
	}


	var path = new Stack<int>();
	for( int v = target; v != 0; v = pred[v]) {
		path.Push(v);
	}

	return path.ToList();
}

var g = CreateGraph();

g.Print();

var path = Qs(g, 1, 4);

Console.WriteLine("[{0}]", string.Join(",", path));
