using Carefully.EnumsAreFun;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Carefully.Test.EnumsAreFun
{
    [TestClass]
    public class EnumFeatureTests
    {
        [TestMethod]
        public void FlagsAreFun()
        {
            using var context = new EnumFeature();
            var item = context.GetId(1);
        }

        [TestMethod]
        public void SeriliserToInteger()
        {
            var vanilla = new EnumPayload();
            var json = System.Text.Json.JsonSerializer.Serialize(vanilla);

            json.Should().Contain(nameof(EnumPayload.AbstractionTypes));
            json.Should().Contain(nameof(EnumPayload.PetsTypes));

            var flagsSet = new EnumPayload() { AbstractionTypes = AbstractionTypes.LeanOn | AbstractionTypes.Sit | AbstractionTypes.Stand };
            var json2 = System.Text.Json.JsonSerializer.Serialize(flagsSet);
            json2.Should().Contain(nameof(EnumPayload.AbstractionTypes));
            json2.Should().Contain("14"); // 2 + 4 + 8 = 14, from the flags
        }

        [TestMethod]
        public void SeriliserToStringStorage()
        {
            var flagsSet = new EnumPayload() 
            { 
                AbstractionTypes = AbstractionTypes.LeanOn | AbstractionTypes.Sit | AbstractionTypes.Stand 
            };
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());

            var json = JsonSerializer.Serialize(flagsSet, options);
            json.Should().Contain(nameof(EnumPayload.AbstractionTypes));
            json.Should().Contain(AbstractionTypes.LeanOn.ToString());
            json.Should().Contain(AbstractionTypes.Sit.ToString());
            json.Should().Contain(AbstractionTypes.Stand.ToString());
        }
        
        [TestMethod]
        public void SpellingMistakesHappen()
        {
            
        }
    }
}
