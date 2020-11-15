using System;

namespace ConsoleApp1
{
    public static class CovariantOverrides
    {
        public static void CovariantOverridesInAction()
        {
            Animal animal = new Lion();
            Console.WriteLine("Hello World! Animal food tastes " + animal.GetFood().Taste());
            // Should print "Hello world! Animal food tastes meaty"
        }

        #region Classes for exhibition
        public abstract class Food { public abstract string Taste(); }
        public class Meat : Food { public override string Taste() => "meaty"; }

        public abstract class Animal
        {
            public abstract Food GetFood();
        }
        public class Lion : Animal
        {
            public override Meat GetFood() => new Meat();
        }
        #endregion
    }
}
