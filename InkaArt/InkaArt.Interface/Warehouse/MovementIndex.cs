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
    public partial class MovementIndex : Form
    {

        private MovementController movement_controller = new MovementController();

        public MovementIndex()
        {
            InitializeComponent();
        }

        private void updateDataGrid()
        {
            DataTable orderList = movement_controller.GetMovements();
            populateDataGrid(orderList);
        }

        private void populateDataGrid(DataTable movement_list)
        {
            data_grid_movements.Rows.Clear();
            foreach (DataRow row in movement_list.Rows)
            {
                string type = movement_controller.getTypeDescription(row["idMovementType"].ToString());
                string reason = movement_controller.getReasonDescription(row["idMovementReason"].ToString());
                string warehouse = movement_controller.getWarehouseName(row["idWarehouse"].ToString());
                // warehouse_destiny
                string movement_date = row["dateIn"].ToString();
                data_grid_movements.Rows.Add(row["idMovement"], type, reason, warehouse, movement_date);
            }
        }

        private void populateComboType()
        {
            MovementTypeController type_controller = new MovementTypeController();
            DataTable types = type_controller.GetMovementTypes();
            combobox_type.DataSource = types;
            combobox_type.DisplayMember = "description";
            combobox_type.ValueMember = "idMovementType";
        }

        private void populateComboReason()
        {
            MovementTypeController type_controller = new MovementTypeController();
            DataTable types = type_controller.GetMovementTypes();
            combobox_type.DataSource = types;
            combobox_type.DisplayMember = "description";
            combobox_type.ValueMember = "idMovementType";
        }

        private void MovementIndex_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSearchClick(object sender, EventArgs e)
        {
            DataTable filtered = movement_controller.GetMovements(textbox_id.Text, combobox_type.SelectedValue.ToString(), combobox_reason.SelectedValue.ToString(), combobox_warehouse.SelectedValue.ToString(), datetime_movement.Value.ToString(), combobox_status.Text);
            populateDataGrid(filtered);
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {

        }

        private void ButtonCreateClick(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void combobox_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void date_movement_DropDown(object sender, EventArgs e)
        {

        }
    }
}
