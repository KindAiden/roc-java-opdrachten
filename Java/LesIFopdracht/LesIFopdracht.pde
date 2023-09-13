/*
Opdracht if

We hebben een RPG game waarin spelers drie dobbelstenen gooien om schade te doen tegen de vijand
Als een van de dobbelstenen een 1 is, wordt er geen schade gedaan. We zeggen dan tegen de speler "mis!".
Anders wordt de schade berekend door het gemiddelde gooi van dobbelstenen te pakken. We vertellen dan tegen de speler : het aantal schade + "HIT!"

>Bonus opdracht<
Als alle drie de dobbelstenen 1 zijn wrijven we dat er lekker in door "Critical MISS!" te zeggen.
Als alle drie dobbelsten 6 zijn feliciteren we de speler door een leuk bericht.


*/

int steen1 = 6;
int steen2 = 6;
int steen3 = 2;
String resultaat = "";

steen1 = int(random(1, 7));
steen2 = int(random(1, 7));
steen3 = int(random(1, 7));

//voeg de getallen van de dobbelstenen toe aan resultaat
resultaat += str(steen1) + "\n" + str(steen2) + "\n" + str(steen3) + "\n";

if(steen1 == 1 || steen2 == 1 || steen3 == 1){
  if(steen1 == 1 && steen2 == 1 && steen3 == 1){
    resultaat += "Critical MISS!";
  }
  else{
    resultaat += "mis!";
  }
}
else{
  resultaat += str(round((steen1 + steen2 + steen3) / 3)) + " HIT!";
}
if(steen1 == 6 && steen2 == 6 && steen3 == 6)
  resultaat += "\nWOW, Amazing hit!";

print(resultaat);
