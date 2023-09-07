import controlP5.*;

ControlP5 cp;
Button button;
Textfield textfield;


void setup(){
  size(800, 800);
  cp = new ControlP5(this);
  button = cp.addButton("Button").setCaptionLabel("Klik mij").setPosition(370, 300);
  textfield = cp.addTextfield("TextInput1").setPosition(300, 200).setCaptionLabel("Type je naam.").setColorLabel(color(0, 0, 0));
}

void draw(){
}

void Button(){
  println("Hoi mijn naam is: " + textfield.getText());
}
