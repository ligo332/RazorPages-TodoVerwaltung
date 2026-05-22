# RazorPagesTodo

Eine einfache Todo-Verwaltung, entwickelt mit **ASP.NET Core Razor Pages** und **.NET 10**.

## Projektbeschreibung

Das Projekt dient als grundlegende Todo-Listen-App, welche über Razor Pages realisiert wurde.
Es demonstriert die Funktionsweise von grundlegenden Operationen (Erstellen, Lesen, Aktualisieren, Löschen) innerhalb einer Webanwendung unter Verwendung von ASP.NET Core. 

Die Persistenz erfolgt standardmäßig im Arbeitsspeicher (`InMemoryTodoRepository`), weshalb neue Todos nach einem Neustart der Anwendung zurückgesetzt werden.

## Funktionen

- **Todos auflisten:** Übersicht aller vorhandenen Todos auf der Startseite.
- **Neues Todo anlegen:** Ein Formular zum Erstellen neuer Aufgaben (`NewTodo`).
- **Todo bearbeiten/abschließen:** Status und Titel eines bestehenden Todos ändern (`EditTodo`).

## Technologien & Architektur

- **Framework:** .NET 10
- **UI:** ASP.NET Core Razor Pages
- **Repository Pattern:** `ITodoRepository` sorgt für eine Abstraktion der Datenzugriffsschicht.
- **Dependency Injection:** Das `InMemoryTodoRepository` ist als Singleton im DI-Container registriert (`Program.cs`).

## Projektstruktur (wichtige Dateien)

- `Pages/Todo.cshtml` & `.cs`: Startseite, listet die aktuellen Aufgaben auf (als Standardroute definiert).
- `Pages/NewTodo.cshtml` & `.cs`: Seite zum Erstellen neuer Aufgaben.
- `Pages/EditTodo.cshtml` & `.cs`: Seite zur Bearbeitung von Aufgaben.
- `Data/`: Beinhaltet das `ITodoRepository` Interface und dessen In-Memory-Implementierung.
- `Models/TodoItem.cs`: Das Datenmodell für eine Aufgabe.

## Ausführen des Projekts

1. Stelle sicher, dass die .NET 10 SDK auf dem System installiert ist.
2. Klone das Repository in ein lokales Verzeichnis.
3. Öffne das Projekt in VisualStudio.
4. Strg+F5 um das Projekt mittels Localhost im Browser zu öffnen.