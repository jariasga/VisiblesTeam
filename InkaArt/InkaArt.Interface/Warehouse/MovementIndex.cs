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

        private void MovementIndex_Load(object sender, EventArgs e)
        {
            datetime_movement.Checked = false;
            datetime_movement.AllowDrop = false;
            initializeComboType();
            //initializeComboReason();
            initializeComboWarehouse();
            initializeComboStatus();            
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DataTable movements = movement_controller.GetMovements();
            populateDataGrid(movements);
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
            //DataTable types = reason_controller.GetMovementReasons();
            //combobox_reason.DataSource = types;
            combobox_reason.DisplayMember = "description";
            combobox_reason.ValueMember = "idMovName";
            combobox_reason.SelectedValue = -1;
        }

        private void initializeComboWarehouse()
        {
            WarehouseCrud warehouse_controller = new WarehouseCrud();
            DataTable warehouses = warehouse_controller.GetWarehouses();
            combobox_warehouse.DataSource = warehouses;
            combobox_warehouse.DisplayMember = "name";
            combobox_warehouse.ValueMember = "idWarehouse";
            combobox_warehouse.SelectedValue = -1;
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
        
        private void ButtonSearchClick(object sender, EventArgs e)
        {
            string date = datetime_movement.Checked ? datetime_movement.Value.ToShortDateString() : null;
            DataTable filtered = movement_controller.GetMovements(true, textbox_id.Text, getComboString(combobox_type), getComboString(combobox_reason), getComboString(combobox_warehouse), date, getComboString(combobox_status));
            populateDataGrid(filtered);
        }

        private string getComboString(ComboBox combo)
        {
            return combo.SelectedValue != null ? combo.SelectedValue.ToString() : "-1";
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            List<string> ids = new List<string>();
            int registros = data_grid_movements.Rows.Count;

            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(data_grid_movements.Rows[i].Cells[5].Value) == true)
                    ids.Add(data_grid_movements.Rows[i].Cells[0].Value.ToString());
            }
            movement_controller.deleteMovements(ids);
            updateDataGrid();

            MessageBox.Show("Almacenes eliminados", "Eliminar almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

        }

        private void ButtonCreateClick(object sender, EventArgs e)
        {
            var create_date = new Movements();
            var result = create_date.ShowDialog();
            if (result == DialogResult.OK)
                updateDataGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void combobox_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void datetimeMovementValueChanged(object sender, EventArgs e)
        {
            if (datetime_movement.Checked)
                datetime_movement.AllowDrop = true;
            else
                datetime_movement.AllowDrop = false;
        }

        private void dataGridMovementsCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data_grid_movements.Rows.Count > 0)
            {
                string id = data_grid_movements.Rows[e.RowIndex].Cells[0].Value.ToString();
                var show_form = new MovementShow(id);
                var result = show_form.ShowDialog();
                if (result == DialogResult.OK)
                    updateDataGrid();
            }
        }
    }
}
