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
            combobox_item_type.DataSource = new BindingSource(types, null);
            combobox_item_type.DisplayMember = "Value";
            combobox_item_type.ValueMember = "Key";
        }

        private void populateForm()
        {
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
            // warehouse
            textbox_warehouse_id.Text = movement["idWarehouse"].ToString();
            textbox_warehouse_name.Text = movement_controller.getWarehouseName(textbox_warehouse_id.Text);
            textbox_warehouse_id_d.Text = movement["idWarehouseDestiny"].ToString();
            if (textbox_warehouse_id_d.Text != "")
                textbox_warehouse_name_d.Text = movement_controller.getWarehouseName(textbox_warehouse_id_d.Text);
            // product
            int item_type;
            if (int.TryParse(movement["itemType"].ToString(), out item_type))
            {
                combobox_item_type.SelectedValue = item_type;
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
