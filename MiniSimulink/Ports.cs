using System.Collections.Generic;
using System.ComponentModel;

namespace MiniSimulink
{
    public class Ports : Component
    {
        [DisplayName("Порты")]
        [Description("Точки входа/выхода а также значения параметров блока")]
        public List<Port> ItemsList { get; set; } = new List<Port>();

        public Port this [int index]
        {
            get => ItemsList[index];
            set => ItemsList[index] = value;
        }
    }
}
