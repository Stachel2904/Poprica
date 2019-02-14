class Json{
 
  PrintWriter writer;
  String input;
  
  JSONObject file;
  JSONArray tilesJson;
  
  String name = "Floortest.json";
  
  public Json(){
    
  }
  
  private void ConvertToGrid(){
    
    JSONArray tiles;
    
    grid.boxes = null;
       
    Tile[][] gridTiles;
    
    gridTiles = new Tile[tilesJson.size()][tilesJson.getJSONArray(0).size()];
    
    println(gridTiles.length);
    
    for (int i = 0; i < tilesJson.size(); i++){
        tiles = tilesJson.getJSONArray(i);
        
        //gridTiles[i] = new Tile[tiles.size()];
        
        for (int j = 0; j < tiles.size(); j++) {
           JSONObject tile = tiles.getJSONObject(j);
           
           //println(tile.getInt("Type"));
           
           gridTiles[i][j] = new Tile(j, i, tile.getInt("Type"), tile.getInt("Event"));
        }
    }
    grid.SetTiles(gridTiles);
    
    //print(grid.boxes.length + "   " + grid.boxes[0].length);
  }
  
  public Grid Read() {
    
    file = loadJSONObject(name);
    
    tilesJson = file.getJSONArray("Tiles");
    
    ConvertToGrid();
    
    return grid;
  }
  
  public void Write(){
    
    writer = createWriter(name);
    input = new String();
    
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
    
    Tile tile = grid.boxes[y][x];
    
    if (tile.IsChecked == false) {
      return "0";
    }
    
    Boolean top = (y-1 > -1) ? grid.boxes[y-1][x].IsChecked : false;
    Boolean topRight = (y-1 > -1 && x+1 < grid.boxes[y].length) ? grid.boxes[y-1][x+1].IsChecked : false;
    Boolean topLeft = (y-1 > -1 && x-1 > -1) ? grid.boxes[y-1][x-1].IsChecked : false;
    Boolean bottom = (y+1 < grid.boxes.length) ? grid.boxes[y+1][x].IsChecked : false;
    Boolean bottomRight = (y+1 < grid.boxes.length && x+1 < grid.boxes[y].length) ? grid.boxes[y+1][x+1].IsChecked : false;
    Boolean bottomLeft = (y+1 < grid.boxes.length && x-1 > -1) ? grid.boxes[y+1][x-1].IsChecked : false;
    Boolean right = (x+1 < grid.boxes[y].length) ? grid.boxes[y][x+1].IsChecked : false;
    Boolean left = (x-1 > -1 ) ? grid.boxes[y][x-1].IsChecked : false;
    
    Boolean[] vector = {top, topRight, right, bottomRight, bottom, bottomLeft, left, topLeft};
    
    Boolean[][] vectors = new Boolean[8][];
    vectors[0] = vector;
    
    Boolean[] tmp = vectors[7];
    
    for (int i = 0; i < 8; i++) {
      if ( i > 0 ) {
        vectors[i] = Shift(vectors[i-1]);
      }
    }
    
    vectors[0] = tmp;
    
    tile.walls = new Boolean[] {!top, !right, !bottom, !left};
    
    for (int i = 0; i < 8; i++) {
      if (vectors[i] == new Boolean[] {true, true, true, true, true, true, true, true}){  //Prisonerroom
        tile.type = 16;
        return "16";
      }
      else if (vectors[i] == new Boolean[] {true, false, false, false, true, false, false, false}){  //Straight
        tile.type = 1;
        return "1";
      }
      else if (vectors[i] == new Boolean[] {false, false, true, false, true, false, false, false}){  //rightturn
        tile.type = 2;
        return "2";
      }
      else if (vectors[i] == new Boolean[] {false, false, false, false, true, false, true, false}){ //lefttrurn
        tile.type = 3;
        return "3";
      }
      else if (vectors[i] == new Boolean[] {false, false, true, false, true, false, true, false}){ //tcross
        tile.type = 4;
        return "4";
      }
      else if (vectors[i] == new Boolean[] {true, false, true, false, true, false, true, false}){ //intersection
        tile.type = 5;
        return "5";
      }
      else if (vectors[i] == new Boolean[] {true, true, true, false, true, false, true, true}){ //roomexit
        tile.type = 15;
        return "15";
      }
      else if (vectors[i] == new Boolean[] {false, false, false, false, true, false, false, false}){ // straightsign
        tile.type = 7;
        return "7";
      }
      else if (vectors[i] == new Boolean[] {false, false, true, true, true, true, true, false}){ //roomwall
        tile.type = 13;
        return "13";
      }
      else if (vectors[i] == new Boolean[] {false, false, false, false, true, true, true, false}){ //roomcorner
        tile.type = 14;
        return "14";
      }
    }
    
    return "0";
  }
  
  public String GetWalls(int x, int y){
    
    Tile tile = grid.boxes[y][x];
    
    String str = "[ " + tile.walls[0] + ", " + tile.walls[1] + ", " + tile.walls[2] + ", " + tile.walls[4] + "]";
    
    return str;
  }
  
  public String GetOrientation(int x, int y){
    return "null";
  }
  
  public Boolean[] Shift(Boolean[] vector) {
    
    Boolean[] ret = {vector[7], vector[0], vector[1], vector[2], vector[3], vector[4], vector[5], vector[6]};
    
    return ret;    
  }  
}
