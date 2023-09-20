float[] cijfers = {3, 7.5, 8};
float gem = 0;

for(int i = 0; i < cijfers.length; i++){
  gem += cijfers[i];
}

gem /= cijfers.length;
print(gem);
