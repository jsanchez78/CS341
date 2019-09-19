/*gradeutil.cpp*/

//
// <<Jacob Sanchez>>
// U. of Illinois, Chicago
// CS 341, Spring 2019
// Project #02: GradeUtil API
//
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

#include "gradeutil.h"

using namespace std;

void Dept::addCourse(Course course)
{
	// Add course to Courses.
	Courses.push_back(course);
}

void College::addDepartment(Dept department)
{
	// Add department to Depts.
	Depts.push_back(department);
}

//
// API:
//

//
// ParseCourse:
//
// Parses a CSV (comma-separated values) line into a Course
// object, which is then returned.  The given line must have
// the following format:
//
//   Dept,Number,Section,Title,A,B,C,D,F,I,NR,S,U,W,Instructor
//
// Example:
//   BIOE,101,01,Intro to Bioengineering,22,8,2,1,0,1,0,0,0,5,Eddington
//
// Note the lack of spaces, except perhaps in the title.
// If the given line does not have this format, the behavior
// of the function is undefined (it may crash, it may throw
// an exception, it may return).
//
Course ParseCourse(string csvline)
{
    /*
     *
     *
     * Note function is described as parsing a CSV line NOT a file
     *
     *
     */

   string _Dept,_Number,_Section,_Title,_A,_B,_C,_D,_F,_I,_NR,_S,_U,_W,_Instructor;


      stringstream ss(csvline);
      getline(ss,_Dept,',');
      getline(ss,_Number,',');
      getline(ss,_Section,',');
      getline(ss,_Title,',');
      getline(ss,_A,',');
      getline(ss,_B,',');
      getline(ss,_C,',');
      getline(ss,_D,',');
      getline(ss,_F,',');
      getline(ss,_I,',');
      getline(ss,_NR,',');
      getline(ss,_S,',');
      getline(ss,_U,',');
      getline(ss,_W,',');
      getline(ss,_Instructor);
      Course test(_Dept,_Title,stoi(_Number),stoi(_Section),_Instructor,stoi(_A),stoi(_B),stoi(_C),stoi(_D),stoi(_F),stoi(_I),stoi(_S),stoi(_U),stoi(_W),stoi(_NR));
      return test;
    }
//
// GetDFWRate:
//
// Returns the DFW rate as a percentage for a given course,
// department, or college.  For a course whose grading type
// is defined as Course::Letter, the DFW rate is defined as
//
//   # of D grades + F grades + Withdrawals
//   -------------------------------------- * 100.0
//   # of A, B, C, D, F grades + Withdrawls
//
// The numerator is returned via the reference parameter DFW;
// the denominator is returned via the reference parameter N.
// If the course grading type is not Course::Letter, the DFW
// rate is 0.0, and parameters DFW and N are set to 0.
//
// When computed for a dept or college, all courses of type
// Course::Letter are considered in computing an overall DFW
// rate for the dept or college.  The reference parameters
// DFW and N are also computed across the dept or college.
//
double GetDFWRate(const Course& c, int& DFW, int& N)
{
  DFW = 0;
  N   = 0;
  double DFWRate = 0.0;
  //
  // TODO:
  //
  if(c.getGradingType() == Course::Letter){
      DFW = c.NumD + c.NumF + c.NumW;
      N = c.NumA + c.NumB + c.NumC + c.NumD+c.NumF;
			if(N != 0)
      	DFWRate = 100.0 * DFW/N;
			if(N == 0)
				return 0;
  }
  return DFWRate;
}
/*
Double for range loop

Calculation is different than COurse

*/

double GetDFWRate(const Dept& dept, int& DFW, int& N)
{
  DFW = 0;
  N   = 0;
	//int tmpN;
  double DFWRate = 0.0;
  //
  // TODO:
  //
  for(const Course &c: dept.Courses){

		if(c.getGradingType() == Course::Letter){//Defined Case
			DFW = DFW + c.NumD + c.NumF + c.NumW;
			N = c.NumA + c.NumB + c.NumC + c.NumD + c.NumF +  c.NumW;

			}
		if(N != 0)
			DFWRate = 100.00 * DFW/N;
	if(N == 0)
		return 0;

		}//End of For loop


		return DFWRate;
	}

