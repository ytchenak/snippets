//reverse-words.csx

// reverse words in string

void Print(IEnumerable<string> list) {
	Console.WriteLine( string.Join(",", list));
}


var input = "  the sky     is   blue  ";

var words = input.Split(' ').Where( x => !string.IsNullOrEmpty(x)).ToList();

int i = 0;
int j = words.Count - 1;
while( i < j) {
	var tmp = words[i];
	words[i] = words[j];
	words[j] = tmp;
	++i;
	--j;
}

var output = string.Join(" ", words);

Console.WriteLine(input);
Console.WriteLine(output);
