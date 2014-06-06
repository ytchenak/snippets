'use strict';

function Node(data, next) {
	this.data = data;
	this.next = next;
};


function List () {
	this.head = null;
}

List.prototype.add = function(data) {
	if( this.head == null ) {
		this.head = new Node(data, null);
	}
	else {
		this.head = new Node(data, this.head);
	}
};

List.prototype.toString = function() {
	var s = '[ ';
	for(var node = this.head; node != null; node = node.next) {
		s += node.data + ' ';
	}
	s += ']';
	return s;
};

List.prototype.reverse = function() {
	var previous = null;
	var current  = this.head;

	while(current != null) {
		var next = current.next;
		current.next = previous;
		this.head = previous = current;
		current = next;
	}

};

var list = new List();
list.add(1);
list.add(2);
list.add(3);
list.add(4);
console.log('original list: ' + list);
list.reverse();
console.log('reversed list: ' + list);
