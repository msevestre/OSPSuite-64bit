namespace OSPSuite_64bit
{
   partial class Form1
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
         this.generateReportButton = new System.Windows.Forms.Button();
         this.loadModelDataButton = new System.Windows.Forms.Button();
         this.flatModelCalculationMethods = new System.Windows.Forms.DataGridView();
         this.rawQueryDataGrid = new System.Windows.Forms.DataGridView();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.flatModelCalculationMethods)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rawQueryDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // generateReportButton
         // 
         this.generateReportButton.Location = new System.Drawing.Point(87, 46);
         this.generateReportButton.Name = "generateReportButton";
         this.generateReportButton.Size = new System.Drawing.Size(75, 23);
         this.generateReportButton.TabIndex = 0;
         this.generateReportButton.Text = "Report";
         this.generateReportButton.UseVisualStyleBackColor = true;
         this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
         // 
         // loadModelDataButton
         // 
         this.loadModelDataButton.Location = new System.Drawing.Point(87, 157);
         this.loadModelDataButton.Name = "loadModelDataButton";
         this.loadModelDataButton.Size = new System.Drawing.Size(75, 23);
         this.loadModelDataButton.TabIndex = 1;
         this.loadModelDataButton.Text = "Load Models";
         this.loadModelDataButton.UseVisualStyleBackColor = true;
         this.loadModelDataButton.Click += new System.EventHandler(this.loadModelDataButton_Click);
         // 
         // flatModelCalculationMethods
         // 
         this.flatModelCalculationMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.flatModelCalculationMethods.Location = new System.Drawing.Point(12, 239);
         this.flatModelCalculationMethods.Name = "flatModelCalculationMethods";
         this.flatModelCalculationMethods.Size = new System.Drawing.Size(677, 273);
         this.flatModelCalculationMethods.TabIndex = 2;
         // 
         // rawQueryDataGrid
         // 
         this.rawQueryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.rawQueryDataGrid.Location = new System.Drawing.Point(695, 239);
         this.rawQueryDataGrid.Name = "rawQueryDataGrid";
         this.rawQueryDataGrid.Size = new System.Drawing.Size(602, 273);
         this.rawQueryDataGrid.TabIndex = 3;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(265, 46);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(118, 23);
         this.button1.TabIndex = 4;
         this.button1.Text = "Parse a Func";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(265, 157);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(142, 23);
         this.button2.TabIndex = 5;
         this.button2.Text = "Core Simulation";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1309, 515);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.rawQueryDataGrid);
         this.Controls.Add(this.flatModelCalculationMethods);
         this.Controls.Add(this.loadModelDataButton);
         this.Controls.Add(this.generateReportButton);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.flatModelCalculationMethods)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rawQueryDataGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button generateReportButton;
      private System.Windows.Forms.Button loadModelDataButton;
      private System.Windows.Forms.DataGridView flatModelCalculationMethods;
      private System.Windows.Forms.DataGridView rawQueryDataGrid;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
   }
}

