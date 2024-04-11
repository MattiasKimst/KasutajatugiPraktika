# Kasutajatoe Pöördumiste Haldussüsteem

Tegu on lihtsa veebirakendusega kasutajatoe pöördumiste haldamiseks, mis võimaldab kasutajal sisestada kirjelduse ja tähtaja järgi pöördumisi, vaadata aktiivseid pöördumisi ja märkida need lahendatuks. 
- **Pöördumise Esitamine**: Kasutajad saavad esitada pöördumisi koos kirjelduse ja tähtajaga.
- **Tähtaja Järjestamine**: Pöördumised on järjestatud loendis kahenevalt lahendamise tähtaja järgi.
- **Tähtaja Hoiatused**: Pöördumised, mille tähtaeg on järgmise tunni jooksul või ületatud, on esile tõstetud punasega.
- **Pöördumise Lahendamine**: Kasutajad saavad märkida pöördumised lahendatuks, eemaldades need loendist.

## Kasutatud Tehnoloogiad

- .NET
- Eraldi andmebaasi kasutusel ei ole, andmeid hoitakse mälus TicketServiceImpl.cs klassis


## Seadistamine


1. Klooni see repositoorium 
3. Liigu projekti kataloogi.
4. Käsureal `dotnet build`.
5. Seejärel käsureal `dotnet run`.
6. Rakendusele pääseb ligi `http://localhost:5035`.

## Testimine

KasutajatugiPraktikaTests projektis on kaks testklassi

1. TicketServiceImplTests.cs sisaldab unit teste Ticketservice loogika jaoks, sh pöördumise lisamine, kustutamine ja sorteeritud listi tagastamine
2. GuiAutomTests sisaldab Selenium Webdriver testi, mis kontrollib kasutajaliidese kaudu uue pöördumise lisamist ja lahendatuks märkimist
   Kindlasti ei ole testide veel kaetud kõik vajalikud eri- ja äärejuhud, mis jäid ajanappusel tegemata


