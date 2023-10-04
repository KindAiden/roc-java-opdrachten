/*
Les Nette Code

Opdracht 3/4

Welke variabel moet ik veranderen om de x te veranderen

*/
//je moet variabele x2 veranderen om de x positie te veranderen
int x = 30;
int y = 40;
boolean flag = false;
int x2 = 20;
int y2 = 20;


int h1 = x - x2;
x = 0;
if(flag){
if(x2 < y2){
h1 += h1;
if(h1 > 0){
print("hoi");
}
}
else{
y2 = h1;
}
}
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

rect(x,y,x2,y2);
  
