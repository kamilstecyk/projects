-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Czas generowania: 13 Sty 2022, 21:49
-- Wersja serwera: 10.4.21-MariaDB
-- Wersja PHP: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `uzytkownicy`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wizyty`
--

CREATE TABLE `wizyty` (
  `iddaty` int(11) NOT NULL,
  `idklienta` int(11) NOT NULL,
  `poczwizyty` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `koniecwizyty` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `usluga` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `wizyty`
--

INSERT INTO `wizyty` (`iddaty`, `idklienta`, `poczwizyty`, `koniecwizyty`, `usluga`) VALUES
(22, 6, '2021-12-24 08:30:00', '2021-12-24 09:30:00', 'Strzyzenie męskie'),
(23, 6, '2022-01-01 08:30:00', '2022-01-01 09:30:00', 'Strzyzenie męskie'),
(24, 6, '2021-12-23 08:30:00', '2021-12-23 09:30:00', 'Strzyzenie męskie'),
(25, 4, '2021-12-22 08:30:00', '2021-12-22 09:30:00', 'Strzyzenie męskie'),
(26, 4, '2021-12-22 09:30:00', '2021-12-22 10:30:00', 'Strzyzenie męskie'),
(27, 4, '2021-12-22 09:30:00', '2021-12-22 10:30:00', 'Strzyzenie męskie'),
(28, 4, '2021-12-23 08:30:00', '2021-12-23 09:30:00', 'Stylizacja'),
(29, 4, '2021-12-24 08:30:00', '2021-12-24 09:30:00', 'Farbowanie'),
(30, 8, '2021-12-30 09:30:00', '2021-12-30 10:30:00', 'Strzyzenie męskie'),
(31, 4, '2022-01-18 08:30:00', '2022-01-18 09:30:00', 'Balejaz'),
(32, 4, '2022-01-13 08:30:00', '2022-01-13 09:30:00', 'Strzyzenie męskie'),
(33, 4, '2022-01-15 09:30:00', '2022-01-15 10:30:00', 'Strzyzenie męskie'),
(34, 4, '2022-01-14 09:30:00', '2022-01-14 10:30:00', 'Strzyzenie męskie');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  ADD PRIMARY KEY (`iddaty`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `iddaty` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
