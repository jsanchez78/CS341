SELECT IUCR, Codes.PrimaryDesc,Codes.SecondaryDesc
FROM Codes 
WHERE PrimaryDesc = 'ROBBERY'
ORDER BY IUCR ASC;
