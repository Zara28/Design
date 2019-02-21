namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLabelDefaultForm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFormDefaultForm = new System.Windows.Forms.Button();
            this.buttonDefaultForm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonsVisibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дизайнФормыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьДефолтныйДизайнToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ggToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeUniqueBtnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.LabelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PictureBoxContextMenuStrip.SuspendLayout();
            this.FormContextMenuStrip.SuspendLayout();
            this.PanelContextMenuStrip.SuspendLayout();
            this.ButtonContextMenuStrip.SuspendLayout();
            this.LabelContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Кнопка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "Panel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(227, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Null";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "label";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLabelDefaultForm);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.buttonFormDefaultForm);
            this.panel1.Controls.Add(this.buttonDefaultForm);
            this.panel1.Location = new System.Drawing.Point(227, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 272);
            this.panel1.TabIndex = 4;
            // 
            // buttonLabelDefaultForm
            // 
            this.buttonLabelDefaultForm.Location = new System.Drawing.Point(21, 225);
            this.buttonLabelDefaultForm.Name = "buttonLabelDefaultForm";
            this.buttonLabelDefaultForm.Size = new System.Drawing.Size(157, 44);
            this.buttonLabelDefaultForm.TabIndex = 10;
            this.buttonLabelDefaultForm.Text = "Дизайн меток";
            this.buttonLabelDefaultForm.UseVisualStyleBackColor = true;
            this.buttonLabelDefaultForm.Click += new System.EventHandler(this.FormDefaultLabel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "sdfsfsdfsdf";
            // 
            // buttonFormDefaultForm
            // 
            this.buttonFormDefaultForm.Location = new System.Drawing.Point(21, 167);
            this.buttonFormDefaultForm.Name = "buttonFormDefaultForm";
            this.buttonFormDefaultForm.Size = new System.Drawing.Size(157, 47);
            this.buttonFormDefaultForm.TabIndex = 1;
            this.buttonFormDefaultForm.Text = "Дизайн форм";
            this.buttonFormDefaultForm.UseVisualStyleBackColor = true;
            this.buttonFormDefaultForm.Click += new System.EventHandler(this.buttonFormDefaultForm_Click);
            // 
            // buttonDefaultForm
            // 
            this.buttonDefaultForm.Location = new System.Drawing.Point(21, 14);
            this.buttonDefaultForm.Name = "buttonDefaultForm";
            this.buttonDefaultForm.Size = new System.Drawing.Size(162, 94);
            this.buttonDefaultForm.TabIndex = 0;
            this.buttonDefaultForm.Text = "Дизайн кнопок";
            this.buttonDefaultForm.UseVisualStyleBackColor = true;
            this.buttonDefaultForm.Click += new System.EventHandler(this.buttonDefaultForm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 249);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(163, 114);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Location = new System.Drawing.Point(0, 57);
            this.button9.Margin = new System.Windows.Forms.Padding(0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(81, 57);
            this.button9.TabIndex = 4;
            this.button9.Text = "Фигня";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(83, 59);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 53);
            this.button7.TabIndex = 2;
            this.button7.Text = "SQLPanel";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 75);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "тест json 123";
            // 
            // PictureBoxContextMenuStrip
            // 
            this.PictureBoxContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PictureBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.PictureBoxContextMenuStrip.Name = "PictureBoxContextMenuStrip";
            this.PictureBoxContextMenuStrip.Size = new System.Drawing.Size(133, 26);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // FormContextMenuStrip
            // 
            this.FormContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FormContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonsVisibilityToolStripMenuItem,
            this.дизайнФормыToolStripMenuItem,
            this.сохранитьДефолтныйДизайнToolStripMenuItem});
            this.FormContextMenuStrip.Name = "visibilityContextMenuStrip";
            this.FormContextMenuStrip.Size = new System.Drawing.Size(240, 70);
            // 
            // buttonsVisibilityToolStripMenuItem
            // 
            this.buttonsVisibilityToolStripMenuItem.Name = "buttonsVisibilityToolStripMenuItem";
            this.buttonsVisibilityToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.buttonsVisibilityToolStripMenuItem.Text = "Видимость кнопок";
            this.buttonsVisibilityToolStripMenuItem.Click += new System.EventHandler(this.buttonsVisibilityToolStripMenuItem_Click);
            // 
            // дизайнФормыToolStripMenuItem
            // 
            this.дизайнФормыToolStripMenuItem.Name = "дизайнФормыToolStripMenuItem";
            this.дизайнФормыToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.дизайнФормыToolStripMenuItem.Text = "Дизайн формы";
            this.дизайнФормыToolStripMenuItem.Click += new System.EventHandler(this.дизайнФормыToolStripMenuItem_Click);
            // 
            // сохранитьДефолтныйДизайнToolStripMenuItem
            // 
            this.сохранитьДефолтныйДизайнToolStripMenuItem.Name = "сохранитьДефолтныйДизайнToolStripMenuItem";
            this.сохранитьДефолтныйДизайнToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.сохранитьДефолтныйДизайнToolStripMenuItem.Text = "Сохранить дефолтный дизайн";
            this.сохранитьДефолтныйДизайнToolStripMenuItem.Click += new System.EventHandler(this.сохранитьДефолтныйДизайнToolStripMenuItem_Click);
            // 
            // PanelContextMenuStrip
            // 
            this.PanelContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PanelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ggToolStripMenuItem});
            this.PanelContextMenuStrip.Name = "PanelContextMenuStrip";
            this.PanelContextMenuStrip.Size = new System.Drawing.Size(158, 26);
            // 
            // ggToolStripMenuItem
            // 
            this.ggToolStripMenuItem.Name = "ggToolStripMenuItem";
            this.ggToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ggToolStripMenuItem.Text = "Дизайн панели";
            this.ggToolStripMenuItem.Click += new System.EventHandler(this.ggToolStripMenuItem_Click);
            // 
            // ButtonContextMenuStrip
            // 
            this.ButtonContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ButtonContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUniqueBtnMenuItem});
            this.ButtonContextMenuStrip.Name = "ButtonContextMenuStrip";
            this.ButtonContextMenuStrip.Size = new System.Drawing.Size(171, 26);
            // 
            // changeUniqueBtnMenuItem
            // 
            this.changeUniqueBtnMenuItem.Name = "changeUniqueBtnMenuItem";
            this.changeUniqueBtnMenuItem.Size = new System.Drawing.Size(170, 22);
            this.changeUniqueBtnMenuItem.Text = "Изменить кнопку";
            this.changeUniqueBtnMenuItem.Click += new System.EventHandler(this.changeUniqueBtnMenuItem_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(327, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(352, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // LabelContextMenuStrip
            // 
            this.LabelContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LabelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLabelToolStripMenuItem});
            this.LabelContextMenuStrip.Name = "LabelContextMenuStrip";
            this.LabelContextMenuStrip.Size = new System.Drawing.Size(129, 26);
            // 
            // changeLabelToolStripMenuItem
            // 
            this.changeLabelToolStripMenuItem.Name = "changeLabelToolStripMenuItem";
            this.changeLabelToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.changeLabelToolStripMenuItem.Text = "Изменить";
            this.changeLabelToolStripMenuItem.Click += new System.EventHandler(this.changeLabelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 366);
            this.ContextMenuStrip = this.FormContextMenuStrip;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PictureBoxContextMenuStrip.ResumeLayout(false);
            this.FormContextMenuStrip.ResumeLayout(false);
            this.PanelContextMenuStrip.ResumeLayout(false);
            this.ButtonContextMenuStrip.ResumeLayout(false);
            this.LabelContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFormDefaultForm;
        private System.Windows.Forms.Button buttonDefaultForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip PictureBoxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FormContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem buttonsVisibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дизайнФормыToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PanelContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ggToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ButtonContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeUniqueBtnMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьДефолтныйДизайнToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip LabelContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeLabelToolStripMenuItem;
        private System.Windows.Forms.Button buttonLabelDefaultForm;
    }
}

