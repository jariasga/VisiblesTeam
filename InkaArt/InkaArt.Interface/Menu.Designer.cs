﻿using InkaArt.Classes;
using System;

namespace InkaArt.Interface
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                pingThread.Abort();
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                LogHandler.WriteLine(ex.ToString());
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.modificarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeMateriasPrimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesDeMedidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.verMateriasPrimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.producciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeProcesosDeProducciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.asignaciónDeTrabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.generarReporteDeProductividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.generarReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almacénToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeAlmacenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.verStocksFísicosYLógicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarPing = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelPingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menu_strip.SuspendLayout();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_strip
            // 
            this.menu_strip.BackColor = System.Drawing.Color.White;
            this.menu_strip.Font = new System.Drawing.Font("Arial", 11F);
            this.menu_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguridadToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.producciónToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.almacénToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(1362, 25);
            this.menu_strip.TabIndex = 1;
            this.menu_strip.Text = "Menú";
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parámetrosGeneralesToolStripMenuItem,
            this.listaDeUsuariosToolStripMenuItem,
            this.rolesToolStripMenuItem,
            this.toolStripSeparator1,
            this.modificarContraseñaToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // parámetrosGeneralesToolStripMenuItem
            // 
            this.parámetrosGeneralesToolStripMenuItem.Name = "parámetrosGeneralesToolStripMenuItem";
            this.parámetrosGeneralesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.parámetrosGeneralesToolStripMenuItem.Text = "Parámetros Generales";
            this.parámetrosGeneralesToolStripMenuItem.Visible = false;
            this.parámetrosGeneralesToolStripMenuItem.Click += new System.EventHandler(this.parámetrosGeneralesToolStripMenuItem_Click);
            // 
            // listaDeUsuariosToolStripMenuItem
            // 
            this.listaDeUsuariosToolStripMenuItem.Name = "listaDeUsuariosToolStripMenuItem";
            this.listaDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.listaDeUsuariosToolStripMenuItem.Text = "Lista de usuarios";
            this.listaDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listaDeUsuariosToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // modificarContraseñaToolStripMenuItem
            // 
            this.modificarContraseñaToolStripMenuItem.Name = "modificarContraseñaToolStripMenuItem";
            this.modificarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.modificarContraseñaToolStripMenuItem.Text = "Modificar contraseña";
            this.modificarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.modificarContraseñaToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolSrip_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeProveedoresToolStripMenuItem,
            this.listaDeMateriasPrimasToolStripMenuItem,
            this.unidadesDeMedidaToolStripMenuItem,
            this.toolStripSeparator7,
            this.verMateriasPrimasToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // listaDeProveedoresToolStripMenuItem
            // 
            this.listaDeProveedoresToolStripMenuItem.Name = "listaDeProveedoresToolStripMenuItem";
            this.listaDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.listaDeProveedoresToolStripMenuItem.Text = "Proveedores";
            this.listaDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.listaDeProveedoresToolStripMenuItem_Click);
            // 
            // listaDeMateriasPrimasToolStripMenuItem
            // 
            this.listaDeMateriasPrimasToolStripMenuItem.Name = "listaDeMateriasPrimasToolStripMenuItem";
            this.listaDeMateriasPrimasToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.listaDeMateriasPrimasToolStripMenuItem.Text = "Materias Primas";
            this.listaDeMateriasPrimasToolStripMenuItem.Click += new System.EventHandler(this.listaDeMateriasPrimasToolStripMenuItem_Click);
            // 
            // unidadesDeMedidaToolStripMenuItem
            // 
            this.unidadesDeMedidaToolStripMenuItem.Name = "unidadesDeMedidaToolStripMenuItem";
            this.unidadesDeMedidaToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.unidadesDeMedidaToolStripMenuItem.Text = "Unidades de Medida";
            this.unidadesDeMedidaToolStripMenuItem.Click += new System.EventHandler(this.unidadesDeMedidaToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(207, 6);
            // 
            // verMateriasPrimasToolStripMenuItem
            // 
            this.verMateriasPrimasToolStripMenuItem.Name = "verMateriasPrimasToolStripMenuItem";
            this.verMateriasPrimasToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.verMateriasPrimasToolStripMenuItem.Text = "Órdenes de Compra";
            this.verMateriasPrimasToolStripMenuItem.Click += new System.EventHandler(this.verMateriasPrimasToolStripMenuItem_Click);
            // 
            // producciónToolStripMenuItem
            // 
            this.producciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeProductosToolStripMenuItem,
            this.listaDeProcesosDeProducciónToolStripMenuItem,
            this.listaDeTurnosToolStripMenuItem,
            this.toolStripSeparator4,
            this.asignaciónDeTrabajadoresToolStripMenuItem,
            this.informeDeTurnoToolStripMenuItem,
            this.toolStripSeparator3,
            this.generarReporteDeProductividadToolStripMenuItem});
            this.producciónToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11F);
            this.producciónToolStripMenuItem.Name = "producciónToolStripMenuItem";
            this.producciónToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.producciónToolStripMenuItem.Text = "Producción";
            // 
            // listaDeProductosToolStripMenuItem
            // 
            this.listaDeProductosToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11F);
            this.listaDeProductosToolStripMenuItem.Name = "listaDeProductosToolStripMenuItem";
            this.listaDeProductosToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.listaDeProductosToolStripMenuItem.Text = "Productos Finales";
            this.listaDeProductosToolStripMenuItem.Click += new System.EventHandler(this.listaDeProductosToolStripMenuItem_Click);
            // 
            // listaDeProcesosDeProducciónToolStripMenuItem
            // 
            this.listaDeProcesosDeProducciónToolStripMenuItem.Name = "listaDeProcesosDeProducciónToolStripMenuItem";
            this.listaDeProcesosDeProducciónToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.listaDeProcesosDeProducciónToolStripMenuItem.Text = "Procesos de Producción";
            this.listaDeProcesosDeProducciónToolStripMenuItem.Click += new System.EventHandler(this.listaDeProcesosDeProducciónToolStripMenuItem_Click);
            // 
            // listaDeTurnosToolStripMenuItem
            // 
            this.listaDeTurnosToolStripMenuItem.Name = "listaDeTurnosToolStripMenuItem";
            this.listaDeTurnosToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.listaDeTurnosToolStripMenuItem.Text = "Turnos de Producción";
            this.listaDeTurnosToolStripMenuItem.Click += new System.EventHandler(this.listaDeTurnosToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(306, 6);
            // 
            // asignaciónDeTrabajadoresToolStripMenuItem
            // 
            this.asignaciónDeTrabajadoresToolStripMenuItem.Name = "asignaciónDeTrabajadoresToolStripMenuItem";
            this.asignaciónDeTrabajadoresToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.asignaciónDeTrabajadoresToolStripMenuItem.Text = "Asignación de Trabajadores";
            this.asignaciónDeTrabajadoresToolStripMenuItem.Click += new System.EventHandler(this.asignaciónDeTrabajadoresToolStripMenuItem_Click);
            // 
            // informeDeTurnoToolStripMenuItem
            // 
            this.informeDeTurnoToolStripMenuItem.Name = "informeDeTurnoToolStripMenuItem";
            this.informeDeTurnoToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.informeDeTurnoToolStripMenuItem.Text = "Jornadas de Trabajo";
            this.informeDeTurnoToolStripMenuItem.Click += new System.EventHandler(this.informeDeTurnoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(306, 6);
            // 
            // generarReporteDeProductividadToolStripMenuItem
            // 
            this.generarReporteDeProductividadToolStripMenuItem.Name = "generarReporteDeProductividadToolStripMenuItem";
            this.generarReporteDeProductividadToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.generarReporteDeProductividadToolStripMenuItem.Text = "Generar Reporte de Productividad...";
            this.generarReporteDeProductividadToolStripMenuItem.Click += new System.EventHandler(this.generarReporteDeProductividadToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verClientesToolStripMenuItem,
            this.verPedidosToolStripMenuItem,
            this.toolStripSeparator2,
            this.generarReporteToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // verClientesToolStripMenuItem
            // 
            this.verClientesToolStripMenuItem.Name = "verClientesToolStripMenuItem";
            this.verClientesToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.verClientesToolStripMenuItem.Text = "Clientes";
            this.verClientesToolStripMenuItem.Click += new System.EventHandler(this.verClientesToolStripMenuItem_Click);
            // 
            // verPedidosToolStripMenuItem
            // 
            this.verPedidosToolStripMenuItem.Name = "verPedidosToolStripMenuItem";
            this.verPedidosToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.verPedidosToolStripMenuItem.Text = "Pedidos";
            this.verPedidosToolStripMenuItem.Click += new System.EventHandler(this.verPedidosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(262, 6);
            // 
            // generarReporteToolStripMenuItem
            // 
            this.generarReporteToolStripMenuItem.Name = "generarReporteToolStripMenuItem";
            this.generarReporteToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.generarReporteToolStripMenuItem.Text = "Generar Reporte de Ventas...";
            this.generarReporteToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // almacénToolStripMenuItem
            // 
            this.almacénToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeAlmacenesToolStripMenuItem,
            this.gestionarMovimientosToolStripMenuItem,
            this.toolStripSeparator9,
            this.verStocksFísicosYLógicosToolStripMenuItem,
            this.kardexToolStripMenuItem});
            this.almacénToolStripMenuItem.Name = "almacénToolStripMenuItem";
            this.almacénToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.almacénToolStripMenuItem.Text = "Almacén";
            // 
            // listaDeAlmacenesToolStripMenuItem
            // 
            this.listaDeAlmacenesToolStripMenuItem.Name = "listaDeAlmacenesToolStripMenuItem";
            this.listaDeAlmacenesToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.listaDeAlmacenesToolStripMenuItem.Text = "Almacenes";
            this.listaDeAlmacenesToolStripMenuItem.Click += new System.EventHandler(this.listaDeAlmacenesToolStripMenuItem_Click);
            // 
            // gestionarMovimientosToolStripMenuItem
            // 
            this.gestionarMovimientosToolStripMenuItem.Name = "gestionarMovimientosToolStripMenuItem";
            this.gestionarMovimientosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.gestionarMovimientosToolStripMenuItem.Text = "Movimientos";
            this.gestionarMovimientosToolStripMenuItem.Click += new System.EventHandler(this.gestionarMovimientosToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(263, 6);
            // 
            // verStocksFísicosYLógicosToolStripMenuItem
            // 
            this.verStocksFísicosYLógicosToolStripMenuItem.Name = "verStocksFísicosYLógicosToolStripMenuItem";
            this.verStocksFísicosYLógicosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.verStocksFísicosYLógicosToolStripMenuItem.Text = "Generar Reporte de Stocks...";
            this.verStocksFísicosYLógicosToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // kardexToolStripMenuItem
            // 
            this.kardexToolStripMenuItem.Name = "kardexToolStripMenuItem";
            this.kardexToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.kardexToolStripMenuItem.Text = "Generar Reporte Kárdex...";
            this.kardexToolStripMenuItem.Click += new System.EventHandler(this.kardexToolStripMenuItem_Click);
            // 
            // status_strip
            // 
            this.status_strip.BackColor = System.Drawing.Color.White;
            this.status_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label,
            this.toolStripProgressBarPing,
            this.toolStripStatusLabelPingStatus});
            this.status_strip.Location = new System.Drawing.Point(0, 717);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(1362, 22);
            this.status_strip.TabIndex = 2;
            this.status_strip.Text = "Estado";
            // 
            // status_label
            // 
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(32, 17);
            this.status_label.Text = "Listo";
            // 
            // toolStripProgressBarPing
            // 
            this.toolStripProgressBarPing.Name = "toolStripProgressBarPing";
            this.toolStripProgressBarPing.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelPingStatus
            // 
            this.toolStripStatusLabelPingStatus.Name = "toolStripStatusLabelPingStatus";
            this.toolStripStatusLabelPingStatus.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelPingStatus.Text = "toolStripStatusLabel1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 692);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::InkaArt.Interface.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1362, 739);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.status_strip);
            this.Controls.Add(this.menu_strip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu_strip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inka Art";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem producciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almacénToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
        private System.Windows.Forms.ToolStripMenuItem verClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kardexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem generarReporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMateriasPrimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeProcesosDeProducciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem listaDeTurnosToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem asignaciónDeTrabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeMateriasPrimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeAlmacenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem verStocksFísicosYLógicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesDeMedidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarPing;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPingStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem generarReporteDeProductividadToolStripMenuItem;
    }
}