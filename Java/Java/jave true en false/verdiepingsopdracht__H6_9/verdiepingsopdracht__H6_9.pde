float cijfer1 = 8.2;
float cijfer2 = 9.7;
boolean diploma = false;
boolean cumlaude = false;

if(cijfer1 >= 5.5 && cijfer2 >= 5.5){
  diploma = true;
  if(cijfer1 >= 8 && cijfer2 >= 8){
    cumlaude = true;
  }
}

if(diploma){
  println("Gefeliciteerd");
}
if(cumlaude){
  println("Je bent cumlaude geslaagd");
}
