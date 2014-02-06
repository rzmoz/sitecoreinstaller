namespace SitecoreInstaller.UI.UserSelections
{
  partial class SelectInstallType
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.pnlSql = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radSqlClient = new System.Windows.Forms.RadioButton();
            this.radSqlLocal = new System.Windows.Forms.RadioButton();
            this.pnlMongo = new System.Windows.Forms.Panel();
            this.radMongoClient = new System.Windows.Forms.RadioButton();
            this.radMongoLocal = new System.Windows.Forms.RadioButton();
            this.lblSqlTitle = new SitecoreInstaller.UI.Forms.SIH2();
            this.lblMongoTitle = new SitecoreInstaller.UI.Forms.SIH2();
            this.pnlSql.SuspendLayout();
            this.pnlMongo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.panel1);
            this.pnlSql.Controls.Add(this.radSqlClient);
            this.pnlSql.Controls.Add(this.radSqlLocal);
            this.pnlSql.Location = new System.Drawing.Point(79, 3);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(112, 17);
            this.pnlSql.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(135, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 7;
            // 
            // radSqlClient
            // 
            this.radSqlClient.AutoSize = true;
            this.radSqlClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.radSqlClient.Location = new System.Drawing.Point(50, 0);
            this.radSqlClient.Name = "radSqlClient";
            this.radSqlClient.Size = new System.Drawing.Size(51, 17);
            this.radSqlClient.TabIndex = 5;
            this.radSqlClient.TabStop = true;
            this.radSqlClient.Text = "Client";
            this.radSqlClient.UseVisualStyleBackColor = true;
            this.radSqlClient.CheckedChanged += new System.EventHandler(this.radSqlClient_CheckedChanged);
            // 
            // radSqlLocal
            // 
            this.radSqlLocal.AutoSize = true;
            this.radSqlLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.radSqlLocal.Location = new System.Drawing.Point(0, 0);
            this.radSqlLocal.Name = "radSqlLocal";
            this.radSqlLocal.Size = new System.Drawing.Size(51, 17);
            this.radSqlLocal.TabIndex = 4;
            this.radSqlLocal.TabStop = true;
            this.radSqlLocal.Text = "Local";
            this.radSqlLocal.UseVisualStyleBackColor = true;
            this.radSqlLocal.CheckedChanged += new System.EventHandler(this.radSqlLocal_CheckedChanged);
            // 
            // pnlMongo
            // 
            this.pnlMongo.Controls.Add(this.radMongoClient);
            this.pnlMongo.Controls.Add(this.radMongoLocal);
            this.pnlMongo.Location = new System.Drawing.Point(79, 21);
            this.pnlMongo.Name = "pnlMongo";
            this.pnlMongo.Size = new System.Drawing.Size(111, 17);
            this.pnlMongo.TabIndex = 7;
            // 
            // radMongoClient
            // 
            this.radMongoClient.AutoSize = true;
            this.radMongoClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.radMongoClient.Location = new System.Drawing.Point(50, 0);
            this.radMongoClient.Name = "radMongoClient";
            this.radMongoClient.Size = new System.Drawing.Size(51, 17);
            this.radMongoClient.TabIndex = 8;
            this.radMongoClient.TabStop = true;
            this.radMongoClient.Text = "Client";
            this.radMongoClient.UseVisualStyleBackColor = true;
            this.radMongoClient.CheckedChanged += new System.EventHandler(this.radMongoClient_CheckedChanged);
            // 
            // radMongoLocal
            // 
            this.radMongoLocal.AutoSize = true;
            this.radMongoLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.radMongoLocal.Location = new System.Drawing.Point(0, 0);
            this.radMongoLocal.Name = "radMongoLocal";
            this.radMongoLocal.Size = new System.Drawing.Size(51, 17);
            this.radMongoLocal.TabIndex = 7;
            this.radMongoLocal.TabStop = true;
            this.radMongoLocal.Text = "Local";
            this.radMongoLocal.UseVisualStyleBackColor = true;
            this.radMongoLocal.CheckedChanged += new System.EventHandler(this.radMongoLocal_CheckedChanged);
            // 
            // lblSqlTitle
            // 
            this.lblSqlTitle.AutoSize = true;
            this.lblSqlTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSqlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblSqlTitle.Location = new System.Drawing.Point(6, 0);
            this.lblSqlTitle.Name = "lblSqlTitle";
            this.lblSqlTitle.Size = new System.Drawing.Size(40, 19);
            this.lblSqlTitle.TabIndex = 10;
            this.lblSqlTitle.Text = "[Sql]";
            // 
            // lblMongoTitle
            // 
            this.lblMongoTitle.AutoSize = true;
            this.lblMongoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMongoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblMongoTitle.Location = new System.Drawing.Point(6, 19);
            this.lblMongoTitle.Name = "lblMongoTitle";
            this.lblMongoTitle.Size = new System.Drawing.Size(67, 19);
            this.lblMongoTitle.TabIndex = 9;
            this.lblMongoTitle.Text = "[Mongo]";
            // 
            // SelectInstallType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSqlTitle);
            this.Controls.Add(this.lblMongoTitle);
            this.Controls.Add(this.pnlMongo);
            this.Controls.Add(this.pnlSql);
            this.Name = "SelectInstallType";
            this.Size = new System.Drawing.Size(202, 42);
            this.pnlSql.ResumeLayout(false);
            this.pnlSql.PerformLayout();
            this.pnlMongo.ResumeLayout(false);
            this.pnlMongo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlSql;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton radSqlClient;
    private System.Windows.Forms.RadioButton radSqlLocal;
    private System.Windows.Forms.Panel pnlMongo;
    private System.Windows.Forms.RadioButton radMongoClient;
    private System.Windows.Forms.RadioButton radMongoLocal;
    private Forms.SIH2 lblMongoTitle;
    private Forms.SIH2 lblSqlTitle;


  }
}
