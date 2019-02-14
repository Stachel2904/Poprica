class Grid {
  
  Checkbox[][] boxes;
  
  Checkbox last, prevlast;
  boolean state;
 
  public Grid(int X, int Y)
  {
    boxes = new Checkbox[Y][X];
    last = null;
    prevlast = null;
    state = false;
    
    for (int i = 0; i < Y; i++){
      for (int j = 0; j < X; j++){
        boxes[i][j] = new Checkbox(
                        (i%boxes.length) * height/21 + width/20,
                        (j%boxes[i].length) * height/21 + width/20);
      }
    }
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
            
        boxes[i][j].display(); 
        //popMatrix();
      }
    }
  }
  
}
