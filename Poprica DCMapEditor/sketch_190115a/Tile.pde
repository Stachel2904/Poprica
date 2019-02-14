class Tile {
  
  int type;
  int eventType;
  
  Boolean[] walls;
  
  
  boolean IsChecked;
  int X, Y;
  int W = 20;
  
  
  public Tile(){
    type = 0;
    eventType = 0;
  }
  
  public Tile( int _x, int _y, int _type, int _event) {
     X = _x;
     Y = _y;
     IsChecked = (_type != 0) ? true : false;
     type = _type;
     eventType = _event;
  }
  
  public int GetType(){
    return type;
  }
  
  public int GetEventType(){
    return eventType;
  }
  
  boolean GetIsChecked()
  {
    return IsChecked;
  }
  
  boolean CheckClick(int x, int y)
  {
    if ( ((x > this.X*W +10) && (x <= this.X*W + W + 10)) && ((y > this.Y*W +10) && ( y <= this.Y*W + W + 10))) {
     IsChecked = !IsChecked;
     return true;
    }
    
    return false;
  }
  
  void display(int x, int y)
  {
    
    if (IsChecked)
      fill(0);
    else
      fill(255);
    
    rect(X*W + 10, Y*W + 10, W, W);
    //rect((X%14) * height/21 + width/20, (Y%20) * height/21 + width/20, W, W);
  } 
  
}
