/*test02.cpp*/

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


TEST_CASE( "Test 02", "[Project01]" )
{
  Course C("CS", "Program Design I", 111, 01, "Hummel",
           /*A-F*/ 1, 2, 3, 4, 5,
           /*I,S,U,W,NR*/ 6, 7, 8, 9, 10);

  REQUIRE(C.Dept == "CS");
  REQUIRE(C.Title == "Program Design I");
  REQUIRE(C.Number == 111);
  REQUIRE(C.Section == 01);
  REQUIRE(C.Instructor == "Hummel");

  REQUIRE(C.NumA == 1);
  REQUIRE(C.NumB == 2);
  REQUIRE(C.NumC == 3);
  REQUIRE(C.NumD == 4);
  REQUIRE(C.NumF == 5);

  REQUIRE(C.NumI == 6);
  REQUIRE(C.NumS == 7);
  REQUIRE(C.NumU == 8);
  REQUIRE(C.NumW == 9);
  REQUIRE(C.NumNR == 10);
  
  REQUIRE(C.getGradingType() == Course::Letter);
  REQUIRE(C.getNumStudents() == 31);

  GradeStats stats = GetGradeDistribution(C);

  REQUIRE(stats.N == 15);
  REQUIRE(stats.NumA == 1);
  REQUIRE(stats.NumB == 2);
  REQUIRE(stats.NumC == 3);
  REQUIRE(stats.NumD == 4);
  REQUIRE(stats.NumF == 5);

  REQUIRE( abs(stats.PercentA - ((1.0/15.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentB - ((2.0/15.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentC - ((3.0/15.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentD - ((4.0/15.0)*100.0)) < 0.0001 );
  REQUIRE( abs(stats.PercentF - ((5.0/15.0)*100.0)) < 0.0001 );

  int    DFW  = -1;
  int    N    = -2;
  double rate = GetDFWRate(C, DFW, N);

  REQUIRE( abs(rate - ((18.0/24.0)*100.0)) < 0.0001 );
  REQUIRE(DFW == 18);
  REQUIRE(N == 24);
}
