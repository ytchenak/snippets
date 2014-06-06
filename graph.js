'use strict';
module.exports.Vertex = Vertex;
module.exports.Edge = Edge;
module.exports.Graph = Graph;

//------------------------------------------------------
//graph vertex. id is unique identificator of the vertex. 
function Vertex (id, data) {
	this.id = id;
	this.data = data;
}
Vertex.prototype.toString = function() {
		return this.id;
};

//--------------------------------------------
// graph edge - connects two vertex and can has own data
function Edge (sourceId, targetId, data) {
	this.sourceId = sourceId;
	this.targetId = targetId;
	this.data = data;
}
Edge.prototype.toString = function() {
		return this.sourceId + '=>' + this.targetId;
};

//---------------------------------------------
//unidirected graph
function Graph () {
	this.vertices = {} 
	this.outgoingEdges = {};
}

Graph.prototype.addVertex = function(id, data) {
	var vertex = new Vertex(id, data);
	this.vertices[id] = vertex;
}

Graph.prototype.getVertex = function(id) {
	return this.vertices[id];
}

Graph.prototype.addEdge = function(sourceId, targetId, data) {
	var edge = new Edge(sourceId, targetId, data);
	if ( this.outgoingEdges[sourceId] == undefined )
		this.outgoingEdges[sourceId] = [] 
	this.outgoingEdges[sourceId].push(edge);
}

Graph.prototype.getOutgoingEdges = function(id) {
	return this.outgoingEdges[id];
}

Graph.prototype.toString = function() {
	var s = '';
	for( var sourceId in this.outgoingEdges) {
		s += sourceId;
		s += ' => [' + this.outgoingEdges[sourceId].map( function(edge) {
			return edge.targetId;
		});
		s += ']; ';
	} 
	return s;
}


