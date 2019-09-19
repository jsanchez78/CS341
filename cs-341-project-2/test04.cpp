/*test04.cpp*/

//
// Prof. Joe Hummel
// U. of Illinois, Chicago
// CS 341, Spring 2019
// Project #01: Grade Analysis
// 


// *****************************************************************
//
// Test cases:
// 
// *****************************************************************

#include <iostream>
#include <string>
#include <cstdlib>
#include <cmath>
#include <vector>

#include "gradeutil.h"
#include "catch.hpp"

using namespace std;


TEST_CASE( "Test 04", "[Project01]" ) 
{
  Course C0("CS", "Database Design", 480, 01, "Deitz", 
            /*A-F*/ 10, 20, 30, 40, 50, 
            /*I,S,U,W,NR*/ 60, 70, 80, 90, 100);
  Course C1("CS", "Professional Seminar", 499, 01, "Hummel", 
            /*A-F*/ 0, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 3, 88, 2, 0, 0);
  Course C2("CS", "Program Design II", 141, 03, "Reed", 
            /*A-F*/ 1, 2, 3, 4, 5, 
            /*I,S,U,W,NR*/ 6, 7, 8, 9, 10);
  Course C3("CS", "Program Design XV", 111, 03, "Zizza", 
            /*A-F*/ 0, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 2, 4, 6, 8, 10); 
  Course C4("CS", "Program Design II", 141, 02, "Reed", 
            /*A-F*/ 0, 22, 0, 10, 2, 
            /*I,S,U,W,NR*/ 1, 5, 10, 15, 20);
  Course C5("CS", "Program Design I", 111, 02, "Hummel", 
            /*A-F*/ 0, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 0, 0, 0, 0, 0);
  Course C6("CS", "Program Design II", 141, 01, "Troy", 
            /*A-F*/ 99, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 0, 0, 0, 0, 98);
  Course C7("CS", "Wearables", 494, 01, "Humphrey", 
            /*A-F*/ 12, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 0, 0, 0, 0, 8);

  Dept dept;
  dept.Name = "CS";
  dept.Courses.push_back(C0);
  dept.Courses.push_back(C1);
  dept.Courses.push_back(C2);
  dept.Courses.push_back(C3);
  dept.Courses.push_back(C4);
  dept.Courses.push_back(C5);
  dept.Courses.push_back(C6);
  dept.Courses.push_back(C7);
  
  vector<Course> courses = FindCourses(dept, 141);
  
  REQUIRE(courses.size() == 3);
  
  REQUIRE(courses[0].Instructor == "Troy");
  REQUIRE(courses[0].Number == 141);
  REQUIRE(courses[0].Section == 01);
  REQUIRE(courses[0].NumA == 99);
  REQUIRE(courses[0].NumNR == 98);
  REQUIRE(courses[1].Instructor == "Reed");
  REQUIRE(courses[1].Number == 141);
  REQUIRE(courses[1].Section == 02);
  REQUIRE(courses[1].NumA == 0);
  REQUIRE(courses[1].NumNR == 20);
  REQUIRE(courses[2].Instructor == "Reed");
  REQUIRE(courses[2].Number == 141);
  REQUIRE(courses[2].Section == 03);
  REQUIRE(courses[2].NumA == 1);
  REQUIRE(courses[2].NumNR == 10);
}
