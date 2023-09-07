import controlP5.*;

ControlP5 cp;
Button button1;
Button button2;


void setup(){
  size(800, 800);
  cp = new ControlP5(this);
  button1 = cp.addButton("Button1").setPosition(200, 100).setSize(400, 200).setCaptionLabel("Klik mij").setColorBackground(color(0, 200, 0));
  button2 = cp.addButton("Button2").setPosition(200, 500).setSize(400, 200).setCaptionLabel("Klik mij").setColorBackground(color(200, 0, 0));
}

void draw(){
}

void Button1(){
  println("Helaas fout!");
}

void Button2(){
 println("Goed gedaan!"); 
}
