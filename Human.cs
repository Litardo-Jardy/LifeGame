using OpenTK.Mathematics;

class Humans
{
  public int posX {get; set;}
  public int posY {get; set;}
  public string id {get; set;}
  public Boolean status {get; set;}
  public Matrix4 Transform {get; set;}
  public Vector3 Color {get; set;} 
  public int colorLoc {get; set;}
  

  public Humans(int posX, int posY, string id, bool status, Matrix4 transform, Vector3 color, int colorLoc)
    {
        this.posX = posX;
        this.posY = posY;
        this.id = id;
        this.status = status;
        this.Transform = transform;
        this.Color = color;
        this.colorLoc = colorLoc;
    }

}

