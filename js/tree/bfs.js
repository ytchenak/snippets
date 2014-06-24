"use strict";

var tr = require('./tree');

function TreeAlgo(tree) {
	this.tree = tree;
}

TreeAlgo.prototype.bfs = function( ) {
	var result = [];
	var stack = [];

	stack.push(this.tree.root)

	while( stack.length > 0 ) {
		var node = stack.shift();
		result.push(node.data);
		if( node.left != null)
			stack.push(node.left);
		if( node.right != null)
			stack.push(node.right);
	}

	return result;
}


var tree = new tr.Tree();
tree.insert(3);
tree.insert(5);
tree.insert(2);
tree.insert(1);
tree.insert(4);

var algo = new TreeAlgo(tree);
console.log("bfs: " + algo.bfs());

