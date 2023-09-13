int[] myarray = {10, 12, 15, 15, 15, 16, 17, 17, 28, 255};
int a = 0;

for(int i = 0; i < myarray.length; i++){
  if(myarray[i] == 17){
    a++;
  }
}
println("17 komt " + a + " keer voor.");
