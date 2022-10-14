namespace Carefully.Dynamics
{
    public class DynamicsAreFun
    {
        // can't declare both at the same time
        //public string Process(object input)
        //{
        //}

        public string Process(dynamic input)
        {
            return "dynamic";
        }

        public string Process(BaseInput input)
        {
            return nameof(BaseInput);
        }

        public string Process(ChildInput input)
        {
            return nameof(ChildInput);
        }

        public string Process(IInput input) 
        { 
            return nameof(IInput);
        }
    }
}
