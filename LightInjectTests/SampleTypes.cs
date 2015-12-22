using System;

namespace LightInjectTests
{
    public class SampleClass : ISampleInterface
    {
        private string _value3 = string.Empty;
        public string Value1 { get; }
        public int Value2 { get; private set; }

        public void AdjustValue2()
        {
            Value2 += Value1.Length + Value3.Length;
        }

        public SampleClass(string value1, int value2)
        {
            if (value1 == null) throw new ArgumentNullException(nameof(value1));

            Value1 = value1;
            Value2 = value2;
        }

        public string Value3
        {
            get { return _value3; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));

                _value3 = value;
            }
        }
    }

    public interface ISampleInterface
    {
        string Value1 { get; }
        int Value2 { get; }

        void AdjustValue2();
    }
}
