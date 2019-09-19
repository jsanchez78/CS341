/*test03.cpp*/

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


TEST_CASE( "Test 03", "[Project01]" ) 
{
  Course C1("CS", "Program Design I", 111, 02, "Hummel", 
            /*A-F*/ 0, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 0, 0, 0, 0, 0);
  Course C2("CS", "Program Design II", 141, 02, "Reed", 
            /*A-F*/ 1, 2, 3, 4, 5, 
            /*I,S,U,W,NR*/ 6, 7, 8, 9, 10);
  Course C3("CS", "Program Design XV", 111, 01, "Zizza", 
            /*A-F*/ 0, 0, 0, 0, 0, 
            /*I,S,U,W,NR*/ 2, 4, 6, 8, 10); 
  Course C4("CS", "Program Design II", 141, 01, "Reed", 
            /*A-F*/ 0, 22, 0, 10, 2, 
            /*I,S,U,W,NR*/ 1, 5, 10, 15, 20);

  Dept dept;
  dept.Name = "CS";
  dept.Courses.push_back(C1);
  dept.Courses.push_back(C2);
  dept.Courses.push_back(C3);
  dept.Courses.push_back(C4);
  
  GradeStats stats = GetGradeDistribution(dept);
  
  REQUIRE(stats.N == 15+34);
  REQUIRE(stats.NumA == 1);
  REQUIRE(stats.NumB == 2+22);
  REQUIRE(stats.NumC == 3);
  REQUIRE(stats.NumD == 4+10);
  REQUIRE(stats.NumF == 5+2);
  
  REQUIRE( abs(stats.PercentA - ((1.0/49.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentB - ((24.0/49.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentC - ((3.0/49.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentD - ((14.0/49.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentF - ((7.0/49.0)*100.0)) < 0.0001 );
  
  int    DFW  = -1;
  int    N    = -2;  
  double rate = GetDFWRate(dept, DFW, N);
  
  REQUIRE( abs(rate - ((45.0/73.0)*100.0)) < 0.0001 );
  REQUIRE(DFW == 9+9+12+15);
  REQUIRE(N == 49+9+15);
}
