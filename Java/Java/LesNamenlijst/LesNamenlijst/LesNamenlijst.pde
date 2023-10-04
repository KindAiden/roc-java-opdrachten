/*  Opdracht NamenLijst
Probeer in de String[Array] namenLijst de namen Jesse en Kees te vinden met code.
Als je een naam vindt dan moet je de naam + " gevonden!" printen. Anders "bestaat niet." printen;

Wat gebeurt er en wat lukt er niet?

*Bonus maak hiervan een methode die een naam als parameter krijgt
  
*/

String[] namenLijst = {"Piet","Joris","Ronald","Billy","Jesse", "Niek"};

void setup(){
  findName("Jesse");
  findName("Kees");
}

void findName(String name){
  String ans = "";
  for (int i = 0; i< namenLijst.length; i++){
    if (namenLijst[i] == name){
      ans = name + " gevonden!";
    }    
    if (ans == ""){
      ans = name + " bestaat niet";
    }
  }
  println(ans);
}
