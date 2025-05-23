using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Predefinir valores de NumericUpDown
            nudPuntos.Value = 4;
            nudAnimales.Value = 5;
            nudDias.Value = 14;
            nudMuestrasPorDia.Value = 20;

            // Configurar ComboBox para contaminantes
            cmbColoidales.Items.AddRange(new object[] { "0.01", "0.05", "0.10", "0.15", "0.20" });
            cmbColoidales.SelectedIndex = 1; // 0.05
            cmbMercurio.Items.AddRange(new object[] { "0.01", "0.10", "0.15", "0.20", "0.25" });
            cmbMercurio.SelectedIndex = 1;   // 0.10
            cmbPetroquimicos.Items.AddRange(new object[] { "0.01", "0.15", "0.25", "0.30", "0.35" });
            cmbPetroquimicos.SelectedIndex = 2; // 0.25
            cmbSulfatos.Items.AddRange(new object[] { "0.01", "0.10", "0.15", "0.20", "0.25" });
            cmbSulfatos.SelectedIndex = 2;    // 0.15
            cmbClorhidrico.Items.AddRange(new object[] { "0.01", "0.10", "0.12", "0.15", "0.20" });
            cmbClorhidrico.SelectedIndex = 2; // 0.12
            cmbFosfatos.Items.AddRange(new object[] { "0.01", "0.10", "0.16", "0.20", "0.25" });
            cmbFosfatos.SelectedIndex = 2;    // 0.16
            cmbOxidos.Items.AddRange(new object[] { "0.01", "0.15", "0.17", "0.20", "0.25" });
            cmbOxidos.SelectedIndex = 2;      // 0.17

            // Configurar ComboBox para condiciones sanguíneas
            cmbAcidez.Items.AddRange(new object[] { "0.01", "0.10", "0.15", "0.18", "0.25" });
            cmbAcidez.SelectedIndex = 3;      // 0.18
            cmbAnemia.Items.AddRange(new object[] { "0.01", "0.05", "0.08", "0.10", "0.15" });
            cmbAnemia.SelectedIndex = 2;      // 0.08
            cmbNormal.Items.AddRange(new object[] { "0.01", "0.20", "0.30", "0.35", "0.40" });
            cmbNormal.SelectedIndex = 3;      // 0.35
            cmbGlucosa.Items.AddRange(new object[] { "0.01", "0.10", "0.15", "0.17", "0.20" });
            cmbGlucosa.SelectedIndex = 3;     // 0.17
            cmbAlcalinidad.Items.AddRange(new object[] { "0.01", "0.15", "0.20", "0.22", "0.25" });
            cmbAlcalinidad.SelectedIndex = 3; // 0.22

            // Configurar ComboBox para selección de tipo de semilla
            cmbSemDi.Items.AddRange(new object[] { "Dinámica", "Específica" });
            cmbSemDi.SelectedIndex = 0; // Por defecto "Dinámica"
            txtSemilla.Visible = false; // Ocultar txtSemilla inicialmente
            lblEspSem.Visible = false;  // Ocultar lblEspSem inicialmente

            // Configurar DataGridView
            dgvResultados.Columns.Add("Punto", "Punto de Muestreo");
            dgvResultados.Columns.Add("PorcentajeAlteraciones", "Alteraciones (%)");
            dgvResultados.Columns.Add("Aptitud", "Aptitud del Agua");
            dgvResultados.Columns.Add("Contaminante", "Contaminante Principal");
            dgvResultados.Columns.Add("CondicionSanguinea", "Condición Sanguínea Principal");
            dgvResultados.Columns.Add("AnimalesAfectados", "Animales Afectados");
            dgvResultados.Columns.Add("Recomendacion", "Recomendación");
            dgvResultados.Columns["PorcentajeAlteraciones"].DefaultCellStyle.Format = "N2";

            // Ajustar el ancho de las columnas para mejor visualización
            dgvResultados.Columns["Punto"].Width = 100;
            dgvResultados.Columns["PorcentajeAlteraciones"].Width = 120;
            dgvResultados.Columns["Aptitud"].Width = 100;
            dgvResultados.Columns["Contaminante"].Width = 150;
            dgvResultados.Columns["CondicionSanguinea"].Width = 150;
            dgvResultados.Columns["AnimalesAfectados"].Width = 120;
            dgvResultados.Columns["Recomendacion"].Width = 120;

            // Asegurar que lblConclusiones esté oculto inicialmente y ajustar su tamaño
            lblConclusiones.Visible = false;
            lblConclusiones.AutoSize = false;
            lblConclusiones.MaximumSize = new Size(400, 0);
            lblConclusiones.Width = 400;

            // Asociar eventos a ComboBox de contaminantes
            cmbColoidales.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbMercurio.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbPetroquimicos.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbSulfatos.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbClorhidrico.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbFosfatos.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbOxidos.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            // Asociar eventos a ComboBox de condiciones sanguíneas
            cmbAcidez.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbAnemia.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbNormal.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbGlucosa.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbAlcalinidad.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            // Asociar evento a ComboBox de selección de semilla
            cmbSemDi.SelectedIndexChanged += CmbSemDi_SelectedIndexChanged;

            // Calcular sumas iniciales
            ActualizarSumaContaminantes();
            ActualizarSumaCondiciones();
        }

        // Parámetros iniciales
        private long a = 1664525; // Constante multiplicativa
        private long c = 1013904223; // Constante aditiva
        private long m = 4294967296; // Módulo (2^32)
        private double umbralNoApta = 0.40; // 40% de condiciones anormales
        private double porcentajeContaminacion = 0.30; // 30% según validación
        private double probAlteracionSi = 0.70; // 70% si agua contaminada
        private double probAlteracionNo = 0.10; // 10% si agua no contaminada
        private const int muestreosPorPunto = 3; // Número fijo de muestreos por punto

        // Distribución de contaminantes en agua (valores iniciales, se ajustarán dinámicamente)
        private Dictionary<string, double> contaminantes = new Dictionary<string, double>
        {
            { "Sustancias coloidales", 0.05 },
            { "Exceso de mercurio", 0.10 },
            { "Residuos petroquimicos", 0.25 },
            { "Sulfatos", 0.15 },
            { "Ácido clorhídrico", 0.12 },
            { "Fosfatos", 0.16 },
            { "Óxidos", 0.17 }
        };

        // Distribución de condiciones en sangre (valores iniciales, se ajustarán dinámicamente)
        private Dictionary<string, double> condiciones = new Dictionary<string, double>
        {
            { "Alto grado de acidez", 0.18 },
            { "Estado de anemia aguda", 0.08 },
            { "Estado en rango normal", 0.35 },
            { "Exceso de glucosa", 0.17 },
            { "Alto grado de alcalinidad", 0.22 }
        };

        // MÓDULO 1: Generación de números pseudoaleatorios
        private List<double> GenerarNumerosPseudoaleatorios(int cantidad, long semilla)
        {
            List<double> numeros = new List<double>();
            long X = (semilla % m); // Asegurarse de que la semilla no sea mayor que m
            for (int i = 0; i < cantidad; i++)
            {
                X = (a * X + c) % m;
                double Ri = (double)X / m;
                numeros.Add(Ri);
            }
            return numeros;
        }

        // MÓDULO 2: Simulación de calidad del agua
        private List<int> SimularCalidadAgua(List<double> numeros, int totalMuestras)
        {
            List<int> aguaContaminada = new List<int>();
            for (int i = 0; i < totalMuestras; i++)
            {
                if (numeros[i] < porcentajeContaminacion)
                    aguaContaminada.Add(1); // Contaminada
                else
                    aguaContaminada.Add(0); // No contaminada
            }
            return aguaContaminada;
        }

        // NUEVO: Asignar contaminantes específicos a muestras contaminadas
        private List<string> AsignarContaminantes(List<double> numeros, List<int> aguaContaminada, int totalMuestras)
        {
            List<string> contaminantesAsignados = new List<string>();
            // Crear intervalos acumulados para contaminantes
            var intervalos = new List<(string nombre, double inicio, double fin)>
            {
                ("Sustancias coloidales", 0.00, contaminantes["Sustancias coloidales"]),
                ("Exceso de mercurio", contaminantes["Sustancias coloidales"], contaminantes["Exceso de mercurio"]),
                ("Residuos petroquimicos", contaminantes["Exceso de mercurio"], contaminantes["Residuos petroquimicos"]),
                ("Sulfatos", contaminantes["Residuos petroquimicos"], contaminantes["Sulfatos"]),
                ("Ácido clorhídrico", contaminantes["Sulfatos"], contaminantes["Ácido clorhídrico"]),
                ("Fosfatos", contaminantes["Ácido clorhídrico"], contaminantes["Fosfatos"]),
                ("Óxidos", contaminantes["Fosfatos"], contaminantes["Óxidos"])
            };

            for (int i = 0; i < totalMuestras; i++)
            {
                if (aguaContaminada[i] == 1) // Solo asignar contaminante si el agua está contaminada
                {
                    double Ri = numeros[i];
                    string contaminante = "Ninguno";
                    foreach (var intervalo in intervalos)
                    {
                        if (Ri >= intervalo.inicio && Ri < intervalo.fin)
                        {
                            contaminante = intervalo.nombre;
                            break;
                        }
                    }
                    contaminantesAsignados.Add(contaminante);
                }
                else
                {
                    contaminantesAsignados.Add("No contaminado");
                }
            }
            return contaminantesAsignados;
        }
        // MÓDULO 3: Simulación de impacto en animales
        private List<int> SimularImpactoAnimales(List<int> aguaContaminada, List<double> numerosSangre, int puntos, int animales, int muestreos)
        {
            List<int> alteracionesSanguineas = new List<int>();
            int idxSangre = 0;
            int muestrasPorPunto = aguaContaminada.Count / puntos; // Total muestras agua / puntos
            for (int punto = 0; punto < puntos; punto++)
            {
                int contaminados = aguaContaminada.GetRange(punto * muestrasPorPunto, muestrasPorPunto).Count(x => x == 1);
                double probContaminacionPunto = (double)contaminados / muestrasPorPunto;
                for (int muestreo = 0; muestreo < muestreos; muestreo++)
                {
                    for (int animal = 0; animal < animales; animal++)
                    {
                        double prob = probContaminacionPunto > 0.3 ? probAlteracionSi : probAlteracionNo;
                        if (numerosSangre[idxSangre] < prob)
                            alteracionesSanguineas.Add(1); // Alterado
                        else
                            alteracionesSanguineas.Add(0); // Normal
                        idxSangre++;
                    }
                }
            }
            return alteracionesSanguineas;
        }

        // MÓDULO 4: Evaluación y decisión
        private (List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)>, int puntosNoApta, List<string> contaminantesNoApta) EvaluarAptitud(List<int> alteraciones, int puntos, int animales, int muestreos, int totalMuestrasAgua)
        {
            List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)> resultadosPuntos = new List<(int, double, string, string, string, int, string)>();
            int puntosNoApta = 0;
            List<string> contaminantesNoApta = new List<string>();
            Dictionary<string, int> conteoContaminantesGlobal = new Dictionary<string, int>
            {
                { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
            };
            long semilla = DateTime.Now.Ticks;
            int totalMuestrasSangre = puntos * animales * muestreos;
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + (int)(totalMuestrasAgua * 0.5), (int)(semilla % m));
            List<double> numerosCondiciones = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + (int)(totalMuestrasSangre * 0.5), (int)(semilla % m + 1));

            for (int punto = 0; punto < puntos; punto++)
            {
                int inicio = punto * animales * muestreos;
                List<int> puntoSangre = alteraciones.GetRange(inicio, animales * muestreos);
                double porcentajeAnormal = (double)puntoSangre.Count(x => x == 1) / puntoSangre.Count * 100;
                string aptitud = porcentajeAnormal > (umbralNoApta * 100) ? "No Apta" : "Apta";
                string contaminante = "";
                string condicionSanguinea = "";
                int animalesAfectados = puntoSangre.Count(x => x == 1);
                string recomendacion = "";

                if (aptitud == "No Apta")
                {
                    puntosNoApta++;
                    // Determinar todos los contaminantes presentes
                    Dictionary<string, int> conteoContaminantesPunto = new Dictionary<string, int>
                    {
                        { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                        { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                        { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
                    };
                    int muestrasPorPunto = totalMuestrasAgua / puntos; // Ajustar al valor pasado
                    for (int i = punto * muestrasPorPunto; i < (punto + 1) * muestrasPorPunto; i++)
                    {
                        double Ri = numerosAgua[i];
                        foreach (var cont in contaminantes)
                        {
                            if (Ri < cont.Value)
                            {
                                conteoContaminantesPunto[cont.Key]++;
                                conteoContaminantesGlobal[cont.Key]++;
                                break;
                            }
                        }
                    }
                    contaminante = string.Join(", ", conteoContaminantesPunto.Where(x => x.Value > 0).Select(x => x.Key));

                    // Determinar condición sanguínea más frecuente
                    Dictionary<string, int> conteoCondicionesPunto = new Dictionary<string, int>
                    {
                        { "Alto grado de acidez", 0 },
                        { "Estado de anemia aguda", 0 },
                        { "Estado en rango normal", 0 },
                        { "Exceso de glucosa", 0 },
                        { "Alto grado de alcalinidad", 0 }
                    };
                    int muestrasPorPuntoSangre = totalMuestrasSangre / puntos; // 15 muestras por punto
                    for (int i = punto * muestrasPorPuntoSangre; i < (punto + 1) * muestrasPorPuntoSangre; i++)
                    {
                        double Ri = numerosCondiciones[i];
                        foreach (var cond in condiciones)
                        {
                            if (Ri < cond.Value)
                            {
                                conteoCondicionesPunto[cond.Key]++;
                                break;
                            }
                        }
                    }
                    condicionSanguinea = conteoCondicionesPunto.OrderByDescending(x => x.Value).First().Key;

                    // Recomendación basada en porcentaje de alteraciones
                    recomendacion = porcentajeAnormal > 60 ? "Limpieza urgente" : "Monitoreo";
                    if (!contaminantesNoApta.Contains(contaminante) && !string.IsNullOrEmpty(contaminante))
                        contaminantesNoApta.Add(contaminante);
                }
                else
                {
                    contaminante = "-";
                    condicionSanguinea = "-";
                    recomendacion = "Sin acción";
                }

                resultadosPuntos.Add((punto + 1, porcentajeAnormal, aptitud, contaminante, condicionSanguinea, animalesAfectados, recomendacion));
            }

            return (resultadosPuntos, puntosNoApta, contaminantesNoApta);
        }

        private void CmbSemDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar txtSemilla y lblEspSem según la selección
            bool isEspecifica = cmbSemDi.SelectedItem.ToString() == "Específica";
            txtSemilla.Visible = isEspecifica;
            lblEspSem.Visible = isEspecifica;
            if (isEspecifica && !string.IsNullOrEmpty(txtSemilla.Text))
            {
                lblEspSem.Text = $"Semilla Específica: {txtSemilla.Text}";
            }
            else
            {
                lblEspSem.Text = "Semilla Específica: (pendiente de ingreso)";
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // Leer parámetros dinámicos desde los controles
            int puntos = (int)nudPuntos.Value;
            int animales = (int)nudAnimales.Value;
            int dias = (int)nudDias.Value;
            int muestrasPorDia = (int)nudMuestrasPorDia.Value;
            int muestreos = muestreosPorPunto;

            // Calcular totales
            int totalMuestrasAgua = muestrasPorDia * dias * puntos;
            int totalMuestrasSangre = animales * puntos * muestreos;

            // Actualizar y mostrar Labels de totales
            lblMuestrasAgua.Text = $"Total Muestras de Agua: {totalMuestrasAgua}";
            lblMuestrasSangre.Text = $"Total Muestras de Sangre: {totalMuestrasSangre}";
            lblMuestrasAgua.Visible = true;
            lblMuestrasSangre.Visible = true;

            // Leer probabilidades de contaminantes desde ComboBox
            double coloidales = double.Parse(cmbColoidales.SelectedItem.ToString());
            double mercurio = double.Parse(cmbMercurio.SelectedItem.ToString());
            double petroquimicos = double.Parse(cmbPetroquimicos.SelectedItem.ToString());
            double sulfatos = double.Parse(cmbSulfatos.SelectedItem.ToString());
            double clorhidrico = double.Parse(cmbClorhidrico.SelectedItem.ToString());
            double fosfatos = double.Parse(cmbFosfatos.SelectedItem.ToString());
            double oxidos = double.Parse(cmbOxidos.SelectedItem.ToString());

            // Validar que la suma de contaminantes no exceda 1
            double sumaContaminantes = coloidales + mercurio + petroquimicos + sulfatos + clorhidrico + fosfatos + oxidos;
            if (sumaContaminantes > 1.0)
            {
                MessageBox.Show("La suma de las probabilidades de contaminantes excede 1. Ajuste los valores.");
                return;
            }
            // Ajustar el último valor (Óxidos) para que la suma llegue a 1 si es menor
            if (sumaContaminantes < 1.0)
            {
                oxidos = 1.0 - (coloidales + mercurio + petroquimicos + sulfatos + clorhidrico + fosfatos);
                if (oxidos < 0)
                {
                    MessageBox.Show("No se puede ajustar la probabilidad de Óxidos. Ajuste los valores.");
                    return;
                }
            }

            // Actualizar la distribución acumulada de contaminantes
            contaminantes["Sustancias coloidales"] = coloidales;
            contaminantes["Exceso de mercurio"] = coloidales + mercurio;
            contaminantes["Residuos petroquimicos"] = contaminantes["Exceso de mercurio"] + petroquimicos;
            contaminantes["Sulfatos"] = contaminantes["Residuos petroquimicos"] + sulfatos;
            contaminantes["Ácido clorhídrico"] = contaminantes["Sulfatos"] + clorhidrico;
            contaminantes["Fosfatos"] = contaminantes["Ácido clorhídrico"] + fosfatos;
            contaminantes["Óxidos"] = contaminantes["Fosfatos"] + oxidos;

            // Leer probabilidades de condiciones sanguíneas desde ComboBox
            double acidez = double.Parse(cmbAcidez.SelectedItem.ToString());
            double anemia = double.Parse(cmbAnemia.SelectedItem.ToString());
            double normal = double.Parse(cmbNormal.SelectedItem.ToString());
            double glucosa = double.Parse(cmbGlucosa.SelectedItem.ToString());
            double alcalinidad = double.Parse(cmbAlcalinidad.SelectedItem.ToString());

            // Validar que la suma de condiciones no exceda 1
            double sumaCondiciones = acidez + anemia + normal + glucosa + alcalinidad;
            if (sumaCondiciones > 1.0)
            {
                MessageBox.Show("La suma de las probabilidades de condiciones sanguíneas excede 1. Ajuste los valores.");
                return;
            }
            // Ajustar el último valor (Alcalinidad) para que la suma llegue a 1 si es menor
            if (sumaCondiciones < 1.0)
            {
                alcalinidad = 1.0 - (acidez + anemia + normal + glucosa);
                if (alcalinidad < 0)
                {
                    MessageBox.Show("No se puede ajustar la probabilidad de Alto grado de alcalinidad. Ajuste los valores.");
                    return;
                }
            }

            // Actualizar la distribución acumulada de condiciones
            condiciones["Alto grado de acidez"] = acidez;
            condiciones["Estado de anemia aguda"] = acidez + anemia;
            condiciones["Estado en rango normal"] = condiciones["Estado de anemia aguda"] + normal;
            condiciones["Exceso de glucosa"] = condiciones["Estado en rango normal"] + glucosa;
            condiciones["Alto grado de alcalinidad"] = condiciones["Exceso de glucosa"] + alcalinidad;

            // Determinar la semilla según la selección de cmbSemDi
            long semilla;
            if (cmbSemDi.SelectedItem.ToString() == "Dinámica")
            {
                semilla = DateTime.Now.Ticks;
            }
            else // "Específica"
            {
                if (!long.TryParse(txtSemilla.Text, out semilla) || semilla < 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para la semilla (un número entero no negativo).");
                    return;
                }
                lblEspSem.Text = $"Semilla Específica: {semilla}";
            }

            int extraAgua = (int)(totalMuestrasAgua * 0.5); // 50% extra de muestras de agua
            int extraSangre = (int)(totalMuestrasSangre * 0.5); // 50% extra de muestras de sangre
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + extraAgua, semilla);
            List<double> numerosSangre = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + extraSangre, semilla + 1);
            List<int> aguaContaminada = SimularCalidadAgua(numerosAgua, totalMuestrasAgua);
            List<string> contaminantesAsignados = AsignarContaminantes(numerosAgua, aguaContaminada, totalMuestrasAgua);
            List<int> alteracionesSanguineas = SimularImpactoAnimales(aguaContaminada, numerosSangre, puntos, animales, muestreos);
            var (resultadosPuntos, puntosNoApta, contaminantesNoApta) = EvaluarAptitud(alteracionesSanguineas, puntos, animales, muestreos, totalMuestrasAgua);

            // Limpiar DataGridView
            dgvResultados.Rows.Clear();

            // Agregar resultados por punto
            foreach (var resultado in resultadosPuntos)
            {
                string contaminante = resultado.aptitud == "No Apta" ? resultado.contaminante : "-";
                string condicion = resultado.aptitud == "No Apta" ? resultado.condicion : "-";
                string animalesAfectados = resultado.animalesAfectados + " de " + (animales * muestreos);
                dgvResultados.Rows.Add(resultado.punto, resultado.porcentaje, resultado.aptitud, contaminante, condicion, animalesAfectados, resultado.recomendacion);
            }

            // Generar y mostrar la conclusión en lblConclusiones
            string conclusion = puntosNoApta > 0 ? "El agua de los mantos freáticos no es apta para el consumo animal. Contaminantes presentes: " + string.Join(", ", contaminantesNoApta) : "El agua de los mantos freáticos es apta para seguir siendo empleada por los animales.";
            lblConclusiones.Text = conclusion;
            lblConclusiones.Visible = true;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSumaContaminantes();
            ActualizarSumaCondiciones();
        }

        private void ActualizarSumaContaminantes()
        {
            double suma = double.Parse(cmbColoidales.SelectedItem.ToString()) +
                          double.Parse(cmbMercurio.SelectedItem.ToString()) +
                          double.Parse(cmbPetroquimicos.SelectedItem.ToString()) +
                          double.Parse(cmbSulfatos.SelectedItem.ToString()) +
                          double.Parse(cmbClorhidrico.SelectedItem.ToString()) +
                          double.Parse(cmbFosfatos.SelectedItem.ToString()) +
                          double.Parse(cmbOxidos.SelectedItem.ToString());
            lblContaminantesTotal.Text = $"{(suma * 100):F0}%";
            lblContaminantesTotal.ForeColor = suma > 1.0 ? Color.Red : Color.Green;
        }

        private void ActualizarSumaCondiciones()
        {
            double suma = double.Parse(cmbAcidez.SelectedItem.ToString()) +
                          double.Parse(cmbAnemia.SelectedItem.ToString()) + // Fixed from SelectedIndex
                          double.Parse(cmbNormal.SelectedItem.ToString()) +
                          double.Parse(cmbGlucosa.SelectedItem.ToString()) +
                          double.Parse(cmbAlcalinidad.SelectedItem.ToString());
            lblCondicionesTotal.Text = $"{(suma * 100):F0}%";
            lblCondicionesTotal.ForeColor = suma > 1.0 ? Color.Red : Color.Green;
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void cmbSemDi_SelectedIndexChanged_1(object sender, EventArgs e)
        {// Mostrar u ocultar txtSemilla y lblEspSem según la selección
            bool isEspecifica = cmbSemDi.SelectedItem.ToString() == "Específica";
            txtSemilla.Visible = isEspecifica;
            lblEspSem.Visible = isEspecifica;
            if (isEspecifica && !string.IsNullOrEmpty(txtSemilla.Text))
            {
                lblEspSem.Text = $"Semilla Específica: {txtSemilla.Text}";
            }
            else
            {
                lblEspSem.Text = "Semilla Específica: (pendiente de ingreso)";
            }

        }
    }

}