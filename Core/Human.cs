using OpenTK.Mathematics;

namespace MyGame.Model
 {
class Humans
 {
  public int posX {get; set;}
  public int posY {get; set;}
  public string id {get; set;}
  public Boolean status {get; set;}
  public Matrix4 Transform {get; set;}
  public int transformLoc {get; set;}
  public Vector3 Color {get; set;} 
  public int colorLoc {get; set;}
  

  public Humans(int posX, int posY, string id, bool status, Matrix4 transform, int transformLoc , Vector3 color, int colorLoc)
    {
       this.posX = posX;
       this.posY = posY;
       this.id = id;
       this.status = status;
       this.Transform = transform;
       this.transformLoc = transformLoc;
       this.Color = color;
       this.colorLoc = colorLoc;
    }

  public int changeColor(List<Humans> humans)
    {

      int[] index = new int[8];
      var countAlives = 0;

      List<string> ids = new List<string>();

      //Left
      index[0] = _filterIndex((posX - 1), (posY -1));
      index[1] = _filterIndex((posX - 1), posY);
      index[2] = _filterIndex((posX - 1), (posY + 1));

      //Top
      index[3] = _filterIndex(posX, (posY - 1));

      //Right
      index[4] = _filterIndex((posX + 1), (posY - 1));
      index[5] = _filterIndex((posX + 1), posY);
      index[6] = _filterIndex((posX + 1), (posY + 1));

      //Bottom
      index[7] = _filterIndex(posX, (posY + 1));

      for(int i = 0; i < index.Count(); i++)
       {
         var position = index[i];
           if (position >= 0 && position < 10000 ) {
             var human = humans[index[i]];
             if (human.status) 
              { 
                countAlives += 1; 
              }
           }
        } return countAlives;
     }

 
  private int _filterIndex(int newPosX, int newPosY)
    {
     if ((newPosX >= 0 && newPosX <= 100) && (newPosY >= 0 && newPosY <= 100))  
      {
        int pY = newPosY * 100;
        int index = pY + newPosX;
        return index;
      } else {
        return -1;
      }
    }
  }
}

