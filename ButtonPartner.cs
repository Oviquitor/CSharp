using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Infraestrutura.Componentes
{
    public partial class ButtonPartner : Button
    {
        public ButtonPartner()
        {
            this.BackColor = Color.FromArgb(48, 73, 99);
            this.ForeColor = Color.White;

            this.FlatStyle = FlatStyle.Flat;

            this.Cursor = Cursors.Hand;

            this.FlatAppearance.BorderColor = Color.FromArgb(70, 100, 140);
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 100, 140);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 182, 198);

            this.AutoSize = false;
        }

        private Color BackColorSaveX;
        private Color BackColorSave
        {
            get
            {
                return BackColorSaveX;
            }
            set
            {
                BackColorSaveX = value;
            }
        }

        private Color ForeColoSaveX;
        private Color ForeColorSave
        {
            get
            {
                return ForeColoSaveX;
            }
            set
            {
                ForeColoSaveX = value;
            }
        }

        private Color BackColorFocus = Color.FromArgb(38, 182, 198);
        [Category("Appearance"), Description("Cor do Backgroud do Button quando entrar o Focus.")]
        [Browsable(true)]
        public Color _BackColorFocus
        {
            get
            {
                return BackColorFocus;
            }
            set
            {
                BackColorFocus = value;
                this.Refresh();
            }
        }

        private Color BackColorDisnabled = Color.WhiteSmoke;
        [Category("Appearance"), Description("Cor do Backgroud do Button quando estiver desabilitado.")]
        [Browsable(true)]
        public Color _BackColorDisnabled
        {
            get
            {
                return BackColorDisnabled;
            }
            set
            {
                BackColorDisnabled = value;
                this.Refresh();
            }
        }

        private Color ForeColorFocus = Color.White;
        [Category("Appearance"), Description("Cor do texto do Button quando entrar o Focus.")]
        [Browsable(true)]
        public Color _ForeColorFocus
        {
            get
            {
                return ForeColorFocus;
            }
            set
            {
                ForeColorFocus = value;
                this.Refresh();
            }
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.Enabled)
            {
                this.BackColor = this._BackColorFocus;
                this.ForeColor = this._ForeColorFocus;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Enabled)
            {
                this.BackColor = this.BackColorSave;
                this.ForeColor = this.ForeColorSave;
            }
        }

        private bool ColorSave = false;

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (ColorSave)
            {
                if (this.Enabled)
                {
                    this.BackColor = this.BackColorSave;
                }
                else
                {
                    this.BackColor = this._BackColorDisnabled;
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.BackColorSave = this.BackColor;
            this.ForeColorSave = this.ForeColor;

            this.ColorSave = true;

            if (this.Enabled == false)
            {
                this.BackColor = this._BackColorDisnabled;
            }
        }
    }
}
