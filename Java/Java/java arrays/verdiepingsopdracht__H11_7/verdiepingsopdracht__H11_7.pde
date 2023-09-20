import controlP5.*;

ControlP5 cp;
Button button1;
Textfield textfield1;
Textfield textfield2;

String[] myarray = new String[10];
int total = 0;

void setup(){
  size(500, 500);
  cp = new ControlP5(this);
  
  textfield1 = cp.addTextfield("TextInput1").setPosition(150, 100).setSize(100, 20).setColorBackground(color(255, 255, 255)).setCaptionLabel("").setColorValue(color(0, 0, 0)).setAutoClear(false);  
  textfield2 = cp.addTextfield("TextInput2").setPosition(50, 200).setSize(400, 20).setColorBackground(color(255, 255, 255)).setCaptionLabel("").setColorValue(color(0, 0, 0)).setAutoClear(false);  
  button1 = cp.addButton("Button1").setCaptionLabel("add name").setPosition(360, 100).setSize(50, 20).setColorBackground(color(255, 255, 255)).setColorLabel(color(0, 0, 0));
}

void draw(){
}

void Button1(){
  myarray[total] = textfield1.getText();
  total++;
  if (total == 10){
    String s = "";
    for(int i = 0; i < myarray.length - 1; i++){
      s += myarray[i] + ", ";
    }
    s += myarray[myarray.length];
    textfield2.setText(s);
  }
}
