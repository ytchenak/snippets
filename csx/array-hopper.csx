//The Array Hopper Problem

// looking for min path

int MinStepsBfs( int[] array) {

	var queue = new Queue<int>();
	var visited = new Dictionary<int, int>(); //keep node where the node was visited from (0 - means will not be visisted)
	queue.Enqueue(0);
	visited[0] = -1; //the first array element is not riched anywhere


	while( queue.Count > 0) {
		var i = queue.Dequeue();
		Console.Write("{0}({1}) - ", array[i], i);

		for( var j=i+1; j < array.Length && j <= i+array[i]; j++) {
			Console.Write("{0}:{1} ", array[i], array[j]);
			if( !visited.ContainsKey(j) ) {
				visited[j] = i; //the j node was riched from i

				if( j == array.Length - 1)
				{
					Console.WriteLine("the end was riched!");

					// backtracking the visited elements to started element
					var result = 0;
					for( var k = j; k > 0; k=visited[k] )
					{
						Console.Write("{0}[{1}] <- ", k, array[k]);
						result++;
					}
					Console.WriteLine("{0}[{1}]", 0, array[0]);
					return result; 
				}


				queue.Enqueue(j);
			}
		}
		Console.WriteLine();
	}

	return -1; //the target is not rechiable
}

int MinStepsDp( int[] array) {
	int result = 0;
	
	//TODO

	return result;
}

int MinStepsGreedy( int[] array) {
	int result = 0;
	
	var i = 0;
	while( i < array.Length ) {
		var steps = array[i];
		int next = 0;
	}

	return result;
}




var array = new int[] {2,1,9,1,1,4};

Console.WriteLine(string.Join(",", array));
Console.WriteLine("MinStepsBfs={0}", MinStepsBfs(array));
Console.WriteLine("MinStepsDp={0}", MinStepsDp(array));
Console.WriteLine("MinStepsGreedy={0}", MinStepsGreedy(array));