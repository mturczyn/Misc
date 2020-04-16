using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForVba
{
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDual)]
  public class SquareEquation
  {
    [ComVisible(true)]
    public double A { get; set; }
    [ComVisible(true)]
    public double B { get; set; }
    [ComVisible(true)]
    public double C { get; set; }

    [ComVisible(true)]
    public void SetSquareEquationParameters(double a, double b, double c) =>
      (A, B, C) = (a, b, c);

    [ComVisible(true)]
    public SquareEquationRoots SolveEquation()
    {
      var delta = Math.Pow(B, 2) - 4 * A * C;
      if (delta < 0)
        return new SquareEquationRoots();
      else if (delta == 0)
        return new SquareEquationRoots() { X1 = -B / (2 * A) };
      else
        return new SquareEquationRoots()
        {
          X1 = (-B - Math.Sqrt(delta)) / (2 * A),
          X2 = (-B + Math.Sqrt(delta)) / (2 * A),
        };
    }
  }

  [ClassInterface(ClassInterfaceType.AutoDual)]
  [ComVisible(true)]
  public class SquareEquationRoots
  {
    // Jest to obejscie braku typów Nullable w COMie.
    [ComVisible(true)]
    [MarshalAs(UnmanagedType.Struct)]
    public object X1;
    [ComVisible(true)]
    [MarshalAs(UnmanagedType.Struct)]
    public object X2;
  }
}
