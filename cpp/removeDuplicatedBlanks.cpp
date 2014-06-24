//inplace remove duplicated spaces from string

#include <iostream>
#include <string>

bool isSpace(char ch) {
	return ch == ' ' || ch == '\t'; //TODO: more space-like character?
}

void removeDuplicatedSpaces(std::string& s) {
	std::string::iterator reader;
	std::string::iterator writer = s.begin();
	
	if( s.size() == 0 )
		return;

	bool isNoSpace = false;
	for( reader = s.begin(); reader != s.end();	++reader) {

		if( isSpace(*reader)) {
			if( isNoSpace ) {
				*writer++ = *reader;
			}
			isNoSpace = false;
			continue;
		}

		isNoSpace = true;
		*writer++ = *reader;
	}
	s.erase(writer-1, reader);
	std::cout << std::endl;
}


int main() {
	std::string s = "   there    are many    space    ";
	std::cout << s << std::endl;
	removeDuplicatedSpaces(s);
	std::cout 
		<< "'" 
		<< s 
		<< "'"
		<< " size=" << s.size() 
		<< std::endl;
	return 0;
}
