UPDATE "Patients"
SET "name"       = @name,
    "surname"    = @surname,
    "patronymic" = @patronymic,
    "address"    = @address,
    "birthday"   = @birthday,
    "sex"        = @sex,
    "areaNumber" = @areaNumber
WHERE "name" = @name
  AND "surname" = @surname
  AND "patronymic" = @patronymic