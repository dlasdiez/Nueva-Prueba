using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lavanderia
{
    public partial class frm_list : Form
    {
        public String ID;
        public String Name;
        private Definitions.FormType m_frm_type;
        private DataTable m_values;

        public frm_list(Definitions.FormType _form_type, DataTable _values)
        {
            InitializeComponent();

            m_frm_type = _form_type;
            m_values = _values;
        }

        private void frm_list_Load(object sender, EventArgs e)
        {
            switch (m_frm_type)
            {
                case Definitions.FormType.Terminal:
                    LoadTerminals();
                    break;
                case Definitions.FormType.Operator:
                    LoadOperators();
                    break;
                case Definitions.FormType.Customer:
                    LoadCustomers();
                    break;
                case Definitions.FormType.Families:
                    LoadFamilies();
                    break;     
                default:
                    break;
            }
        }

        private void LoadTerminals()
        {
            this.Text = "Listado de Terminales";
            this.dgv_list.DataSource = m_values;

            this.dgv_list.Columns[0].HeaderText = "Código";
            this.dgv_list.Columns[0].Width = 50;
            
            this.dgv_list.Columns[1].HeaderText = "Nombre";
            this.dgv_list.Columns[1].Width = this.dgv_list.Size.Width - this.dgv_list.Columns[0].Width - 100;
        }

        private void LoadOperators()
        {
            this.Text = "Listado de Operadores";
            this.dgv_list.DataSource = m_values;

            this.dgv_list.Columns[0].HeaderText = "Código";
            this.dgv_list.Columns[0].Width = 80;

            this.dgv_list.Columns[1].HeaderText = "Nombre";
            this.dgv_list.Columns[1].Width = this.dgv_list.Size.Width - this.dgv_list.Columns[0].Width - 100;
        }

        private void LoadCustomers()
        {
            this.Text = "Listado de Clientes";
            this.dgv_list.DataSource = m_values;

            this.dgv_list.Columns[0].HeaderText = "Código";
            this.dgv_list.Columns[0].Width = 150;

            this.dgv_list.Columns[1].HeaderText = "Nombre";
            this.dgv_list.Columns[1].Width = this.dgv_list.Size.Width - this.dgv_list.Columns[0].Width - 100;
        }

        private void LoadFamilies()
        {
            this.Text = "Listado de Familias";
            this.dgv_list.DataSource = m_values;

            this.dgv_list.Columns[0].HeaderText = "Código";
            this.dgv_list.Columns[0].Width = 150;

            //this.dgv_list.Columns[1].HeaderText = "Nombre";
            //this.dgv_list.Columns[1].Width = this.dgv_list.Size.Width - this.dgv_list.Columns[0].Width - 100;
        }

        private void dgv_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.ID = dgv_list.Rows[e.RowIndex].Cells[0].Value.ToString();

                switch (m_frm_type)
                {
                    case Definitions.FormType.Families:
                        this.Name = "";
                        break;
                    default:
                        this.Name = dgv_list.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                }
                this.Close();
            }
        }
    }
}
