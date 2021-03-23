
namespace MazeGen.App
{
    partial class Main
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
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.renderer = new MazeGen.App.MazeRenderer();
            this.controls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.container.SuspendLayout();
            this.controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.ColumnCount = 1;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.container.Controls.Add(this.renderer, 0, 0);
            this.container.Controls.Add(this.controls, 0, 1);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Margin = new System.Windows.Forms.Padding(0);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.container.Size = new System.Drawing.Size(1299, 788);
            this.container.TabIndex = 0;
            // 
            // renderer
            // 
            this.renderer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.renderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderer.EndpointColor = System.Drawing.Color.Blue;
            this.renderer.ForeColor = System.Drawing.Color.White;
            this.renderer.Location = new System.Drawing.Point(0, 0);
            this.renderer.Margin = new System.Windows.Forms.Padding(0);
            this.renderer.Name = "renderer";
            this.renderer.Size = new System.Drawing.Size(1299, 630);
            this.renderer.SolutionColor = System.Drawing.Color.DarkRed;
            this.renderer.TabIndex = 0;
            // 
            // controls
            // 
            this.controls.Controls.Add(this.btnStep);
            this.controls.Controls.Add(this.btnFinish);
            this.controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controls.Location = new System.Drawing.Point(6, 636);
            this.controls.Margin = new System.Windows.Forms.Padding(6);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(1287, 146);
            this.controls.TabIndex = 1;
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStep.Location = new System.Drawing.Point(0, 0);
            this.btnStep.Margin = new System.Windows.Forms.Padding(0);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(146, 146);
            this.btnStep.TabIndex = 0;
            this.btnStep.Text = "S";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinish.Location = new System.Drawing.Point(152, 0);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(146, 146);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "F";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 788);
            this.Controls.Add(this.container);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MazeGen";
            this.container.ResumeLayout(false);
            this.controls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel container;
        private MazeRenderer renderer;
        private System.Windows.Forms.FlowLayoutPanel controls;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnFinish;
    }
}

