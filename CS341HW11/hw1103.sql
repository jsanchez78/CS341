SELECT COUNT(*) AS NumCrimes
FROM Crimes
WHERE '2015-12-01'=CONVERT(date,CrimeDate);