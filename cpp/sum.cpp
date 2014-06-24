#include <iostream>
#include<algorithm>

class Sum
{
  private:
          int s;
  public:
  Sum(int x):s(x)
  {
      
  }
  
  int getSum()
  {
      return s;
  }
  
  void operator()(int p)
  {
     s = s + p;   
  }

};

int main()
{
   std::cout << "Hello World" << std::endl; 
   
   int arr[] = {1,2,3,4,5,6,7,8};
   Sum obj = std::for_each(arr,arr+7,Sum(1000));
   std::cout << obj.getSum() << std::endl;
   
   return 0;
}