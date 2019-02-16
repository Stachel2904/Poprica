int sizeX = 20;
int sizeY = 14;

int Xpressed, Ypressed;

int time;

int checkedEvent = 1;

Button createFile;
Button loadFile;
Button newGrid;

Textbox tbX, tbY;

Grid grid;
Json file;

void setup() 
{
  file = new Json();
  
  frameRate(120);
  size(900, 800);
  
  grid = new Grid(sizeX, sizeY);
  createFile = new Button(width*0.14, height*0.9, "Create File");
  loadFile = new Button(width*0.28, height*0.9, "Load FIle");
  newGrid = new Button(width*0.42, height*0.9, "New Grid"); 
  
  tbX = new Textbox((int) (width*0.35), (int) (height*0.95));
  tbY = new Textbox((int) (width*0.43), (int) (height*0.95));
  
  
  //file = new Json();
}

void draw()
{
  background(255);
  
  if (grid != null) {
     grid.display();
  }
  
  createFile.display();
  loadFile.display();
  newGrid.display();
  
  tbX.display();
  tbY.display();
  
  //if (mousePressed){
    //line(Xpressed, Ypressed, mouseX, mouseY);
  //}
}

void mousePressed()
{
  
  if (createFile.hover()){
   file.Write(); 
  }
  
  if (loadFile.hover()){
    file.Read();
  }
  
  if (newGrid.hover()){
    grid = new Grid(tbX.GetText(), tbY.GetText());
  }
  
  tbX.hover();
  tbY.hover();
  
  Xpressed = mouseX;
  Ypressed = mouseY;
  
  grid.CheckClick(Xpressed, Ypressed);
}

void keyPressed() {
  tbX.KEYPRESSED(key, (int)keyCode);
  tbY.KEYPRESSED(key, (int)keyCode);
    
}
