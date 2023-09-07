import controlP5.*;

ControlP5 cp;
Textfield textfield1;

boolean running = false;
float lasttime;
float currenttime = 0;

void setup(){
  size(100, 100);
  cp = new ControlP5(this);
  
  textfield1 = cp.addTextfield("TextInput1").setPosition(25, 40).setSize(50, 20).setColorBackground(color(255, 255, 255)).setCaptionLabel("").setColorValue(color(0, 0, 0)).setAutoClear(false);
}

void draw(){
  if (running){
    currenttime = millis() - lasttime;
    textfield1.setText(str(currenttime/100));
  }
}

void keyPressed(){
  if(key == ' '){
    running = !running;
    if(running){
      lasttime = millis();
      currenttime = 0;
    }
  }  
}
