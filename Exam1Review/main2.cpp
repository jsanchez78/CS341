/*
Testing Exam1 Questions CS341
*/
#include <iostream>
#include <list>
#include <iterator>
#include <vector>
using namespace std;

int main(){

  vector<int> v3;

  int a = 1;
  int b = 2;
  int *c = &a;
  v3.push_back(a);
  v3.push_back(b);
  v3.push_back(*c);

  for(const int & print:v3){
    cout << print << endl;
  }

  return 0;
}
