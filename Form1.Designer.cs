namespace ProjetVellemanTEST
{
    partial class frmAppMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.grpMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tmrGameUpdate
            // 
            this.tmrGameUpdate.Enabled = true;
            this.tmrGameUpdate.Interval = 1;
            this.tmrGameUpdate.Tick += new System.EventHandler(this.gameUpdate);
            // 
            // grpMain
            // 
            this.grpMain.Location = new System.Drawing.Point(0, 2);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(1918, 1077);
            this.grpMain.TabIndex = 0;
            // 
            // frmAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1918, 1078);
            this.ControlBox = false;
            this.Controls.Add(this.grpMain);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1940, 1090);
            this.MinimumSize = new System.Drawing.Size(1918, 1030);
            this.Name = "frmAppMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onKeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel grpMain;
        internal System.Windows.Forms.Timer tmrGameUpdate;
    }
}

