using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMoq2
{
   public class Program
   {
      public class InputParameters
      {
         public int x, y;
      }

      public interface IService
      {
         bool DoSomething(InputParameters input);
      }

      public class Service : IService
      {
         public bool DoSomething(InputParameters input)
         {
            return input.x > input.y;
         }
      }

      public class Processor
      {
         public IService _service;

         public Processor(IService theServive)
         {
            _service = theServive;
         }

         public void Process()
         {
            InputParameters input = new InputParameters();
            input.x = 5;
            input.y = 50;

            _service.DoSomething(input);

            input.x = 100;

            _service.DoSomething(input);
         }
      }

      static void Main(string[] args)
      {
         Processor processor = new Processor(new Service());
         processor.Process();

         Console.WriteLine("Done!");
      }
   }
}
