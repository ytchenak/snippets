// Given a string (for example: "a?bc?def?g"), write a program to generate all the possible strings by replacing ? with 0 and 1. 
// Example: 
// Input : a?b?c? 
// Output: a0b0c0, a0b0c1, a0b1c0, a0b1c1, a1b0c0, a1b0c1, a1b1c0, a1b1c1.


public List<string> Generate(string template) {

	var result = new List<string>();
	var current = template.ToArray();
	var index = new List<int>();
	for(int i=0; i<template.Length; i++) {
		if( template[i] == '?') {
			index.Add(i); //put index
			current[i] = '0'; //initial value
		}
	}

	result.Add( new string(current));
	var maxCount = 1 << index.Count;
	for( int n=1; n<maxCount; n++) {
		var carry = true; //we add 1.
		for (var i=index.Count-1; i>=0; i--) {
			if( !carry)
				break;
			var pos = index[i];
			if( current[pos] == '1' ) { //max value
				current[pos] = '0';
				carry = true;
			}
			else { //was '0'
				current[pos] = '1';	
				carry = false;
			}
		}
		result.Add( new string(current));
	}
	return result;
}


public List<string> GenerateRecursive(string template) {

	var result = new List<string>();
	var current = template.ToArray();
	var index = new List<int>();
	for(int i=0; i<template.Length; i++) {
		if( template[i] == '?') {
			index.Add(i); //put index
			current[i] = '0'; //initial value
		}
	}
	
	return result;
} 

var template = "a?bc?def?g";

Console.WriteLine(template);

var result = Generate(template);
Console.WriteLine("generated {0} strings", result.Count );
foreach (var s in result) {
    Console.WriteLine(s);
}
