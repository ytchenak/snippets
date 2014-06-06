'use strict';
var gh = require('./graph')

//-------------------------------------------------------------
function GraphAlgo(graph) {
	this.graph = graph;
}


GraphAlgo.prototype.bfs = function(rootId, result, discovered) {
	var self = this;

	var discovered = {} 
	var result = [];
	var stack = [];

	// //initial discover root and make it as discovered
	stack.push(rootId);
	discovered[rootId] = 1

	while( stack.length > 0 ) {
		var vertexId = stack.shift();
		console.log('discovered ' + vertexId );

		var edges = this.graph.getOutgoingEdges(vertexId);

		if( edges != undefined) {
			edges.forEach( function(edge) {
				// discover each target and marked it as discovered
				if( discovered[edge.targetId] == undefined ) {
					discovered[edge.targetId] = 1;
					stack.push(edge.targetId);
				}
			});
			console.log(' stack: ' + stack);
		}
	}

}

//==================================================

var g = new gh.Graph();
g.addVertex(1);
g.addVertex(2);
g.addVertex(3);
g.addVertex(4);
 
g.addEdge(1, 2);
g.addEdge(1, 3);
g.addEdge(2, 4);
g.addEdge(3, 4);
g.addEdge(3, 2);
g.addEdge(4, 1);

console.log('graph: ' + g.toString()); 

var algo = new GraphAlgo(g);
algo.bfs(1);



