using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carefully.EnumsAreFun
{
    public enum PetsTypes
    {
        None,
        Cat,
        Dog,
        Hamster,
        Child
    }

    [Flags]
    public enum AbstractionTypes
    {
        None,
        Sit,
        Stand,
        LeanOn,
    }

    public class EnumPayload
    {
        public int Id { get; set; }
        public AbstractionTypes AbstractionTypes { get; set; }
        public PetsTypes PetsTypes { get; set; }
    }
}
