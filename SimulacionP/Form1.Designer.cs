namespace SimulacionP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPuntos = new System.Windows.Forms.NumericUpDown();
            this.nudAnimales = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDias = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMuestrasPorDia = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMercurio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbClorhidrico = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbOxidos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFosfatos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSulfatos = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.cmbPetroquimicos = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.cmbColoidales = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbAlcalinidad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGlucosa = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbNormal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAnemia = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbAcidez = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCondicionesTotal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblContaminantesTotal = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSemilla = new System.Windows.Forms.TextBox();
            this.cmbSemDi = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblEspSem = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvInformacion = new System.Windows.Forms.DataGridView();
            this.txtCorridas = new System.Windows.Forms.TextBox();
            this.lblConclusiones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorDia)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(546, 103);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(130, 36);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar simulacion";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 176);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(6, 6);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            this.dgvResultados.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(2, 367);
            this.dgvResultados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.RowTemplate.Height = 24;
            this.dgvResultados.Size = new System.Drawing.Size(854, 167);
            this.dgvResultados.TabIndex = 2;
            this.dgvResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puntos de muestreo";
            // 
            // nudPuntos
            // 
            this.nudPuntos.Location = new System.Drawing.Point(26, 28);
            this.nudPuntos.Margin = new System.Windows.Forms.Padding(2);
            this.nudPuntos.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPuntos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPuntos.Name = "nudPuntos";
            this.nudPuntos.Size = new System.Drawing.Size(90, 20);
            this.nudPuntos.TabIndex = 4;
            this.nudPuntos.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudAnimales
            // 
            this.nudAnimales.Location = new System.Drawing.Point(158, 28);
            this.nudAnimales.Margin = new System.Windows.Forms.Padding(2);
            this.nudAnimales.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAnimales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnimales.Name = "nudAnimales";
            this.nudAnimales.Size = new System.Drawing.Size(90, 20);
            this.nudAnimales.TabIndex = 6;
            this.nudAnimales.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Animales en punto";
            // 
            // nudDias
            // 
            this.nudDias.Location = new System.Drawing.Point(270, 28);
            this.nudDias.Margin = new System.Windows.Forms.Padding(2);
            this.nudDias.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDias.Name = "nudDias";
            this.nudDias.Size = new System.Drawing.Size(90, 20);
            this.nudDias.TabIndex = 8;
            this.nudDias.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dias de muestreo";
            // 
            // nudMuestrasPorDia
            // 
            this.nudMuestrasPorDia.Location = new System.Drawing.Point(385, 28);
            this.nudMuestrasPorDia.Margin = new System.Windows.Forms.Padding(2);
            this.nudMuestrasPorDia.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMuestrasPorDia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMuestrasPorDia.Name = "nudMuestrasPorDia";
            this.nudMuestrasPorDia.Size = new System.Drawing.Size(90, 20);
            this.nudMuestrasPorDia.TabIndex = 10;
            this.nudMuestrasPorDia.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(382, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Muestras por dia";
            // 
            // cmbMercurio
            // 
            this.cmbMercurio.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.15",
            "0.20",
            "0.25"});
            this.cmbMercurio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMercurio.FormattingEnabled = true;
            this.cmbMercurio.Location = new System.Drawing.Point(2, 36);
            this.cmbMercurio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMercurio.Name = "cmbMercurio";
            this.cmbMercurio.Size = new System.Drawing.Size(92, 21);
            this.cmbMercurio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Probabilidades contaminantes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Acido Clorhidrico";
            // 
            // cmbClorhidrico
            // 
            this.cmbClorhidrico.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.12",
            "0.15",
            "0.20"});
            this.cmbClorhidrico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClorhidrico.FormattingEnabled = true;
            this.cmbClorhidrico.Location = new System.Drawing.Point(0, 83);
            this.cmbClorhidrico.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClorhidrico.Name = "cmbClorhidrico";
            this.cmbClorhidrico.Size = new System.Drawing.Size(92, 21);
            this.cmbClorhidrico.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.cmbOxidos);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbFosfatos);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbSulfatos);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.cmbPetroquimicos);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Controls.Add(this.cmbColoidales);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbClorhidrico);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbMercurio);
            this.panel1.Location = new System.Drawing.Point(24, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 202);
            this.panel1.TabIndex = 16;
            // 
            // cmbOxidos
            // 
            this.cmbOxidos.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.15",
            "0.17",
            "0.20",
            "0.25"});
            this.cmbOxidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOxidos.FormattingEnabled = true;
            this.cmbOxidos.Location = new System.Drawing.Point(0, 169);
            this.cmbOxidos.Margin = new System.Windows.Forms.Padding(2);
            this.cmbOxidos.Name = "cmbOxidos";
            this.cmbOxidos.Size = new System.Drawing.Size(92, 21);
            this.cmbOxidos.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 154);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Oxidos";
            // 
            // cmbFosfatos
            // 
            this.cmbFosfatos.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.16",
            "0.20",
            "0.25"});
            this.cmbFosfatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFosfatos.FormattingEnabled = true;
            this.cmbFosfatos.Location = new System.Drawing.Point(100, 128);
            this.cmbFosfatos.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFosfatos.Name = "cmbFosfatos";
            this.cmbFosfatos.Size = new System.Drawing.Size(92, 21);
            this.cmbFosfatos.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Fosfatos";
            // 
            // cmbSulfatos
            // 
            this.cmbSulfatos.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.15",
            "0.20",
            "0.25"});
            this.cmbSulfatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSulfatos.FormattingEnabled = true;
            this.cmbSulfatos.Location = new System.Drawing.Point(0, 128);
            this.cmbSulfatos.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSulfatos.Name = "cmbSulfatos";
            this.cmbSulfatos.Size = new System.Drawing.Size(92, 21);
            this.cmbSulfatos.TabIndex = 22;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(0, 112);
            this.lbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(45, 13);
            this.lbl1.TabIndex = 23;
            this.lbl1.Text = "Sulfatos";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(102, 20);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(55, 13);
            this.label.TabIndex = 21;
            this.label.Text = "Coloidales";
            // 
            // cmbPetroquimicos
            // 
            this.cmbPetroquimicos.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.15",
            "0.25",
            "0.30",
            "0.35"});
            this.cmbPetroquimicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPetroquimicos.FormattingEnabled = true;
            this.cmbPetroquimicos.Location = new System.Drawing.Point(100, 83);
            this.cmbPetroquimicos.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPetroquimicos.Name = "cmbPetroquimicos";
            this.cmbPetroquimicos.Size = new System.Drawing.Size(92, 21);
            this.cmbPetroquimicos.TabIndex = 19;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(100, 67);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(73, 13);
            this.lbl.TabIndex = 20;
            this.lbl.Text = "Petroquimicos";
            // 
            // cmbColoidales
            // 
            this.cmbColoidales.AutoCompleteCustomSource.AddRange(new string[] {
            "0.05",
            "0.10",
            "0.15",
            "0.20"});
            this.cmbColoidales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColoidales.FormattingEnabled = true;
            this.cmbColoidales.Location = new System.Drawing.Point(102, 36);
            this.cmbColoidales.Margin = new System.Windows.Forms.Padding(2);
            this.cmbColoidales.Name = "cmbColoidales";
            this.cmbColoidales.Size = new System.Drawing.Size(92, 21);
            this.cmbColoidales.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Mercurio";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cmbAlcalinidad);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmbGlucosa);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cmbNormal);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cmbAnemia);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cmbAcidez);
            this.panel2.Location = new System.Drawing.Point(296, 67);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 174);
            this.panel2.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 113);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Alto grado de alcalinidad";
            // 
            // cmbAlcalinidad
            // 
            this.cmbAlcalinidad.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.15",
            "0.20",
            "0.22",
            "0.25"});
            this.cmbAlcalinidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlcalinidad.FormattingEnabled = true;
            this.cmbAlcalinidad.Location = new System.Drawing.Point(5, 128);
            this.cmbAlcalinidad.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAlcalinidad.Name = "cmbAlcalinidad";
            this.cmbAlcalinidad.Size = new System.Drawing.Size(92, 21);
            this.cmbAlcalinidad.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(110, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Exheso glucosa";
            // 
            // cmbGlucosa
            // 
            this.cmbGlucosa.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.15",
            "0.17",
            "0.20"});
            this.cmbGlucosa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGlucosa.FormattingEnabled = true;
            this.cmbGlucosa.Location = new System.Drawing.Point(110, 80);
            this.cmbGlucosa.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGlucosa.Name = "cmbGlucosa";
            this.cmbGlucosa.Size = new System.Drawing.Size(92, 21);
            this.cmbGlucosa.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 65);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Rango normal";
            // 
            // cmbNormal
            // 
            this.cmbNormal.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.20",
            "0.30",
            "0.35",
            "0.40"});
            this.cmbNormal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNormal.FormattingEnabled = true;
            this.cmbNormal.Location = new System.Drawing.Point(2, 80);
            this.cmbNormal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNormal.Name = "cmbNormal";
            this.cmbNormal.Size = new System.Drawing.Size(92, 21);
            this.cmbNormal.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Anemia aguda";
            // 
            // cmbAnemia
            // 
            this.cmbAnemia.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.05",
            "0.08",
            "0.10",
            "0.15"});
            this.cmbAnemia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnemia.FormattingEnabled = true;
            this.cmbAnemia.Location = new System.Drawing.Point(110, 36);
            this.cmbAnemia.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnemia.Name = "cmbAnemia";
            this.cmbAnemia.Size = new System.Drawing.Size(92, 21);
            this.cmbAnemia.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Alto grado acidez";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(50, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Probabilidades sanguineas";
            // 
            // cmbAcidez
            // 
            this.cmbAcidez.AutoCompleteCustomSource.AddRange(new string[] {
            "0.01",
            "0.10",
            "0.15",
            "0.18",
            "0.25"});
            this.cmbAcidez.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcidez.FormattingEnabled = true;
            this.cmbAcidez.Location = new System.Drawing.Point(2, 36);
            this.cmbAcidez.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAcidez.Name = "cmbAcidez";
            this.cmbAcidez.Size = new System.Drawing.Size(92, 21);
            this.cmbAcidez.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Porcentaje de probabilidades sanguineas";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(2, 13);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "(No exceder el 100%)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.Controls.Add(this.lblCondicionesTotal);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(296, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 42);
            this.panel3.TabIndex = 20;
            // 
            // lblCondicionesTotal
            // 
            this.lblCondicionesTotal.AutoSize = true;
            this.lblCondicionesTotal.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblCondicionesTotal.Location = new System.Drawing.Point(158, 13);
            this.lblCondicionesTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCondicionesTotal.Name = "lblCondicionesTotal";
            this.lblCondicionesTotal.Size = new System.Drawing.Size(13, 13);
            this.lblCondicionesTotal.TabIndex = 28;
            this.lblCondicionesTotal.Text = "0";
            this.lblCondicionesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Ivory;
            this.panel4.Controls.Add(this.lblContaminantesTotal);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Location = new System.Drawing.Point(27, 274);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(218, 42);
            this.panel4.TabIndex = 30;
            // 
            // lblContaminantesTotal
            // 
            this.lblContaminantesTotal.AutoSize = true;
            this.lblContaminantesTotal.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblContaminantesTotal.Location = new System.Drawing.Point(157, 13);
            this.lblContaminantesTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContaminantesTotal.Name = "lblContaminantesTotal";
            this.lblContaminantesTotal.Size = new System.Drawing.Size(13, 13);
            this.lblContaminantesTotal.TabIndex = 28;
            this.lblContaminantesTotal.Text = "0";
            this.lblContaminantesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(2, 13);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "(No exceder el 100%)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(2, 0);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(216, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Porcentaje de probabilidades contaminantes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimulacionP.Properties.Resources.Duck;
            this.pictureBox1.Location = new System.Drawing.Point(706, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // txtSemilla
            // 
            this.txtSemilla.Location = new System.Drawing.Point(600, 26);
            this.txtSemilla.Margin = new System.Windows.Forms.Padding(2);
            this.txtSemilla.Name = "txtSemilla";
            this.txtSemilla.Size = new System.Drawing.Size(76, 20);
            this.txtSemilla.TabIndex = 35;
            this.txtSemilla.Visible = false;
            // 
            // cmbSemDi
            // 
            this.cmbSemDi.FormattingEnabled = true;
            this.cmbSemDi.Location = new System.Drawing.Point(490, 26);
            this.cmbSemDi.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSemDi.Name = "cmbSemDi";
            this.cmbSemDi.Size = new System.Drawing.Size(92, 21);
            this.cmbSemDi.TabIndex = 36;
            this.cmbSemDi.SelectedIndexChanged += new System.EventHandler(this.cmbSemDi_SelectedIndexChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(488, 7);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Tipo de semilla";
            // 
            // lblEspSem
            // 
            this.lblEspSem.AutoSize = true;
            this.lblEspSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspSem.Location = new System.Drawing.Point(598, 7);
            this.lblEspSem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEspSem.Name = "lblEspSem";
            this.lblEspSem.Size = new System.Drawing.Size(94, 13);
            this.lblEspSem.TabIndex = 38;
            this.lblEspSem.Text = "ingresar semilla";
            this.lblEspSem.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(530, 49);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(151, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "Cantidad de simulaciones";
            // 
            // dgvInformacion
            // 
            this.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacion.Location = new System.Drawing.Point(733, 150);
            this.dgvInformacion.Name = "dgvInformacion";
            this.dgvInformacion.Size = new System.Drawing.Size(406, 150);
            this.dgvInformacion.TabIndex = 40;
            // 
            // txtCorridas
            // 
            this.txtCorridas.Location = new System.Drawing.Point(533, 67);
            this.txtCorridas.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorridas.Name = "txtCorridas";
            this.txtCorridas.Size = new System.Drawing.Size(76, 20);
            this.txtCorridas.TabIndex = 41;
            // 
            // lblConclusiones
            // 
            this.lblConclusiones.AutoSize = true;
            this.lblConclusiones.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblConclusiones.Location = new System.Drawing.Point(861, 367);
            this.lblConclusiones.Name = "lblConclusiones";
            this.lblConclusiones.Size = new System.Drawing.Size(41, 13);
            this.lblConclusiones.TabIndex = 42;
            this.lblConclusiones.Text = "label20";
            this.lblConclusiones.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1143, 592);
            this.Controls.Add(this.lblConclusiones);
            this.Controls.Add(this.txtCorridas);
            this.Controls.Add(this.dgvInformacion);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblEspSem);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbSemDi);
            this.Controls.Add(this.txtSemilla);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nudMuestrasPorDia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudDias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudAnimales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPuntos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEjecutar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Simulador Mantos Freaticos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorDia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPuntos;
        private System.Windows.Forms.NumericUpDown nudAnimales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMuestrasPorDia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMercurio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbClorhidrico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOxidos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFosfatos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSulfatos;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cmbPetroquimicos;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cmbColoidales;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbAcidez;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbAlcalinidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbGlucosa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbNormal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbAnemia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCondicionesTotal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblContaminantesTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSemilla;
        private System.Windows.Forms.ComboBox cmbSemDi;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblEspSem;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgvInformacion;
        private System.Windows.Forms.TextBox txtCorridas;
        private System.Windows.Forms.Label lblConclusiones;
    }
}

