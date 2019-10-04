#include <iostream>
#include <vector>
using namespace std;

int _sumVec(vector<int>::iterator curr,vector<int>::iterator end){
  //Base Case
  if(curr == end)
    return 0;
  cout << *curr << endl;
  return *curr + _sumVec(++curr,end);
}

int sumVec(vector<int> &v){
  return _sumVec(v.begin(),v.end());
}

int main(){
  vector<int> test;
  test.push_back(1);
  test.push_back(2);
  test.push_back(3);
  cout << sumVec(test) << endl;
}
