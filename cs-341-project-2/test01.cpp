/*test01.cpp*/

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


TEST_CASE( "Test 01", "[Project01]" ) 
{
  Course C;
  
  // format: Dept,Number,Section,Title,A,B,C,D,F,I,NR,S,U,W,Instructor
  
  C = ParseCourse("CS,111,01,Program Design I,0,0,0,0,0,0,0,0,0,0,Hummel");
           
  REQUIRE(C.Dept == "CS");
  REQUIRE(C.Title == "Program Design I");
  REQUIRE(C.Number == 111);
  REQUIRE(C.Section == 01);
  REQUIRE(C.Instructor == "Hummel");
  
  REQUIRE(C.NumA == 0);
  REQUIRE(C.NumB == 0);           
  REQUIRE(C.NumC == 0);
  REQUIRE(C.NumD == 0);
  REQUIRE(C.NumF == 0);
  
  REQUIRE(C.NumI == 0);
  REQUIRE(C.NumS == 0);           
  REQUIRE(C.NumU == 0);
  REQUIRE(C.NumW == 0);
  REQUIRE(C.NumNR == 0);  
  
  REQUIRE(C.getGradingType() == Course::Unknown);
  REQUIRE(C.getNumStudents() == 0);
}
