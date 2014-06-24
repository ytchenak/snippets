var array = new List<int> {2, 8, 9, 6, 4, 5, 3, 1}.ToArray();

void Print( int[] array)
{
	foreach (var item in array) {
	    Console.Write("{0} ", item);
	}
	Console.WriteLine();
}

void Swapped( ref int x, ref int y)
{
	var tmp = x;
	x = y;
	y = tmp;
}

void Sort(int [] array) 
{
	var n = array.Length-1;

	while( n > 0 )
	{
		var newn = 0;
		for( var i=0; i<n; i++)
		{
			if( array[i] > array[i+1] )
			{
				Swapped(
					ref array[i], 
					ref array[i+1]);
				newn = i;
			}
		}
		n = newn;
	}
}

Print(array);
Sort(array);
Print(array);

