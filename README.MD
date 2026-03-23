# Keylogger string decoder in C#
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Overview
This repository contains a custom **generic stack implementation** that is used to **decode a keylogger string** provided via standard input. It is a solution for a laboratory exercise for a Data Structures and Algorithms university class.

## Context and purpose
The main purpose of this project is to demonstrate a fundamental understanding of the **Stack<T>** data structure without relying on the built-in C# `System.Collections.Generic.Stack<T>`.

It solves the problem of deciphering a final password from a raw keylogger string that includes simulated cursor movements and backspaces.

## How to run
It runs as a simple .NET console application. Clone the repository, navigate to the project folder, and execute the following commands in your terminal:

`dotnet build`
`dotnet run`

After running, type or paste your keylogger string into the console and press Enter.

## Implemented features
A custom `MyStack<T>` class featuring standard stack operations:
- `Pop()`
- `Push(T item)`
- `Peek`
- `IsEmpty()`
- `ToArray()`
- `Count`

A `Decoder` method that processes the string using a two-stack system to handle cursor movement.

## Lab exercise instruction (in polish)
**Zadanie: Złam hasło**

Keylogger zainstalowany na komputerze ofiary rejestruje naciśnięcia klawiszy podczas wprowadzania hasła w tekstowym polu formularza i zapisuje je do postaci napisu. Zakładamy, że tekst edytowany jest w trybie insert (pionowa kreska kursora między dwoma znakami).

Rejestrowane są klawisze alfanumeryczne oraz trzy klawisze specjalne, zakodowane w następujący sposób:
- `'<'` reprezentuje strzałkę w lewo (przesunięcie kursora w lewo o 1 pozycję).
- `'>'` reprezentuje strzałkę w prawo  (przesunięcie kursora w prawo o 1 pozycję).
- `'-'` reprezentuje klawisz Backspace (usunięcie znaku na lewo od kursora).

Przykładowo:
1. Ofiara wprowadziła tekst *generio1*.
2. Następnie nacisnęła strzałkę w lewo i wprowadziła *3* (zatem w formularzu widać *generio31*).
3. Następnie nacisnęła strzałkę w prawo i wprowadziła *2* (zatem w formularzu widnieje *generio312*).
4. Następnie wprowadziła *ghj* i nacisnęła trzykrotnie *Backspace*, usuwając te trzy litery.
5. Zatwierdziła hasło (ostatecznie hasło to *generio312*).

Keylogger zwrócił tekst *generio1<3>2ghj---* reprezentujący działania ofiary podczas wpisywania hasła.

**Twoim zadaniem jest ustalić ostateczną wersję hasła na podstawie zapisów keyloggera.**
Napisz program w języku C#, który wczyta ze standardowego wejścia napis wygenerowany przez keyloggera, przeanalizuje go i wypisze na standardowe wyjście przechwycone hasło.

### Example
`Input:  generio1<3>2ghj---`
`Output: generio312`

## Licence
This project is licensed under the [MIT License](LICENSE.md) - see the LICENSE.md file for details.
