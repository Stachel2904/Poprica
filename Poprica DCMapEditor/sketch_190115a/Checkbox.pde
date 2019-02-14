class Checkbox {
  
  boolean IsChecked;
  int X, Y;
  int W = 30;
 
  public Checkbox(int _x, int _y)
  {
    X = _x;
    Y = _y;
    IsChecked = false;
    
  }
  
  boolean GetIsChecked()
  {
    return IsChecked;
  }
  
  boolean CheckClick(int x, int y)
  {
    if ( ((x > this.X) && (x <= this.X + W)) && ((y > this.Y) && ( y <= this.Y + W))) {
     IsChecked = !IsChecked;
     return true;
    }
    
    return false;
  }
  
  void display()
  {
    
    if (IsChecked)
      fill(0);
    else
      fill(255);
      
    rect(X, Y, W, W);
  }
  
}
