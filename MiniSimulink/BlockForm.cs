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
    public partial class BlockForm : Form
    {
        public BlockForm()
        {
            InitializeComponent();
        }

        [DisplayName("Блок для отображения на форме")]
        [Description("")]
        public BlockControl Block { get; set; }

        /// <summary>
        /// форма создается
        /// далее ей через настоящую функцию присваивается блок
        /// </summary>
        /// <param name="blockControl">блок, которым управляет форма</param>
        public void Setup(BlockControl blockControl)
        {
            Block = blockControl;
            this.Text = $"{Block.BlockName} Id {Block.Id}/ Prior {Block.Priority} t={Block.CurrentTime} step={Block.Step}";

            this.propertyGrid1.SelectedObject = Block;
            this.propertyGrid2.SelectedObject = Block.Input;
            this.propertyGrid3.SelectedObject = Block.Parameters;
            this.propertyGrid4.SelectedObject = Block.Output;

        }

        private void BlockForm_Load(object sender, EventArgs e)
        {

        }

        private void отменитьИзмененияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Block.Invalidate();
            this.Close();
        }
    }
}
