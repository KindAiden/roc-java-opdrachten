int Size = 100;
int x = 100;
int y = 100;

void setup(){
  size(300, 300);
  
  for(int i = 0; i < 5; i++){
    circle();
    Size -= 10;
  }
}

void circle(){
    ellipse(x + Size / 2, y + Size / 2, Size, Size);
}
