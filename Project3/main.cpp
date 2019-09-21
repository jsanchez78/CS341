/*gradeutil.cpp*/

//
// Prof. Joe Hummel
// U. of Illinois, Chicago
// CS 341, Spring 2019
// Project #02: GradeUtil API (Solution)
//
// Edited by Sean Deitz
// for CS 341, Fall 2019
//

#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <sstream>
#include <map>
#include <algorithm>
#include <functional>

#include "gradeutil.cpp"

using namespace std;

/*


Reverse Engineer the HashMap Application below to work for <string, College>



Better name would be course_map

Can change later


map<string,const Vector<Course>&>;
*/

map<string,College> input(string filename)
{
  ifstream  file(filename);
  string    line;

  map<string,const vector<Course>& c> college_map;///String to name of department

  if (!file.good())
  {
    cout << "**Error: cannot open input file!" << endl;
    return college_map;
  }

  getline(file, line);  // skip header row: //MIGHT NOT Want to skip NOW ????
  //
  // for each line of data, create a student and push into the vector:
  //
  while (getline(file, line))
  {
    Course C = ParseCourse("fall-2018.csv");
    auto keyvaluepair = std::pair<string, Course>(C.Dept,C);///Type of pair
    college_map.insert(keyvaluepair);//map.insert(std::pair<string,Student>);
  }
  return college_map;
}

/*


*/


//Count num of courses taught
int num_courses(const vector<Dept>&  Depts){
  return Depts.Courses.size();
}

//Count total students in a college
int studentsTaught(const vector<Dept>&  Depts){

  int count = 0;//Must initialize at 0 or will receive a garbage value
  for(const auto& n: Depts)
  {
    for(const auto& c: n)
    {
        count += c.getNumStudents();
    }
  }
  return count;
}

void college_stats(const College& college){
  GradeStats college_stats = GetGradeDistribution(college);
  cout << college_stats.PercentA << "%, " << college_stats.PercentB << "%, " << college_stats.PercentC << "%, " << college_stats.PercentD << "%, " << college_stats.PercentF;
  return;
}

void summary(){
  string college;
  cin >> college;

  if(college.compare("all")){

      return;
  }
  ///Otherwise a department is specified
  //We can generate a hashmap correlating with that particular dept string
  while (college != "all")
  {
    //
    // TODO #4: now lookup using map's find() method. Much like
    // std::find_if, find() returns an iterator to a (key, value)
    // pair.
    //
    auto iter2 = college_map.find(name);
    //
     if (iter2 == college_map.end())
       cout << "not found" << endl;
     else{
        cout << dept << ":\n";
        cout << "# courses taught: " << iter2.Courses.size();

     }
  }

}

int main(){

    ///Inputing CSV file && Parsing Data
    cout << std::fixed;
    cout << std::setprecision(2);

    // 1. Input student data:
    auto college_map = input("fall-2018.csv");


  ///Extracting Data ends here


  //Now We will Output said data
  int DFW;
  int N;
  //We can do something as follows College c = college_map.second;
  // 2. Output:
  cout << "** College of " << college_map.first << " " << college_map.second.Name << " " << college_map.third << " **\n";
  cout << "# of courses taught: " << num_courses(college_map.second.Depts) << endl;;//Pass in college vector<Dept> Depts
  cout << "# of students taught: " << studentsTaught() << endl;;
  cout << "grade distribution (A-F): " << college_stats(college_map.second) << endl;;
  cout << "DFW rate: " << GetDFWRate(college_map.second,DFW,N) << "%\n";


  for(const auto& keyvaluepair : students)
  {
    //
    // TODO #2: output student's name : exam average
    //
    // NOTE: each element is a (key, value) pair.  So don't think in terms
    // of students, but in terms of (key, value) pairs.  What's the key?
    // What's the value?
    //
    cout << keyvaluepair.first << ":" <<  << endl;
  }



  string command;
  cout << "Enter a command> ";
  cin >> command;

  ///Now we will designate input to command accordingly

  if(command.compare("summary"))
    summary();




  return 0;
  }
