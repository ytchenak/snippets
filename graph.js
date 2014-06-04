

//JSON.stringify(g)

// process.on('uncaughtException', function(err) {
//     console.log(err);
// });

function Vertex (data) {
	this.data = data;
}
Vertex.prototype.toString = function() {
		return this.data;
};

function Edge (source, target) {
	this.source = source;
	this.target = target;
	this.toString = function() {
		return this.source + '=>' + this.target;
	}
}

function Graph () {
	this.edges1 = {};
	this.edges2 = {};

	this.addVertex = function(v) {
		if( !(this.edges1[v]) ) 
			this.edges1[v1] = [];
		if( !(this.edges2[v]) ) 
			this.edges2[v2] = [];
	}

	this.addEdge = function(v1, v2) {
		if( !(this.edges1[v1]) ) 
			this.edges1[v1] = [];
		this.edges1[v1].push( new Edge(v1, v2));
	}

	this.toString = function() {
		var s = '\n';
		for( var v in this.edges1) {
			s += v;
			s += ' => [ ';
			this.edges1[v].forEach( function(e) {
				s += e.target + ' ';
			});
			s += '] ';
		} 
		return s;
	}

	this.dfs = function(v) {
		var marked  = {};
		var stack  = [];
		this.dfsRecursive(v, marked);
		// this.dfsStack(v, marked, stack);
	}
	this.dfsRecursive = function(v, marked) {
		var _this = this;
		marked[v] = true;

		console.log('visiting Vertex ' + v);
	
		var vEdges = this.edges1[v];
		if( vEdges == undefined) {
			// return;
		}

		vEdges.forEach( function(e) {
			var vTarget = e.target;
			if( marked[vTarget] ) {
				console.log('Vertex ' + vTarget + ' is already visited');
				return;
			}
			_this.dfsRecursive(vTarget, marked);
		});
	}
	this.dfsStack = function(v, marked, stack) {
		var _this = this;
		stack.pop(v);
	
		while ( stack.length > 0) {
			v = stack.shift(); 
			marked[v] = true;
			console.log('visiting Vertex ' + v);
			var vEdges = this.edges1[v];
			if( vEdges == undefined) {
				return;
			}

			vEdges.forEach( function(e) {
				var vTarget = e.target;
				if( !marked[vTarget] ) {
					stack.push(vTarget);
				}
			});
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
//g.addEdge(v6, v1);


console.log('graph:' + g.toString()); 
g.dfs(v1);



