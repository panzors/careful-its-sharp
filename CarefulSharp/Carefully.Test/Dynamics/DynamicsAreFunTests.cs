using Carefully.Dynamics;
using FluentAssertions;
using System.Dynamic;

namespace Carefully.Test.Dynamics
{
    [TestClass]
    public class DynamicsAreFunTests
    {
        [TestMethod]
        public void StraightForwardCalls()
        {
            var sut = new DynamicsAreFun();

            var baseInput = new BaseInput(); // extends IInput
            sut.Process(baseInput)
                .Should().Be(nameof(BaseInput));

            var child = new ChildInput(); // extends BaseInput
            sut.Process(child)
                .Should().Be(nameof(ChildInput)); 

            var otherInput = new OtherInput(); // extends IInput
            sut.Process(otherInput)
                .Should().Be(nameof(IInput));

            var dynamicInput = new ExpandoObject();
            sut.Process(dynamicInput)
                .Should().Be("dynamic");

            sut.Process(1)
                .Should().Be("dynamic");
        }

        [TestMethod]
        public void UndeclaredTypeFallsBackToConcreteDefinition()
        {
            var sut = new DynamicsAreFun();

            var undeclared = new UndeclaredInput();
            sut.Process(undeclared)
                .Should().Be(nameof(BaseInput)); // Should be the BaseInput? or IInput?
        }

        [TestMethod]
        public void ExplicitCastingTreatsItAsExplicitType()
        {
            var sut = new DynamicsAreFun();

            

            var undeclared = new UndeclaredInput();
            sut.Process((IInput)undeclared)
                .Should().Be(nameof(IInput));

            BaseInput childAsBase = new ChildInput();
            sut.Process(childAsBase)
                .Should().Be(nameof(BaseInput));

            IInput childAsInterface = new ChildInput();
            sut.Process(childAsInterface)
                .Should().Be(nameof(IInput));
        }

        [TestMethod]
        public void NullsGoToAWeirdPlace()
        {
            var sut = new DynamicsAreFun();
            sut.Process(null)
                .Should().Be(nameof(ChildInput));
            // should this not go to dynamic instead?

        }

        /// This is some weird beahviour. 
        /// For some reason processing a dynamic leads to contamination
        /// sut.Process((dynamic)child).Should().Be(nameof(ChildInput));
        [TestMethod]
        public void ThisIsWeird_WhyDoesThisNotWork()
        {
            var sut = new DynamicsAreFun();
            dynamic allocated = new ChildInput();
            var result = sut.Process(allocated);
            
            // Here
            ((string)result).Should().Be(nameof(ChildInput));

            var child = new ChildInput();
            var result2 = sut.Process((dynamic)child);
            
            // Here
            ((string)result2).Should().Be(nameof(ChildInput));
        }

    }
}
