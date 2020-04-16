using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0NewFeatures
{
  public static class PatternMatchingAndTupleAssignment
  {
    static void Demo()
    {
      var points = new TestPoint[]
      {
        new TestPoint(0.5, 0.5),
        new TestPoint(-1, 0.5),
        new TestPoint(2, 0.5),
        new TestPoint(0.5, -1),
        new TestPoint(0.5, 2),
      };
      foreach (var point in points)
        Console.WriteLine(point.GetRegion());
      Console.ReadKey();
    }
  }

  public class TestPoint
  {
    public double X { get; set; }
    public double Y { get; set; }

    #region Tuple assignments
    public TestPoint(double x, double y) => (X, Y) = (x, y);

    public void SwapCords() => (X, Y) = (Y, X);
    #endregion

    public enum PlaneRegion
    {
      UnitSquare, // From (0, 0) to (1, 1)
      AboveUnitSquare,
      ToRightOfUnitSquare,
      Rest,
    }

    public PlaneRegion GetRegion()
    {
      return (X >= 0, X <= 1, Y >= 0, Y <= 1) switch
      {
        (true, true, true, true) => PlaneRegion.UnitSquare,
        (true, false, true, true) => PlaneRegion.AboveUnitSquare,
        (true, true, true, false) => PlaneRegion.ToRightOfUnitSquare,
        (_, _, _, _) => PlaneRegion.Rest,
      };
    }
  }
}
