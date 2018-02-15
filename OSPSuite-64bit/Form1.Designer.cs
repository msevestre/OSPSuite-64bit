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
         this.SuspendLayout();
         // 
         // generateReportButton
         // 
         this.generateReportButton.Location = new System.Drawing.Point(87, 46);
         this.generateReportButton.Name = "generateReportButton";
         this.generateReportButton.Size = new System.Drawing.Size(75, 23);
         this.generateReportButton.TabIndex = 0;
         this.generateReportButton.Text = "button1";
         this.generateReportButton.UseVisualStyleBackColor = true;
         // 
         // loadModelDataButton
         // 
         this.loadModelDataButton.Location = new System.Drawing.Point(87, 157);
         this.loadModelDataButton.Name = "loadModelDataButton";
         this.loadModelDataButton.Size = new System.Drawing.Size(75, 23);
         this.loadModelDataButton.TabIndex = 1;
         this.loadModelDataButton.Text = "button2";
         this.loadModelDataButton.UseVisualStyleBackColor = true;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.loadModelDataButton);
         this.Controls.Add(this.generateReportButton);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button generateReportButton;
      private System.Windows.Forms.Button loadModelDataButton;
   }
}

