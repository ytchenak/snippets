#include <iostream>
#include <cassert>


namespace my {

	namespace {
		template<typename T>
		struct Node {
			Node* next;
			Node* prev;
			T data;

			Node(T data) {
				this->data = data;
				this->prev = NULL;
				this->next = NULL; 
			};
		};
	}

	template<class T>
	class List {
	public:
		List() {
			_head = NULL;
			_tail = NULL;
		}

		void add(const T& data) {
			Node<T>* node = new Node<T>(data);
			if( _tail == NULL) {
				_head = node;
				_tail = node;
			}
			else {
				_tail->next = node;
				node->prev = _tail;
				_tail = node;
			}
		}

		void print() {
			for( Node<T>* node = _head; node != NULL; node = node->next) {
				std::cout << node->data << std::endl;
			}
		}



	private:
		Node<T>* _head;
		Node<T>* _tail;

	};

};



int main()
{
	std::cout << "hey" << std::endl;
	my::List<int>* list = new my::List<int>();
	list->add(1);
	list->add(2);
	list->add(3);
	list->print();
	return 0;
}