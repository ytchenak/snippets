"use strict";

var tr = require('./tree');

function TreeAlgo(tree) {
	this.tree = tree;
}

TreeAlgo.prototype.sort = function( ) {
	var result = [];

	function traverseRecurse( node, result ) {
		if( node == null )
			return;
		traverseRecurse(node.left, result);
		result.push(node.data);
		traverseRecurse(node.right, result);
	}
	
	traverseRecurse(this.tree.root, result);
	return result;
}


var tree = new tr.Tree();
tree.insert(3);
tree.insert(5);
tree.insert(2);
tree.insert(1);
tree.insert(4);

var algo = new TreeAlgo(tree);
console.log("sort: " + algo.sort());

