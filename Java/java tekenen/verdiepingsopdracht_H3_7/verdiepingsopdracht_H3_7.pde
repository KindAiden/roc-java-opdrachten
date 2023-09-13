size(800, 800);
background(180, 180, 255);

//draw ground
fill(150, 255, 150);
rect(-1, 600, 801, 201);

//draw house base
fill(232, 220, 202);
rect(250, 400, 300, 300);

//draw chimney
fill(166, 82, 58);
rect(290, 330, 20, 40);

//draw roof
fill(255, 100, 100);
triangle(230, 410, 570, 410, 400, 300);

//draw door
fill(194, 148, 103);
rect(450, 600, 50, 100);
fill(255, 255, 0);
ellipse(460, 640, 5, 5);

//draw top window
fill(167, 214, 234);
ellipse(400, 360, 60, 60);

//draw bottom windows
rect(275, 590, 150, 60, 5);
rect(290, 450, 100, 60, 5);
rect(450, 450, 50, 60, 5);
