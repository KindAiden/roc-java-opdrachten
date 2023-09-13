size(1200,1200);
background(255,255,255);

int size1 = 500;
int size2 = 500;

for(int i = 0; i < 50; i++){
  println(size1);
  println(size2);
  ellipse(300, 300, size1, size1);
  ellipse(600 + size2/2, 300 + size2/2, size2, size2);
  size1 = size1 - 10;
  size2 = size2 - 10;
}
