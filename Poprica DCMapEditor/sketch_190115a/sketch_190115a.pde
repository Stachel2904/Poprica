int sizeX = 14;
int sizeY = 20;

int Xpressed, Ypressed;

int time;

Button createFile;

Grid grid;
ToJson file;

void setup() 
{
  frameRate(120);
  size(900, 800);
  
  file = new ToJson("Floortest.json");
  
  grid = new Grid(sizeX, sizeY);
  createFile = new Button(width*0.14, height*0.9, "Create File");
  
  //file = new Json();
}

void draw()
{
  background(255);
  grid.display();
  
  createFile.display();
  
  //if (mousePressed){
    //line(Xpressed, Ypressed, mouseX, mouseY);
  //}
}

void mousePressed()
{
  
  if (createFile.hover()){
   file.Write(); 
  }
  
  Xpressed = mouseX;
  Ypressed = mouseY;
  
  grid.CheckClick(Xpressed, Ypressed);
}
