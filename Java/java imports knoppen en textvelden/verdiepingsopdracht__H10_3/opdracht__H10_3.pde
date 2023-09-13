import controlP5.*;

ControlP5 cp;
Button button;
Textfield textfield;


void setup(){
  size(800, 800);
  cp = new ControlP5(this);
  button = cp.addButton("Button").setCaptionLabel("Klik mij").setPosition(370, 300);
  textfield = cp.addTextfield("TextInput1").setPosition(300, 200).setCaptionLabel("Type je prijs.").setColorLabel(color(0, 0, 0));
}

void draw(){
}

void Button(){
  float btw = int(textfield.getText()) + int(textfield.getText()) * 0.21;
  println(textfield.getText(), "+", int(textfield.getText()) * 0.21, "=", btw);
}
