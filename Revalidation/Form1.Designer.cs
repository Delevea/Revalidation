﻿namespace Revalidation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelCheck = new System.Windows.Forms.Label();
            this.labelStandard = new System.Windows.Forms.Label();
            this.textCheck = new System.Windows.Forms.TextBox();
            this.textStandard = new System.Windows.Forms.TextBox();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.StandardBtn = new System.Windows.Forms.Button();
            this.textFilesBox = new System.Windows.Forms.TextBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.tips = new System.Windows.Forms.Label();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCheck.Location = new System.Drawing.Point(12, 18);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(65, 12);
            this.labelCheck.TabIndex = 0;
            this.labelCheck.Text = "校验路径：";
            // 
            // labelStandard
            // 
            this.labelStandard.AutoSize = true;
            this.labelStandard.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStandard.Location = new System.Drawing.Point(12, 53);
            this.labelStandard.Name = "labelStandard";
            this.labelStandard.Size = new System.Drawing.Size(65, 12);
            this.labelStandard.TabIndex = 1;
            this.labelStandard.Text = "索引文件：";
            // 
            // textCheck
            // 
            this.textCheck.Location = new System.Drawing.Point(97, 15);
            this.textCheck.Name = "textCheck";
            this.textCheck.ReadOnly = true;
            this.textCheck.Size = new System.Drawing.Size(326, 21);
            this.textCheck.TabIndex = 2;
            this.textCheck.TabStop = false;
            // 
            // textStandard
            // 
            this.textStandard.Location = new System.Drawing.Point(97, 50);
            this.textStandard.Name = "textStandard";
            this.textStandard.ReadOnly = true;
            this.textStandard.Size = new System.Drawing.Size(326, 21);
            this.textStandard.TabIndex = 3;
            this.textStandard.TabStop = false;
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(429, 12);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(25, 25);
            this.CheckBtn.TabIndex = 4;
            this.CheckBtn.TabStop = false;
            this.CheckBtn.Text = "...";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // StandardBtn
            // 
            this.StandardBtn.Location = new System.Drawing.Point(429, 48);
            this.StandardBtn.Name = "StandardBtn";
            this.StandardBtn.Size = new System.Drawing.Size(25, 25);
            this.StandardBtn.TabIndex = 5;
            this.StandardBtn.TabStop = false;
            this.StandardBtn.Text = "...";
            this.StandardBtn.UseVisualStyleBackColor = true;
            this.StandardBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // textFilesBox
            // 
            this.textFilesBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textFilesBox.Location = new System.Drawing.Point(14, 86);
            this.textFilesBox.Multiline = true;
            this.textFilesBox.Name = "textFilesBox";
            this.textFilesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textFilesBox.Size = new System.Drawing.Size(409, 177);
            this.textFilesBox.TabIndex = 6;
            this.textFilesBox.TabStop = false;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(429, 240);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(106, 23);
            this.ExportBtn.TabIndex = 8;
            this.ExportBtn.TabStop = false;
            this.ExportBtn.Text = "导出";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(429, 205);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(106, 23);
            this.StartBtn.TabIndex = 12;
            this.StartBtn.TabStop = false;
            this.StartBtn.Text = "校验";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // tips
            // 
            this.tips.AutoSize = true;
            this.tips.ForeColor = System.Drawing.Color.Red;
            this.tips.Location = new System.Drawing.Point(463, 54);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(77, 12);
            this.tips.TabIndex = 13;
            this.tips.Text = "载入成功文件";
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(460, 13);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 14;
            this.CreateBtn.TabStop = false;
            this.CreateBtn.Text = "生成";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 290);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.textFilesBox);
            this.Controls.Add(this.StandardBtn);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.textStandard);
            this.Controls.Add(this.textCheck);
            this.Controls.Add(this.labelStandard);
            this.Controls.Add(this.labelCheck);
            this.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Document Revalidation v0.0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.Label labelStandard;
        private System.Windows.Forms.TextBox textCheck;
        private System.Windows.Forms.TextBox textStandard;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button StandardBtn;
        private System.Windows.Forms.TextBox textFilesBox;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label tips;
        private System.Windows.Forms.Button CreateBtn;
    }
}

