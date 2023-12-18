# Generátor Rozvrhů (Alpha)
## Popis
Tento projekt v jazyce C# obsahuje třídy a metody pro generování náhodných rozvrhů pro třídy C4a, C4b a C4c. Kromě generování rozvrhů umožňuje také jejich ohodnocování. Projekt využívá vícevláknový přístup pro efektivní generování a hodnocení rozvrhů.

## Spuštění
### Předpoklady
Pro správné spuštění programu je nutné mít nainstalovaný .NET runtime.

### Postup
Stáhněte si zdrojový kód do svého počítače.
Otevřete příkazový řádek a přejděte do adresáře s projektem.
Spusťte program pomocí příkazu dotnet run.
### Konfigurace
Projekt obsahuje několik parametrů, které lze konfigurovat před spuštěním:

threadCount: Počet vláken pro paralelní generování a hodnocení rozvrhů.
casovyLimit: Časový limit běhu programu v sekundách.
Tyto parametry můžete upravit v souboru Program.cs ve statické třídě Program před spuštěním programu.

## Vstupní Data
Program předpokládá, že máte definované předměty, učebny a učitele. Tyto informace jsou načítány ze souborů XML (import.xml). V případě potřeby můžete tyto soubory upravit nebo doplnit podle vlastních potřeb.

## Ovládání Programu
Po spuštění programu budete vyzváni k výběru třídy (C4a, C4b nebo C4c) a nastavení časového limitu běhu programu. Po zadaní těchto informací začne program generovat a ohodnocovat rozvrhy. Výsledky, včetně počtu vygenerovaných a ohodnocených rozvrhů, budou zobrazeny na konci běhu programu.

## Autor
Miloš Tesař, C4b