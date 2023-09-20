int a = 200;
int screenX = 600;
int screenY = 600;

void setup(){
  size(600, 600);
  bos(a);
}

void bos(int amount){
  int x = 20;
  int y = 20;
  int w = round(random(20, 80));;
  int h = round(random(20, 80));;
  for(int i = 0; i < amount; i++){
    tree(x, y, w, h);
    x += round(random(20, 60));
    y += round(random(-10, 10));
    if(x > screenX - 20){
      x = 20 + round(random(-10, 10));
      y += h + round(random(-50, 5)) + h / 2;
    }
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
