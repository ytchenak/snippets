"use strict";

var tr = require('./tree');

function TreeAlgo(tree) {
	this.tree = tree;
}

TreeAlgo.prototype.find = function(data) {

	function findFromNode(node, data) {
		if( node == null )
			return null;
		if( node.data == data)
			return node;
		while(node != null) {
			if( data < node.data ) {
				return this.findFromNode(node.left, data);
			}
			else { //data > node.data
				return this.findFromNode(node.right, data);
			}
		}
		return null;
	}

	return findFromNode(this.tree.root, data);
}


var tree = new tr.Tree();
tree.insert(3);
tree.insert(5);
tree.insert(2);
tree.insert(1);
tree.insert(4);

var algo = new TreeAlgo(tree);
var node = algo.find(3);
console.log('find(3)=' + (node != null? node.data : 'null'));
