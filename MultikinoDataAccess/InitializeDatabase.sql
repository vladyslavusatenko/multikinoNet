

-- Create Roles
CREATE ROLE AdminRole;
GO
CREATE ROLE UserRole;
GO
-- Create Logins and Users

CREATE LOGIN admin_user WITH PASSWORD = 'Admin123!';
GO
CREATE USER admin_user FOR LOGIN admin_user;
GO
EXEC sp_addrolemember 'AdminRole', 'admin_user';
GO

CREATE LOGIN regular_user WITH PASSWORD = 'User123!';
GO
CREATE USER regular_user FOR LOGIN regular_user;
GO
EXEC sp_addrolemember 'UserRole', 'regular_user';
GO
-- Grant Permissions
GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE ON SCHEMA::dbo TO AdminRole;
GO
GRANT SELECT ON SCHEMA::dbo TO UserRole;
GO

-- ===== VIEWS =====

CREATE VIEW v_SprzedazNaFilm AS
SELECT F.Tytul, SUM(B.Cena) AS Przychody
FROM Bilet B
JOIN Seans S ON B.SeansId = S.SeansId
JOIN Film F ON S.FilmId = F.FilmId
GROUP BY F.Tytul;
GO

CREATE VIEW v_ZapelnienieSal AS
SELECT Sa.Nazwa AS Sala, COUNT(M.MiejsceId) AS LiczbaMiejsc, 
       SUM(CASE WHEN M.Zajete = 1 THEN 1 ELSE 0 END) AS MiejscaZajete
FROM Sala Sa
JOIN Miejsce M ON Sa.SalaId = M.SalaId
GROUP BY Sa.Nazwa;
GO

CREATE VIEW v_AktywneSeanse AS
SELECT S.SeansId, F.Tytul, S.DataSeansu, Sa.Nazwa AS Sala
FROM Seans S
JOIN Film F ON S.FilmId = F.FilmId
JOIN Sala Sa ON S.SalaId = Sa.SalaId
WHERE S.DataSeansu > GETDATE();
GO

CREATE VIEW v_SeanseZPrzychodami AS
SELECT F.Tytul, S.DataSeansu, SUM(B.Cena) AS Przychody
FROM Seans S
JOIN Film F ON S.FilmId = F.FilmId
JOIN Bilet B ON B.SeansId = S.SeansId
GROUP BY F.Tytul, S.DataSeansu;
GO

CREATE VIEW v_StatystykaUzytkownikow AS
SELECT U.Imie, U.Nazwisko, COUNT(B.BiletId) AS LiczbaZakupionychBiletow
FROM Uzytkownik U
LEFT JOIN Bilet B ON U.UzytkownikId = B.UzytkownikId
GROUP BY U.Imie, U.Nazwisko;
GO

CREATE VIEW v_SeanseDzienTygodnia AS
SELECT DATENAME(WEEKDAY, DataSeansu) AS DzienTygodnia, COUNT(SeansId) AS LiczbaSeansow
FROM Seans
GROUP BY DATENAME(WEEKDAY, DataSeansu);
GO

CREATE VIEW v_ObecneFilmy AS
SELECT F.Tytul, S.DataSeansu
FROM Seans S
JOIN Film F ON S.FilmId = F.FilmId
WHERE S.DataSeansu >= GETDATE();
GO
-- ===== STORED PROCEDURES =====

CREATE PROCEDURE sp_DodajFilm 
    @Tytul NVARCHAR(255), 
    @Gatunek NVARCHAR(100), 
    @Opis NVARCHAR(1000), 
    @CzasTrwania INT
AS
BEGIN
    INSERT INTO Film (Tytul, Gatunek, Opis, CzasTrwania)
    VALUES (@Tytul, @Gatunek, @Opis, @CzasTrwania);
END;
GO

CREATE PROCEDURE sp_DodajSeans 
    @FilmId INT, 
    @SalaId INT, 
    @DataSeansu DATETIME
AS
BEGIN
    INSERT INTO Seans (FilmId, SalaId, DataSeansu)
    VALUES (@FilmId, @SalaId, @DataSeansu);
END;
GO

CREATE PROCEDURE sp_UsunSeans 
    @SeansId INT
AS
BEGIN
    DELETE FROM Seans WHERE SeansId = @SeansId;
END;
GO

CREATE PROCEDURE sp_KupBilet 
    @SeansId INT, 
    @UzytkownikId INT, 
    @Cena DECIMAL(10, 2), 
    @DataZakupu DATETIME
AS
BEGIN
    INSERT INTO Bilet (SeansId, UzytkownikId, Cena, DataZakupu)
    VALUES (@SeansId, @UzytkownikId, @Cena, @DataZakupu);
END;
GO

CREATE PROCEDURE sp_ZwrocBilet 
    @BiletId INT
AS
BEGIN
    DELETE FROM Bilet WHERE BiletId = @BiletId;
END;
GO

CREATE PROCEDURE sp_ZmienRoleUzytkownika 
    @UzytkownikId INT, 
    @NowaRola NVARCHAR(50)
AS
BEGIN
    UPDATE Uzytkownik SET Rola = @NowaRola WHERE UzytkownikId = @UzytkownikId;
END;
GO

CREATE PROCEDURE sp_ZmienDaneFilmu 
    @FilmId INT, 
    @NowyTytul NVARCHAR(255), 
    @NowyGatunek NVARCHAR(100), 
    @NowyOpis NVARCHAR(1000), 
    @NowyCzasTrwania INT
AS
BEGIN
    UPDATE Film
    SET Tytul = @NowyTytul, Gatunek = @NowyGatunek, Opis = @NowyOpis, CzasTrwania = @NowyCzasTrwania
    WHERE FilmId = @FilmId;
