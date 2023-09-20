

void setup(){
 size(1000, 1000); 
}

void draw(){
  fill(random(0, 255), random(0, 255), random(0, 255));
  rect(mouseX - 10, mouseY -10, 20, 20);
}
