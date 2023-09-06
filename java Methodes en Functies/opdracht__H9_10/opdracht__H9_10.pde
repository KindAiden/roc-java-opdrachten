int a = 200;
int screenX = 600;
int screenY = 600;

void setup(){
  size(600, 600);
  bos(a);
}

void bos(int amount){
  int x = 50;
  int y = 50;
  int w = 50;
  int h = 50;
  for(int i = 0; i < amount; i++){
    tree(x, y, w, h);
    x = round(random(0, screenX));
    y = round(random(0, screenY));
    w = round(random(20, 80));
    h = round(random(20, 80));
  }
}

void tree(int x, int y, int w, int h){
  fill(133,94,66);
  rect(x - w / 4, y, w / 2, h);
  fill(0, 150, 0);
  ellipse(x, y, w, w);
}
