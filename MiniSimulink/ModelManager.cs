using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSimulink
{
    /// <summary>
    /// менеджер блоков модели
    /// </summary>
    public partial class ModelManager : Component
    {
        public ModelManager()
        {
            InitializeComponent();
        }

        public ModelManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        #region ModelManagerInputOutput

        [DisplayName("Название модели")] [Description("Заголовок модели для отображения")] public string ModelName { get; set; } = "NewModel";

        [DisplayName("Для вывода сообщений")]
        [Description("Компонент TextBox (Multiline=true) для вывода сообщений пользователю")]
        public TextBox MessageTextBox { get; set; }

        [DisplayName("Для вывода отладочной информации")]
        [Description("Компонент TextBox (Multiline=true) для вывода отладочной информации пользователю")]
        public TextBox DebugTextBox { get; set; }

        public void WriteLine(TextBox textBox, string s, bool clear = false)
        {
            if (clear)
            {
                textBox.Clear();
            }
            if (textBox != null)
            {
                textBox.Text += Environment.NewLine + s;
            }
        }

        public void WriteMessage(string s, bool clear = false)
        {
            string s1 = $"{this.DateTime} >>> {s}";
            WriteLine(this.MessageTextBox, s1, clear);
        }
        public void WriteDebug(string s, bool clear = false)
        {
            string s1 = $"{this.DateTime} >>> {s}";
            WriteLine(this.DebugTextBox, s1, clear);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region ModelManagerPropertys

        [DisplayName("Свойства модели")]
        [Description("Сетка свойств модели")]
        public PropertyGrid ModelPropertyGrid { get; set; }

        public void SetupModelPropertyGrid()
        {
            this.ModelPropertyGrid.SelectedObject = this;
        }



        [DisplayName("Свойства компонента")]
        [Description("Сетка свойств выбранного компонента")]
        public PropertyGrid BlockPropertyGrid { get; set; }

        public void SetupBlockPropertyGrid()
        {
            //this.BlockPropertyGrid.SelectedObject = this;
            throw new NotImplementedException("Присвоить свойство выбранный объект текущему блоку в блок-схеме");
        }

        public DateTime DateTime => DateTime.Now;

        [DisplayName("Время начала моделирования")]
        [Description("")]
        public double StartTime { get; set; } = 0.0;

        [DisplayName("Время завершения моделирования")]
        [Description("")]
        public double EndTime { get; set; } = 10.0;

        [DisplayName("Шаг интегрирования по времемени")]
        [Description("")]
        public double StepTime { get; set; } = 0.01;

        [DisplayName("панель для отображения графики")]
        [Description("")]
        public GroupBox GroupBox { get; set; }

        public void SetupGroupBox()
        {
            if (this.GroupBox != null)
            {
                GroupBox.Text = ModelName;
            }
        }

        #endregion

        [DisplayName("Список блоков")]
        [Description("Блоки по мере их поступления")]
        public List<BlockControl> BlockControls { get; set; } = new List<BlockControl>();

        public void AppendBlock(BlockControl bc)
        {
            if (BlockControls.Count == 0)
            {
                bc.Id = 0;
            }
            else
            {
                bc.Id = BlockControls[BlockControls.Count - 1].Id + 1;
            }
            BlockControls.Add(bc);
        }

        public void PlaceBlock(BlockControl bc)
        {
            if (this.GroupBox != null)
            {
                int x = this.GroupBox.Width;
                int y = this.GroupBox.Height;

                bc.Location = new Point(x / 2, y / 2);
                this.GroupBox.Controls.Add(bc);
            }
        }

        public void JitterBlock(BlockControl bc,int jitter = 20)
        {
            Random rnd = new Random();

            int dx = rnd.Next(jitter / 2, jitter * 2);
            int dy = rnd.Next(jitter / 2, jitter * 2);

            bc.Location = new Point(bc.Location.X + dx,bc.Location.Y+dy);
            bc.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        public void AppendAndPlaceBlock(BlockControl bc)
        {
            AppendBlock(bc);
            PlaceBlock(bc);
            JitterBlock(bc);
        }

    }
}
