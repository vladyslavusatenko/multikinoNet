-- Wstawianie przykładowych użytkowników
INSERT INTO Uzytkownik (Imie, Nazwisko, Email, Haslo, Rola)
VALUES 
('Admin', 'Administrator', 'admin@multikino.pl', 'e4ad6c930c43360e15e283c3e171707e8e91e68a99c63b99775135999acce044', 'Administrator'), -- Hasło: Admin123!
('Jan', 'Kowalski', 'jan.kowalski@multikino.pl', '3fabb20aae7994f41f3788b2d7ede9f76ba2212a52fe18a8da232b5e9e891df1', 'Użytkownik'); -- Hasło: User123!

-- Wstawianie przykładowych filmów
INSERT INTO Film (Tytul, Gatunek, Opis, CzasTrwania)
VALUES 
('Incepcja', 'Sci-Fi/Thriller', 'Film o snach we śnie', 148),
('Pulp Fiction', 'Kryminał', 'Kultowy film Quentina Tarantino', 154),
('Matrix', 'Sci-Fi/Akcja', 'Rzeczywistość nie jest tym, czym się wydaje', 136);

-- Wstawianie przykładowych sal
INSERT INTO Sala (Nazwa, LiczbaMiejsc)
VALUES 
('Sala 1', 100),
('Sala 2', 80),
('Sala VIP', 50);

-- Wstawianie przykładowych miejsc (dla uproszczenia tylko po 10 miejsc na salę)
-- Sala 1
INSERT INTO Miejsce (SalaId, Numer, Zajete)
VALUES 
(1, 1, 0), (1, 2, 0), (1, 3, 0), (1, 4, 0), (1, 5, 0),
(1, 6, 0), (1, 7, 0), (1, 8, 0), (1, 9, 0), (1, 10, 0);

-- Sala 2
INSERT INTO Miejsce (SalaId, Numer, Zajete)
VALUES 
(2, 1, 0), (2, 2, 0), (2, 3, 0), (2, 4, 0), (2, 5, 0),
(2, 6, 0), (2, 7, 0), (2, 8, 0), (2, 9, 0), (2, 10, 0);

-- Sala VIP
INSERT INTO Miejsce (SalaId, Numer, Zajete)
VALUES 
(3, 1, 0), (3, 2, 0), (3, 3, 0), (3, 4, 0), (3, 5, 0),
(3, 6, 0), (3, 7, 0), (3, 8, 0), (3, 9, 0), (3, 10, 0);

-- Wstawianie przykładowych seansów (data obecna + kilka dni)
INSERT INTO Seans (FilmId, SalaId, DataSeansu)
VALUES 
(1, 1, DATEADD(day, 1, GETDATE())), -- Incepcja w Sali 1, jutro
(2, 2, DATEADD(day, 1, GETDATE())), -- Pulp Fiction w Sali 2, jutro
(3, 3, DATEADD(day, 2, GETDATE())); -- Matrix w Sali VIP, pojutrze

-- Wstawianie przykładowych biletów
INSERT INTO Bilet (SeansId, UzytkownikId, MiejsceId, Cena, DataZakupu)
VALUES 
(1, 2, 1, 25.00, GETDATE()), -- Bilet na Incepcję dla Jana Kowalskiego, miejsce 1
(1, 2, 2, 25.00, GETDATE()); -- Bilet na Incepcję dla Jana Kowalskiego, miejsce 2

-- Aktualizujemy status miejsc na "zajęte"
UPDATE Miejsce SET Zajete = 1 WHERE MiejsceId IN (1, 2);