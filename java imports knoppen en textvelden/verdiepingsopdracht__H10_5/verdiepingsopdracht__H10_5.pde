import controlP5.*;

ControlP5 cp;
Button button1;
Button button2;
Button button3;
Button button4;
Textfield textfield1;
Textfield textfield2;
Textfield textfield3;

int total;

void setup(){
  size(800, 400);
  cp = new ControlP5(this);
  
  textfield1 = cp.addTextfield("TextInput1").setPosition(150, 100).setSize(100, 20).setColorBackground(color(255, 255, 255)).setCaptionLabel("").setColorValue(color(0, 0, 0)).setAutoClear(false);
  textfield2 = cp.addTextfield("TextInput2").setPosition(255, 100).setSize(100, 20).setColorBackground(color(255, 255, 255)).setCaptionLabel("").setColorValue(color(0, 0, 0)).setAutoClear(false);
  textfield3 = cp.addTextfield("TextInput3").setPosition(300, 300).setColorLabel(color(0, 0, 0)).setCaptionLabel("");
  
  button1 = cp.addButton("Button1").setCaptionLabel("+").setPosition(360, 100).setSize(20, 20).setColorBackground(color(255, 255, 255)).setColorLabel(color(0, 0, 0));
  button2 = cp.addButton("Button2").setCaptionLabel("-").setPosition(385, 100).setSize(20, 20).setColorBackground(color(255, 255, 255)).setColorLabel(color(0, 0, 0));
  button3 = cp.addButton("Button3").setCaptionLabel("*").setPosition(410, 100).setSize(20, 20).setColorBackground(color(255, 255, 255)).setColorLabel(color(0, 0, 0));
  button4 = cp.addButton("Button4").setCaptionLabel("/").setPosition(435, 100).setSize(20, 20).setColorBackground(color(255, 255, 255)).setColorLabel(color(0, 0, 0));
}

void draw(){
  textfield3.setText(str(total));
}

void Button1(){
  total = int(textfield1.getText()) + int(textfield2.getText());
}

void Button2(){
  total = int(textfield1.getText()) - int(textfield2.getText());
}

void Button3(){
  total = int(textfield1.getText()) * int(textfield2.getText());
}

void Button4(){
  total = int(textfield1.getText()) / int(textfield2.getText());
}
