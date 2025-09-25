namespace IShapesClb
{
  public interface IShape
  {
    static abstract string ShapeName { get; }
    Dictionary<string, object> GetShapeCoordinates(string command);

  }
}
