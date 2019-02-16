import java.util.Arrays;
import java.util.Optional;

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
        input += "\t\t\t\t\t\"Event\" : " + GetEvent(j, i) + ",\n";
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
    input += "\t\t\t\"DefaultEntryPoint\" : \"9, 27, 0\"\n";
    
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
    
    for (int i = 0; i < 8; i++) {
      if ( i > 0 ) {
        vectors[i] = Shift(vectors[i-1]);
      }
    }
    
    vectors[0] = Shift(vectors[7]);
    
    tile.walls = new Boolean[] {!top, !right, !bottom, !left};
    
    for (int i = 0; i < 8; i++) {
      
      if (Arrays.equals(vectors[i], new Boolean[] {true, true, true, true, true, true, true, true})){  //Prisonerroom
        tile.orientation = new int[] {0, -1, 0};
        tile.type = 15;
        return "15";
      }
      else if (Arrays.equals(vectors[i], new Boolean[] {false, false, true, true, true, true, true, false})){ //roomwall
      
        if (i == 0)
          tile.orientation =  new int[] {0, -1, 0};
        else if (i == 2)
          tile.orientation =  new int[] {1, 0, 0};
        else if (i == 4)
          tile.orientation =  new int[] {0, 1, 0};
        else
          tile.orientation =  new int[] {-1, 0, 0};
      
        tile.type = 12;
        return "12";
      }
      else if (i % 2 == 0 && (Arrays.equals( new Boolean[] { vectors[i][0], vectors[i][1], vectors[i][2], vectors[i][3], vectors[i][4], vectors[i][5], vectors[i][6], vectors[i][7]}, new Boolean[] {false, false, false, false, true, true, true, false})
                           || Arrays.equals( new Boolean[] { vectors[i][0], vectors[i][1], vectors[i][2], vectors[i][3], vectors[i][4], vectors[i][5], vectors[i][6], vectors[i][7]}, new Boolean[] {false, false, false, false, true, true, true, true})
                           || Arrays.equals( new Boolean[] { vectors[i][0], vectors[i][1], vectors[i][2], vectors[i][3], vectors[i][4], vectors[i][5], vectors[i][6], vectors[i][7]}, new Boolean[] {false, false, false, true, true, true, true, false})
                           || Arrays.equals( new Boolean[] { vectors[i][0], vectors[i][1], vectors[i][2], vectors[i][3], vectors[i][4], vectors[i][5], vectors[i][6], vectors[i][7]}, new Boolean[] {false, false, false, true, true, true, true, true}))){ //roomcorner
      
        if (i == 0)
          tile.orientation =  new int[] {0, -1, 0};
        else if (i == 2)
          tile.orientation =  new int[] {0, 1, 0};
        else if (i == 4)
          tile.orientation =  new int[] {0, -1, 0};
        else
          tile.orientation =  new int[] {0, 1, 0};
      
        tile.type = 13;
        return "13";
      }
      else if (Arrays.equals(vectors[i], new Boolean[] {true, true, true, false, true, false, true, true})){ //roomexit
      
        if (i == 0)
          tile.orientation =  new int[] {0, 1, 0};
        else if (i == 2)
          tile.orientation =  new int[] {-1, 0, 0};
        else if (i == 4)
          tile.orientation =  new int[] {0, -1, 0};
        else
          tile.orientation =  new int[] {1, 0, 0};
      
        tile.type = 14;
        return "14";
      }
      else if (Arrays.equals( new Boolean[] {vectors[i][0], vectors[i][2], vectors[i][4], vectors[i][6]}, new Boolean[] {true, false, true, false})){ //Straight
        
        if ( i == 0)
          tile.orientation = new int[] {0, -1, 0}; //up
        else
          tile.orientation = new int[] {1, 0, 0};  //right
      
        tile.type = 1;
        return "1";
      }
      else if (i % 2 == 0 && Arrays.equals( new Boolean[] {vectors[i][0], vectors[i][2], vectors[i][4], vectors[i][6]}, new Boolean[] {false, true, true, false})) { //vectors[i], new Boolean[] {false, false, true, false, true, false, false, false})) { //turn
      
        if (i == 0)
          tile.orientation = new int[] {0, -1, 0}; //up
        else if (i == 2)
          tile.orientation = new int[] {-1, 0, 0};  //right
        else if (i == 4)
          tile.orientation = new int[] {0, 1, 0};  //down
        else
          tile.orientation = new int[] {1, 0, 0}; //left
      
        tile.type = 2;
        return "2";
      }
      else if (i % 2 == 0 && Arrays.equals( new Boolean[] {vectors[i][0], vectors[i][2], vectors[i][4], vectors[i][6]} , new Boolean[] {false, true, true, true})) { //tcross
      
        if (i == 0)
          tile.orientation = new int[] {0, 1, 0}; //down
        else if (i == 2)
          tile.orientation = new int[] {1, 0, 0}; //right
        else if (i == 4)
          tile.orientation = new int[] {0, -1, 0}; //top
        else
          tile.orientation = new int[] {-1, 0, 0}; //left
      
        tile.type = 3;
        return "3";
      }
      else if (Arrays.equals(vectors[i], new Boolean[] {true, false, true, false, true, false, true, false})){ //intersection
      
        tile.orientation =  new int[] {0, -1, 0};
      
        tile.type = 4;
        return "4";
      }
      else if (i % 2 == 0 && Arrays.equals( new Boolean[] {vectors[i][0], vectors[i][2], vectors[i][4], vectors[i][6]} , new Boolean[] {false, false, true, false})) { // straightsign
      
        if (i == 0)
          tile.orientation =  new int[] {0, -1, 0};
        else if (i == 2)
          tile.orientation =  new int[] {1, 0, 0};
        else if (i == 4)
          tile.orientation =  new int[] {0, 1, 0};
        else
          tile.orientation =  new int[] {-1, 0, 0};
      
        tile.type = 6;
        return "6";
      }
    }
    
    return "0";
  }
  
  public String GetWalls(int x, int y){
    
    Tile tile = grid.boxes[y][x];
    
    if (!tile.IsChecked)
      return "null";
    
    String str = "[ " + tile.walls[0] + ", " + tile.walls[1] + ", " + tile.walls[2] + ", " + tile.walls[3] + "]";
    
    return str;
  }
  
  public String GetOrientation(int x, int y){
    
    Tile tile = grid.boxes[y][x];
    
    if (!tile.IsChecked || tile.orientation == null)
      return "\"0, 0, 0\"";
      
    String str = "\"" +  tile.orientation[0] + ", " + tile.orientation[1] + ", " + tile.orientation[2] + "\"";
    
    return str;
  }
  
  public String GetEvent(int x, int y) {
     return "" + grid.boxes[y][x].eventType; 
  }
  
  public Boolean[] Shift(Boolean[] vector) {
    
    Boolean[] ret = {vector[7], vector[0], vector[1], vector[2], vector[3], vector[4], vector[5], vector[6]};
    
    return ret;    
  }  
}
