# Generátor Rozvrhů (Alpha)
## Popis
Tento projekt v jazyce C# obsahuje třídy a metody pro generování náhodných rozvrhů pro třídy C4a, C4b a C4c. Kromě generování rozvrhů umožňuje také jejich ohodnocování. Projekt využívá vícevláknový přístup pro efektivní generování a hodnocení rozvrhů.

## Spuštění
### Předpoklady
Pro správné spuštění programu je nutné být na počítačovém zařízení Windows 10 a více

### Postup
Postupujte následovně:

1. Stáhněte si zazipovaný soubor do svého počítače.
2. Soubor Extrahujte.
3. Přesuňte se do adresáře: "Alpha\RozvrhHodin\bin\Debug\net7.0" 
4. Spusťte aplikaci: "RozvrhHodin.exe"

### Konfigurace
Konfigurace aplikace proběhne po spuštění programu.

### Vstupní Data
Program předpokládá, že máte definované předměty, učebny a učitele. Tyto informace jsou načítány ze souborů XML (v adresáři: "Alpha\RozvrhHodin\bin\Debug\net7.0\data"). V případě potřeby můžete tyto soubory upravit nebo doplnit podle vlastních potřeb.

## Ovládání Programu
Po spuštění programu se program pokusí načíst vstupní data. 
- Pokud se mu nepodaří je načíst, vyhodí vám chybnou hlášku "Nepovedlo se načíst vstupní data." a program se sám automaticky ukončí. (Této chybě lze předejít tím, že nebudete upravovat vstupní data.)

Následně budete vyzváni ke konfiguraci. 
- Nejprve pomocí výběru třídy (C4a, C4b nebo C4c).
- Poté nastavením časového limitu běhu programu. 

Po zadaní těchto informací začne program generovat a ohodnocovat rozvrhy. 
- (Více informací v sekci Generování Rozvrhu a Hodnocení Rozvrhu)

Výsledky, včetně počtu vygenerovaných a ohodnocených rozvrhů, budou zobrazeny na konci běhu programu.

## Generování Rozvrhu
Rozvrhy se generují v 5-ti krocích

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
Pokud surový rozvrh obsahuje méně než 50 hodin, jsou přidány volné hodiny, dokud nedosáhnou této hodnoty.
Pokud surový rozvrh obsahuje více než 50 hodin, je vyhozena výjimka s upozorněním na příliš mnoho hodin.
### Krok 5: Vytvoření Strukturovaného Rozvrhu
Surový rozvrh je následně promíchán a rozdělen do strukturovaného týdenního rozvrhu.
Výsledný rozvrh obsahuje 5 dní v týdnu, každý s 10 hodinami.
### Výjimky
Pokud nelze najít učitele pro některý předmět, nebo pokud neexistuje vhodná učebna pro některou hodinu, jsou vyvolány výjimky s odpovídajícím upozorněním.

## Hodnocení Rozvrhu
Hodnocení kvality daného rozvrhu je na základě několika pravidel:

### Pravidlo 1: Bonus/Malus za Přítomnost Hodiny v Rozvrhu
Každému políčku v rozvrhu je přidělen bonus/malus v závislosti na tom, zda je v daném časovém slotu obsazeno nebo volno.
Příklady zahrnují preferované hodiny a dny v týdnu, kdy je účast lepší nebo horší.
(Například pátek 9. hodina je pro někoho +100 bodů, pro někoho -100 bodů. Hodně se to liší, pokud chodíte do zaměstnání, nebo jste student. Také ranní hodiny jsou někdy oblíbené a někdy ne, apod. Nakonec každé políčko bude mít nějaký bonus/penále.)
### Pravidlo 2: Kontrola stejných Teoretických Hodin v jednom dni
Kontroluje, zda v rozvrhu neexistují dvě nebo více teoretické hodiny téhož předmětu v jednom dni.
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
Pokud nalezne, že nejsou vedle sebe, hodnocení se sníží.
### Pravidlo 7: Omezení na Výuku Matematiky a Profilových Předmětů
Matematika a profilové předměty by neměly být vyučovány první hodinu nebo po obědě.
Porušení pravidla snižuje hodnocení.
### Pravidlo 8: Bonus za Výuku od Třídního Učitele
Poskytuje bonus, pokud třídní učitel dané třídy vyučuje danou alespoň jeden předmět v rozvrhu.
Pokud ne, nastane penalizace.
### Pravidlo 9: Bonus za Výuku ve Kmenové Třídě
Poskytuje bonus, pokud se předmět vyučuje ve kmenové třídě zadané třídy.
Pokud ne, nastane penalizace.
### Pravidlo 10: Pravidlo Wellbeing
Reflektuje osobní preference ohledně učitelů, učeben, a předmětů.
Vytváří penalizace nebo bonusy na základě osobních preferencí.
### Výjimky
Výjimky jsou vyvolány v případě, že jsou porušena pravidla nebo došlo k neočekávané situaci při hodnocení.

## Autor
Miloš Tesař
Žák z C4b na SPŠE Ječná Praha 2