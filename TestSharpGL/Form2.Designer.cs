namespace TestSharpGL
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Triangle = new System.Windows.Forms.Button();
            this.LineTest = new System.Windows.Forms.Button();
            this.button_Light = new System.Windows.Forms.Button();
            this.button_Rotation = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.button_Rotation);
            this.panel1.Controls.Add(this.button_Light);
            this.panel1.Controls.Add(this.button_Triangle);
            this.panel1.Controls.Add(this.LineTest);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 448);
            this.panel1.TabIndex = 0;
            // 
            // button_Triangle
            // 
            this.button_Triangle.Location = new System.Drawing.Point(3, 41);
            this.button_Triangle.Name = "button_Triangle";
            this.button_Triangle.Size = new System.Drawing.Size(75, 23);
            this.button_Triangle.TabIndex = 1;
            this.button_Triangle.Text = "三角形";
            this.button_Triangle.UseVisualStyleBackColor = true;
            this.button_Triangle.Click += new System.EventHandler(this.button_Triangle_Click);
            // 
            // LineTest
            // 
            this.LineTest.Location = new System.Drawing.Point(3, 12);
            this.LineTest.Name = "LineTest";
            this.LineTest.Size = new System.Drawing.Size(75, 23);
            this.LineTest.TabIndex = 0;
            this.LineTest.Text = "直线测试";
            this.LineTest.UseVisualStyleBackColor = true;
            this.LineTest.Click += new System.EventHandler(this.LineTest_Click);
            // 
            // button_Light
            // 
            this.button_Light.Location = new System.Drawing.Point(3, 77);
            this.button_Light.Name = "button_Light";
            this.button_Light.Size = new System.Drawing.Size(75, 23);
            this.button_Light.TabIndex = 2;
            this.button_Light.Text = "加光照";
            this.button_Light.UseVisualStyleBackColor = true;
            this.button_Light.Click += new System.EventHandler(this.button_Light_Click);
            // 
            // button_Rotation
            // 
            this.button_Rotation.Location = new System.Drawing.Point(4, 107);
            this.button_Rotation.Name = "button_Rotation";
            this.button_Rotation.Size = new System.Drawing.Size(75, 23);
            this.button_Rotation.TabIndex = 3;
            this.button_Rotation.Text = "旋转";
            this.button_Rotation.UseVisualStyleBackColor = true;
            this.button_Rotation.Click += new System.EventHandler(this.button_Rotation_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 446);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LineTest;
        private System.Windows.Forms.Button button_Triangle;
        private System.Windows.Forms.Button button_Light;
        private System.Windows.Forms.Button button_Rotation;

    }
}