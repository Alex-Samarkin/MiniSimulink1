using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
                textBox.Text += System.Environment.NewLine + s;
            }
        }

        public void WriteMessage(string s, bool clear = false)
        {
            string s1 = $"{this.DateTime} >>> {s}";
            WriteLine(this.MessageTextBox,s1,clear);
        }
        public void WriteDebug(string s, bool clear = false)
        {
            string s1 = $"{this.DateTime} >>> {s}";
            WriteLine(this.DebugTextBox, s1, clear);
        }


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



    }
}
