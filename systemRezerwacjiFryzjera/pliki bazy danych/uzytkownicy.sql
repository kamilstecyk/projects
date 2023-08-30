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
-- Struktura tabeli dla tabeli `uzytkownicy`
--

CREATE TABLE `uzytkownicy` (
  `id` int(11) NOT NULL,
  `imie` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `login` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `haslo` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `mail` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `telefon` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `uzytkownicy`
--

INSERT INTO `uzytkownicy` (`id`, `imie`, `nazwisko`, `login`, `haslo`, `mail`, `telefon`) VALUES
(3, 'Filip', 'Kubiś', 'kubi123', '$2y$10$kOREkOc.iGROd2Qc/8sCGuav3WLnxxQmDMlet6mB7j7zL9LHNm1um', 'kubi123@gmail.com', '560 421 561'),
(4, 'Kamil', 'Stecyk', 'kamils987', '$2y$10$UoINChYKjHxEVVKRuiYCp.l9iuJ5qIF1dW8ScQvEbb4FhPFw2K5wq', 'kamils@gmail.com', '678 908 123'),
(5, 'Wioletta', 'Stec', 'wioletka123', '$2y$10$thLZCCBvvjY1FopXsyKh3.Jyo4D.SAm0SAiHmja6IuJssOYhvcjrm', 'wiola@gmail.com', '780 123 142'),
(6, 'Krystyna', 'Niemen', 'krysia123', '$2y$10$sEzRdYsdBjsPQAolmeo3Bu29D0v27874ZILXt9XosTuGnfzudcoKS', 'krysia@gmail.com', '678901234'),
(7, 'Paweł', 'Michal', 'michal123', '$2y$10$3158wo4B4yYfdBprzu9T2ehRLy4YTT1HQdWYguuWVJOopJ7nSX2.O', 'michal@gmail.com', '789 123 123'),
(8, 'Wioletta', 'Stec', 'wioletkaa', '$2y$10$e5n/ugu.Jv58SGXUBCc0BuLEddbUlRZjEO7spwaPvwFkUvKg/slB2', 'wioletta.stec@gmail.com', '123879012'),
(9, 'Kamil', 'Grosicki', 'kamilg123', '$2y$10$48cfkj8cSj1LKqm1EmG1X.1qwU.DbYijyRZ0u/GvUR17NXxPfyv0i', 'kamilg@gmail.com', '098213243');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
