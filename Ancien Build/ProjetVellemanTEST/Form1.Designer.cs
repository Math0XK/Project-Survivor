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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.lblHit = new System.Windows.Forms.Label();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.grpMain.SuspendLayout();
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
            this.grpMain.Controls.Add(this.lblHit);
            this.grpMain.Controls.Add(this.pnlPlayer);
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(1058, 1029);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // lblHit
            // 
            this.lblHit.AutoSize = true;
            this.lblHit.Location = new System.Drawing.Point(76, 102);
            this.lblHit.Name = "lblHit";
            this.lblHit.Size = new System.Drawing.Size(35, 16);
            this.lblHit.TabIndex = 2;
            this.lblHit.Text = "HIT !";
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPlayer.BackColor = System.Drawing.Color.Red;
            this.pnlPlayer.Location = new System.Drawing.Point(429, 189);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(50, 50);
            this.pnlPlayer.TabIndex = 0;
            // 
            // frmAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 1053);
            this.Controls.Add(this.grpMain);
            this.Name = "frmAppMain";
            this.Text = "Jeu Test";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onKeyUp);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameUpdate;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Label lblHit;
        internal System.Windows.Forms.GroupBox grpMain;
    }
}

