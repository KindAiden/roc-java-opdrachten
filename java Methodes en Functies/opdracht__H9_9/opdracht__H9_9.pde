int x = 50;
int y = 50;
int w = 50;
int h = 150;

void setup(){
  size(600, 600);
  tree(x, y, w, h);
}

void tree(int x, int y, int w, int h){
  fill(133,94,66);
  rect(x - w / 4, y, w / 2, h);
  fill(0, 150, 0);
  ellipse(x, y, w, w);
}
