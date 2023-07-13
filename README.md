# DotnetTemplate Dokumentation
DotnetTemplate er en applikation, der er designet med en onion layered arkitektur. Denne dokumentation beskriver arkitekturen og strukturen i applikationen samt de tilhørende testprojekter.

## Arkitektur
DotnetTemplate følger en onion layered arkitektur, hvor koden er organiseret i tre hovedlag: Api, ControllerService og ServiceGateway.

## Api-laget
Api-laget er ansvarlig for at håndtere indgående anmodninger og levere svar til klienten. Det er det øverste lag i arkitekturen og fungerer som grænsefladen mellem applikationen og omverdenen.

## ControllerService-laget
ControllerService-laget er placeret mellem Api-laget og ServiceGateway-laget. Det håndterer forretningslogikken og koordinerer kommunikationen mellem Api-laget og ServiceGateway-laget. Dette lag returnerer de specifikke DTO-modeller til den controller-action som den kaldes fra.

## ServiceGateway-laget
ServiceGateway-laget er det laveste lag i arkitekturen og er ansvarlig for at kommunikere med eksterne tjenester eller datakilder.

## Afhængigheder
Api afhænger af ControllerService. Dette lag kan ikke benytte ServiceGateway. Dette er styret ved at <PrivateAssets>All</PrivateAssets> er sat på projekt referencen.
ControllerService afhænger af ServiceGateway.
ServiceGateway har ingen afhængigheder til andre projekter.

## Projektstruktur
Projektstrukturen i DotnetTemplate er organiseret efter arkitekturen og følger en konventionel opdeling i mapper og filer. 
Solutionfilen ligger i roden.

**Source/Api**: Indeholder kode til Api-laget.

**Tests/Unit/Api.Tests**: Indeholder testprojektet til Api-laget.

**Source/ControllerService**: Indeholder kode til **ControllerService-laget.

**Tests/Unit/ControllerService.Tests**: Indeholder testprojektet til ControllerService-laget.

**Source/ServiceGateway**: Indeholder kode til ServiceGateway-laget.

**Tests/Unit/ServiceGateway.Tests**: Indeholder testprojektet til ServiceGateway-laget.

## Installation og Kørsel
For at installere og køre DotnetTemplate, skal du følge disse trin:

1. Klon eller download projektet fra repository.
2. Åbn en terminal og naviger til projektets rodmappe.
3. Kør **dotnet restore** for at gendanne alle afhængigheder.
4. Gå til det ønskede projektlag (f.eks. Api, ControllerService eller ServiceGateway) i terminalen.
5. Kør **dotnet build** for at bygge projektet.
6. Kør **dotnet run** i API-mappen for at køre projektet for det pågældende lag. Åben din browser og gå til http://localhost:XXXX/swagger/index.html
7. Kør **dotnet** test for at køre testprojektet for det pågældende lag.

Husk at følge de specifikke instruktioner i hvert projekts README-fil for yderligere opsætning eller konfiguration.