int x = 475;
int y = 475;


void setup(){
  size(1000, 1000);
}

void draw(){
  background(255);
  rect(x, y, 50, 50);
}

void keyPressed(){
  int dir = keyCode - 37;
  switch(dir){
    case 0:
      x -= 10;
      break;
    case 1:
      y -= 10;
      break;
    case 2:
      x += 10;
      break;
    case 3:
      y += 10;
      break;
  }
}
