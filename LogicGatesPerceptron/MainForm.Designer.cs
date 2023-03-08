namespace LogicGatesPerceptron
{
    partial class MainForm
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
            this.clearBtn = new System.Windows.Forms.Button();
            this.predictBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.canvasContainer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 273);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(116, 34);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // predictBtn
            // 
            this.predictBtn.Location = new System.Drawing.Point(143, 273);
            this.predictBtn.Name = "predictBtn";
            this.predictBtn.Size = new System.Drawing.Size(119, 34);
            this.predictBtn.TabIndex = 2;
            this.predictBtn.Text = "Predict";
            this.predictBtn.UseVisualStyleBackColor = true;
            this.predictBtn.Click += new System.EventHandler(this.predictBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(279, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(85, 85);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // canvasContainer
            // 
            this.canvasContainer.BackColor = System.Drawing.Color.White;
            this.canvasContainer.Location = new System.Drawing.Point(12, 12);
            this.canvasContainer.Name = "canvasContainer";
            this.canvasContainer.Size = new System.Drawing.Size(250, 250);
            this.canvasContainer.TabIndex = 4;
            this.canvasContainer.TabStop = false;
            this.canvasContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseDown);
            this.canvasContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseMove);
            this.canvasContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "15x15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Predicted Output";
            // 
            // labelInput
            // 
            this.labelInput.Location = new System.Drawing.Point(143, 313);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(119, 23);
            this.labelInput.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 388);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvasContainer);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.predictBtn);
            this.Controls.Add(this.clearBtn);
            this.Name = "MainForm";
            this.Text = "Logic Gates Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button clearBtn;
        private Button predictBtn;
        private PictureBox pictureBox;
        private PictureBox canvasContainer;
        private Label label1;
        private Label label2;
        private TextBox labelInput;
    }
}