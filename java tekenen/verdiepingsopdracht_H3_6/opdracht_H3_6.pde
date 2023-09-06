size(1000, 500);
background(240, 240, 240);

//draw line
fill(0, 0, 0);
line(20, 20, 320, 20);
text("Lijn", 150, 40);
//draw rect
noFill();
rect(20, 60, 300, 150);
text("Rechthoek", 130, 230);
//draw rect with circle
fill(255, 0, 255);
rect(350, 60, 300, 150);
ellipse(500, 135, 300, 150);
fill(0, 0, 0);
text("gevulde rechthoek met ovaal", 425, 230);
//draw pie
noFill();
arc(830, 135, 300, 150, 0, 120);
fill(255, 0, 255);
arc(830, 135, 300, 150,-1,0);
fill(0, 0, 0);
text("taartpunt met ovaal eromheen", 750, 230);
//draw rect but round
noFill();
rect(20, 275, 300, 150, 10);
text("Afgeronde rechthoek", 110, 450);
//draw oval but P I N K
fill(255, 0, 255);
ellipse(500, 350, 300, 150);
fill(0, 0, 0);
text("gevulde ovaal", 450, 450);
//circle
noFill();
ellipse(830, 350, 150, 150);
text("Cirkel", 825, 450);
