int oldx;
int oldy;


void setup(){
  size(1000, 1000);
}

void draw(){
}

void mousePressed(){
  line(oldx, oldy, mouseX, mouseY);
  oldx = mouseX;
  oldy = mouseY;
}
