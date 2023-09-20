size(200,200);
background(255,255,255);

int size = 75;

for(int i = 0; i < 5; i++){
  println(size);
  ellipse(100 - size/2, 100 - size/2, size, size);
  size = size - 10;
}
