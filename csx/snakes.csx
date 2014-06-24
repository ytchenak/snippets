//snakes
class Counter {
	private char[,] _array;
	private string _target;
	private int _rowNumber;
	private int _columnNumber;

	public Counter(char[,] array, string target) {
		_array = array;
		_target = target;
		_rowNumber = array.GetLength(0);
		_columnNumber = array.GetLength(1);
	}
	
	public int Count() {
		int count = 0;
		for( int row=0; row < _rowNumber; row++) {
			for( int column=0; column < _columnNumber; column++) {
				var path = new Stack<int>();
				count += Count(row, column, 0, path);
			}
		}
		return count;
	}

	private int Count(int row, int column, int offset, Stack<int> path) {

		int count = 0;

		// recursive exit points
		if( _array[row, column] != _target[offset] )  //not matched
			return 0;

		if( offset == _target.Length-1)  //matched
			return 1;

		//recursive iteration
		path.Push(row*_columnNumber+column); //add matched cell index into the path

		if( CanMove(Direction.Down, 	path, row, column) )	count += Count(row+1, 	column,		offset+1, path);
		if( CanMove(Direction.Right, 	path, row, column) )	count += Count(row,   	column+1, 	offset+1, path);
		if( CanMove(Direction.Up, 		path, row, column) )	count += Count(row-1, 	column,		offset+1, path);
		if( CanMove(Direction.Left, 	path, row, column) )	count += Count(row,   	column-1, 	offset+1, path);
		
		path.Pop(); //return to the path. the cell can be used again.

		return count;
	}

	private enum Direction { Down, Right, Up, Left };
	
	private bool CanMove(Direction direction, Stack<int> path, int row, int column) {

		switch(direction) {
			case Direction.Down: row++; break;
			case Direction.Right: column++; break;
			case Direction.Up: row--; break;
			case Direction.Left: column--; break;
		}
		if( row >= 0 && row < _rowNumber 
			&& column >= 0 && column < _columnNumber 
			&& !path.Contains(row*_columnNumber+column)
			) {
			return true;
		}
		return false;
	}


}

// main
var array = new char[,]  {
		{'S','N','B','S','N'}, 
		{'B','A','K','E','A'}, 
		{'B','K','B','B','K'}, 
		{'S','E','B','S','E'},
	};

var target = "SNAKES";

var counter = new Counter(array, target);

Console.WriteLine("count = {0}", counter.Count()); 
