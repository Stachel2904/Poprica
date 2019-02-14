class Grid {
  
  public Tile[][] boxes;
  
  Tile last, prevlast;
  boolean state;
 
  public Grid(int X, int Y)
  {
    boxes = new Tile[Y][X];
    last = null;
    prevlast = null;
    state = false;
    
    for (int i = 0; i < Y; i++){
      for (int j = 0; j < X; j++){
        boxes[i][j] = new Tile(
                              j, 
                              i,
                              0, 0);
      }
    }
  }
  
  public int CalcXPos(int x){
    return (x%14) * height/21 + width/20;
  }
  
  public int CalcYPos(int y){
    return (y%20) * height/21 + width/20;
  }
  
  boolean CheckClick(int X, int Y)
  {
    boolean click = false;
    
     for (int i = 0; i < boxes.length; i++){
      for (int j = 0; j < boxes[i].length; j++){
        click = boxes[i][j].CheckClick(X, Y);
        
        if (click){
         state = !state;
         
         if(state)
           last = boxes[i][j];
         else
           prevlast = boxes[i][j];
         
         if (last == prevlast)
           return false;
        }
        
      }
     }
     
     return click;
  }
  
  public void SetTiles(Tile[][] tiles){
    
    boxes = new Tile[tiles.length][tiles[0].length];
    
    for (int i = 0; i < tiles.length; i++) {
       for (int j = 0; j < tiles[i].length; j++) {
         boxes[i][j] = tiles[i][j];
       }
    }
    
  }
  
  void Connect()
  {
    
  }
  
  void display()
  {
    for (int i = 0; i < boxes.length; i++){
      for (int j = 0; j < boxes[i].length; j++){
        
        //pushMatrix();
        //translate(
        //    (i%boxes.length) * height/21 + width/20,
        //    (j%boxes[i].length) * height/21 + width/20);
            
        boxes[i][j].display(j, i); 
        //popMatrix();
      }
    }
  }
  
}
