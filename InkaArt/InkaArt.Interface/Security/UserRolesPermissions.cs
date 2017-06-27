using InkaArt.Business.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Security
{
    public partial class UserRolesPermissions : Form
    {
        RoleController role;
        DataTable table;
        public UserRolesPermissions()
        {
            InitializeComponent();
            role = new RoleController();

            listRoles();
            fillPermissions();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBoxNewRole.Text, "")) MessageBox.Show("Por favor, complete todos los campos", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool generalParameters, userList, roles, suppliers, rawMaterials, unitOfmeasure, purcharseOrder, finalProduct, productionProcess, productionTurn, workerAssignment, turnReport, productivityReport, clients, orders, generateReport, warehouse, movements, stockReport, kardexReport;
                //  Security
                generalParameters = returnCheckState(checkedListBoxPermissions.GetItemCheckState(0));
                userList = returnCheckState(checkedListBoxPermissions.GetItemCheckState(1));
                roles = returnCheckState(checkedListBoxPermissions.GetItemCheckState(2));
                //  Purcharse
                suppliers = returnCheckState(checkedListBoxPermissions.GetItemCheckState(3));
                rawMaterials = returnCheckState(checkedListBoxPermissions.GetItemCheckState(4));
                unitOfmeasure = returnCheckState(checkedListBoxPermissions.GetItemCheckState(5));
                purcharseOrder = returnCheckState(checkedListBoxPermissions.GetItemCheckState(6));
                //  Production
                finalProduct = returnCheckState(checkedListBoxPermissions.GetItemCheckState(7));
                productionProcess = returnCheckState(checkedListBoxPermissions.GetItemCheckState(8));
                productionTurn = returnCheckState(checkedListBoxPermissions.GetItemCheckState(9));
                workerAssignment = returnCheckState(checkedListBoxPermissions.GetItemCheckState(10));
                turnReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(11));
                productivityReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(12));
                //  Sales
                clients = returnCheckState(checkedListBoxPermissions.GetItemCheckState(13));
                orders = returnCheckState(checkedListBoxPermissions.GetItemCheckState(14));
                generateReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(15));
                //  Warehouse
                warehouse = returnCheckState(checkedListBoxPermissions.GetItemCheckState(16));
                movements = returnCheckState(checkedListBoxPermissions.GetItemCheckState(17));
                stockReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(18));
                kardexReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(19));

                if (filter() == 0)
                {
                    int verInserted = role.insertData(textBoxNewRole.Text, generalParameters, userList, roles,
                    suppliers, rawMaterials, unitOfmeasure, purcharseOrder,
                    finalProduct, productionProcess, productionTurn, workerAssignment, turnReport, productivityReport,
                    clients, orders, generateReport,
                    warehouse, movements, stockReport, kardexReport);
                    if (verInserted == 1) MessageBox.Show("Se creó el nuevo rol", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("El nombre del rol ya existe", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            textBoxNewRole.Text = "";
            listRoles();
        }

        private bool returnCheckState(CheckState check)
        {
            if ((int)check == 1) return true;
            else return false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBoxNewRole.Text, "")) MessageBox.Show("Por favor, complete todos los campos", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool generalParameters, userList, roles, suppliers, rawMaterials, unitOfmeasure, purcharseOrder, finalProduct, productionProcess, productionTurn, workerAssignment, turnReport, productivityReport, clients, orders, generateReport, warehouse, movements, stockReport, kardexReport;
                //  Security
                generalParameters = returnCheckState(checkedListBoxPermissions.GetItemCheckState(0));
                userList = returnCheckState(checkedListBoxPermissions.GetItemCheckState(1));
                roles = returnCheckState(checkedListBoxPermissions.GetItemCheckState(2));
                //  Purcharse
                suppliers = returnCheckState(checkedListBoxPermissions.GetItemCheckState(3));
                rawMaterials = returnCheckState(checkedListBoxPermissions.GetItemCheckState(4));
                unitOfmeasure = returnCheckState(checkedListBoxPermissions.GetItemCheckState(5));
                purcharseOrder = returnCheckState(checkedListBoxPermissions.GetItemCheckState(6));
                //  Production
                finalProduct = returnCheckState(checkedListBoxPermissions.GetItemCheckState(7));
                productionProcess = returnCheckState(checkedListBoxPermissions.GetItemCheckState(8));
                productionTurn = returnCheckState(checkedListBoxPermissions.GetItemCheckState(9));
                workerAssignment = returnCheckState(checkedListBoxPermissions.GetItemCheckState(10));
                turnReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(11));
                productivityReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(12));
                //  Sales
                clients = returnCheckState(checkedListBoxPermissions.GetItemCheckState(13));
                orders = returnCheckState(checkedListBoxPermissions.GetItemCheckState(14));
                generateReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(15));
                //  Warehouse
                warehouse = returnCheckState(checkedListBoxPermissions.GetItemCheckState(16));
                movements = returnCheckState(checkedListBoxPermissions.GetItemCheckState(17));
                stockReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(18));
                kardexReport = returnCheckState(checkedListBoxPermissions.GetItemCheckState(19));

                if ((filter() == 1 && string.Equals(textBoxNewRole.Text, comboBoxDescription.Text))|| filter() == 0)
                {
                    int verInserted = role.updateData(Convert.ToInt32(textBoxIDRole.Text), textBoxNewRole.Text, generalParameters, userList, roles,
                        suppliers, rawMaterials, unitOfmeasure, purcharseOrder,
                        finalProduct, productionProcess, productionTurn, workerAssignment, turnReport, productivityReport,
                        clients, orders, generateReport,
                        warehouse, movements, stockReport, kardexReport);
                    if (verInserted == 1) MessageBox.Show("Se guardó el rol", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("El nombre del rol ya existe", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                listRoles();
                comboBoxDescription.Text = textBoxNewRole.Text;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxIDRole.Text = table.Rows[comboBoxDescription.SelectedIndex]["id_role"].ToString();
            textBoxNewRole.Text = table.Rows[comboBoxDescription.SelectedIndex]["description"].ToString();
            fillPermissions();
        }

        private void listRoles()
        {
            table = role.showData();
            comboBoxDescription.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxDescription.Items.Add(table.Rows[i]["description"]);
            }
        }
        private void fillPermissions()
        {
            checkedListBoxPermissions.Items.Clear();
            if (string.Equals(textBoxIDRole.Text, ""))
            {
                //  Security
                checkedListBoxPermissions.Items.Add("1.  Parámetros generales", false);
                checkedListBoxPermissions.Items.Add("2.  Lista de usuarios", false);
                checkedListBoxPermissions.Items.Add("3.  Roles", false);
                //  Purchases
                checkedListBoxPermissions.Items.Add("4.  Proveedores", false);
                checkedListBoxPermissions.Items.Add("5.  Materia prima", false);
                checkedListBoxPermissions.Items.Add("6.  Unidades de medida", false);
                checkedListBoxPermissions.Items.Add("7.  Orden de compra", false);
                //  Production
                checkedListBoxPermissions.Items.Add("8.  Producto final", false);
                checkedListBoxPermissions.Items.Add("9.  Proceso de producción", false);
                checkedListBoxPermissions.Items.Add("10. Turnos de producción", false);
                checkedListBoxPermissions.Items.Add("11. Asignacion de trabajadores", false);
                checkedListBoxPermissions.Items.Add("12. Informe de turno", false);
                checkedListBoxPermissions.Items.Add("13. Reporte de productividad", false);
                //  Sales
                checkedListBoxPermissions.Items.Add("14. Clientes", false);
                checkedListBoxPermissions.Items.Add("15. Pedidos", false);
                checkedListBoxPermissions.Items.Add("16. Reporte de Ventas", false);
                //  Warehouse
                checkedListBoxPermissions.Items.Add("17. Almacenes", false);
                checkedListBoxPermissions.Items.Add("18. Gestión de movimientos", false);
                checkedListBoxPermissions.Items.Add("19. Reporte de Stocks", false);
                checkedListBoxPermissions.Items.Add("20. Reporte de Kardex", false);
            }
            else
            {
                DataRow row = role.getRoleRowbyID(Convert.ToInt32(textBoxIDRole.Text));

                //  Security
                checkedListBoxPermissions.Items.Add("1.  Parámetros generales", (bool)row["security_general_parameters"]);
                checkedListBoxPermissions.Items.Add("2.  Lista de usuarios", (bool)row["security_user_list"]);
                checkedListBoxPermissions.Items.Add("3.  Roles", (bool)row["security_roles"]);
                //  Purchases
                checkedListBoxPermissions.Items.Add("4.  Proveedores", (bool)row["purchases_suppliers"]);
                checkedListBoxPermissions.Items.Add("5.  Materia prima", (bool)row["purchases_raw_materials"]);
                checkedListBoxPermissions.Items.Add("6.  Unidades de medida", (bool)row["purchases_unit_of_measure"]);
                checkedListBoxPermissions.Items.Add("7.  Orden de compra", (bool)row["purchases_purchase_order"]);
                //  Production
                checkedListBoxPermissions.Items.Add("8.  Producto final", (bool)row["production_final_product"]);
                checkedListBoxPermissions.Items.Add("9.  Proceso de producción", (bool)row["production_production_process"]);
                checkedListBoxPermissions.Items.Add("10. Turnos de producción", (bool)row["production_production_turn"]);
                checkedListBoxPermissions.Items.Add("11. Asignacion de trabajadores", (bool)row["production_worker_assignment"]);
                checkedListBoxPermissions.Items.Add("12. Informe de turno", (bool)row["production_turn_report"]);
                checkedListBoxPermissions.Items.Add("13. Reporte de productividad", (bool)row["production_productivity_report"]);
                //  Sales
                checkedListBoxPermissions.Items.Add("14. Clientes", (bool)row["sales_clients"]);
                checkedListBoxPermissions.Items.Add("15. Pedidos", (bool)row["sales_orders"]);
                checkedListBoxPermissions.Items.Add("16. Reporte de Ventas", (bool)row["sales_generate_report"]);
                //  Warehouse
                checkedListBoxPermissions.Items.Add("17. Almacenes", (bool)row["warehouse_warehouses"]);
                checkedListBoxPermissions.Items.Add("18. Gestión de movimientos", (bool)row["warehouse_movements"]);
                checkedListBoxPermissions.Items.Add("19. Reporte de Stocks", (bool)row["warehouse_stock_reports"]);
                checkedListBoxPermissions.Items.Add("20. Reporte de Kardex", (bool)row["warehouse_kardex_reports"]);
            }
        }

        public int filter()
        {
            DataRow[] rows;
            table = role.showData();
            rows = table.Select("description = '" + textBoxNewRole.Text + "'");
            return rows.Count();
        }

        private void buttonMassiveUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Users File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
                if (role.massiveUpload(dialog.FileName))
                {
                    MessageBox.Show("Se realizó la carga masiva de manera exitosa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else MessageBox.Show("No se pudo cargar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            listRoles();
        }
    }
}
