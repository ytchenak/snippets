

//JSON.stringify(g)

process.on('uncaughtException', function(err) {
    console.log(err);
});

function Vertex (data) {
	this.data = data;
}
Vertex.prototype.toString = function() {
		return this.data;
};

//--------------------------------------------

function Edge (source, target) {
	this.source = source;
	this.target = target;
}

Edge.prototype.toString = function() {
		return this.source + '=>' + this.target;
};


//unidirected graph
function Graph () {
	this.edges = {};
}

Graph.prototype.addVertex = function(v) {
	if( !(this.edges[v]) ) 
		this.edges[v1] = [];
}

Graph.prototype.addVertex = function(v) {
	if( !(this.edges[v]) ) 
		this.edges[v1] = [];
}

Graph.prototype.addEdge = function(v1, v2) {
	if( !(this.edges[v1]) ) 
		this.edges[v1] = [];
	this.edges[v1].push( new Edge(v1, v2));
}

Graph.prototype.toString = function() {
	var s = '';
	for( var v in this.edges) {
		s += v;
		s += ' => [' + this.edges[v].map( function(e) {
			return e.target.data;
		});
		s += ']; ';
	} 
	return s;
}

Graph.prototype.dfs = function(v, result) {
	var discovered = {} //hash
	var result = [];
	this.dfsRecursive(v, discovered, result);
	return result;
}
Graph.prototype.dfsRecursive = function(v, discovered, result) {
	var _this = this;
	discovered[v] = true;

	var vEdges = this.edges[v];
	if( vEdges != undefined) {

		vEdges.forEach( function(e) {
			var vTarget = e.target;
			if( !discovered[vTarget] ) {
				_this.dfsRecursive(vTarget, discovered, result);
			}
		});
	}
	result.unshift(v) //reverse post order
}
Graph.prototype.bfs = function(v) {
	var _this = this;
	var discovered = {}; //hash
	var queue = [];
	queue.push(v);

	while ( queue.length > 0) {
		v = queue.shift(); 
		if( !discovered[v]) {
			console.log('visiting Vertex ' + v);
			discovered[v] = true;
			var vEdges = this.edges[v];
			if( vEdges != undefined) {
				vEdges.forEach( function(e) {
					var vTarget = e.target;
					queue.push(vTarget);
				});
			}
		}
	}
}


var v1 = new Vertex('1');
var v2 = new Vertex('2');
var v3 = new Vertex('3');
var v4 = new Vertex('4');
var v5 = new Vertex('5');
var v6 = new Vertex('6');
var v6 = new Vertex('7');
 
var g = new Graph();
g.addEdge(v1, v2);
g.addEdge(v1, v3);
g.addEdge(v2, v4);
g.addEdge(v2, v5);
g.addEdge(v3, v6);
g.addEdge(v5, v3);
g.addEdge(v3, v4);

console.log('graph: ' + g.toString()); 
var result = g.dfs(v1);
console.log('topological sorted: '+ result.map( function(v) {
	return v.data;
}));



