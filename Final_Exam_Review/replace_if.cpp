#include <iostream>     // std::cout
#include <algorithm>    // std::replace_if
#include <vector>       // std::vector

template<typename ContainerType,typename ElementType>;

bool exam_scores(ElementType NV){
  return (NV > 100);
}
void replace_if(typename ContainerType::iterator B,typename ContainerType::iterator E, std::function<bool(ElementType)> P,ElementType NV){

  while(B != E){ //Until end of list
    if(P(B))
      *B = NV;
    B++;
  }
}
void replace_if2(typename ContainerType::iterator B,typename ContainerType::iterator E, std::function<bool(ElementType)> P,ElementType NV){

  for_each(B,E,
  [&](ElementType &e)
      if(P(e)){
        e = NV;
      }
    );
}
int main(){
  std::vector<int> v = {90,101,89,99,200,123,40,98,114};
  replace_if(v.begin(),v.end(),exam_scores(ElementType NV),ElementType NV);
  for(int &e:v){
    std::cout << e << std::endl;
  }
}
