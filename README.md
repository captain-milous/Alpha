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

## Generování Rozvrhu
Rozvrhy se generují jednoduše v 5-ti krocích

### Krok 1: Přiřazení Učitele k Předmětu
Pro každý předmět v seznamu predmety se vytváří instance třídy Hodina.
Pro každý předmět se vyhledávají učitelé, kteří tento předmět vyučují. Pokud existuje více učitelů, jeden z nich je náhodně vybrán.
Vytvořený objekt Hodina je přiřazen vybranému učiteli.
### Krok 2: Přiřazení Učebny
Pro každou hodinu s přiřazeným učitelem se vyhledávají učebny, které umožňují výuku předmětu této hodiny.
Pokud existuje více učeben, jedna z nich je náhodně vybrána a přiřazena hodině.
### Krok 3: Vytvoření Surového Rozvrhu
Na základě přiřazených hodin s učitelem a učebnou se vytváří surový rozvrh obsahující potřebný počet hodin pro každý předmět.
### Krok 4: Přidání Volných Hodin a Promíchání
Pokud surový rozvrh obsahuje méně než 50 hodin, jsou přidány volné hodiny, dokud dosáhnou této minimální hodnoty.
Pokud surový rozvrh obsahuje více než 50 hodin, je vyhozena výjimka s upozorněním na příliš mnoho hodin.
### Krok 5: Vytvoření Strukturovaného Rozvrhu
Surový rozvrh je následně promíchán a rozdělen do strukturovaného týdenního rozvrhu.
Výsledný rozvrh obsahuje 5 dní v týdnu, každý s 10 hodinami.
### Výjimky
Pokud nelze najít učitele pro některý předmět, nebo pokud neexistuje vhodná učebna pro některou hodinu, jsou vyvolány výjimky s odpovídajícím upozorněním.

## Hodnocení Rozvrhu
Metoda OhodnotRozvrh slouží k ohodnocení kvality daného rozvrhu na základě několika pravidel. Následující popis vysvětluje jednotlivé pravidla hodnocení rozvrhu:

### Pravidlo 1: Bonus/Malus za Přítomnost Hodiny v Rozvrhu
Každému políčku v rozvrhu je přidělen bonus/malus v závislosti na tom, zda je v daném časovém slotu obsazeno nebo volno.
Příklady zahrnují preferované hodiny a dny v týdnu, kdy je účast lepší nebo horší.
### Pravidlo 2: Kontrola Duplicitních Teoretických Hodin
Kontroluje, zda v rozvrhu neexistují duplicitní teoretické hodiny téhož předmětu v jednom dni.
Pokud ano, snižuje hodnocení rozvrhu.
### Pravidlo 3: Vyhodnocení Přechodů mezi Učebnami
Hodnotí, zda při přechodech mezi hodinami dochází k přesunu do jiného patra nebo jiné učebny.
Zohledňuje, že přesuny ve stejném patře jsou méně kritické.
### Pravidlo 4: Povinná Přestávka na Obědě
Zajišťuje, že v rozvrhu je alespoň jedna volná hodina mezi 5. a 8. hodinou pro oběd.
Chybějící přestávka snižuje hodnocení rozvrhu.
### Pravidlo 5: Optimální Počet Vykonaných Hodin za Den
Hodnotí, zda denní počet vykonaných hodin odpovídá optimálnímu rozmezí (5-6 hodin).
Přebytek nebo nedostatek hodin snižuje hodnocení.
### Pravidlo 6: Kontrola Cvičení a Teoretických Hodin
Kontroluje, zda dvouhodinová nebo tříhodinová cvičení jsou umístěna za sebou.
Nepřípustné konfigurace vedou k penalizaci.
### Pravidlo 7: Omezení na Výuku Matematiky a Profilových Předmětů
Matematika a profilové předměty by neměly být vyučovány první hodinu nebo po obědě.
Porušení pravidla snižuje hodnocení.
### Pravidlo 8: Bonus za Výuku od Třídního Učitele
Poskytuje bonus, pokud třídní učitel vyučuje danou třídu.
### Pravidlo 9: Bonus za Výuku ve Kmenové Třídě
Poskytuje bonus, pokud učitel vyučuje ve své kmenové třídě.
### Pravidlo 10: Pravidlo Wellbeing
Reflektuje osobní preference ohledně učitelů, učeben, a předmětů.
Vytváří penalizace nebo bonusy na základě osobních preferencí.
### Výjimky
Výjimky jsou vyvolány v případě, že jsou porušena pravidla nebo došlo k neočekávané situaci při hodnocení.

## Autor
Miloš Tesař, C4b