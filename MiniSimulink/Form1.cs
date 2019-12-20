using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniSimulink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ModelManager.MessageTextBox = messageTextBox;
            ModelManager.DebugTextBox = debugTextBox;

            ModelManager.ModelPropertyGrid = modelPropertyGrid;
            ModelManager.SetupModelPropertyGrid();

            ModelManager.BlockPropertyGrid = blockPropertyGrid;

            ModelManager.GroupBox = modelGroupBox;
            ModelManager.SetupGroupBox();

            ModelManager.WriteMessage("Начало работы",true);
            ModelManager.WriteDebug("Начало отладки", true);

            
            ModelManager.WriteDebug(p.FullFormattedValue);
            ModelManager.BlockPropertyGrid.SelectedObject = p;
            ModelManager.WriteDebug("редактор на отдельный порт");

            ports.Add(new Port());
            ports.Add(new Port());
            ports.Add(new Port());
            ports.Add(new Port());

            Ports.ItemsList = ports;

            ModelManager.BlockPropertyGrid.SelectedObject = Ports;
            ModelManager.WriteDebug("редактор на массив портов");

        }

        public ModelManager ModelManager { get; set; } = new ModelManager();
        public Port p = new Port();
        private List<Port> ports = new List<Port>();
        public Ports Ports = new Ports();
        
     }
}
