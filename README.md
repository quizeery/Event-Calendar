# TO DO LIST - Kalendarz Wydarzeń

## Opis Projektu
Aplikacja webowa służąca do zarządzania wydarzeniami w kalendarzu. Umożliwia tworzenie, edycję i usuwanie wydarzeń, które są wyświetlane w formie kalendarza oraz listy.

## Funkcjonalności
- Wyświetlanie wydarzeń w kalendarzu
- Dodawanie nowych wydarzeń
- Edycja istniejących wydarzeń
- Usuwanie wydarzeń
- Widok listy wszystkich wydarzeń

## Technologie
- ASP.NET Core 8.0
- Entity Framework Core
- MariaDB
- Bootstrap 5
- FullCalendar.js
- jQuery

## Struktura Projektu 
FunnyWeb/
├── Controllers/
│ ├── HomeController.cs # Kontroler strony głównej z kalendarzem
│ ├── CategoryController.cs # Kontroler zarządzania wydarzeniami
│ └── Data/
│ └── ApplicationDBContext.cs # Kontekst bazy danych
├── Models/
│ └── Event.cs # Model wydarzenia
├── Views/
│ ├── Home/
│ │ └── Index.cshtml # Strona główna z kalendarzem
│ └── Category/
│ ├── Index.cshtml # Lista wydarzeń
│ ├── Create.cshtml # Formularz tworzenia wydarzenia
│ ├── Edit.cshtml # Formularz edycji wydarzenia
│ └── Delete.cshtml # Modal potwierdzenia usunięcia
└── wwwroot/
└── css/
├── calendar-custom.css # Style kalendarza
└── home-custom.css # Style strony głównej

## Konfiguracja i Uruchomienie

### Wymagania Systemowe
- .NET 8.0 SDK
- MariaDB
- Przeglądarka internetowa (Chrome, Firefox, Edge)

### Konfiguracja Bazy Danych
1. Utwórz nową bazę danych w MariaDB:
sql
CREATE DATABASE funnyweb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

2. Skonfiguruj połączenie z bazą danych w pliku `appsettings.json`:
json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=funnyweb;User=root;Password=;"
}



### Pierwsze Uruchomienie
1. Otwórz terminal w folderze projektu
2. Wykonaj migracje:
bash
dotnet ef database update

3. Uruchom aplikację
bash
dotnet run

4. Otwórz w przeglądarce: `http://localhost:5000`

## Instrukcja Obsługi

### Strona Główna
- Kalendarz pokazuje wszystkie wydarzenia
- Kliknięcie na wydarzenie wyświetla szczegóły
- Wydarzenia są automatycznie sortowane według daty

### Zarządzanie Wydarzeniami
1. **Dodawanie Wydarzenia:**
   - Kliknij "Dodaj nowe wydarzenie"
   - Wypełnij pola:
     * Nazwa wydarzenia
     * Opis wydarzenia
     * Data wydarzenia
   - Zatwierdź przyciskiem "Utwórz"

2. **Edycja Wydarzenia:**
   - Znajdź wydarzenie na liście
   - Kliknij przycisk "Edytuj"
   - Wprowadź zmiany
   - Zapisz zmiany

3. **Usuwanie Wydarzenia:**
   - Znajdź wydarzenie na liście
   - Kliknij przycisk "Usuń"
   - Potwierdź usunięcie w oknie modalnym

## Struktura Bazy Danych
Tabela `Events`:
- Id (int, primary key)
- Title (string, required)
- Description (string, required)
- EventDate (DateTime)
- Color (string)
- AllDay (bool)

## Rozwiązywanie Problemów
1. **Problem z połączeniem do bazy:**
   - Sprawdź czy MariaDB jest uruchomiona
   - Zweryfikuj dane połączenia w appsettings.json

2. **Błędy podczas migracji:**
   - Usuń folder Migrations
   - Wykonaj `dotnet ef migrations add InitialMigration`
   - Wykonaj `dotnet ef database update`

## Autor
[Twoje Imię]

## Licencja
MIT License

Dokumentacja zawiera:
1. Opis projektu i funkcjonalności
2. Listę użytych technologii
3. Strukturę projektu
4. Instrukcje instalacji i konfiguracji
5. Szczegółową instrukcję obsługi
6. Opis struktury bazy danych
7. Sekcję rozwiązywania problemów