using System;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    public static class TestComposer
    {
        public static ComposedGivens Given(Action firstGiven)
        {
            return new ComposedGivens(firstGiven);
        }
        
        public static ComposedGivens Given(Func<Task> firstGiven)
        {
            return new ComposedGivens(firstGiven);
        }        
    }
}