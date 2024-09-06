DELETE FROM "Patients"
WHERE "name" = @name
    AND "surname" = @surname
    AND "patronymic" = @patronymic