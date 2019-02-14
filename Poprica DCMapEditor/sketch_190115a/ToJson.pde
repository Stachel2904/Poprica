class ToJson{
 
  PrintWriter writer;
  String input;
  
  public ToJson(String name){
    writer = createWriter(name);
    input = new String();
  }
  
  public void Write(){
    
    input = "{\n\t\t\"Tiles\" : \n\t\t\t[\n";
   
    for(int i = 0; i < grid.boxes.length; i++){
      
      input += "\n\t\t\t\t[\n";
      
      for(int j = 0; j < grid.boxes[i].length; j++){
        
        input += "\t\t\t\t\t{\n";        
        input += "\t\t\t\t\t\"Type\" : " + GetTileType(j, i) + ",\n";
        input += "\t\t\t\t\t\"Walls\" : " + GetWalls(j, i) + ",\n";
        input += "\t\t\t\t\t\"Orientation\" : " + GetOrientation(j, i) + ",\n";
        input += "\t\t\t\t\t\"Event\" : " + "null" + ",\n";
        input += "\t\t\t\t\t\"Enemies\" : " + "null" + ",\n";
        input += "\t\t\t\t\t},\n";
        
      }
      
      if (i != grid.boxes.length - 1)
        input += "\t\t\t\t],\n";
      else
        input += "\t\t\t\t]\n";
    }
    
    input += "\t\t\t],\n";
    
    input += "\t\t\t\"FloorNum\" : 1,\n";
    input += "\t\t\t\"DefaultEntryPoint\" : \"1, 2, 0\"\n";
    
    input += "}\0";
    
    WriteComplete();
    
  }
  
  public void WriteComplete(){
   
   writer.print(input);
   writer.flush();
   writer.close(); 
  }
  
  public String GetTileType(int x, int y){
    return "1";
  }
  
  public String GetWalls(int x, int y){
    return "null";
  }
  
  public String GetOrientation(int x, int y){
    return "null";
  }
  
  
  
}
