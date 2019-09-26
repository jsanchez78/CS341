///If weird stuff happens
//Check logic if
//All vs courseNum vs instructorPrefix
//Searching through each course with matching criteria
cout << "\ncourse # or instructor prefix? ";
cin >> instructorPrefix;
//Case: Specified Dept
stringstream ss(instructorPrefix); // create stringstream object
ss >> courseNum; // try to convert input to a course #:

search = FindCourses(college,instructorPrefix);
///Case: instructorPrefix
if(ss.fail()){

 //Searching through each course with matching criteria
 for(auto &d:search){
   GradeStats dist = GetGradeDistribution(d);
   double rate = GetDFWRate(d,DFW,N);
   cout << d.Title << "(" << d.Section << "): " << d.Instructor << endl;
   cout << "# of students: " << d.getNumStudents() << endl;
   cout << "course type: " << grading_map[d.getGradingType()] << endl;;
   cout << "grade distribution (A-F): " << dist.PercentA << "%, " << dist.PercentB << "%, " << dist.PercentC << "%, " << dist.PercentD << "%, " << dist.PercentF << "%\n";
   cout << "DFW rate: " << rate << endl;
 }
}


// conversion failed, input is not numeric
else{
  //Course number is entered

  //Searching through each course with matching criteria
  for(auto &d:search){
    GradeStats dist = GetGradeDistribution(d);
    double rate = GetDFWRate(d,DFW,N);
    cout << d.Title << "(" << d.Section << "): " << d.Instructor << endl;
    cout << "# of students: " << d.getNumStudents() << endl;
    cout << "course type: " << grading_map[d.getGradingType()] << endl;;
    cout << "grade distribution (A-F): " << dist.PercentA << "%, " << dist.PercentB << "%, " << dist.PercentC << "%, " << dist.PercentD << "%, " << dist.PercentF << "%\n";
    cout << "DFW rate: " << rate << endl;
  }
}
// conversion worked, courseNum contains numeric value
