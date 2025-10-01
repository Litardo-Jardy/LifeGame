using OpenTK.Mathematics;

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

  public int[] changeColor(List<Humans> humans)
  {
   var countDeads = 0;
   var countAlives = 0;

   List<string> ids = new List<string>();

   //Left
   ids.Add((posX - 1).ToString() + (posY - 1).ToString());
   ids.Add((posX - 1).ToString() + posY.ToString());
   ids.Add((posX - 1).ToString() + (posY + 1).ToString());

   //Top
   ids.Add((posX - 1).ToString() + (posY - 1).ToString());
   ids.Add(posX.ToString() + (posY - 1).ToString());
   ids.Add((posX + 1).ToString() + (posY - 1).ToString());

   //Right
   ids.Add((posX + 1).ToString() + (posY - 1).ToString());
   ids.Add((posX + 1).ToString() + posY.ToString());
   ids.Add((posX + 1).ToString() + (posY + 1).ToString());

   //Bottom
   ids.Add((posX - 1).ToString() + (posY + 1).ToString());
   ids.Add(posX.ToString() + (posY + 1).ToString());
   ids.Add((posX + 1).ToString() + (posY + 1).ToString());


   foreach(var human in humans)
   {
     if (ids.Count == 0)
     {
       break;
     }
     for(int i = 0; i < ids.Count; i++)
     {
       if (human.id == ids[i])
       {
          if (human.status) 
	  {
           countAlives += 1; 
	  }else {
           countDeads += 1;}
	  ids.Remove(ids[i]);
	  break;
       }

     }
   }

   return [countDeads, countAlives];

  }

}