END;
GO

CREATE PROCEDURE sp_GenerujRaportDzienny
AS
BEGIN
    SELECT * FROM v_SeanseZPrzychodami 
    WHERE DataSeansu >= CAST(GETDATE() AS DATE) 
    AND DataSeansu < DATEADD(DAY, 1, CAST(GETDATE() AS DATE));
END;
GO

CREATE PROCEDURE sp_GenerujRaportMiesieczny
AS
BEGIN
    SELECT * FROM v_SeanseZPrzychodami 
    WHERE DataSeansu >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) 
    AND DataSeansu < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0);
END;
GO

CREATE PROCEDURE sp_UtworzUzytkownika 
    @Imie NVARCHAR(50), 
    @Nazwisko NVARCHAR(50), 
    @Email NVARCHAR(100), 
    @Haslo NVARCHAR(255), 
    @Rola NVARCHAR(50)
AS
BEGIN
    DECLARE @HashedPassword VARBINARY(64);
    SET @HashedPassword = HASHBYTES('SHA2_256', CONVERT(NVARCHAR(4000), @Haslo)); 

    INSERT INTO Uzytkownik (Imie, Nazwisko, Email, Haslo, Rola)
    VALUES (
        @Imie,
        @Nazwisko,
        @Email,
        CONVERT(NVARCHAR(255), @HashedPassword, 1),
        @Rola
    );
END;
GO


-- ===== FUNCTIONS =====

CREATE FUNCTION ufn_CzyMiejsceZajete (@MiejsceId INT)
RETURNS BIT
AS
BEGIN
    DECLARE @Zajete BIT;
    SELECT @Zajete = Zajete FROM Miejsce WHERE MiejsceId = @MiejsceId;
    RETURN @Zajete;
END;
GO

CREATE FUNCTION ufn_PodsumowanieFilmu (@FilmId INT)
RETURNS NVARCHAR(1000)
AS
BEGIN
    DECLARE @Podsumowanie NVARCHAR(1000);
    SELECT @Podsumowanie = Opis FROM Film WHERE FilmId = @FilmId;
    RETURN @Podsumowanie;
END;
GO

CREATE FUNCTION ufn_LiczbaBiletowUzytkownika (@UzytkownikId INT)
RETURNS INT
AS
BEGIN
    DECLARE @LiczbaBiletow INT;
    SELECT @LiczbaBiletow = COUNT(*) FROM Bilet WHERE UzytkownikId = @UzytkownikId;
    RETURN @LiczbaBiletow;
END;
GO

CREATE FUNCTION ufn_CzyFilmJestGranyObecnie (@FilmId INT)
RETURNS BIT
AS
BEGIN
    DECLARE @CzyGrany BIT;
    SELECT @CzyGrany = CASE WHEN EXISTS (
        SELECT 1 FROM Seans WHERE FilmId = @FilmId AND DataSeansu > GETDATE()) 
        THEN 1 ELSE 0 END;
    RETURN @CzyGrany;
END;
GO

-- ===== TRIGGERS =====

CREATE TRIGGER TR_ZakazUsuwaniaFilmu
ON Film
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM Seans S
        JOIN deleted D ON S.FilmId = D.FilmId
    )
    BEGIN
        RAISERROR ('Nie można usunąć filmu, który ma przypisane seanse!', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        DELETE FROM Film WHERE FilmId IN (SELECT FilmId FROM deleted);
    END
END;
GO

CREATE TRIGGER TR_HistoriaUsunietychBiletow
ON Bilet
AFTER DELETE
AS
BEGIN
    INSERT INTO HistoriaBiletow (BiletId, SeansId, UzytkownikId, MiejsceNr, Cena, DataZakupu)
    SELECT 
        d.BiletId,
        d.SeansId,
        d.UzytkownikId,
        m.Numer,             
        d.Cena,
        d.DataZakupu
    FROM deleted d
    JOIN Miejsce m ON d.MiejsceId = m.MiejsceId;
END;
GO

CREATE TRIGGER TR_LogowanieOperacji_Film
ON Film
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @operacja NVARCHAR(10);

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
        SET @operacja = 'UPDATE';
    ELSE IF EXISTS(SELECT * FROM inserted)
        SET @operacja = 'INSERT';
    ELSE
        SET @operacja = 'DELETE';

    INSERT INTO LogZdarzen (NazwaTabeli, Operacja, Uzytkownik, DataOperacji)
    VALUES ('Film', @operacja, SYSTEM_USER, GETDATE());
END;
GO

CREATE TRIGGER TR_OgraniczenieDoubleBooking
ON Bilet
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Bilet b ON b.SeansId = i.SeansId AND b.MiejsceId = i.MiejsceId
    )
    BEGIN
        RAISERROR('To miejsce jest już zajęte na ten seans.', 16, 1);
        ROLLBACK;
    END
    ELSE
    BEGIN
        INSERT INTO Bilet (SeansId, UzytkownikId, MiejsceId, Cena, DataZakupu)
        SELECT SeansId, UzytkownikId, MiejsceId, Cena, DataZakupu
        FROM inserted;
    END
END;
GO

INSERT INTO Uzytkownik (Imie, Nazwisko, Email, Haslo, Rola)
VALUES (
    'Admin',
    'Root',
    'admin@email.com',
    '$2a$12$BXe6HZY7JymtRAmo37Wqkut/rkSuVBPca9UWB1TP0TziZUhV61B52', -- hashed "Admin123!"
    'Administrator'
);
GO

PRINT 'Baza została poprawnie zainicjalizowana';
GO
