
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
    public partial class PersonalData : Form
    {
        private WorkerController worker;
        private UserController user;
        private RoleController role;
        private DataRow userRow;
        DataTable roleTable;
        int workerID;
        public PersonalData(DataGridView dataGridV, UserController userC, WorkerController workerC, RoleController roleC)
        {
            InitializeComponent();
            workerID = Convert.ToInt32(dataGridV.SelectedRows[0].Cells["id_worker"].Value.ToString().Trim());
            textBoxName.Text = dataGridV.SelectedRows[0].Cells["first_name"].Value.ToString();
            textBoxLastName.Text = dataGridV.SelectedRows[0].Cells["last_name"].Value.ToString();
            textBoxDNI.Text = dataGridV.SelectedRows[0].Cells["dni"].Value.ToString();
            textBoxPhone.Text = dataGridV.SelectedRows[0].Cells["phone"].Value.ToString();
            textBoxAddress.Text = dataGridV.SelectedRows[0].Cells["address"].Value.ToString();
            textBoxEmail.Text = dataGridV.SelectedRows[0].Cells["email"].Value.ToString();
            comboBoxUserTurn.Text = dataGridV.SelectedRows[0].Cells["turn"].Value.ToString();
            worker = workerC;
            user = userC;
            role = roleC;

            int idUserDataGrid = Convert.ToInt32(dataGridV.SelectedRows[0].Cells["id_user"].Value.ToString().Trim());
            userRow = user.getUserRowbyID(idUserDataGrid);

            int roleID = Convert.ToInt32(userRow["id_role"].ToString());
            textBoxUsername.Text = userRow["username"].ToString();
            textBoxDescription.Text = userRow["description"].ToString();
            comboBoxUserStatus.Text = userRow["status"].ToString();

            DataRow roleRow = role.getRoleRowbyID(roleID);
            textBoxIDRol.Text = roleID.ToString();
            comboBoxRoles.Text = roleRow["description"].ToString();

            textBoxUsername.Enabled = false;
            comboBoxUserStatus.Enabled = false;
            comboBoxRoles.Enabled = true;

            buttonSave.Text = "Guardar";
            fillBasicData();
        }
        public PersonalData(UserController userC, WorkerController workerC, RoleController roleC)
        {
            InitializeComponent();
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxDNI.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            textBoxEmail.Text = "";

            textBoxUsername.Enabled = true;
            textBoxUsername.Text = "";
            comboBoxUserStatus.Enabled = true;
            comboBoxUserStatus.Text = "";
            comboBoxRoles.Enabled = true;
            comboBoxRoles.Text = "";

            buttonSave.Text = "Crear";
            worker = workerC;
            user = userC;
            role = roleC;
            fillBasicData();
        }

        private void fillBasicData()
        {
            roleTable = role.showData();
            comboBoxRoles.Items.Clear();
            for (int i = 0; i < roleTable.Rows.Count; i++)
            {
                comboBoxRoles.Items.Add(roleTable.Rows[i]["description"]);
            }
            fillMap();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.Equals(buttonSave.Text, "Crear"))
            {
                string password = "";
                user.showData();
                user.insertData(textBoxUsername.Text, textBoxDescription.Text,  1, ref password, Convert.ToInt32(textBoxIDRol.Text));                
                worker.insertData(textBoxName.Text, textBoxLastName.Text, Convert.ToInt32(textBoxDNI.Text.Trim()), Convert.ToInt32(1), worker.getUserID(textBoxUsername.Text), Convert.ToInt32(textBoxPhone.Text.Trim()), textBoxAddress.Text, textBoxEmail.Text);

                worker.sendPassword(textBoxEmail.Text, textBoxUsername.Text, password);
            }
            else if (string.Equals(buttonSave.Text, "Guardar"))
            {
                if (user != null)
                {
                    user.updateData(textBoxUsername.Text, textBoxDescription.Text, 1, Convert.ToInt32(textBoxIDRol.Text));
                    int userID = worker.getUserID(textBoxUsername.Text);
                    worker.updateData(workerID, textBoxName.Text, textBoxLastName.Text, Convert.ToInt32(textBoxDNI.Text.Trim()), Convert.ToInt32(1), userID, Convert.ToInt32(textBoxPhone.Text.Trim()), textBoxAddress.Text, textBoxEmail.Text);
                    }
                
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxIDRol.Text = roleTable.Rows[comboBoxRoles.SelectedIndex]["id_role"].ToString();
        }

        private void fillMap()
        {
            GeoCoderStatusCode status;

            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            PointLatLng? address = GMapProviders.GoogleMap.GetPoint(textBoxAddress.Text, out status);
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MarkersEnabled = true;

            if (status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                PointLatLng point = new PointLatLng(address.Value.Lat, address.Value.Lng);
                gMapControl1.Position = point;

                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.orange_dot);
                marker.ToolTipText = textBoxAddress.Text;
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.IsVisible = true;

                GMapOverlay over = new GMapOverlay("markers");
                over.Markers.Add(marker);

                gMapControl1.Overlays.Add(over);
            }
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 25;
            gMapControl1.Zoom = 16;
            gMapControl1.AutoScroll = true;
        }
    }
}
