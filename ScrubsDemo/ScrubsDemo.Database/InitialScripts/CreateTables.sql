CREATE TABLE "Areas"
(
    "number" integer PRIMARY KEY NOT NULL
);

CREATE TABLE "Specializations"
(
    "id"   integer PRIMARY KEY NOT NULL,
    "name" varchar(100)        NOT NULL
);

CREATE TABLE "Offices"
(
    "number" integer PRIMARY KEY NOT NULL
);

CREATE TABLE "Patients"
(
    "name"       varchar(100) NOT NULL,
    "surname"    varchar(100) NOT NULL,
    "patronymic" varchar(100),
    "address"    varchar(300) NOT NULL,
    "birthday"   datetime     NOT NULL,
    "sex"        integer      NOT NULL,
    "areaNumber" integer      NOT NULL,
    CONSTRAINT fk_area_patients FOREIGN KEY ("areaNumber") REFERENCES "Areas" ("number")
);

CREATE TABLE "Doctors"
(
    "fullName"       varchar(300) PRIMARY KEY NOT NULL,
    "office"         integer                  NOT NULL,
    "specialization" integer                  NOT NULL,
    "area"           integer                  NOT NULL,
    CONSTRAINT fk_office_doctors FOREIGN KEY ("office") REFERENCES "Offices" ("number"),
    CONSTRAINT fk_specialization_doctors FOREIGN KEY ("specialization") REFERENCES "Specializations" ("id"),
    CONSTRAINT fk_area_doctors FOREIGN KEY ("area") REFERENCES "Areas" ("number")
);