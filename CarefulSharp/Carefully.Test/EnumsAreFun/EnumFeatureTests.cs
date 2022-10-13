using Carefully.Database;
using Carefully.EnumsAreFun;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carefully.Test.EnumsAreFun
{
    [TestClass]
    public class EnumFeatureTests
    {
        [TestMethod]
        public void FlagsAreFun()
        {
            //Create();
            using var context = new EnumFeature();
            var item = context.GetId(1);
        }

        [TestMethod]
        public void DefaultingIsFun()
        {

        }
        
        [TestMethod]
        public void DatabaseStorageIsTerrifying()
        {

        }
        
        [TestMethod]
        public void SpellingMistakesHappen()
        {

        }
    }
}
