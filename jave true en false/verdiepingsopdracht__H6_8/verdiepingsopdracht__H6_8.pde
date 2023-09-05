float cijfer = 8.2;
boolean diploma = false;
boolean cumlaude = false;

if(cijfer >= 5.5){
  diploma = true;
  if(cijfer >= 8){
    cumlaude = true;
  }
}

if(diploma){
  println("Gefeliciteerd");
}
if(cumlaude){
  println("Je bent cumlaude geslaagd");
}
