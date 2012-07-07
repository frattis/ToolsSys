using System.Windows.Forms;

namespace RDev.ToolsSys.UserInterface.Windows.Cadastros
{
    partial class CadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroCliente));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonNovo = new System.Windows.Forms.ToolStripButton();
            this.ButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.ButtonImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.buttonSalvarFoto = new System.Windows.Forms.Button();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.groupBoxDocumento = new System.Windows.Forms.GroupBox();
            this.textRg = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.labelRG = new System.Windows.Forms.Label();
            this.labelCPF = new System.Windows.Forms.Label();
            this.maskedCpf = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxContato = new System.Windows.Forms.GroupBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCel = new System.Windows.Forms.Label();
            this.maskedFax = new System.Windows.Forms.MaskedTextBox();
            this.maskedCel = new System.Windows.Forms.MaskedTextBox();
            this.labelTelCom = new System.Windows.Forms.Label();
            this.maskedTelRes = new System.Windows.Forms.MaskedTextBox();
            this.labelTelRes = new System.Windows.Forms.Label();
            this.maskedTelCom = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxEndereco1 = new System.Windows.Forms.GroupBox();
            this.textNumero1 = new System.Windows.Forms.TextBox();
            this.labelNumero1 = new System.Windows.Forms.Label();
            this.labelCidade1 = new System.Windows.Forms.Label();
            this.comboCidade1 = new System.Windows.Forms.ComboBox();
            this.labelEstado1 = new System.Windows.Forms.Label();
            this.comboBoxEstado1 = new System.Windows.Forms.ComboBox();
            this.textBairro1 = new System.Windows.Forms.TextBox();
            this.labelBairro1 = new System.Windows.Forms.Label();
            this.textEndereco1 = new System.Windows.Forms.TextBox();
            this.labelEndereco1 = new System.Windows.Forms.Label();
            this.labelTipoEnd1 = new System.Windows.Forms.Label();
            this.comboBoxTipoEnd1 = new System.Windows.Forms.ComboBox();
            this.buttonPesquisarCEP1 = new System.Windows.Forms.Button();
            this.maskedCep1 = new System.Windows.Forms.MaskedTextBox();
            this.labelCep1 = new System.Windows.Forms.Label();
            this.groupBoxEndereco2 = new System.Windows.Forms.GroupBox();
            this.textNumero2 = new System.Windows.Forms.TextBox();
            this.labelNumero2 = new System.Windows.Forms.Label();
            this.labelCidade2 = new System.Windows.Forms.Label();
            this.comboCidade2 = new System.Windows.Forms.ComboBox();
            this.labelEstado2 = new System.Windows.Forms.Label();
            this.comboBoxEstado2 = new System.Windows.Forms.ComboBox();
            this.textBairro2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textEndereco2 = new System.Windows.Forms.TextBox();
            this.labelEndereco2 = new System.Windows.Forms.Label();
            this.labelTipoEnd2 = new System.Windows.Forms.Label();
            this.buttonPesquisarCep2 = new System.Windows.Forms.Button();
            this.maskedCep2 = new System.Windows.Forms.MaskedTextBox();
            this.labelCep2 = new System.Windows.Forms.Label();
            this.groupBoxOutros = new System.Windows.Forms.GroupBox();
            this.maskedNascimento = new System.Windows.Forms.MaskedTextBox();
            this.labelNascimento = new System.Windows.Forms.Label();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.comboBoxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.radioButtonFeminino = new System.Windows.Forms.RadioButton();
            this.radioButtonMasculino = new System.Windows.Forms.RadioButton();
            this.openFileDialogSalvarFoto = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxFoto3por4 = new System.Windows.Forms.PictureBox();
            this.groupBoxSexo = new System.Windows.Forms.GroupBox();
            this.labelCadastroCliente = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.comboBoxTipoEnd2 = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxDataCadastrado = new System.Windows.Forms.MaskedTextBox();
            this.labelDataCadastro = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBoxDocumento.SuspendLayout();
            this.groupBoxContato.SuspendLayout();
            this.groupBoxEndereco1.SuspendLayout();
            this.groupBoxEndereco2.SuspendLayout();
            this.groupBoxOutros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto3por4)).BeginInit();
            this.groupBoxSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNovo,
            this.ButtonSalvar,
            this.ButtonImprimir,
            this.toolStripSeparator,
            this.ButtonHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(498, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonNovo
            // 
            this.ButtonNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonNovo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonNovo.Image")));
            this.ButtonNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNovo.Name = "ButtonNovo";
            this.ButtonNovo.Size = new System.Drawing.Size(23, 22);
            this.ButtonNovo.Text = "&New";
            // 
            // ButtonSalvar
            // 
            this.ButtonSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSalvar.Image")));
            this.ButtonSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSalvar.Name = "ButtonSalvar";
            this.ButtonSalvar.Size = new System.Drawing.Size(23, 22);
            this.ButtonSalvar.Text = "&Save";
            this.ButtonSalvar.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // ButtonImprimir
            // 
            this.ButtonImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("ButtonImprimir.Image")));
            this.ButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonImprimir.Name = "ButtonImprimir";
            this.ButtonImprimir.Size = new System.Drawing.Size(23, 22);
            this.ButtonImprimir.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHelp.Image")));
            this.ButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(23, 22);
            this.ButtonHelp.Text = "He&lp";
            // 
            // buttonSalvarFoto
            // 
            this.buttonSalvarFoto.Location = new System.Drawing.Point(13, 164);
            this.buttonSalvarFoto.Name = "buttonSalvarFoto";
            this.buttonSalvarFoto.Size = new System.Drawing.Size(104, 23);
            this.buttonSalvarFoto.TabIndex = 3;
            this.buttonSalvarFoto.Text = "Salvar Foto";
            this.buttonSalvarFoto.UseVisualStyleBackColor = true;
            this.buttonSalvarFoto.Click += new System.EventHandler(this.buttonSalvarFoto_Click);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(131, 89);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(38, 13);
            this.labelNome.TabIndex = 4;
            this.labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(175, 86);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(311, 20);
            this.textBoxNome.TabIndex = 5;
            // 
            // groupBoxDocumento
            // 
            this.groupBoxDocumento.Controls.Add(this.textRg);
            this.groupBoxDocumento.Controls.Add(this.buttonPesquisar);
            this.groupBoxDocumento.Controls.Add(this.labelRG);
            this.groupBoxDocumento.Controls.Add(this.labelCPF);
            this.groupBoxDocumento.Controls.Add(this.maskedCpf);
            this.groupBoxDocumento.Location = new System.Drawing.Point(134, 112);
            this.groupBoxDocumento.Name = "groupBoxDocumento";
            this.groupBoxDocumento.Size = new System.Drawing.Size(352, 48);
            this.groupBoxDocumento.TabIndex = 0;
            this.groupBoxDocumento.TabStop = false;
            this.groupBoxDocumento.Text = "Documentos1";
            // 
            // textRg
            // 
            this.textRg.Location = new System.Drawing.Point(227, 16);
            this.textRg.Name = "textRg";
            this.textRg.Size = new System.Drawing.Size(108, 20);
            this.textRg.TabIndex = 8;
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Image = global::RDev.ToolsSys.UserInterface.Windows.Properties.Resources._1341504165_gnome_searchtool;
            this.buttonPesquisar.Location = new System.Drawing.Point(165, 16);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(22, 21);
            this.buttonPesquisar.TabIndex = 7;
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            // 
            // labelRG
            // 
            this.labelRG.AutoSize = true;
            this.labelRG.Location = new System.Drawing.Point(193, 19);
            this.labelRG.Name = "labelRG";
            this.labelRG.Size = new System.Drawing.Size(26, 13);
            this.labelRG.TabIndex = 3;
            this.labelRG.Text = "RG:";
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Location = new System.Drawing.Point(8, 19);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(30, 13);
            this.labelCPF.TabIndex = 2;
            this.labelCPF.Text = "CPF:";
            // 
            // maskedCpf
            // 
            this.maskedCpf.Location = new System.Drawing.Point(44, 16);
            this.maskedCpf.Mask = "000.000.000-00";
            this.maskedCpf.Name = "maskedCpf";
            this.maskedCpf.Size = new System.Drawing.Size(115, 20);
            this.maskedCpf.TabIndex = 0;
            this.maskedCpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxContato
            // 
            this.groupBoxContato.Controls.Add(this.textBoxEmail);
            this.groupBoxContato.Controls.Add(this.labelEmail);
            this.groupBoxContato.Controls.Add(this.label3);
            this.groupBoxContato.Controls.Add(this.labelCel);
            this.groupBoxContato.Controls.Add(this.maskedFax);
            this.groupBoxContato.Controls.Add(this.maskedCel);
            this.groupBoxContato.Controls.Add(this.labelTelCom);
            this.groupBoxContato.Controls.Add(this.maskedTelRes);
            this.groupBoxContato.Controls.Add(this.labelTelRes);
            this.groupBoxContato.Controls.Add(this.maskedTelCom);
            this.groupBoxContato.Location = new System.Drawing.Point(134, 166);
            this.groupBoxContato.Name = "groupBoxContato";
            this.groupBoxContato.Size = new System.Drawing.Size(352, 93);
            this.groupBoxContato.TabIndex = 6;
            this.groupBoxContato.TabStop = false;
            this.groupBoxContato.Text = "Contato";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(70, 65);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(272, 20);
            this.textBoxEmail.TabIndex = 13;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(24, 69);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 12;
            this.labelEmail.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fax:";
            // 
            // labelCel
            // 
            this.labelCel.AutoSize = true;
            this.labelCel.Location = new System.Drawing.Point(191, 17);
            this.labelCel.Name = "labelCel";
            this.labelCel.Size = new System.Drawing.Size(25, 13);
            this.labelCel.TabIndex = 10;
            this.labelCel.Text = "Cel:";
            // 
            // maskedFax
            // 
            this.maskedFax.Location = new System.Drawing.Point(227, 39);
            this.maskedFax.Mask = "(00) 0000-0000";
            this.maskedFax.Name = "maskedFax";
            this.maskedFax.Size = new System.Drawing.Size(115, 20);
            this.maskedFax.TabIndex = 9;
            this.maskedFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedCel
            // 
            this.maskedCel.Location = new System.Drawing.Point(227, 13);
            this.maskedCel.Mask = "(00) 0000-0000";
            this.maskedCel.Name = "maskedCel";
            this.maskedCel.Size = new System.Drawing.Size(115, 20);
            this.maskedCel.TabIndex = 8;
            this.maskedCel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTelCom
            // 
            this.labelTelCom.AutoSize = true;
            this.labelTelCom.Location = new System.Drawing.Point(10, 43);
            this.labelTelCom.Name = "labelTelCom";
            this.labelTelCom.Size = new System.Drawing.Size(49, 13);
            this.labelTelCom.TabIndex = 7;
            this.labelTelCom.Text = "Tel Com:";
            // 
            // maskedTelRes
            // 
            this.maskedTelRes.Location = new System.Drawing.Point(70, 13);
            this.maskedTelRes.Mask = "(00) 0000-0000";
            this.maskedTelRes.Name = "maskedTelRes";
            this.maskedTelRes.Size = new System.Drawing.Size(115, 20);
            this.maskedTelRes.TabIndex = 4;
            this.maskedTelRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTelRes
            // 
            this.labelTelRes.AutoSize = true;
            this.labelTelRes.Location = new System.Drawing.Point(12, 17);
            this.labelTelRes.Name = "labelTelRes";
            this.labelTelRes.Size = new System.Drawing.Size(47, 13);
            this.labelTelRes.TabIndex = 6;
            this.labelTelRes.Text = "Tel Res:";
            // 
            // maskedTelCom
            // 
            this.maskedTelCom.Location = new System.Drawing.Point(70, 39);
            this.maskedTelCom.Mask = "(00) 0000-0000";
            this.maskedTelCom.Name = "maskedTelCom";
            this.maskedTelCom.Size = new System.Drawing.Size(115, 20);
            this.maskedTelCom.TabIndex = 5;
            this.maskedTelCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxEndereco1
            // 
            this.groupBoxEndereco1.Controls.Add(this.textNumero1);
            this.groupBoxEndereco1.Controls.Add(this.labelNumero1);
            this.groupBoxEndereco1.Controls.Add(this.labelCidade1);
            this.groupBoxEndereco1.Controls.Add(this.comboCidade1);
            this.groupBoxEndereco1.Controls.Add(this.labelEstado1);
            this.groupBoxEndereco1.Controls.Add(this.comboBoxEstado1);
            this.groupBoxEndereco1.Controls.Add(this.textBairro1);
            this.groupBoxEndereco1.Controls.Add(this.labelBairro1);
            this.groupBoxEndereco1.Controls.Add(this.textEndereco1);
            this.groupBoxEndereco1.Controls.Add(this.labelEndereco1);
            this.groupBoxEndereco1.Controls.Add(this.labelTipoEnd1);
            this.groupBoxEndereco1.Controls.Add(this.comboBoxTipoEnd1);
            this.groupBoxEndereco1.Controls.Add(this.buttonPesquisarCEP1);
            this.groupBoxEndereco1.Controls.Add(this.maskedCep1);
            this.groupBoxEndereco1.Controls.Add(this.labelCep1);
            this.groupBoxEndereco1.Location = new System.Drawing.Point(12, 265);
            this.groupBoxEndereco1.Name = "groupBoxEndereco1";
            this.groupBoxEndereco1.Size = new System.Drawing.Size(474, 106);
            this.groupBoxEndereco1.TabIndex = 7;
            this.groupBoxEndereco1.TabStop = false;
            this.groupBoxEndereco1.Text = "Endereço";
            // 
            // textNumero1
            // 
            this.textNumero1.Location = new System.Drawing.Point(414, 42);
            this.textNumero1.Name = "textNumero1";
            this.textNumero1.Size = new System.Drawing.Size(54, 20);
            this.textNumero1.TabIndex = 22;
            // 
            // labelNumero1
            // 
            this.labelNumero1.AutoSize = true;
            this.labelNumero1.Location = new System.Drawing.Point(388, 46);
            this.labelNumero1.Name = "labelNumero1";
            this.labelNumero1.Size = new System.Drawing.Size(20, 13);
            this.labelNumero1.TabIndex = 21;
            this.labelNumero1.Text = "nº:";
            // 
            // labelCidade1
            // 
            this.labelCidade1.AutoSize = true;
            this.labelCidade1.Location = new System.Drawing.Point(277, 73);
            this.labelCidade1.Name = "labelCidade1";
            this.labelCidade1.Size = new System.Drawing.Size(43, 13);
            this.labelCidade1.TabIndex = 20;
            this.labelCidade1.Text = "Cidade:";
            // 
            // comboCidade1
            // 
            this.comboCidade1.FormattingEnabled = true;
            this.comboCidade1.Location = new System.Drawing.Point(326, 69);
            this.comboCidade1.Name = "comboCidade1";
            this.comboCidade1.Size = new System.Drawing.Size(142, 21);
            this.comboCidade1.TabIndex = 19;
            // 
            // labelEstado1
            // 
            this.labelEstado1.AutoSize = true;
            this.labelEstado1.Location = new System.Drawing.Point(166, 73);
            this.labelEstado1.Name = "labelEstado1";
            this.labelEstado1.Size = new System.Drawing.Size(43, 13);
            this.labelEstado1.TabIndex = 18;
            this.labelEstado1.Text = "Estado:";
            // 
            // comboBoxEstado1
            // 
            this.comboBoxEstado1.FormattingEnabled = true;
            this.comboBoxEstado1.Location = new System.Drawing.Point(215, 69);
            this.comboBoxEstado1.Name = "comboBoxEstado1";
            this.comboBoxEstado1.Size = new System.Drawing.Size(56, 21);
            this.comboBoxEstado1.TabIndex = 17;
            // 
            // textBairro1
            // 
            this.textBairro1.Location = new System.Drawing.Point(68, 69);
            this.textBairro1.Name = "textBairro1";
            this.textBairro1.Size = new System.Drawing.Size(92, 20);
            this.textBairro1.TabIndex = 16;
            // 
            // labelBairro1
            // 
            this.labelBairro1.AutoSize = true;
            this.labelBairro1.Location = new System.Drawing.Point(12, 73);
            this.labelBairro1.Name = "labelBairro1";
            this.labelBairro1.Size = new System.Drawing.Size(37, 13);
            this.labelBairro1.TabIndex = 15;
            this.labelBairro1.Text = "Bairro:";
            // 
            // textEndereco1
            // 
            this.textEndereco1.Location = new System.Drawing.Point(228, 42);
            this.textEndereco1.Name = "textEndereco1";
            this.textEndereco1.Size = new System.Drawing.Size(154, 20);
            this.textEndereco1.TabIndex = 14;
            // 
            // labelEndereco1
            // 
            this.labelEndereco1.AutoSize = true;
            this.labelEndereco1.Location = new System.Drawing.Point(166, 46);
            this.labelEndereco1.Name = "labelEndereco1";
            this.labelEndereco1.Size = new System.Drawing.Size(56, 13);
            this.labelEndereco1.TabIndex = 13;
            this.labelEndereco1.Text = "Endereço:";
            // 
            // labelTipoEnd1
            // 
            this.labelTipoEnd1.AutoSize = true;
            this.labelTipoEnd1.Location = new System.Drawing.Point(6, 46);
            this.labelTipoEnd1.Name = "labelTipoEnd1";
            this.labelTipoEnd1.Size = new System.Drawing.Size(56, 13);
            this.labelTipoEnd1.TabIndex = 12;
            this.labelTipoEnd1.Text = "Tipo End.:";
            // 
            // comboBoxTipoEnd1
            // 
            this.comboBoxTipoEnd1.FormattingEnabled = true;
            this.comboBoxTipoEnd1.Location = new System.Drawing.Point(68, 42);
            this.comboBoxTipoEnd1.Name = "comboBoxTipoEnd1";
            this.comboBoxTipoEnd1.Size = new System.Drawing.Size(92, 21);
            this.comboBoxTipoEnd1.TabIndex = 11;
            // 
            // buttonPesquisarCEP1
            // 
            this.buttonPesquisarCEP1.Image = global::RDev.ToolsSys.UserInterface.Windows.Properties.Resources._1341504165_gnome_searchtool;
            this.buttonPesquisarCEP1.Location = new System.Drawing.Point(134, 16);
            this.buttonPesquisarCEP1.Name = "buttonPesquisarCEP1";
            this.buttonPesquisarCEP1.Size = new System.Drawing.Size(22, 20);
            this.buttonPesquisarCEP1.TabIndex = 10;
            this.buttonPesquisarCEP1.UseVisualStyleBackColor = true;
            // 
            // maskedCep1
            // 
            this.maskedCep1.Location = new System.Drawing.Point(48, 16);
            this.maskedCep1.Mask = "00000-000";
            this.maskedCep1.Name = "maskedCep1";
            this.maskedCep1.Size = new System.Drawing.Size(80, 20);
            this.maskedCep1.TabIndex = 8;
            this.maskedCep1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCep1
            // 
            this.labelCep1.AutoSize = true;
            this.labelCep1.Location = new System.Drawing.Point(12, 20);
            this.labelCep1.Name = "labelCep1";
            this.labelCep1.Size = new System.Drawing.Size(31, 13);
            this.labelCep1.TabIndex = 9;
            this.labelCep1.Text = "CEP:";
            // 
            // groupBoxEndereco2
            // 
            this.groupBoxEndereco2.Controls.Add(this.comboBoxTipoEnd2);
            this.groupBoxEndereco2.Controls.Add(this.textNumero2);
            this.groupBoxEndereco2.Controls.Add(this.labelNumero2);
            this.groupBoxEndereco2.Controls.Add(this.labelCidade2);
            this.groupBoxEndereco2.Controls.Add(this.comboCidade2);
            this.groupBoxEndereco2.Controls.Add(this.labelEstado2);
            this.groupBoxEndereco2.Controls.Add(this.comboBoxEstado2);
            this.groupBoxEndereco2.Controls.Add(this.textBairro2);
            this.groupBoxEndereco2.Controls.Add(this.label6);
            this.groupBoxEndereco2.Controls.Add(this.textEndereco2);
            this.groupBoxEndereco2.Controls.Add(this.labelEndereco2);
            this.groupBoxEndereco2.Controls.Add(this.labelTipoEnd2);
            this.groupBoxEndereco2.Controls.Add(this.buttonPesquisarCep2);
            this.groupBoxEndereco2.Controls.Add(this.maskedCep2);
            this.groupBoxEndereco2.Controls.Add(this.labelCep2);
            this.groupBoxEndereco2.Location = new System.Drawing.Point(13, 377);
            this.groupBoxEndereco2.Name = "groupBoxEndereco2";
            this.groupBoxEndereco2.Size = new System.Drawing.Size(474, 106);
            this.groupBoxEndereco2.TabIndex = 23;
            this.groupBoxEndereco2.TabStop = false;
            this.groupBoxEndereco2.Text = "Endereço";
            // 
            // textNumero2
            // 
            this.textNumero2.Location = new System.Drawing.Point(414, 42);
            this.textNumero2.Name = "textNumero2";
            this.textNumero2.Size = new System.Drawing.Size(54, 20);
            this.textNumero2.TabIndex = 22;
            // 
            // labelNumero2
            // 
            this.labelNumero2.AutoSize = true;
            this.labelNumero2.Location = new System.Drawing.Point(388, 46);
            this.labelNumero2.Name = "labelNumero2";
            this.labelNumero2.Size = new System.Drawing.Size(20, 13);
            this.labelNumero2.TabIndex = 21;
            this.labelNumero2.Text = "nº:";
            // 
            // labelCidade2
            // 
            this.labelCidade2.AutoSize = true;
            this.labelCidade2.Location = new System.Drawing.Point(277, 73);
            this.labelCidade2.Name = "labelCidade2";
            this.labelCidade2.Size = new System.Drawing.Size(43, 13);
            this.labelCidade2.TabIndex = 20;
            this.labelCidade2.Text = "Estado:";
            // 
            // comboCidade2
            // 
            this.comboCidade2.FormattingEnabled = true;
            this.comboCidade2.Location = new System.Drawing.Point(326, 69);
            this.comboCidade2.Name = "comboCidade2";
            this.comboCidade2.Size = new System.Drawing.Size(142, 21);
            this.comboCidade2.TabIndex = 19;
            // 
            // labelEstado2
            // 
            this.labelEstado2.AutoSize = true;
            this.labelEstado2.Location = new System.Drawing.Point(166, 73);
            this.labelEstado2.Name = "labelEstado2";
            this.labelEstado2.Size = new System.Drawing.Size(43, 13);
            this.labelEstado2.TabIndex = 18;
            this.labelEstado2.Text = "Estado:";
            // 
            // comboBoxEstado2
            // 
            this.comboBoxEstado2.FormattingEnabled = true;
            this.comboBoxEstado2.Location = new System.Drawing.Point(215, 69);
            this.comboBoxEstado2.Name = "comboBoxEstado2";
            this.comboBoxEstado2.Size = new System.Drawing.Size(56, 21);
            this.comboBoxEstado2.TabIndex = 17;
            // 
            // textBairro2
            // 
            this.textBairro2.Location = new System.Drawing.Point(68, 69);
            this.textBairro2.Name = "textBairro2";
            this.textBairro2.Size = new System.Drawing.Size(92, 20);
            this.textBairro2.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bairro:";
            // 
            // textEndereco2
            // 
            this.textEndereco2.Location = new System.Drawing.Point(228, 42);
            this.textEndereco2.Name = "textEndereco2";
            this.textEndereco2.Size = new System.Drawing.Size(154, 20);
            this.textEndereco2.TabIndex = 14;
            // 
            // labelEndereco2
            // 
            this.labelEndereco2.AutoSize = true;
            this.labelEndereco2.Location = new System.Drawing.Point(166, 46);
            this.labelEndereco2.Name = "labelEndereco2";
            this.labelEndereco2.Size = new System.Drawing.Size(56, 13);
            this.labelEndereco2.TabIndex = 13;
            this.labelEndereco2.Text = "Endereço:";
            // 
            // labelTipoEnd2
            // 
            this.labelTipoEnd2.AutoSize = true;
            this.labelTipoEnd2.Location = new System.Drawing.Point(6, 46);
            this.labelTipoEnd2.Name = "labelTipoEnd2";
            this.labelTipoEnd2.Size = new System.Drawing.Size(56, 13);
            this.labelTipoEnd2.TabIndex = 12;
            this.labelTipoEnd2.Text = "Tipo End.:";
            // 
            // buttonPesquisarCep2
            // 
            this.buttonPesquisarCep2.Image = global::RDev.ToolsSys.UserInterface.Windows.Properties.Resources._1341504165_gnome_searchtool;
            this.buttonPesquisarCep2.Location = new System.Drawing.Point(134, 15);
            this.buttonPesquisarCep2.Name = "buttonPesquisarCep2";
            this.buttonPesquisarCep2.Size = new System.Drawing.Size(22, 20);
            this.buttonPesquisarCep2.TabIndex = 10;
            this.buttonPesquisarCep2.UseVisualStyleBackColor = true;
            // 
            // maskedCep2
            // 
            this.maskedCep2.Location = new System.Drawing.Point(48, 16);
            this.maskedCep2.Mask = "00000-000";
            this.maskedCep2.Name = "maskedCep2";
            this.maskedCep2.Size = new System.Drawing.Size(80, 20);
            this.maskedCep2.TabIndex = 8;
            this.maskedCep2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCep2
            // 
            this.labelCep2.AutoSize = true;
            this.labelCep2.Location = new System.Drawing.Point(12, 20);
            this.labelCep2.Name = "labelCep2";
            this.labelCep2.Size = new System.Drawing.Size(31, 13);
            this.labelCep2.TabIndex = 9;
            this.labelCep2.Text = "CEP:";
            // 
            // groupBoxOutros
            // 
            this.groupBoxOutros.Controls.Add(this.maskedNascimento);
            this.groupBoxOutros.Controls.Add(this.labelNascimento);
            this.groupBoxOutros.Controls.Add(this.labelEstadoCivil);
            this.groupBoxOutros.Controls.Add(this.comboBoxEstadoCivil);
            this.groupBoxOutros.Location = new System.Drawing.Point(13, 489);
            this.groupBoxOutros.Name = "groupBoxOutros";
            this.groupBoxOutros.Size = new System.Drawing.Size(473, 51);
            this.groupBoxOutros.TabIndex = 24;
            this.groupBoxOutros.TabStop = false;
            this.groupBoxOutros.Text = "Outras Informaçoes";
            // 
            // maskedNascimento
            // 
            this.maskedNascimento.Location = new System.Drawing.Point(334, 19);
            this.maskedNascimento.Mask = "00/00/0000";
            this.maskedNascimento.Name = "maskedNascimento";
            this.maskedNascimento.Size = new System.Drawing.Size(127, 20);
            this.maskedNascimento.TabIndex = 26;
            this.maskedNascimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNascimento
            // 
            this.labelNascimento.AutoSize = true;
            this.labelNascimento.Location = new System.Drawing.Point(224, 23);
            this.labelNascimento.Name = "labelNascimento";
            this.labelNascimento.Size = new System.Drawing.Size(107, 13);
            this.labelNascimento.TabIndex = 25;
            this.labelNascimento.Text = "Data de Nascimento:";
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(12, 23);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.labelEstadoCivil.TabIndex = 24;
            this.labelEstadoCivil.Text = "Estado Civil:";
            // 
            // comboBoxEstadoCivil
            // 
            this.comboBoxEstadoCivil.FormattingEnabled = true;
            this.comboBoxEstadoCivil.Location = new System.Drawing.Point(83, 19);
            this.comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            this.comboBoxEstadoCivil.Size = new System.Drawing.Size(127, 21);
            this.comboBoxEstadoCivil.TabIndex = 23;
            // 
            // radioButtonFeminino
            // 
            this.radioButtonFeminino.AutoSize = true;
            this.radioButtonFeminino.Location = new System.Drawing.Point(19, 41);
            this.radioButtonFeminino.Name = "radioButtonFeminino";
            this.radioButtonFeminino.Size = new System.Drawing.Size(67, 17);
            this.radioButtonFeminino.TabIndex = 2;
            this.radioButtonFeminino.TabStop = true;
            this.radioButtonFeminino.Text = "Feminino";
            this.radioButtonFeminino.UseVisualStyleBackColor = true;
            // 
            // radioButtonMasculino
            // 
            this.radioButtonMasculino.AutoSize = true;
            this.radioButtonMasculino.Location = new System.Drawing.Point(19, 18);
            this.radioButtonMasculino.Name = "radioButtonMasculino";
            this.radioButtonMasculino.Size = new System.Drawing.Size(73, 17);
            this.radioButtonMasculino.TabIndex = 0;
            this.radioButtonMasculino.TabStop = true;
            this.radioButtonMasculino.Text = "Masculino";
            this.radioButtonMasculino.UseVisualStyleBackColor = true;
            // 
            // openFileDialogSalvarFoto
            // 
            this.openFileDialogSalvarFoto.FileName = "openFileDialog1";
            this.openFileDialogSalvarFoto.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSalvarFoto_FileOk);
            // 
            // pictureBoxFoto3por4
            // 
            this.pictureBoxFoto3por4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxFoto3por4.BackgroundImage = global::RDev.ToolsSys.UserInterface.Windows.Properties.Resources._1341505661_Black_Camera;
            this.pictureBoxFoto3por4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxFoto3por4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto3por4.Location = new System.Drawing.Point(12, 28);
            this.pictureBoxFoto3por4.Name = "pictureBoxFoto3por4";
            this.pictureBoxFoto3por4.Size = new System.Drawing.Size(105, 130);
            this.pictureBoxFoto3por4.TabIndex = 2;
            this.pictureBoxFoto3por4.TabStop = false;
            // 
            // groupBoxSexo
            // 
            this.groupBoxSexo.Controls.Add(this.radioButtonMasculino);
            this.groupBoxSexo.Controls.Add(this.radioButtonFeminino);
            this.groupBoxSexo.Location = new System.Drawing.Point(13, 193);
            this.groupBoxSexo.Name = "groupBoxSexo";
            this.groupBoxSexo.Size = new System.Drawing.Size(115, 66);
            this.groupBoxSexo.TabIndex = 25;
            this.groupBoxSexo.TabStop = false;
            this.groupBoxSexo.Text = "Sexo";
            // 
            // labelCadastroCliente
            // 
            this.labelCadastroCliente.AutoSize = true;
            this.labelCadastroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCadastroCliente.Location = new System.Drawing.Point(162, 29);
            this.labelCadastroCliente.Name = "labelCadastroCliente";
            this.labelCadastroCliente.Size = new System.Drawing.Size(307, 33);
            this.labelCadastroCliente.TabIndex = 14;
            this.labelCadastroCliente.Text = "Cadastro de Clientes";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(176, 60);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(52, 20);
            this.textBoxId.TabIndex = 27;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(132, 63);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 13);
            this.labelId.TabIndex = 26;
            this.labelId.Text = "ID:";
            // 
            // comboBoxTipoEnd2
            // 
            this.comboBoxTipoEnd2.FormattingEnabled = true;
            this.comboBoxTipoEnd2.Location = new System.Drawing.Point(68, 42);
            this.comboBoxTipoEnd2.Name = "comboBoxTipoEnd2";
            this.comboBoxTipoEnd2.Size = new System.Drawing.Size(92, 21);
            this.comboBoxTipoEnd2.TabIndex = 23;
            // 
            // maskedTextBoxDataCadastrado
            // 
            this.maskedTextBoxDataCadastrado.Location = new System.Drawing.Point(333, 60);
            this.maskedTextBoxDataCadastrado.Mask = "00/00/0000 00:00:00";
            this.maskedTextBoxDataCadastrado.Name = "maskedTextBoxDataCadastrado";
            this.maskedTextBoxDataCadastrado.Size = new System.Drawing.Size(153, 20);
            this.maskedTextBoxDataCadastrado.TabIndex = 28;
            this.maskedTextBoxDataCadastrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDataCadastro
            // 
            this.labelDataCadastro.AutoSize = true;
            this.labelDataCadastro.Location = new System.Drawing.Point(234, 63);
            this.labelDataCadastro.Name = "labelDataCadastro";
            this.labelDataCadastro.Size = new System.Drawing.Size(93, 13);
            this.labelDataCadastro.TabIndex = 27;
            this.labelDataCadastro.Text = "Data de Cadastro:";
            // 
            // CadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 548);
            this.Controls.Add(this.maskedTextBoxDataCadastrado);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelDataCadastro);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelCadastroCliente);
            this.Controls.Add(this.groupBoxSexo);
            this.Controls.Add(this.groupBoxOutros);
            this.Controls.Add(this.groupBoxEndereco2);
            this.Controls.Add(this.groupBoxEndereco1);
            this.Controls.Add(this.groupBoxContato);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.buttonSalvarFoto);
            this.Controls.Add(this.pictureBoxFoto3por4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxDocumento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastroCliente";
            this.Text = "CadastroCliente";
            this.Load += new System.EventHandler(this.CadastroCliente_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxDocumento.ResumeLayout(false);
            this.groupBoxDocumento.PerformLayout();
            this.groupBoxContato.ResumeLayout(false);
            this.groupBoxContato.PerformLayout();
            this.groupBoxEndereco1.ResumeLayout(false);
            this.groupBoxEndereco1.PerformLayout();
            this.groupBoxEndereco2.ResumeLayout(false);
            this.groupBoxEndereco2.PerformLayout();
            this.groupBoxOutros.ResumeLayout(false);
            this.groupBoxOutros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto3por4)).EndInit();
            this.groupBoxSexo.ResumeLayout(false);
            this.groupBoxSexo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonNovo;
        private System.Windows.Forms.ToolStripButton ButtonSalvar;
        private System.Windows.Forms.ToolStripButton ButtonImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton ButtonHelp;
        private System.Windows.Forms.PictureBox pictureBoxFoto3por4;
        private System.Windows.Forms.Button buttonSalvarFoto;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.GroupBox groupBoxDocumento;
        private System.Windows.Forms.Label labelRG;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.MaskedTextBox maskedCpf;
        private System.Windows.Forms.GroupBox groupBoxContato;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCel;
        private System.Windows.Forms.MaskedTextBox maskedFax;
        private System.Windows.Forms.MaskedTextBox maskedCel;
        private System.Windows.Forms.Label labelTelCom;
        private System.Windows.Forms.MaskedTextBox maskedTelRes;
        private System.Windows.Forms.Label labelTelRes;
        private System.Windows.Forms.MaskedTextBox maskedTelCom;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.GroupBox groupBoxEndereco1;
        private System.Windows.Forms.TextBox textNumero1;
        private System.Windows.Forms.Label labelNumero1;
        private System.Windows.Forms.Label labelCidade1;
        private System.Windows.Forms.ComboBox comboCidade1;
        private System.Windows.Forms.Label labelEstado1;
        private System.Windows.Forms.ComboBox comboBoxEstado1;
        private System.Windows.Forms.TextBox textBairro1;
        private System.Windows.Forms.Label labelBairro1;
        private System.Windows.Forms.TextBox textEndereco1;
        private System.Windows.Forms.Label labelEndereco1;
        private System.Windows.Forms.Label labelTipoEnd1;
        private System.Windows.Forms.ComboBox comboBoxTipoEnd1;
        private System.Windows.Forms.Button buttonPesquisarCEP1;
        private System.Windows.Forms.MaskedTextBox maskedCep1;
        private System.Windows.Forms.Label labelCep1;
        private System.Windows.Forms.GroupBox groupBoxEndereco2;
        private System.Windows.Forms.TextBox textNumero2;
        private System.Windows.Forms.Label labelNumero2;
        private System.Windows.Forms.Label labelCidade2;
        private System.Windows.Forms.ComboBox comboCidade2;
        private System.Windows.Forms.Label labelEstado2;
        private System.Windows.Forms.ComboBox comboBoxEstado2;
        private System.Windows.Forms.TextBox textBairro2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textEndereco2;
        private System.Windows.Forms.Label labelEndereco2;
        private System.Windows.Forms.Label labelTipoEnd2;
        private System.Windows.Forms.Button buttonPesquisarCep2;
        private System.Windows.Forms.MaskedTextBox maskedCep2;
        private System.Windows.Forms.Label labelCep2;
        private System.Windows.Forms.GroupBox groupBoxOutros;
        private System.Windows.Forms.MaskedTextBox maskedNascimento;
        private System.Windows.Forms.Label labelNascimento;
        private System.Windows.Forms.Label labelEstadoCivil;
        private System.Windows.Forms.RadioButton radioButtonFeminino;
        private System.Windows.Forms.ComboBox comboBoxEstadoCivil;
        private System.Windows.Forms.RadioButton radioButtonMasculino;
        private System.Windows.Forms.OpenFileDialog openFileDialogSalvarFoto;
        private System.Windows.Forms.GroupBox groupBoxSexo;
        private System.Windows.Forms.Label labelCadastroCliente;
        private System.Windows.Forms.TextBox textRg;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
        private ComboBox comboBoxTipoEnd2;
        private MaskedTextBox maskedTextBoxDataCadastrado;
        private Label labelDataCadastro;
    }
}