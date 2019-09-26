/*main.cpp*/

//
// <<YOUR NAME HERE>>
// U. of Illinois, Chicago
// CS 341, Fall 2019
// HW #05: std::map
//

#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <sstream>
#include <map>
#include <algorithm>
#include <functional>

#include "student.h"

using namespace std;


//
// input(filename):x
//
// Inputs student data from the file and returns a map of Student objects.
//
map<string,Student> input(string filename)
{
  ifstream  file(filename);
  string    line, name, mid, fnl;

  map<string,Student> students;

  if (!file.good())
  {
    cout << "**Error: cannot open input file!" << endl;
    return students;
  }

  getline(file, line);  // skip header row:

  //
  // for each line of data, create a student and push into the vector:
  //
  while (getline(file, line))
  {
    stringstream  ss(line);

    // format: name,midterm,final
    getline(ss, name, ',');
    getline(ss, mid, ',');
    getline(ss, fnl);

    Student  S(name, stoi(mid), stoi(fnl));

    //
    // TODO #1: insert student into map, using name as the key.
    // Insert using map's overloaded [ ] operator:
    //
    // students[???] = ???;

  students[name] = S;
  }

  return students;
}

//
// main:
//
int main()
{
  cout << std::fixed;
  cout << std::setprecision(2);

  // 1. Input student data:
  auto students = input("exams.csv");

  // 2. Output:
  cout << "** students **" << endl;


  //Iterator option but not necessary
  //map<string,Student>::iterator it = students.begin();
  for(const auto& keyvaluepair : students)
  {
    //
    // TODO #2: output student's name : exam average
    //
    // NOTE: each element is a (key, value) pair.  So don't think in terms
    // of students, but in terms of (key, value) pairs.  What's the key?
    // What's the value?
    //
    cout << keyvaluepair.first << ":" << keyvaluepair.second.ExamAvg() << endl;
  }

  // 3. Interact with user and lookup students:
  string name;

  cout << "** lookup **" << endl;

  cout << "Please enter a name (or #)> ";
  cin >> name;

  while (name != "#")
  {
    //
    // TODO #3: lookup student using std::find_if
    //
    // NOTE: each element is a (key, value) pair.  So don't think in terms
    // of students, but in terms of (key, value) pairs.  The lambda expression
    // takes a (key, value) pair as it's argument.  And the find_if function
    // will return an iterator denoting a (key, value) pair.
    //
    auto iter = std::find_if(students.begin(), students.end(),
      [=](std::pair<const string,Student>& x){///
        if(x.first == name)
          return true;
        else
          return false;
      }
      );
     if (iter == students.end())
       cout << "not found" << endl;
     else
       cout << name << ":" << students[name].ExamAvg() << endl;

    //
    // TODO #4: now lookup using map's overloaded [ ] operator:
    //
    // NOTE: this has the advantage that [key] will return the
    //  value associated with this key; the (key, value) pairs
    //  are hidden.  But there's a disadvantage that you'll see
    //  when you run and test...
    //
    Student s = students[name];
    //
    cout << s.Name << ":" << s.ExamAvg() << endl;

    //
    // prompt for next name and repeat:
    //
    cout << "Please enter a name (or #)> ";
    cin >> name;
  }

  //
  // done:
  //
  return 0;
}
