SELECT d.fullName, d.office, d.specialization as specializationId, d.area, s.name as specialization
FROM Doctors d
         INNER JOIN Specializations s ON s.id = d.specialization
ORDER BY @column ASC
OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY;