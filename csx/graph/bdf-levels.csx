#load graph.csx

//bdf-levels.csx

// helper structure keeping vertex id and its level
struct QItem {
	public int Id;
	public int Level;
}

// sort the entire 
void SortByLevels( Graph g, int start, ref List<List<int>> levels ) {
	
	var queue = new Queue<QItem>();
	var visited = new HashSet<int>();
	queue.Enqueue( new QItem { Id = start, Level = 0} );
	visited.Add(start);

	while( queue.Count > 0 ) {

		// take next vertex to handle
		var q = queue.Dequeue();
		int v = q.Id;
		int level = q.Level;

		// add the current vertex to the current level
		if( level < levels.Count   )
			levels[level].Add(v);
		else
			levels.Add( new List<int> { v } );

		//add all not visited children of v
		foreach (var w in g.GetOutgoing(q.Id).Select( e => e.Target)) {
			if( visited.Add(w) ) {
				queue.Enqueue( new QItem { Id = w, Level = level + 1});
			}
		}
	}
}

var g = CreateGraph();
var levels = new List<List<int>>();
SortByLevels(g, 1, ref levels);

for( int level=0; level<levels.Count; level++) {
	Console.WriteLine("{0}: [{1}]", level, string.Join(",", levels[level]));
}
