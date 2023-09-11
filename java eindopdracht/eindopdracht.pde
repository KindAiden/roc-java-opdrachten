import controlP5.*;

ControlP5 cp;
Textlabel text;

int y1; // player 1's Y position
int y2; // player 2's Y position
int height1 = 100; // player 1's height
int height2 = 100; // player 2's height
int speed = 10; // speed at which the paddels move
int ballx = width / 2 - 10;
int bally = height / 2 - 10;
int ballvelocityX = 3;
int ballvelocityY = 3;
int timer = 30; // time to wait before starting a round
int score1; // player 1's score
int score2; // player 2's score

void setup(){
  size(1200, 900);
  cp = new ControlP5(this);
  text = cp.addLabel("0 - 0").setPosition(width/2-33, 100).setSize(50, 50).setFont(createFont("Arial", 30)).setColorBackground(color(0, 0, 0));
  reset(boolean(int(random(0, 2))));
}

void draw(){
  background(0);
  //draw player paddels
  fill(240, 240, 240);
  rect(100, y1, 20, height1);
  rect(width - 120, y2, 20, height2);
  //draw ball
  rect(ballx, bally, 20, 20);
  timer--;
  if(timer >= 0)
    return;
  //check for input
  if(keyPressed){
    if(keyCode == 87 || keyCode == 38){
      y1 -= speed;
      y1 = max(y1, 0);
    }
    if(keyCode == 83 || keyCode == 40){
      y1 += speed;
      y1 = min(y1, height - height1);
    }
  }
  moveBall();
  movePlayer2();
  text.setText(score1 + " - " + score2).align(0, 0, 2, 2);
}

void moveBall(){
  //update the ball position
  ballx += ballvelocityX;
  bally += ballvelocityY;
  
  //check if the ball is touching a paddel
  if(ballx >= 100 && ballx <= 120 && bally + 20 >= y1 && bally <= y1 + height1){
    ballx = 120;
    ballvelocityX = int(random(3, 10));
    ballvelocityY += int(random(-2, 3));
  }
  if(ballx + 20 >= width - 120 && ballx + 20 <= width - 100 && bally + 20 >= y2 && bally <= y2 + height2){
    ballx = width - 140;
    ballvelocityX = int(random(-3, -10));
    ballvelocityY += int(random(-2, 3));
  }
  
  //check if the ball has reached the edge of the screen
  if(bally <= 0){
    bally = 0;
    ballvelocityY *= -1;
    return;
  }
  if(bally >= height - 20){
    bally = height - 20;
    ballvelocityY *= -1;
    return;
  }
  if(ballx < -20){ //the ball went past the left side of the screen
    score2++;
    reset(false);
    return;
  }
  if(ballx > width){ //the ball went past the right side of the screen
    score1++;
    reset(true);
    return;
  }
}

//reset all positions to the center of the screen to start the new round
void reset(boolean goLeft){
  timer = 60;
  ballx = width / 2 - 10;
  bally = height / 2 - 10;
  ballvelocityX = int(random(3, 10));
  ballvelocityY = int(random(-15, 15));
  y1 = height / 2 - height1 / 2;
  y2 = height / 2 - height2 / 2;
  if(goLeft)
    ballvelocityX *= -1; 
}

void movePlayer2(){
  int middle = y2 + height2 / 2;
  int movespeed = speed - 2;
  if(bally + 20 <= middle + height2 / 4 && bally >= middle - height2 / 4)
    return;
  
  if (ballvelocityX < 0)
    movespeed = 2;
  if(bally < middle){
    y2 -= movespeed;
  }
  if(bally > middle){
    y2 += movespeed;
  }
  y2 = max(y2, 0);
  y2 = min(y2, height - height1);
}
