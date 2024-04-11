# Kasutajatoe Pöördumiste Haldussüsteem

Tegu on lihtsa veebirakendusega kasutajatoe pöördumiste haldamiseks, mis võimaldab kasutajal sisestada kirjelduse ja tähtaja järgi pöördumisi, vaadata aktiivseid pöördumisi ja märkida need lahendatuks. 
- **Pöördumise Esitamine**: Kasutajad saavad esitada pöördumisi koos kirjelduse ja tähtajaga.
- **Tähtaja järgi järjestamine**: Pöördumised on järjestatud loendis kahenevalt lahendamise tähtaja järgi.
- **Tähtaja hoiatused**: Pöördumised, mille tähtaeg on järgmise tunni jooksul või ületatud, on esile tõstetud punasega.
- **Pöördumise Lahendamine**: Kasutajad saavad märkida pöördumised lahendatuks, mis eemaldab need loendist.

## Kasutatud Tehnoloogiad

- .NET
- VMCS struktuur - Service klassi on koondatud kogu loogika, samuti, kuna andmebaasi ei olnud nõutud, hoitakse andmeid SortedSet andmestruktuuris service klassis


## Käivitamine


1. Klooni see repositoorium
2. Liigu projekti kataloogi `cd .\KasutajatugiPraktika\ `.
3. Veendu, et on olemas .NET 8.0 SDK
4. Käsureal `dotnet run`.
6. Rakendusele pääseb ligi `http://localhost:5035`.

## Testimine

KasutajatugiPraktikaTests projektis on kaks testklassi

1. TicketServiceImplTests.cs sisaldab unit teste Ticketservice loogika jaoks, sh pöördumise lisamine, kustutamine ja sorteeritud listi tagastamine
2. GuiAutomTests sisaldab Selenium Webdriver testi, mis kontrollib kasutajaliidese kaudu uue pöördumise lisamist ja lahendatuks märkimist
   
NB! Kindlasti ei ole testide arv ja katvus veel piisav ajanappuse tõttu, vaja oleks läbi vaadata ka eri-, ääre- ja negatiivsed juhud. Hetkel katavad unit testid vaid põhilise loogika ja UI test vaid ühe kõige tavalisema positiivse juhu.


## Testide käivitamine

1. Liigu projekti kataloogi `cd .\KasutajatugiPraktika\ `.
2. Käsureal `dotnet run`.
3. Uus terminaliaken
4. Liigu testimisprojekti kataloogi `cd .\KasutajatugiPraktikaTests\ `.
5. Käsureal `dotnet run`.

## Küsimused
Küsimuste korral võta julgesti ühendust mattias.kimst@mail.ee


