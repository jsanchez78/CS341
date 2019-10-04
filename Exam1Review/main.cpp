/*
Testing Exam1 Questions CS341
*/
#include <iostream>
#include <list>
#include <iterator>
#include <vector>
using namespace std;
/*
void bad_copy(vector<int> v1){
  vector<int> v2;
  v2 = v1;
  v1[0] = 2;
  v2[1] = 3;

  for(auto &x:v2){
    cout << x << endl;
  }
  for(auto &x:v1){
    cout << x << endl;
  }
}
*/
int main(){
  list<double> test;
  vector<int> v1;
  v1[1] = 4;
  test.push_back(42.5);
  test.push_back(11.9);
  test.push_back(18.2);


  auto x = test.begin();
  auto y = test.end();

  auto E1 = *x;
  auto E2 = *y;


  cout << "Value of E1: " << E1 << endl;
  cout << "Value of E2: " << E2 << endl;


  /*
  Testing bad and dumby copies



  for(auto &x:v1){
    cout << x << endl;
  }
  //bad_copy(v1);

  for(auto &x:v1){
    cout << x << endl;
  }  */

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
