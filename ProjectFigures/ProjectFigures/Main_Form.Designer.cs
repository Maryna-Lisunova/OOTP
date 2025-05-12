namespace Lab1_Figures
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cb_figyres = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btn_save = new Button();
            label3 = new Label();
            btn_cancel = new Button();
            btn_clear = new Button();
            panel1 = new Panel();
            label4 = new Label();
            trackBar_pen = new TrackBar();
            trackBar_corners = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            btn_pencolor = new Button();
            btn_backcolor = new Button();
            btn_redo = new Button();
            btn_desirialize = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_pen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_corners).BeginInit();
            SuspendLayout();
            // 
            // cb_figyres
            // 
            cb_figyres.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_figyres.FormattingEnabled = true;
            cb_figyres.Location = new Point(758, 245);
            cb_figyres.Name = "cb_figyres";
            cb_figyres.Size = new Size(253, 28);
            cb_figyres.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(758, 222);
            label1.Name = "label1";
            label1.Size = new Size(253, 20);
            label1.TabIndex = 1;
            label1.Text = "Выберите фигуру:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(758, 276);
            label2.Name = "label2";
            label2.Size = new Size(253, 20);
            label2.TabIndex = 2;
            label2.Text = "Количество углов";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
            btn_save.Font = new Font("Segoe UI", 9F);
            btn_save.Location = new Point(900, 452);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(111, 41);
            btn_save.TabIndex = 4;
            btn_save.Text = "Сохранить";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(758, 296);
            label3.Name = "label3";
            label3.Size = new Size(253, 20);
            label3.TabIndex = 6;
            label3.Text = "(для многоугольника)";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(900, 499);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(111, 43);
            btn_cancel.TabIndex = 7;
            btn_cancel.Text = "Отменить";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(758, 548);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(253, 43);
            btn_clear.TabIndex = 8;
            btn_clear.Text = "Очистить";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(trackBar_pen);
            panel1.Location = new Point(758, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(253, 89);
            panel1.TabIndex = 10;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(253, 30);
            label4.TabIndex = 1;
            label4.Text = "Толщина пера";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBar_pen
            // 
            trackBar_pen.Dock = DockStyle.Bottom;
            trackBar_pen.Location = new Point(0, 33);
            trackBar_pen.Minimum = 1;
            trackBar_pen.Name = "trackBar_pen";
            trackBar_pen.Size = new Size(253, 56);
            trackBar_pen.TabIndex = 0;
            trackBar_pen.Value = 1;
            // 
            // trackBar_corners
            // 
            trackBar_corners.Location = new Point(758, 319);
            trackBar_corners.Name = "trackBar_corners";
            trackBar_corners.Size = new Size(253, 56);
            trackBar_corners.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(888, 9);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 13;
            label6.Text = "Цвет заливки";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(776, 9);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 14;
            label7.Text = "Цвет пера";
            // 
            // btn_pencolor
            // 
            btn_pencolor.Location = new Point(776, 32);
            btn_pencolor.Name = "btn_pencolor";
            btn_pencolor.Size = new Size(80, 80);
            btn_pencolor.TabIndex = 15;
            btn_pencolor.UseVisualStyleBackColor = true;
            btn_pencolor.Click += btn_pencolor_Click;
            // 
            // btn_backcolor
            // 
            btn_backcolor.Location = new Point(900, 32);
            btn_backcolor.Name = "btn_backcolor";
            btn_backcolor.Size = new Size(80, 80);
            btn_backcolor.TabIndex = 16;
            btn_backcolor.UseVisualStyleBackColor = true;
            btn_backcolor.Click += btn_backcolor_Click;
            // 
            // btn_redo
            // 
            btn_redo.Location = new Point(758, 499);
            btn_redo.Name = "btn_redo";
            btn_redo.Size = new Size(124, 43);
            btn_redo.TabIndex = 18;
            btn_redo.Text = "Восстановить";
            btn_redo.UseVisualStyleBackColor = true;
            btn_redo.Click += btn_redo_Click;
            // 
            // btn_desirialize
            // 
            btn_desirialize.Location = new Point(758, 452);
            btn_desirialize.Name = "btn_desirialize";
            btn_desirialize.Size = new Size(124, 41);
            btn_desirialize.TabIndex = 19;
            btn_desirialize.Text = "Загрузить";
            btn_desirialize.UseVisualStyleBackColor = true;
            btn_desirialize.Click += btn_desirialize_Click;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 603);
            Controls.Add(btn_desirialize);
            Controls.Add(btn_redo);
            Controls.Add(btn_backcolor);
            Controls.Add(btn_pencolor);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(trackBar_corners);
            Controls.Add(panel1);
            Controls.Add(btn_clear);
            Controls.Add(btn_cancel);
            Controls.Add(label3);
            Controls.Add(btn_save);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_figyres);
            Name = "Main_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пэинт";
            Paint += Main_Form_Paint;
            MouseClick += Main_Form_MouseClick;
            MouseDoubleClick += Main_Form_MouseDoubleClick;
            MouseDown += Main_Form_MouseDown;
            MouseMove += Main_Form_MouseMove;
            MouseUp += Main_Form_MouseUp;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_pen).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_corners).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_figyres;
        private Label label1;
        private Label label2;
        private Button btn_save;
        private Label label3;
        private Button btn_cancel;
        private Button btn_clear;
        private Panel panel1;
        private Label label4;
        private TrackBar trackBar_pen;
        private TrackBar trackBar_corners;
        private Label label6;
        private Label label7;
        private Button btn_pencolor;
        private Button btn_backcolor;
        private Button btn_redo;
        private Button btn_desirialize;
    }
}
