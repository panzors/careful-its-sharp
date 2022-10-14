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
        None = 0, // bin 0000 = 0
        Sit = 1 << 1, // bin 0010 = 2
        Stand = 1 << 2, // bin 0100 = 4
        LeanOn = 1 << 3, // bin 1000 = 8
    }

    [Flags]
    public enum BrokenFlagTypes
    {
        None,
        Type1,
        Type2,
        Type3
    }

    public enum SpellingMistakes
    {
        Paid,
        Void,
        Cancelled,
        Canceled,
    }

    public class EnumPayload
    {
        public int Id { get; set; }
        public AbstractionTypes AbstractionTypes { get; set; }
        public PetsTypes PetsTypes { get; set; }
    }
}
