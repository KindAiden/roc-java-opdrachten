String a = "hello ";
String b = "there. \n";
String c = "General ";
String d = "Kenobi!";

void setup(){
 String s = string(a, b, c, d);
 println(s);
}

String string(String a, String b, String c, String d){
  return a + b + c + d;
}
