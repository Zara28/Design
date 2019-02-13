namespace WindowsFormsApplication1
{
    partial class FormUniqueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonFont = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.fo = new System.Windows.Forms.FontDialog();
            this.cl = new System.Windows.Forms.ColorDialog();
            this.minimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(16, 15);
            this.buttonFont.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(100, 47);
            this.buttonFont.TabIndex = 0;
            this.buttonFont.Text = "Шрифт менять";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(440, 15);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(100, 47);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.Text = "Цвет фона менять";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(231, 16);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 46);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Выбор сохранять";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // minimizeCheckBox
            // 
            this.minimizeCheckBox.AutoSize = true;
            this.minimizeCheckBox.Location = new System.Drawing.Point(16, 69);
            this.minimizeCheckBox.Name = "minimizeCheckBox";
            this.minimizeCheckBox.Size = new System.Drawing.Size(201, 21);
            this.minimizeCheckBox.TabIndex = 3;
            this.minimizeCheckBox.Text = "Кнопку \"скрыть\" показать";
            this.minimizeCheckBox.UseVisualStyleBackColor = true;
            this.minimizeCheckBox.CheckedChanged += new System.EventHandler(this.minimizeCheckBox_CheckedChanged);
            // 
            // FormUniqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Menyat;
            this.ClientSize = new System.Drawing.Size(555, 368);
            this.Controls.Add(this.minimizeCheckBox);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonFont);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(573, 415);
            this.MinimumSize = new System.Drawing.Size(573, 415);
            this.Name = "FormUniqueForm";
            this.Load += new System.EventHandler(this.FormThisDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.FontDialog fo;
        private System.Windows.Forms.ColorDialog cl;
        private System.Windows.Forms.CheckBox minimizeCheckBox;
    }
}