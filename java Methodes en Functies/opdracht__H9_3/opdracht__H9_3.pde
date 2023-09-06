int x = 50;
int y = 25;

void setup(){
  int gem = gemiddelde(x, y);
  print(gem);
}

int gemiddelde(int a, int b){
  int gem = (a + b) / 2;
  return gem;
}
