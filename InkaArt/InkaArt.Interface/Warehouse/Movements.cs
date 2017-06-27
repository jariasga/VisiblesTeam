using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class Movements : Form
    {
        private ReasonMovementController reasonMovementController = new ReasonMovementController();
        private TypeMovementController typeMovementController = new TypeMovementController();

        public Movements()
        {
            InitializeComponent();
        }

        private void buttonAceptClick(object sender, EventArgs e)
        {
            string reason = combobox_reason.Text;

            if(reason == "")
            {
                MessageBox.Show("Por favor ingrese una razon del movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (text_warehouse_id.Text == "")
            {
                MessageBox.Show("Por favor seleccione un almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nameWarehouseOrigin;
            string idWarehouesOrigin;
            nameWarehouseOrigin = text_warehouse.Text;
            idWarehouesOrigin = text_warehouse_id.Text;

            if (reason == "Produccion")
            {
                if(idWarehouesOrigin == "")
                {
                    MessageBox.Show("Por favor seleccione un almacén antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(combobox_type.Text == "")
                {
                    MessageBox.Show("Por favor ingrese un tpo de movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (combobox_type.Text == "Entrada")
                {
                    Form formView = new InkaArt.Interface.Warehouse.ProductionMovement(idWarehouesOrigin, nameWarehouseOrigin, combobox_type.Text);
                    formView.Show();
                }
                else
                {
                    if (combobox_type.Text == "Salida")
                    {

                        Form formView = new InkaArt.Interface.Warehouse.ProductionMovementOut(idWarehouesOrigin, nameWarehouseOrigin, combobox_type.Text);

                        formView.Show();
                    }
                }
                
            }
            else
            {
                if(reason == "Compra" && string.Compare(combobox_type.Text,"Entrada")==0)
                {
                    Form formView = new InkaArt.Interface.Warehouse.PurchaseMovement(text_warehouse_id.Text);
                    formView.Show();
                }
                else
                {
                    if (reason == "Venta")
                    {
                        Form formView = new InkaArt.Interface.Warehouse.SaleMovementcs(idWarehouesOrigin, nameWarehouseOrigin, combobox_type.Text);
                        formView.Show();
                    }
                    else
                    {
                        if (reason == "Traslado")
                        {
                            Form formView = new InkaArt.Interface.Warehouse.ExchangeMovement(idWarehouesOrigin, nameWarehouseOrigin, combobox_type.Text);
                            formView.Show();
                        }
                        else
                        {
                            if (reason == "Rotura")
                            {
                                //Form formView = new InkaArt.Interface.Warehouse.breakProduct(idWarehouesOrigin, nameWarehouseOrigin, comboBox1.Text);
                                Form formView = new InkaArt.Interface.Warehouse.BrokenItems(idWarehouesOrigin);
                                formView.Show();                            }
                            else  if (reason == "Hallazgo")
                            {
                                Form formView = new InkaArt.Interface.Warehouse.MovementFindIn(idWarehouesOrigin);
                                formView.Show();
                            }
                            else if(reason == "Diferencia de stock")
                            {
                                Form formView = new InkaArt.Interface.Warehouse.MovementForDifference(idWarehouesOrigin);
                                formView.Show();
                            }
                            else if (reason == "Devolución")
                            {
                                Form formView = new InkaArt.Interface.Warehouse.ReturnMovement(idWarehouesOrigin, nameWarehouseOrigin, combobox_type.Text);
                                formView.Show();
                            }
                            else MessageBox.Show("Por favor seleccione una razón válida de movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            //int a;
        }

        private void buttonSearchClick(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseSearchMovement(text_warehouse_id, text_warehouse);
            new_warehouse_window.Show();
        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Movements_Load(object sender, EventArgs e)
        {
            DataTable movementReasonList;
            DataTable movementTypeList;

            movementReasonList = reasonMovementController.GetReasonMovementList();
            foreach (DataRow row in movementReasonList.Rows)
            {
                combobox_reason.Items.Add(row["description"]);
            }

            movementTypeList = typeMovementController.GetTypeMovementList();
            foreach (DataRow row in movementTypeList.Rows)
            {
                combobox_type.Items.Add(row["description"]);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
