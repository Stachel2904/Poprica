class Checkbox {
  
  int eventType = 0;
  
  boolean IsChecked;
  int X, Y;
  int W = 20;
  
  public Checkbox(){
   
    
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
     
     if (IsChecked)
       eventType = checkedEvent;
     else
       eventType = 0;
     
     return true;
    }
    
    return false;
  }
  
}
