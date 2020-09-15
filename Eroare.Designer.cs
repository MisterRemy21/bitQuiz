namespace Teste
{
    partial class Eroare
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
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eroare));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.Elipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.labelEroare = new Bunifu.UI.WinForms.BunifuLabel();
            this.buttonOK = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dragControlText = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.buttonCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.SuspendLayout();
            // 
            // Elipse
            // 
            this.Elipse.ElipseRadius = 5;
            this.Elipse.TargetControl = this;
            // 
            // labelEroare
            // 
            this.labelEroare.AutoEllipsis = false;
            this.labelEroare.AutoSize = false;
            this.labelEroare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.labelEroare.CursorType = null;
            this.labelEroare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.labelEroare.Location = new System.Drawing.Point(8, 7);
            this.labelEroare.Name = "labelEroare";
            this.labelEroare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelEroare.Size = new System.Drawing.Size(169, 44);
            this.labelEroare.TabIndex = 52;
            this.labelEroare.Text = "Ești sigur că vrei să pierzi progresul?";
            this.labelEroare.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEroare.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // buttonOK
            // 
            this.buttonOK.AllowToggling = false;
            this.buttonOK.AnimationSpeed = 200;
            this.buttonOK.AutoGenerateColors = false;
            this.buttonOK.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
            this.buttonOK.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonOK.ButtonText = "OK";
            this.buttonOK.ButtonTextMarginLeft = 0;
            this.buttonOK.ColorContrastOnClick = 45;
            this.buttonOK.ColorContrastOnHover = 45;
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.buttonOK.CustomizableEdges = borderEdges2;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOK.DisabledBorderColor = System.Drawing.Color.Silver;
            this.buttonOK.DisabledFillColor = System.Drawing.Color.Silver;
            this.buttonOK.DisabledForecolor = System.Drawing.Color.White;
            this.buttonOK.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F);
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.IconMarginLeft = 11;
            this.buttonOK.IconPadding = 10;
            this.buttonOK.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.IdleBorderRadius = 30;
            this.buttonOK.IdleBorderThickness = 1;
            this.buttonOK.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.IdleIconLeftImage = null;
            this.buttonOK.IdleIconRightImage = null;
            this.buttonOK.IndicateFocus = false;
            this.buttonOK.Location = new System.Drawing.Point(95, 51);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(191)))), ((int)(((byte)(51)))));
            this.buttonOK.onHoverState.BorderRadius = 30;
            this.buttonOK.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonOK.onHoverState.BorderThickness = 1;
            this.buttonOK.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(191)))), ((int)(((byte)(51)))));
            this.buttonOK.onHoverState.ForeColor = System.Drawing.Color.White;
            this.buttonOK.onHoverState.IconLeftImage = null;
            this.buttonOK.onHoverState.IconRightImage = null;
            this.buttonOK.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.OnIdleState.BorderRadius = 30;
            this.buttonOK.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonOK.OnIdleState.BorderThickness = 1;
            this.buttonOK.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.buttonOK.OnIdleState.IconLeftImage = null;
            this.buttonOK.OnIdleState.IconRightImage = null;
            this.buttonOK.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.OnPressedState.BorderRadius = 30;
            this.buttonOK.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonOK.OnPressedState.BorderThickness = 1;
            this.buttonOK.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonOK.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.buttonOK.OnPressedState.IconLeftImage = null;
            this.buttonOK.OnPressedState.IconRightImage = null;
            this.buttonOK.Size = new System.Drawing.Size(82, 37);
            this.buttonOK.TabIndex = 53;
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonOK.TextMarginLeft = 0;
            this.buttonOK.UseDefaultRadiusAndThickness = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // dragControl
            // 
            this.dragControl.Fixed = true;
            this.dragControl.Horizontal = true;
            this.dragControl.TargetControl = this;
            this.dragControl.Vertical = true;
            // 
            // dragControlText
            // 
            this.dragControlText.Fixed = true;
            this.dragControlText.Horizontal = true;
            this.dragControlText.TargetControl = this.labelEroare;
            this.dragControlText.Vertical = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AllowToggling = false;
            this.buttonCancel.AnimationSpeed = 200;
            this.buttonCancel.AutoGenerateColors = false;
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
            this.buttonCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.ButtonText = "Nu";
            this.buttonCancel.ButtonTextMarginLeft = 0;
            this.buttonCancel.ColorContrastOnClick = 45;
            this.buttonCancel.ColorContrastOnHover = 45;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.buttonCancel.CustomizableEdges = borderEdges1;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonCancel.DisabledBorderColor = System.Drawing.Color.Silver;
            this.buttonCancel.DisabledFillColor = System.Drawing.Color.Silver;
            this.buttonCancel.DisabledForecolor = System.Drawing.Color.White;
            this.buttonCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.IconMarginLeft = 11;
            this.buttonCancel.IconPadding = 10;
            this.buttonCancel.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.IdleBorderRadius = 30;
            this.buttonCancel.IdleBorderThickness = 1;
            this.buttonCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.IdleIconLeftImage = null;
            this.buttonCancel.IdleIconRightImage = null;
            this.buttonCancel.IndicateFocus = false;
            this.buttonCancel.Location = new System.Drawing.Point(8, 51);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(191)))), ((int)(((byte)(51)))));
            this.buttonCancel.onHoverState.BorderRadius = 30;
            this.buttonCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.onHoverState.BorderThickness = 1;
            this.buttonCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(191)))), ((int)(((byte)(51)))));
            this.buttonCancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.onHoverState.IconLeftImage = null;
            this.buttonCancel.onHoverState.IconRightImage = null;
            this.buttonCancel.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.OnIdleState.BorderRadius = 30;
            this.buttonCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.OnIdleState.BorderThickness = 1;
            this.buttonCancel.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.OnIdleState.IconLeftImage = null;
            this.buttonCancel.OnIdleState.IconRightImage = null;
            this.buttonCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.OnPressedState.BorderRadius = 30;
            this.buttonCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.buttonCancel.OnPressedState.BorderThickness = 1;
            this.buttonCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(176)))), ((int)(((byte)(246)))));
            this.buttonCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.OnPressedState.IconLeftImage = null;
            this.buttonCancel.OnPressedState.IconRightImage = null;
            this.buttonCancel.Size = new System.Drawing.Size(81, 37);
            this.buttonCancel.TabIndex = 54;
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCancel.TextMarginLeft = 0;
            this.buttonCancel.UseDefaultRadiusAndThickness = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // Eroare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(185, 100);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelEroare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Eroare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bitQuiz";
            this.Load += new System.EventHandler(this.Eroare_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Elipse;
        private Bunifu.UI.WinForms.BunifuLabel labelEroare;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton buttonOK;
        private Bunifu.Framework.UI.BunifuDragControl dragControl;
        private Bunifu.Framework.UI.BunifuDragControl dragControlText;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton buttonCancel;
    }
}