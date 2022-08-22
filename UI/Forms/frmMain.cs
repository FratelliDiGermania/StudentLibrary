using JT.UniStuttgart.StudentLibrary.Client.UI;
using JT.UniStuttgart.StudentLibrary.Views.InterfacesManager;
using JT.UniStuttgart.StudentLibrary.Logic.DBManagement.Presenter.PresenterManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JT.UniStuttgart.StudentLibrary.Client.UI
{
    public partial class frmMain : Form, IStudent
    {
        StudentPresenter Presenter { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }
        public string IdText
        {
            get
            {
                return tbID.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    throw new ArgumentOutOfRangeException();
                }
                tbID.Text = value;
            }
        }
        public string NameText
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(tbName.Text))
                {
                    throw new ArgumentOutOfRangeException();
                }
                tbName.Text = value;
            }
        }
        public string AddressText
        {
            get
            {
                return tbAddress.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                {
                    throw new ArgumentOutOfRangeException();
                }
                tbAddress.Text = value;
            }
        }
        public string PhoneText
        {
            get
            {
                return tbPhone.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(tbPhone.Text))
                {
                    throw new ArgumentOutOfRangeException();
                }
                tbPhone.Text = value;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Presenter = new StudentPresenter(this);
            UIManager.FitDatagridview(dgvStudent);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UIManager.VerifyInputs(this);
            Presenter = new StudentPresenter(this);
            Presenter.AddStudent();
            Presenter.GetStudent();
        }
    }
}
