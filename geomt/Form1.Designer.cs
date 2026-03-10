namespace geomt
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.x_c = new System.Windows.Forms.TextBox();
            this.y_c = new System.Windows.Forms.TextBox();
            this.h1 = new System.Windows.Forms.TextBox();
            this.w1 = new System.Windows.Forms.TextBox();
            this.y1 = new System.Windows.Forms.TextBox();
            this.x1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1120, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x_c";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1120, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "y_c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1120, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1120, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "w";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1120, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1120, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "y";
            // 
            // x_c
            // 
            this.x_c.Location = new System.Drawing.Point(1150, 79);
            this.x_c.Name = "x_c";
            this.x_c.Size = new System.Drawing.Size(100, 20);
            this.x_c.TabIndex = 6;
            // 
            // y_c
            // 
            this.y_c.Location = new System.Drawing.Point(1150, 109);
            this.y_c.Name = "y_c";
            this.y_c.Size = new System.Drawing.Size(100, 20);
            this.y_c.TabIndex = 7;
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(1150, 144);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(100, 20);
            this.h1.TabIndex = 8;
            // 
            // w1
            // 
            this.w1.Location = new System.Drawing.Point(1150, 174);
            this.w1.Name = "w1";
            this.w1.Size = new System.Drawing.Size(100, 20);
            this.w1.TabIndex = 9;
            // 
            // y1
            // 
            this.y1.Location = new System.Drawing.Point(1150, 234);
            this.y1.Name = "y1";
            this.y1.Size = new System.Drawing.Size(100, 20);
            this.y1.TabIndex = 10;
            // 
            // x1
            // 
            this.x1.Location = new System.Drawing.Point(1150, 205);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(100, 20);
            this.x1.TabIndex = 11;
            // 
            // chart1
            // 
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(42, 49);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(932, 551);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "graph";
            // 
            // buttonDraw
            // 
            this.buttonDraw.BackColor = System.Drawing.Color.Green;
            this.buttonDraw.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonDraw.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDraw.ForeColor = System.Drawing.Color.White;
            this.buttonDraw.Location = new System.Drawing.Point(1150, 280);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(100, 23);
            this.buttonDraw.TabIndex = 13;
            this.buttonDraw.Text = "Построить";
            this.buttonDraw.UseVisualStyleBackColor = false;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(1150, 309);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 23);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 694);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.y1);
            this.Controls.Add(this.w1);
            this.Controls.Add(this.h1);
            this.Controls.Add(this.y_c);
            this.Controls.Add(this.x_c);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox x_c;
        private System.Windows.Forms.TextBox y_c;
        private System.Windows.Forms.TextBox h1;
        private System.Windows.Forms.TextBox w1;
        private System.Windows.Forms.TextBox y1;
        private System.Windows.Forms.TextBox x1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button ClearButton;
    }
}

