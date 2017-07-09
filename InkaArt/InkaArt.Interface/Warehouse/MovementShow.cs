using InkaArt.Business.Sales;
using InkaArt.Business.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Warehouse
{
    public partial class MovementShow : Form
    {

        MovementController movement_controller;
        DataRow movement;

        public MovementShow()
        {
            InitializeComponent();
        }

        public MovementShow(string id)
        {
            InitializeComponent();

            movement_controller = new MovementController();
            DataTable movements = movement_controller.GetMovements(true, id);
            movement = movements.Rows[0];

            initializeComboType();
            initializeComboReason();
            initializeComboStatus();
            initializeComboDocType();
            initializeComboItemType();
            populateForm();
        }

        private void initializeComboType()
        {
            MovementTypeController type_controller = new MovementTypeController();
            DataTable types = type_controller.GetMovementTypes();
            combobox_type.DataSource = types;
            combobox_type.DisplayMember = "description";
            combobox_type.ValueMember = "idMovementType";
            combobox_type.SelectedValue = -1;
        }

        private void initializeComboReason()
        {
            MovementReasonController reason_controller = new MovementReasonController();
            DataTable types = reason_controller.GetMovementReasons();
            combobox_reason.DataSource = types;
            combobox_reason.DisplayMember = "description";
            combobox_reason.ValueMember = "idMovName";
            combobox_reason.SelectedValue = -1;
        }

        private void initializeComboDocType()
        {
            DocumentTypeController type_controller = new DocumentTypeController();
            DataTable types = type_controller.GetDocumentTypes();
            combobox_doc_type.DataSource = types;
            combobox_doc_type.DisplayMember = "nombre";
            combobox_doc_type.ValueMember = "idTipoDocumento";
        }

        private void initializeComboStatus()
        {
            Dictionary<int, string> statuses = new Dictionary<int, string>();
            statuses.Add(1, "Activo");
            statuses.Add(0, "Inactivo");
            combobox_status.DataSource = new BindingSource(statuses, null);
            combobox_status.DisplayMember = "Value";
            combobox_status.ValueMember = "Key";
            combobox_status.SelectedValue = -1;
        }

        private void initializeComboItemType()
        {
            Dictionary<int, string> types = new Dictionary<int, string>();
            types.Add(0, "Materia Prima");
            types.Add(1, "Producto");
        }

        private void populateForm()
        {
            int typeMov = Int32.Parse(movement["idMovementType"].ToString());
            // movement
            combobox_reason.SelectedValue = movement["idMovementReason"].ToString();
            combobox_type.SelectedValue = movement["idMovementType"].ToString();
            combobox_status.SelectedValue = int.Parse(movement["status"].ToString());
            textbox_date.Text = movement["dateIn"].ToString();
            // document
            int id_doc_type;
            if (int.TryParse(movement["idDocumentType"].ToString(), out id_doc_type))
                combobox_doc_type.SelectedValue = id_doc_type;
            textbox_doc_number.Text = movement["idBill"].ToString() == "" ? movement["idNote"].ToString() : movement["idBill"].ToString();

            if (typeMov == 2) //entrada
            {
                textbox_warehouse_idO.Text = "-";
                textbox_warehouse_nameO.Text = "-";
                textbox_warehouse_idD.Text = movement["idWarehouse"].ToString();
                textbox_warehouse_nameD.Text = movement_controller.getWarehouseName(textbox_warehouse_idD.Text);
            } else if (typeMov == 13) //salida
            {
                textbox_warehouse_idD.Text = "-";
                textbox_warehouse_nameD.Text = "-";
                textbox_warehouse_idO.Text = movement["idWarehouse"].ToString();
                textbox_warehouse_nameO.Text = movement_controller.getWarehouseName(textbox_warehouse_idO.Text);
            } else //entrada-salida
            {
                // warehouse
                textbox_warehouse_idO.Text = movement["idWarehouse"].ToString();
                textbox_warehouse_nameO.Text = movement_controller.getWarehouseName(textbox_warehouse_idO.Text);
                textbox_warehouse_idD.Text = movement["idWarehouseDestiny"].ToString();
                if (textbox_warehouse_idD.Text != "")
                    textbox_warehouse_nameD.Text = movement_controller.getWarehouseName(textbox_warehouse_idD.Text);
            }
            
            // product
            int item_type;
            if (int.TryParse(movement["itemType"].ToString(), out item_type))
            {
                if (item_type == 0)
                    groupBox_item.Text = "Materia Prima";
                else
                    groupBox_item.Text = "Producto";
                textbox_item_name.Text = movement_controller.getItemName(item_type, movement["idItem"].ToString());
                textbox_quantity.Text = movement["quantity"].ToString();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void combobox_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