double GetDFWRate(const College& college, int& DFW, int& N)
	{
  DFW = 0;
  N   = 0;
  double DFWRate = 0.0;
	//double size = college.Depts.size();
  //
  // TODO:
  //

  for(const Dept &d: college.Depts){

		for(const Course &c: d.Courses){
			if(c.getGradingType() == Course::Letter){//Defined Case
			DFW = DFW + c.NumD + c.NumF + c.NumW;
			N = c.NumA + c.NumB + c.NumC + c.NumD + c.NumF +  c.NumW;

			}
		/*

			Compute DFWRate Values

		*/
		if(N != 0)
			DFWRate = 100.00 * DFW/N;
		if(N == 0)
			return 0;
			}

  }
    return DFWRate;
	}
//
// GetGradeDistribution
//
// Returns an object containing the grade distribution for a given
// course, dept or college.  For a course whose grading type is
// defined as Course::Letter, the grade distribution is defined by
// the following values:
//
//   N: the # of A, B, C, D, F grades
//   NumA, NumB, NumC, NumD, NumF: # of A, B, C, D, F grades
//   PercentA, PercentB, PercentC, PercentD, PercentF: % of A, B,
//     C, D, F grades.  Example: PercentA = NumA / N * 100.0
//
// If the course grading type is not Course::Letter, all values
// are 0.  When computed for a dept or college, all courses of
// type Course::Letter are considered in computing an overall
// grade distribution for the dept or college.
//
GradeStats GetGradeDistribution(const Course& c)
{
  //
  // TODO:
  //
  /*// Data members:
	//
	int    N;  // total # of grades assigned:
	int    NumA, NumB, NumC, NumD, NumF;  // number of A's, B's, etc.
	  // percentage of A's, B's, etc.
    	//
	// Default constructor:
	//
	GradeStats()
		: N(0), NumA(0), NumB(0), NumC(0), NumD(0), NumF(0),
		PercentA(0.0), PercentB(0.0), PercentC(0.0), PercentD(0.0), PercentF(0.0)
	{ }

*/
	if(c.getGradingType() != Course::Letter){
		GradeStats test;
		return test;
	}
	double total = c.NumA + c.NumB + c.NumC + c.NumD + c.NumF;
	//int total = c.Number;//This is the line which is different on Gradescope submission
  double PercentA, PercentB, PercentC, PercentD, PercentF;

  PercentA = 100.0 * c.NumA / total;
  PercentB = 100.0 * c.NumB / total;
  PercentC = 100.0 * c.NumC / total;
  PercentD = 100.0 * c.NumD / total;
  PercentF = 100.0 * c.NumF / total;

  GradeStats test = GradeStats(total,c.NumA,c.NumB,c.NumC,c.NumD,c.NumF,PercentA,PercentB,PercentC,PercentD,PercentF);

  return test;
}

GradeStats GetGradeDistribution(const Dept& dept)
{
  //
  // TODO:
  //
	int N = 0;  // total # of grades assigned:
	int NumA = 0;// number of A's, B's, etc.
	int NumB = 0;
	int NumC = 0;
	int NumD = 0;
	int NumF = 0;
	double PercentA = 0.0;
	double PercentB = 0.0;
	double PercentC = 0.0;
	double PercentD = 0.0;
	double PercentF = 0.0;
	//int totalCourses_inDeptGraded = 0.0;
	if(dept.Courses.empty())
		return Gradestats();
	for(const Course &c: dept.Courses){
		if(c.getGradingType() == Course::Letter){
			N = N + c.NumA + c.NumB + c.NumC + c.NumD + c.NumF;
			NumA += c.NumA;
			NumB += c.NumB;
			NumC += c.NumC;
			NumD += c.NumD;
			NumF += c.NumF;
		}
		PercentA = 100.0 * NumA / N;
		PercentB = 100.0 * NumB / N;
		PercentC = 100.0 * NumC / N;
		PercentD = 100.0 * NumD / N;
		PercentF = 100.0 * NumF / N;
	}
  GradeStats deptStats(N,NumA,NumB,NumC,NumD,NumF,PercentA,PercentB,PercentC,PercentD,PercentF);
	return deptStats;

}
GradeStats GetGradeDistribution(const College& college)

  //
  // TODO:
  //
	int N = 0;  // total # of grades assigned:
	int NumA = 0;// number of A's, B's, etc.
	int NumB = 0;
	int NumC = 0;
	int NumD = 0;
	int NumF = 0;
	double PercentA = 0.0;
	double PercentB = 0.0;
	double PercentC = 0.0;
	double PercentD = 0.0;
	double PercentF = 0.0;

	for(const Dept& d: college.Depts){
		//int totalCourses_inDeptGraded = 0.0;
		if(dept.Courses.empty())
			return Gradestats();
		for(const Course &c: d.Courses){
			if(c.getGradingType() == Course::Letter){
				N = N + c.NumA + c.NumB + c.NumC + c.NumD + c.NumF;
				NumA += c.NumA;
				NumB += c.NumB;
				NumC += c.NumC;
				NumD += c.NumD;
				NumF += c.NumF;
			}
			PercentA = 100.0 * NumA / N;
			PercentB = 100.0 * NumB / N;
			PercentC = 100.0 * NumC / N;
			PercentD = 100.0 * NumD / N;
			PercentF = 100.0 * NumF / N;
		}
	}
	GradeStats collegeStats(N,NumA,NumB,NumC,NumD,NumF,PercentA,PercentB,PercentC,PercentD,PercentF);
	return collegeStats;
	}

