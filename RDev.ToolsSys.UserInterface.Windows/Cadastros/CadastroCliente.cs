using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDev.ToolsSys.Business.Help;
using RDev.ToolsSys.Business.Pessoas.Entidade;
using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.UserInterface.Windows.Cadastros
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            var tipoEstadoCivils = new List<TipoEstadoCivil>
                                       {
                                           TipoEstadoCivil.CASADO,
                                           TipoEstadoCivil.SOLTEIRO,
                                           TipoEstadoCivil.VIUVO,
                                           TipoEstadoCivil.OUTROS
                                       };
            comboBoxEstadoCivil.DataSource = tipoEstadoCivils;
            comboBoxEstadoCivil.SelectedIndex = -1;

            var TipoEnderecos = new List<TipoEndereco>
                                        {
                                            TipoEndereco.COMERCIAL, 
                                            TipoEndereco.RESIDENCIAL
                                        };
            comboBoxTipoEnd1.DataSource = TipoEnderecos;
            comboBoxTipoEnd1.SelectedIndex = -1;

            TipoEnderecos = new List<TipoEndereco>
                                        {
                                            TipoEndereco.COMERCIAL, 
                                            TipoEndereco.RESIDENCIAL
                                        };
            comboBoxTipoEnd2.DataSource = TipoEnderecos;
            comboBoxTipoEnd2.SelectedIndex = -1;
        }

        private void buttonSalvarFoto_Click(object sender, EventArgs e)
        {
            openFileDialogSalvarFoto.ShowDialog();
            MessageBox.Show(@"Foto Carregada com Sucesso!", @"Cadastrar Foto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openFileDialogSalvarFoto_FileOk(object sender, CancelEventArgs e)
        {
            var file = (OpenFileDialog)sender;
            pictureBoxFoto3por4.BackgroundImage = null;
            pictureBoxFoto3por4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxFoto3por4.BackgroundImage = new Bitmap(file.OpenFile());
        }

        #region Salvar o Cliente
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            CadastrarCliente();
        }

        private void CadastrarCliente()
        {
            try
            {
                var pessoa = new Pessoa();

                pessoa.Nome = textBoxNome.Text;
                pessoa.Nascimento = Convert.ToDateTime(maskedNascimento.Text);
                pessoa.TipoSexo = radioButtonMasculino.Checked ? TipoSexo.Masculino : TipoSexo.Feminino;

                AdicionarDocumentos(pessoa);
                AdicionarEnderecos(pessoa);
                AdicionarContatos(pessoa);

                pessoa.TipoEstadoCivil = (TipoEstadoCivil)comboBoxEstadoCivil.SelectedItem;

                pessoa.Cadastrado = DateTime.Now;

                pessoa.ValidarDados();
            }
            catch (CamposObrigatoriosNaoPreenchidosException exception)
            {
                MessageBox.Show(CamposObrigatorios(exception), @"Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarDocumentos(Pessoa pessoa)
        {
            pessoa.Documentos.Add(new Documento { Numero = maskedCpf.Text, TipoDocumento = TipoDocumento.CPF });
            pessoa.Documentos.Add(new Documento { Numero = textRg.Text, TipoDocumento = TipoDocumento.RG });
        }

        private void AdicionarEnderecos(Pessoa pessoa)
        {
            var endereco = new Endereco();
            endereco.Cep = maskedCep1.Text;
            endereco.Cidade = comboCidade1.SelectedText;
            endereco.Estado = comboBoxEstado1.SelectedText;
            endereco.Logradouro = textEndereco1.Text;
            endereco.Numero = textNumero1.Text;
            endereco.TipoEndereco = (TipoEndereco)comboBoxTipoEnd1.SelectedItem;
            pessoa.Enderecos.Add(endereco);

            endereco = new Endereco();
            endereco.Cep = maskedCep2.Text;
            endereco.Cidade = comboCidade2.Text;
            endereco.Estado = comboBoxEstado2.Text;
            endereco.Logradouro = textEndereco2.Text;
            endereco.Numero = textNumero2.Text;
            endereco.TipoEndereco = (TipoEndereco)comboBoxTipoEnd2.SelectedItem;
            pessoa.Enderecos.Add(endereco);
        }

        private void AdicionarContatos(Pessoa pessoa)
        {
            if (pessoa == null) throw new ArgumentNullException("pessoa");
            var contato = new Contato();
            contato.Numero = maskedTelCom.Text;
            contato.TipoContato = TipoContato.COMERCIAL;
            contato.Email = string.Empty;
            pessoa.Contatos.Add(contato);

            contato = new Contato();
            contato.Numero = maskedTelRes.Text;
            contato.TipoContato = TipoContato.RESIDENCIAL;
            contato.Email = string.Empty;
            pessoa.Contatos.Add(contato);

            contato = new Contato();
            contato.Numero = maskedFax.Text;
            contato.TipoContato = TipoContato.FAX;
            contato.Email = string.Empty;
            pessoa.Contatos.Add(contato);

            contato = new Contato();
            contato.Numero = maskedCel.Text;
            contato.TipoContato = TipoContato.CELULAR;
            contato.Email = string.Empty;
            pessoa.Contatos.Add(contato);

            contato = new Contato();
            contato.Email = textBoxEmail.Text;
            contato.TipoContato = TipoContato.EMAIL;
            contato.Numero = string.Empty;
            pessoa.Contatos.Add(contato);
        }
        #endregion

        private string CamposObrigatorios(CamposObrigatoriosNaoPreenchidosException exception)
        {
            var campos = new StringBuilder(exception.Message + Environment.NewLine);
            foreach (var value in exception.campos)
            {
                campos.Append(value.Key + Environment.NewLine);
            }
            return campos.ToString();
        }
    }
}
