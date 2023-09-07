import controlP5.*;

ControlP5 cp;
Button button1;
Button button2;
Textfield textfield;

int leerlingen;
int ouders;


void setup(){
  size(800, 800);
  cp = new ControlP5(this);
  button1 = cp.addButton("Button1").setCaptionLabel("studenten").setPosition(370, 200);
  button2 = cp.addButton("Button2").setCaptionLabel("ouders").setPosition(370, 300);
  textfield = cp.addTextfield("TextInput1").setPosition(300, 400).setColorLabel(color(0, 0, 0)).setCaptionLabel("");
}

void draw(){
  textfield.setText("leerlingen: " + leerlingen + ", ouders: " + ouders + ", totaal: " + int(leerlingen + ouders));
}

void Button1(){
  leerlingen++;
}

void Button2(){
  ouders++;
}