//
// FindCourses(dept, courseNumber)
//
// Searches the courses in the department for those that match
// the given course number.  If none are found, then the returned
// vector is empty.  If one or more courses are found, copies of
// the course objects are returned in a vector, and returned in
// ascending order by section number.
//
vector<Course> FindCourses(const Dept& dept, int courseNumber)
{
	vector<Course>  courses;

	for(const Course& c: dept.Courses){
		if(c.Number == courseNumber)
			courses.push_back(c);//The actual course found
		}
		sort(courses.begin(),courses.end(),
			[](const Course& first,const Course& second){
					return !(first.Section >= second.Section);//If shit fucks up GO HERE
			}
		);
		return courses;
	}

//
// FindCourses(dept, instructorPrefix)
//
// Searches the courses in the department for those whose
// instructor name starts with the given instructor prefix.
// For example, the prefix "Re" would match instructors "Reed"
// and "Reynolds".
//
// If none are found, then the returned vector is empty.  If
// one or more courses are found, copies of the course objects
// are returned in a vector, with the courses appearing in
// ascending order by course number.  If two courses have the
// same course number, they are given in ascending order by
// section number.  Note that courses are NOT sorted by instructor
// name.
//
vector<Course> FindCourses(const Dept& dept, string instructorPrefix)
{
	vector<Course>  courses;
	int size = instructorPrefix.size();
	char *begin;
	char *end;
	for(const Course& c: dept.Courses){
		begin = c.at(0);
		end = c.at(size-1);
		if(c.Instructor.find(begin,end,instructorPrefix))
			courses.push_back(c);//The actual course found
		}
		sort(courses.begin(),courses.end(),
			[](const Course& first,const Course& second){
					return !(first.Section >= second.Section);//If shit fucks up GO HERE
			}
		);
		return courses;
}
//
// FindCourses(college, courseNumber)
//
// Searches for all courses in the college for those that match
// the given course number.  If none are found, then the returned
// vector is empty.  If one or more courses are found, copies of
// the course objects are returned in a vector, with the courses
// appearing in ascending order by department, then course number,
// and then section number.
//
vector<Course> FindCourses(const College& college, int courseNumber)
{
	vector<Course>  courses;
  //
  // TODO:
  //
	for(const Dept& d: college.Depts){
		for(const Course& c: d.Courses){
			if(c.Number == courseNumber)
				courses.push_back(c);//The actual course found
			}

		}
		sort(courses.begin(),courses.end(),
			[](const Course& first,const Course& second){
					return !(first.Section >= second.Section);//If shit fucks up GO HERE
			}
		);
	return courses;

	}
//
// FindCourses(college, instructorPrefix)
//
// Searches all the courses in the college for those whose
// instructor name starts with the given instructor prefix.
// For example, the prefix "Re" would match instructors "Reed"
// and "Reynolds".  If none are found, then the returned
// vector is empty.  If one or more courses are found, copies of
// the course objects are returned in a vector, with the courses
// appearing in ascending order by department,
// then course number, and then section.
//

vector<Course> FindCourses(const College& college, string instructorPrefix)
{
	vector<Course>  courses;
	int size = instructorPrefix.size();
	char *begin;
	char *end;
  //
  // TODO:
  //
	for(const Dept& d: college.Depts){

		for(const Course& c: d.Courses){
			begin = c.at(0);
			end = c.at(size-1);
			if(c.Instructor.find(begin,end,instructorPrefix))
				courses.push_back(c);//The actual course found
			}
		}
		sort(courses.begin(),courses.end(),
			[](const Course& first,const Course& second){
					if(first.Number > second.Number){
							return false;
					}
					else if(first.Number == second.Number){
							if(first.Section > second.Section)
								return false;
							return true;
					}
					else
						return true;
			}
		);
	return courses;
}
