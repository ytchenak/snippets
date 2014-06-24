//graph.csx


//TODO: can be added tempalte data
class Vertex {
	private int _id;

	public int Id { get { return _id; } }
	
	public Vertex(int id) {
		_id = id;
	}
}


class Edge {
	private int _source;
	private int _target;

	public int Source { get { return _source; } }
	public int Target { get { return _target; } }

	public Edge(int source, int target) {
		_source = source;
		_target = target;
	}
}


// unidirect graph. can be covnert to bidirection by adding incoming edges
class Graph {
	private Dictionary<int, Vertex> _vertices = new Dictionary<int, Vertex>();
	private Dictionary<int, List<Edge>> 	_outgoing = new Dictionary<int, List<Edge>>();

	public void AddVertex(int id) {
		_vertices[id] = new Vertex(id);
	}

	public void AddEdge(int source, int target) {
		if(!_vertices.ContainsKey(source)) throw new ArgumentException("source");
		if(!_vertices.ContainsKey(target)) throw new ArgumentException("target");
		if( _outgoing.ContainsKey(source))
			_outgoing[source].Add( new Edge(source, target) );
		else
			_outgoing[source] = new List<Edge> { new Edge(source, target) };
	}

	public Vertex GetVertex(int id) {
		return _vertices[id];
	}

	public IEnumerable<Edge> GetOutgoingEdges(int id) {

		List<Edge> edges;
		if( _outgoing.TryGetValue(id, out edges))
			return edges;
		else
			return Enumerable.Empty<Edge>();
	}

	public IEnumerable<int> GetOutgoingVertecies(int id) {

		List<Edge> edges;
		if( _outgoing.TryGetValue(id, out edges))
			return edges.Select( e => e.Target );
		else
			return Enumerable.Empty<int>();
	}

	public void Print()	{
		Console.WriteLine("graph:");
		foreach (var v in _vertices) {
		    Console.WriteLine("{0}->[{1}]", 
		    	v.Key, 
		    	_outgoing.ContainsKey(v.Key)?
		    		string.Join(",", _outgoing[v.Key].Select(e => e.Target)) :
		    		""
		    	);
		}
	}
}

Graph CreateGraph() {
	var g = new Graph();
	g.AddVertex(1);
	g.AddVertex(2);
	g.AddVertex(3);
	g.AddVertex(4);

	g.AddEdge(1, 2);
	g.AddEdge(1, 3);
	g.AddEdge(2, 3);
	g.AddEdge(2, 4);
	g.AddEdge(3, 4);

	return g;
}

