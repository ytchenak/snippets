var list = new List<int>() {9,8,7,6,5,4,3,2,1};

void Print(List<int> list) {
	Console.WriteLine("[{0}]", string.Join( ",", list));
}


Print(list);
list.Sort();

int a = 0;
int b = 0;
int c = list.Length-1;
int d = 10;

for( ; a<c-3; a++) {


	b += 1;
	c -= 1;


	//lower upper bound
	if( list[a] + list[b] + list[c-1] <= d) {
			
	}

	//output
	for( int i=b+1; i<c ) {
		Console.WriteLine("{0}+{1}+{2}<={4}", a, b, c, d);
	}

	// 
	b++;

}





