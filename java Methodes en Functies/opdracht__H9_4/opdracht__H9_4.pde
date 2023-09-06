int a = 20;
int b = 20;
int c = 50;
int d = 50;

void setup(){
 size(200, 200); 
 rectangle(a, b, c, d);
}

void draw(){
}

void rectangle(int x, int y, int w, int h){
  line(x, y, x + w, y);
  line(x + w, y, x + w, y + h);
  line(x + w, y + h, x, y + h);
  line(x, y + h, x, y);
}
