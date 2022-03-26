namespace Gestione_file_avanzata
{
    partial class Cruscotto
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
            this.FlowContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlowContainer
            // 
            this.FlowContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FlowContainer.Location = new System.Drawing.Point(-6, 39);
            this.FlowContainer.Name = "FlowContainer";
            this.FlowContainer.Size = new System.Drawing.Size(811, 416);
            this.FlowContainer.TabIndex = 0;
            // 
            // Cruscotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FlowContainer);
            this.Name = "Cruscotto";
            this.Text = "Cruscotto";
            this.Load += new System.EventHandler(this.Cruscotto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel FlowContainer;
    }
}