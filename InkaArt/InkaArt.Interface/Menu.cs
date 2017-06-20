using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InkaArt.Interface.Purchases;
using InkaArt.Interface.Sales;
using InkaArt.Interface.Production;
using InkaArt.Interface.Warehouse;
using InkaArt.Interface.Security;
using InkaArt.Business.Security;
using System.Data;
using System.Threading;
using System.Net.NetworkInformation;
using InkaArt.Classes;

namespace InkaArt.Interface
{
    public partial class Menu : Form
    {
        private Form login;
        private RoleController controller;
        Thread pingThread;
        delegate void SetPingStatusTextCallback(string text);
        public Menu(Form login)
        {
            InitializeComponent();
            this.login = login;
            if (LoginController.needPassChange)
            {
                Form change_password = new ChangePassword();
                change_password.ControlBox = false;
                change_password.ShowDialog(this);
            }
            getPermissions();
            pingThread = new Thread(new ThreadStart(pingStatus));
            pingThread.IsBackground = true;
            pingThread.Start();
        }
        
        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form userList = new UserMaintenance();
            userList.MdiParent = this;
            userList.Show();
        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form reporteVentas = new FormSellsConfiguration();
            //reporteVentas.MdiParent = this;
            //reporteVentas.Show();
        }
      
        private void parámetrosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parameters_form = new GeneralParameters();
            parameters_form.MdiParent = this;
            parameters_form.Show();
        }

        private void LogoutToolSrip_Click(object sender, EventArgs e)
        {
            //Esto llamará a Menu_FormClosing y a Menu_FormClosed, respectivamente
            this.Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult logout = MessageBox.Show("¿Desea cerrar sesión?", "Inka Art",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (logout == DialogResult.No) e.Cancel = true;
        }


        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.login.Show();
        }

        /* Purchases */

        private void listaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form suppliers_form = new Suppliers();
            suppliers_form.MdiParent = this;
            suppliers_form.Show();
        }

        private void listaDeMateriasPrimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form raw_materials_form = new RawMaterials();
            raw_materials_form.MdiParent = this;
            raw_materials_form.Show();
        }

        private void verMateriasPrimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form purchase_order_form = new PurchaseOrder();
            purchase_order_form.MdiParent = this;
            purchase_order_form.Show();
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form unit_of_measurement = new UnitOfMeasurementList();
            unit_of_measurement.MdiParent = this;
            unit_of_measurement.Show();
        }

        /* Production */

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form products_form = new FinalProducts();
            products_form.MdiParent = this;
            products_form.Show();
        }

        private void listaDeProcesosDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form processes_form = new Jobs();
            processes_form.MdiParent = this;
            processes_form.Show();
        }

        private void listaDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form turn_management = new TurnManagement();
            turn_management.MdiParent = this;
            turn_management.Show();
        }

        private void asignaciónDeTrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form workers_assignment = new WorkersAssignment();
            workers_assignment.MdiParent = this;
            workers_assignment.Show();
        }

        private void productividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form reporte_productividad = new GeneratePerformanceReport();
            reporte_productividad.MdiParent = this;
            reporte_productividad.Show();
        }

        /* Sales */

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form clients_form = new ClientsIndex();
            clients_form.MdiParent = this;
            clients_form.Show();
        }

        private void verPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form client_orders_form = new ClientOrderIndex();
            client_orders_form.MdiParent = this;
            client_orders_form.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form reporte_ventas = new GenerateSalesReport();
            reporte_ventas.MdiParent = this;
            reporte_ventas.Show();
        }

        /* Warehouse */

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form salidas_productos = new ProductOut();
            salidas_productos.MdiParent = this;
            salidas_productos.Show();
        }

        private void ingresosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ingresos_productos = new ProductIn();
            ingresos_productos.MdiParent = this;
            ingresos_productos.Show();
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form reporte_kardex = new GenerateKardexReport();
            reporte_kardex.MdiParent = this;
            reporte_kardex.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form reporte_stocks = new GenerateStockReport();
            reporte_stocks.MdiParent = this;
            reporte_stocks.Show();
        }

        private void listaDeAlmacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form almacenes = new WarehouseIndex();
            almacenes.MdiParent = this;
            almacenes.Show();
        }

        private void gestionarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form movements = new MovementIndex();
            movements.MdiParent = this;
            movements.Show();            
        }

        private void informeDeTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inform = new RegisterRatioReport();
            inform.MdiParent = this;
            inform.Show();
        }

        private void modificarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form change_password = new ChangePassword();
            change_password.MdiParent = this;
            change_password.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form roles = new UserRolesPermissions();
            roles.MdiParent = this;
            roles.Show();
        }

        private void getPermissions()
        {
            controller = new RoleController();
            DataRow roleRow = controller.getRoleRowbyID(LoginController.roleID);
            //  Security
            parámetrosGeneralesToolStripMenuItem.Enabled = (bool)roleRow["security_general_parameters"];
            listaDeUsuariosToolStripMenuItem.Enabled = (bool)roleRow["security_user_list"];
            rolesToolStripMenuItem.Enabled = (bool)roleRow["security_roles"];
            //  Purchases
            listaDeProveedoresToolStripMenuItem.Enabled = (bool)roleRow["purchases_suppliers"];
            listaDeMateriasPrimasToolStripMenuItem.Enabled = (bool)roleRow["purchases_raw_materials"];
            unidadesDeMedidaToolStripMenuItem.Enabled = (bool)roleRow["purchases_unit_of_measure"];
            verMateriasPrimasToolStripMenuItem.Enabled = (bool)roleRow["purchases_purchase_order"];
            //  Production
            listaDeProductosToolStripMenuItem.Enabled = (bool)roleRow["production_final_product"];
            listaDeProcesosDeProducciónToolStripMenuItem.Enabled = (bool)roleRow["production_production_process"];
            listaDeTurnosToolStripMenuItem.Enabled = (bool)roleRow["production_production_turn"];
            asignaciónDeTrabajadoresToolStripMenuItem.Enabled = (bool)roleRow["production_worker_assignment"];
            informeDeTurnoToolStripMenuItem.Enabled = (bool)roleRow["production_turn_report"];
            generarReporteDeProductividadToolStripMenuItem.Enabled = (bool)roleRow["production_productivity_report"];
            //  Sales
            verClientesToolStripMenuItem.Enabled = (bool)roleRow["sales_clients"];
            verPedidosToolStripMenuItem.Enabled = (bool)roleRow["sales_orders"];
            generarReporteToolStripMenuItem.Enabled = (bool)roleRow["sales_generate_report"];
            //  Warehouse
            listaDeAlmacenesToolStripMenuItem.Enabled = (bool)roleRow["warehouse_warehouses"];
            gestionarMovimientosToolStripMenuItem.Enabled = (bool)roleRow["warehouse_movements"];
            verStocksFísicosYLógicosToolStripMenuItem.Enabled = (bool)roleRow["warehouse_stock_reports"];
            kardexToolStripMenuItem.Enabled = (bool)roleRow["warehouse_kardex_reports"];
        }

        private void pingStatus()
        {
            Ping ping = new Ping();
            ping.InitializeLifetimeService();

            while (true)
            {
                try
                {
                    long ms = ping.Send(BD_Connector.serverAddress).RoundtripTime;
                    this.SetPingStatusText("Reply from server: " + ms + "ms");
                }
                catch (Exception)
                {
                    this.SetPingStatusText("Server unreacheable");
                }
                Thread.Sleep(1000);
            }
        }

        private void SetPingStatusText(string text)
        {
            /*if (this.toolStripStatusLabelPingStatus.InvokeRequired)
            {
                SetPingStatusTextCallback d = new SetPingStatusTextCallback(SetPingStatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {*/
            try
            {
                this.toolStripStatusLabelPingStatus.Text = text;
            }
            catch (Exception e)
            {
                LogHandler.WriteLine(e.ToString());
            }
        }
    }
}
