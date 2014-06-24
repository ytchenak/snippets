"use strict";

module.exports.Tree = Tree;

function Tree() {
	this.root = null;
}

Tree.prototype.insert = function(data) {

	function Node(data) {
		this.data = data;
		this.left = null;
		this.right = null;
	}

	var node = new Node(data);
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




