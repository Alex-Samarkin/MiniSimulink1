using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSimulink
{
    public partial class Port : Component
    {
        public Port()
        {
            InitializeComponent();
        }

        public Port(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [DisplayName("Название порта")]
        [Description("")]
        public string PortName { get; set; } = "Port1";

        [DisplayName("Описание порта")]
        [Description("")]
        public string PortDescription { get; set; } = "Без описания";

        private double _value = 0;
        [DisplayName("Состояние порта")]
        [Description("")]
        public double Value {
            get => _value;
            set
            {
                if (Math.Abs(OldValue - value) > .1e-15)
                {
                    OldValue = _value;
                    _value = value;
                }
            }
        }
        [DisplayName("Предыдущее состояние порта")]
        [Description("Значение порта до операции Set свойства Value, при условии что Value реально изменилось")]
        public double OldValue { get; set; } = 0;

        public double RestorePort()
        {
            double d = Value;
            Value = OldValue;
            return d;
        }

        [DisplayName("Единицы измерения")]
        [Description("Справочно, не влияет на вычисления")]
        public string Measure { get; set; } = "None";

        [DisplayName("Масштаб")]
        [Description("Используется в Scaled - для выдачи с умножением на коэффициент и Unscaled - для выдачи с делением на коэффициент")]
        public double Scale { get; set; } = 1;

        public double Scaled => Value * Scale;
        public double UnScaled => Value / Scale;

        public string FormattedValue => $"{PortName}/{PortDescription} >>> {Value} [{Measure}]";
        public string FullFormattedValue => $"{PortName}/{PortDescription}: {Value} [{Measure}] Scale: {Scale} Scaled: {Scaled}";
    }
}
