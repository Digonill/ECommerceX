namespace Ecx.Infra.CrossCutting.IoC
{
    public interface IConstrutorParameter
    {
        string Name { get; set; }
        object Value { get; set; }
    }
    public class ConstrutorParameter : IConstrutorParameter
    {
        public ConstrutorParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
