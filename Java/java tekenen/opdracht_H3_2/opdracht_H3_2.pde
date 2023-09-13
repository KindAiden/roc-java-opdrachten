size(512, 384);
int screenX = 512;
int screenY = 384;

fill(255, 0, 0);
rect(0, 0, screenX, screenY / 3);
fill(255, 255, 255);
rect(0, screenY / 3, screenX, screenY - screenY / 3);
fill(0, 0, 255);
rect(0, screenY - screenY / 3, screenX, screenY);
