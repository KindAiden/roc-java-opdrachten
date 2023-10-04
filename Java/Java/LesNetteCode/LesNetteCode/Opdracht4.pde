/*
Les Nette Code

Opdracht 4/4

Welke variabelen moet ik veranderen om hoi te laten printen door de code

*/
//variabele h1 moet groter zijn dan 0, dus kan je zowel x en x2 veranderen zolang het resultaat boven 0 is
int x = 30;
int y = 40;
boolean JA = false;
int x2 = 20;
int y2 = 20;

//breedte
int h1 = x - x2;
x = 0;
if(JA){
if(x2 < y2){
h1 += h1;
if(h1 > 0){
//test
print("hoi");
}
}
//hoogte
else{
y2 = h1;
}
}
//nieuwe waarde
else{
x = x2;
}
if(x2 > y2){
print("BIG");
if(x2 > y2*2){
print("MEGA");
}
}
else{print("sm0ll");
}

rect(x,y,h1,y2);
  
