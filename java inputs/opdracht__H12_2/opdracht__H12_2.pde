int a;
boolean done = false;

void draw(){
  if (millis() >= 10000 && !done){
    println("you pressed space " + a + " times.");
    done = true;
  }
}
void keyPressed(){
  if(key == ' '){
    a++;
  }  
}
