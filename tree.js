"use strict";
function Tree() {

	function Node(data, left, right, id) {
		this.data = data;
		this.left = left;
		this.right = right;
		this.toString = function() {
			return this.data;
		}
	}


	this.root = null;

	this.insert = function(data) {
		var node = new Node(data, null, null);
		if( this.root == null) {
			this.root = node;
			return;
		}
		
		var current = this.root;
		while(true) {
			var parent = current;
			if( data < current.data ) {
				current = current.left;
				if( current == null ) {
					parent.left = node;
					break;
				}
			}
			else { //current >= current.data) 
				current = current.right;
				if( current == null ) {
					parent.right = node;
					break;
				}
			}
		}
	}
	this.traverseRecurse = function( node, callback ) {
		if( node == null )
			return;
		this.traverseRecurse(node.left, callback);
		callback(node.data);
		this.traverseRecurse(node.right, callback);
	}
	this.traverse = function( callback ) {
		console.log(callback);
		this.traverseRecurse(this.root, callback);
	}

	this.findFromNode = function(node, data) {
		console.log('find - ' + node + ' ' + data);
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

	this.find = function(data) {
		return this.findFromNode(this.root, data);
	}
}



var tree = new Tree();
tree.insert(5);
tree.insert(2);
tree.insert(1);
tree.insert(4);
tree.insert(3);
tree.traverse( function(data) {
	process.stdout.write(data.toString() + ' ');
});
console.log("");

var node = tree.find(3);
console.log('find=' + node);
/