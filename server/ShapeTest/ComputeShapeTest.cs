using IShapesClb;
using ShapesClb;

namespace ShapeTest
{
  public class ComputeShapeTests
  {
    private IComputeShape ComputeShape;
    [SetUp]
    public void Setup()
    {
      ComputeShape = new ComputeShape();
    }

    [Test]
    public void TestValidCircle()
    {
      Dictionary<string, object> result = Helpers.GetObject<Dictionary<string, object>>(ComputeShape.GetShapeCoordinates("draw a circle with a radius of 50"));
      Assert.That(result["valid"], Is.EqualTo(true));
      Assert.That(result["radius"], Is.EqualTo(50));

    }
    [Test]
    public void TestInValidCircle()
    {
      Dictionary<string, object> result = Helpers.GetObject<Dictionary<string, object>>(ComputeShape.GetShapeCoordinates("draw a circle with a radius"));
      Assert.That(result["valid"], Is.EqualTo(false));

    }
    [Test]
    public void TestValidPolygon()
    {
      Dictionary<string, object> result = Helpers.GetObject<Dictionary<string, object>>(ComputeShape.GetShapeCoordinates("draw a polygon with 10 sides and side length of 20"));
      Assert.That(result["valid"], Is.EqualTo(true));

    }
    [Test]
    public void TestInValidPolygon()
    {
      Dictionary<string, object> result = Helpers.GetObject<Dictionary<string, object>>(ComputeShape.GetShapeCoordinates("draw a polygon with 10 sides and side length of"));
      Assert.That(result["valid"], Is.EqualTo(false));

    }
  }
}
