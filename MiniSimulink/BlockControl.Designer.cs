namespace MiniSimulink
{
    partial class BlockControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputPorts = new System.Windows.Forms.Label();
            this.inputPorts = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outputPorts);
            this.groupBox1.Controls.Add(this.inputPorts);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // outputPorts
            // 
            this.outputPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPorts.AutoSize = true;
            this.outputPorts.Location = new System.Drawing.Point(146, 65);
            this.outputPorts.Name = "outputPorts";
            this.outputPorts.Size = new System.Drawing.Size(28, 13);
            this.outputPorts.TabIndex = 1;
            this.outputPorts.Text = "out>";
            this.outputPorts.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // inputPorts
            // 
            this.inputPorts.AutoSize = true;
            this.inputPorts.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPorts.Location = new System.Drawing.Point(3, 16);
            this.inputPorts.Name = "inputPorts";
            this.inputPorts.Size = new System.Drawing.Size(21, 13);
            this.inputPorts.TabIndex = 0;
            this.inputPorts.Text = "in>";
            // 
            // BlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(24, 24);
            this.Name = "BlockControl";
            this.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Size = new System.Drawing.Size(190, 93);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BlockControl_Paint);
            this.DoubleClick += new System.EventHandler(this.BlockControl_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlockControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlockControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BlockControl_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label outputPorts;
        private System.Windows.Forms.Label inputPorts;
    }
}
