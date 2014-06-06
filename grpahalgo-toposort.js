'use strict';
var gh = require('./graph')

//-------------------------------------------------------------
function GraphAlgo(graph) {
	this.graph = graph;
}

GraphAlgo.prototype.topologicalSort = function(rootId) {
	var discovered = {} //hash
	var result = [];
	this.dfsRecursive(rootId, result, discovered);
	return result;
}

//make dfs recursive reverse post order traverse
GraphAlgo.prototype.dfsRecursive = function(vertexId, result, discovered) {
	var self = this;

	discovered[vertexId] = 1;
	console.log('start vertex ' + vertexId 
		+ ' discovered: ' + JSON.stringify(discovered)
		);

	var edges = this.graph.getOutgoingEdges(vertexId);

	if( edges != undefined) {
		edges.forEach( function(edge) {
			console.log( edge + ' : ' + discovered[edge.targetId]);
			if( discovered[edge.targetId] == undefined ) {
				self.dfsRecursive(edge.targetId, result, discovered);
			}
		});
	}

	discovered[vertexId] = 2;
	console.log('end vertex ' + vertexId 
		+ ' discovered: ' + JSON.stringify(discovered)
		);

	result.unshift(this.graph.getVertex(vertexId)); //reverse post order
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
var result = algo.topologicalSort(1);
console.log('topological sorted: '+ result.map( function(vertex) {
	return vertex.id;
}));



