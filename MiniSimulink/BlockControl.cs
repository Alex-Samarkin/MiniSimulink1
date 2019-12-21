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
            /// используются только параметры блока
        }

        public double CurrentTime { get; set; } = 0;
        public double Step { get; set; } = 0.01;

        //точка перемещения
        Point DownPoint;
        //нажата ли кнопка мыши
        bool IsDragMode = false;

        private Point MouseDownLocation;

        private void BlockControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void BlockControl_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void BlockControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Left = e.X + Left - MouseDownLocation.X;
                Top = e.Y + Top - MouseDownLocation.Y;
            }
        }
    }
}
