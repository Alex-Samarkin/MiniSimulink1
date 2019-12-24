using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSimulink
{
    public partial class BlockControl : UserControl
    {
        public BlockControl()
        {
            InitializeComponent();
            BlockName = _BlockName;
        }
        protected string _BlockName = "Block";
        public string BlockName
        {
            get => _BlockName; set
            {
                _BlockName = value;
                this.groupBox1.Text = _BlockName;
            }
        }
        public Ports Input { get; set; } = new Ports();
        public Ports Output { get; set; } = new Ports();
        public Ports Parameters { get; set; } = new Ports();

        public virtual void TFcn()
        {
            /// функция преобразования Input - вход
            /// Output - выход
            /// Parameters - константы
            /// CurrentTime - текущее время, если требуетсяя работа в абсолютном значении
            /// Step - шаг по времени
            /// используются только параметры блока - значения портов
        }

        public double CurrentTime { get; set; } = 0;
        public double Step { get; set; } = 0.01;

        [Category("Идентификаторы блока")]
        [DisplayName("Номер блока")]
        [Description("Номер блока в списке блоков. Нумеруется менеджером модели при вставке блока. Гарантируется, что при вставке позлние блоки получают большие номера")]
        public int Id { get; set; } = 0;

        [Category("Идентификаторы блока")]
        [DisplayName("Приоритет блока")]
        [Description("Приоритет определяет порядок расчета и определяется типом блока. Меньший приоритет рассчитывается раньше. Приоритет определяется преимущественно типом блока. Например, константы с приоритетом 100 будут вычислены раньше, чем блок усиления с приоритетом 1000.")]
        public int Priority { get; set; } = 1000;




        #region MoveBlockWithMouse

        //точка перемещения
        Point DownPoint;
        //нажата ли кнопка мыши
        bool IsDragMode = false;

        private Point MouseDownLocation;

        private void BlockControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void BlockControl_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void BlockControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left = e.X + Left - MouseDownLocation.X;
                Top = e.Y + Top - MouseDownLocation.Y;
            }
        }

        #endregion



        private void BlockControl_Paint(object sender, PaintEventArgs e)
        {
            this.groupBox1.Text = $"{BlockName} (Id{Id}/Prior{Priority})";
            this.inputPorts.Text = $"in {Input.ItemsList.Count} >";
            this.outputPorts.Text = $"out {Output.ItemsList.Count} >";
        }

        private void BlockControl_DoubleClick(object sender, EventArgs e)
        {
            BlockForm blockForm = new BlockForm();
            blockForm.Setup(this);
            blockForm.Show();
        }


    }
}
