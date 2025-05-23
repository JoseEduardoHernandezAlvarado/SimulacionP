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

            // Configurar DataGridView para resultados por punto
            dgvResultados.Columns.Add("Punto", "Punto de Muestreo");
            dgvResultados.Columns.Add("PorcentajeAlteraciones", "Alteraciones Promedio (%)");
            dgvResultados.Columns.Add("Aptitud", "Aptitud del Agua (Más Frecuente)");
            dgvResultados.Columns.Add("Contaminante", "Contaminante Principal (Más Frecuente)");
            dgvResultados.Columns.Add("CondicionSanguinea", "Condición Sanguínea Principal (Más Frecuente)");
            dgvResultados.Columns.Add("AnimalesAfectados", "Animales Afectados Promedio");
            dgvResultados.Columns.Add("Recomendacion", "Recomendación (Más Frecuente)");
            dgvResultados.Columns["PorcentajeAlteraciones"].DefaultCellStyle.Format = "N2";

            // Ajustar el ancho de las columnas para mejor visualización
            dgvResultados.Columns["Punto"].Width = 100;
            dgvResultados.Columns["PorcentajeAlteraciones"].Width = 120;
            dgvResultados.Columns["Aptitud"].Width = 100;
            dgvResultados.Columns["Contaminante"].Width = 150;
            dgvResultados.Columns["CondicionSanguinea"].Width = 150;
            dgvResultados.Columns["AnimalesAfectados"].Width = 120;
            dgvResultados.Columns["Recomendacion"].Width = 120;

            // Configurar dgvInformacion (ya está en el diseñador, solo añadir columnas)
            dgvInformacion.Columns.Clear();
            dgvInformacion.Columns.Add("PuntosContaminados", "Puntos de muestreo contaminados (%)");
            dgvInformacion.Columns.Add("AguaNoApta", "Clasificados como agua no apta (%)");
            dgvInformacion.Columns.Add("AnimalesAlteradosContaminada", "Animales alterados agua contaminada (%)");
            dgvInformacion.Columns.Add("AnimalesAlteradosNoContaminada", "Animales alterados agua no contaminada (%)");
            dgvInformacion.Columns.Add("TotalAnimales", "Total de animales simulados (Cantidad)");
            dgvInformacion.Columns.Add("AnimalesAlterados", "Animales con alteraciones (Cantidad)");
            // Formato para columnas de porcentaje
            dgvInformacion.Columns["PuntosContaminados"].DefaultCellStyle.Format = "N2";
            dgvInformacion.Columns["AguaNoApta"].DefaultCellStyle.Format = "N2";
            dgvInformacion.Columns["AnimalesAlteradosContaminada"].DefaultCellStyle.Format = "N2";
            dgvInformacion.Columns["AnimalesAlteradosNoContaminada"].DefaultCellStyle.Format = "N2";
            dgvInformacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInformacion.ReadOnly = true;
            dgvInformacion.AllowUserToAddRows = false;

            // Asegurar que lblConclusiones esté oculto inicialmente y ajustar su tamaño
           
         
            lblConclusiones.MaximumSize = new Size(400, 100);
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
        private long a = 23; // Constante multiplicativa
        private long c = 101; // Constante aditiva
        private long m = 1009; // Módulo (2^32)
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

        // MÓDULO 4: Evaluación y decisión (modificado para devolver más datos para múltiples corridas)
        private (List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)> resultadosPuntos, int puntosNoApta, List<string> contaminantesNoApta, List<int> aguaContaminada, List<int> alteracionesSanguineas) EvaluarAptitud(List<int> alteraciones, int puntos, int animales, int muestreos, int totalMuestrasAgua, long semilla)
        {
            List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)> resultadosPuntos = new List<(int, double, string, string, string, int, string)>();
            int puntosNoApta = 0;
            List<string> contaminantesNoApta = new List<string>();
            int totalMuestrasSangre = puntos * animales * muestreos;
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + (int)(totalMuestrasAgua * 0.5), (int)(semilla % m));
            List<double> numerosCondiciones = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + (int)(totalMuestrasSangre * 0.5), (int)(semilla % m + 1));
            List<int> aguaContaminada = SimularCalidadAgua(numerosAgua, totalMuestrasAgua);
            List<string> contaminantesAsignados = AsignarContaminantes(numerosAgua, aguaContaminada, totalMuestrasAgua);

            // Crear intervalos acumulados para condiciones sanguíneas
            var intervalosCondiciones = new List<(string nombre, double inicio, double fin)>
            {
                ("Alto grado de acidez", 0.00, condiciones["Alto grado de acidez"]),
                ("Estado de anemia aguda", condiciones["Alto grado de acidez"], condiciones["Estado de anemia aguda"]),
                ("Estado en rango normal", condiciones["Estado de anemia aguda"], condiciones["Estado en rango normal"]),
                ("Exceso de glucosa", condiciones["Estado en rango normal"], condiciones["Exceso de glucosa"]),
                ("Alto grado de alcalinidad", condiciones["Exceso de glucosa"], condiciones["Alto grado de alcalinidad"])
            };

            for (int punto = 0; punto < puntos; punto++)
            {
                int inicio = punto * animales * muestreos;
                List<int> puntoSangre = alteraciones.GetRange(inicio, animales * muestreos);
                double porcentajeAnormal = (double)puntoSangre.Count(x => x == 1) / puntoSangre.Count * 100;
                string aptitud = porcentajeAnormal > (umbralNoApta * 100) ? "No Apta" : "Apta";
                string contaminante = "-";
                string condicionSanguinea = "-";
                int animalesAfectados = puntoSangre.Count(x => x == 1);
                string recomendacion = aptitud == "Apta" ? "Sin acción" : (porcentajeAnormal > 60 ? "Limpieza urgente" : "Monitoreo");

                if (aptitud == "No Apta")
                {
                    puntosNoApta++;
                    // Obtener el contaminante más frecuente para este punto
                    int muestrasPorPunto = totalMuestrasAgua / puntos;
                    var conteoContaminantesPunto = new Dictionary<string, int>
                    {
                        { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                        { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                        { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
                    };
                    for (int i = punto * muestrasPorPunto; i < (punto + 1) * muestrasPorPunto; i++)
                    {
                        if (contaminantesAsignados[i] != "No contaminado")
                            conteoContaminantesPunto[contaminantesAsignados[i]]++;
                    }
                    contaminante = conteoContaminantesPunto.OrderByDescending(x => x.Value).FirstOrDefault(x => x.Value > 0).Key ?? "Ninguno";
                    if (contaminante != "Ninguno" && !contaminantesNoApta.Contains(contaminante))
                        contaminantesNoApta.Add(contaminante);

                    // Obtener la condición sanguínea más frecuente
                    var conteoCondicionesPunto = new Dictionary<string, int>
                    {
                        { "Alto grado de acidez", 0 }, { "Estado de anemia aguda", 0 },
                        { "Estado en rango normal", 0 }, { "Exceso de glucosa", 0 },
                        { "Alto grado de alcalinidad", 0 }
                    };
                    int idxInicioCond = punto * animales * muestreos;
                    for (int i = idxInicioCond; i < idxInicioCond + animales * muestreos; i++)
                    {
                        double Ri = numerosCondiciones[i];
                        foreach (var intervalo in intervalosCondiciones)
                        {
                            if (Ri >= intervalo.inicio && Ri < intervalo.fin)
                            {
                                conteoCondicionesPunto[intervalo.nombre]++;
                                break;
                            }
                        }
                    }
                    condicionSanguinea = conteoCondicionesPunto.OrderByDescending(x => x.Value).First().Key;
                }

                resultadosPuntos.Add((punto + 1, porcentajeAnormal, aptitud, contaminante, condicionSanguinea, animalesAfectados, recomendacion));
            }

            return (resultadosPuntos, puntosNoApta, contaminantesNoApta, aguaContaminada, alteraciones);
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
            // Leer y validar el número de corridas desde txtCorridas
            int numCorridas;
            if (!int.TryParse(txtCorridas.Text, out numCorridas) || numCorridas <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido de corridas (un entero positivo).");
                return;
            }

            // Leer parámetros dinámicos desde los controles
            int puntos = (int)nudPuntos.Value;
            int animales = (int)nudAnimales.Value;
            int dias = (int)nudDias.Value;
            int muestrasPorDia = (int)nudMuestrasPorDia.Value;
            int muestreos = muestreosPorPunto;

            // Calcular totales
            int totalMuestrasAgua = muestrasPorDia * dias * puntos;
            int totalMuestrasSangre = animales * puntos * muestreos;
            int totalAnimalesSimulados = totalMuestrasSangre;

        
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

            // Determinar la semilla inicial según la selección de cmbSemDi
            long semillaBase;
            if (cmbSemDi.SelectedItem.ToString() == "Dinámica")
            {
                semillaBase = DateTime.Now.Ticks;
            }
            else // "Específica"
            {
                if (!long.TryParse(txtSemilla.Text, out semillaBase) || semillaBase < 0)
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para la semilla (un número entero no negativo).");
                    return;
                }
                lblEspSem.Text = $"Semilla Específica: {semillaBase}";
            }

            int extraAgua = (int)(totalMuestrasAgua * 0.5); // 50% extra de muestras de agua
            int extraSangre = (int)(totalMuestrasSangre * 0.5); // 50% extra de muestras de sangre

            // Estructuras para almacenar los resultados de todas las corridas
            var resultadosPorPunto = new List<List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)>>();
            double totalPuntosContaminados = 0;
            double totalPuntosNoApta = 0;
            double totalAnimalesAlteradosAguaContaminada = 0;
            double totalAnimalesAlteradosAguaNoContaminada = 0;
            int totalAnimalesConAlteraciones = 0;

            // Ejecutar las simulaciones (corridas)
            for (int corrida = 0; corrida < numCorridas; corrida++)
            {
                long semillaCorrida = semillaBase + corrida; // Ajustar la semilla para cada corrida
                List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + extraAgua, semillaCorrida);
                List<double> numerosSangre = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + extraSangre, semillaCorrida + 1);
                List<int> aguaContaminada = SimularCalidadAgua(numerosAgua, totalMuestrasAgua);
                List<int> alteracionesSanguineas = SimularImpactoAnimales(aguaContaminada, numerosSangre, puntos, animales, muestreos);
                var (resultadosPuntosCorrida, puntosNoAptaCorrida, contaminantesNoAptaCorrida, aguaContaminadaCorrida, alteracionesCorrida) = EvaluarAptitud(alteracionesSanguineas, puntos, animales, muestreos, totalMuestrasAgua, semillaCorrida);

                // Almacenar los resultados por punto
                resultadosPorPunto.Add(resultadosPuntosCorrida);

                // Calcular métricas para dgvInformacion
                // Puntos de muestreo contaminados (%)
                totalPuntosContaminados += (double)aguaContaminadaCorrida.Count(x => x == 1) / totalMuestrasAgua * 100;

                // Clasificados como agua no apta (%)
                totalPuntosNoApta += (double)puntosNoAptaCorrida / puntos * 100;

                // Animales alterados (agua contaminada y no contaminada)
                int muestrasPorPunto = totalMuestrasAgua / puntos;
                int animalesPorPunto = animales * muestreos;
                int animalesAlteradosContaminada = 0;
                int animalesAlteradosNoContaminada = 0;
                int totalAnimalesContaminada = 0;
                int totalAnimalesNoContaminada = 0;

                for (int punto = 0; punto < puntos; punto++)
                {
                    int contaminados = aguaContaminadaCorrida.GetRange(punto * muestrasPorPunto, muestrasPorPunto).Count(x => x == 1);
                    bool esContaminado = contaminados > 0; // Consideramos un punto contaminado si tiene al menos una muestra contaminada
                    int inicioSangre = punto * animalesPorPunto;
                    int animalesAfectadosPunto = alteracionesCorrida.GetRange(inicioSangre, animalesPorPunto).Count(x => x == 1);

                    if (esContaminado)
                    {
                        animalesAlteradosContaminada += animalesAfectadosPunto;
                        totalAnimalesContaminada += animalesPorPunto;
                    }
                    else
                    {
                        animalesAlteradosNoContaminada += animalesAfectadosPunto;
                        totalAnimalesNoContaminada += animalesPorPunto;
                    }
                }

                totalAnimalesAlteradosAguaContaminada += totalAnimalesContaminada > 0 ? (double)animalesAlteradosContaminada / totalAnimalesContaminada * 100 : 0;
                totalAnimalesAlteradosAguaNoContaminada += totalAnimalesNoContaminada > 0 ? (double)animalesAlteradosNoContaminada / totalAnimalesNoContaminada * 100 : 0;

                // Total de animales con alteraciones
                totalAnimalesConAlteraciones += alteracionesCorrida.Count(x => x == 1);
            }

            // Procesar resultados para dgvResultados (promedios y frecuencias por punto)
            var resultadosPromedio = new List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, double animalesAfectados, string recomendacion)>();
            for (int punto = 1; punto <= puntos; punto++)
            {
                var resultadosPunto = resultadosPorPunto.SelectMany(r => r.Where(x => x.punto == punto)).ToList();

                // Promedio de porcentaje de alteraciones
                double porcentajePromedio = resultadosPunto.Average(x => x.porcentaje);

                // Aptitud más frecuente
                string aptitudFrecuente = resultadosPunto.GroupBy(x => x.aptitud)
                    .OrderByDescending(g => g.Count())
                    .First().Key;

                // Contaminante más frecuente (solo si no es "-")
                string contaminanteFrecuente = resultadosPunto.Where(x => x.contaminante != "-")
                    .GroupBy(x => x.contaminante)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault()?.Key ?? "-";

                // Condición sanguínea más frecuente (solo si no es "-")
                string condicionFrecuente = resultadosPunto.Where(x => x.condicion != "-")
                    .GroupBy(x => x.condicion)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault()?.Key ?? "-";

                // Promedio de animales afectados (dividido por el número de corridas)
                double animalesAfectadosPromedio = resultadosPunto.Average(x => x.animalesAfectados) / numCorridas;

                // Recomendación más frecuente
                string recomendacionFrecuente = resultadosPunto.GroupBy(x => x.recomendacion)
                    .OrderByDescending(g => g.Count())
                    .First().Key;

                resultadosPromedio.Add((punto, porcentajePromedio, aptitudFrecuente, contaminanteFrecuente, condicionFrecuente, animalesAfectadosPromedio, recomendacionFrecuente));
            }

            // Limpiar DataGridView y agregar resultados promediados
            dgvResultados.Rows.Clear();
            foreach (var resultado in resultadosPromedio)
            {
                string animalesAfectados = $"{resultado.animalesAfectados:F2} de {animales * muestreos}";
                dgvResultados.Rows.Add(resultado.punto, resultado.porcentaje, resultado.aptitud, resultado.contaminante, resultado.condicion, animalesAfectados, resultado.recomendacion);
            }

            // Generar y mostrar la conclusión en lblConclusiones
            int puntosNoAptaPromedio = resultadosPromedio.Count(x => x.aptitud == "No Apta");
            var contaminantesNoApta = resultadosPromedio.Where(x => x.contaminante != "-").Select(x => x.contaminante).Distinct().ToList();
            string conclusion = puntosNoAptaPromedio > 0 ? "El agua de los mantos freáticos no es apta para el consumo animal (promedio). Contaminantes presentes: " + string.Join(", ", contaminantesNoApta) : "El agua de los mantos freáticos es apta para seguir siendo empleada por los animales (promedio).";
            lblConclusiones.Text = conclusion;
            lblConclusiones.Visible = true;

            // Calcular métricas promediadas para dgvInformacion
            double promedioPuntosContaminados = totalPuntosContaminados / numCorridas;
            double promedioPuntosNoApta = totalPuntosNoApta / numCorridas;
            double promedioAnimalesAlteradosContaminada = totalAnimalesAlteradosAguaContaminada / numCorridas;
            double promedioAnimalesAlteradosNoContaminada = totalAnimalesAlteradosAguaNoContaminada / numCorridas;
            int promedioAnimalesConAlteraciones = totalAnimalesConAlteraciones / numCorridas;

            // Limpiar y llenar dgvInformacion
            dgvInformacion.Rows.Clear();
            dgvInformacion.Rows.Add(promedioPuntosContaminados, promedioPuntosNoApta, promedioAnimalesAlteradosContaminada, promedioAnimalesAlteradosNoContaminada, totalAnimalesSimulados, promedioAnimalesConAlteraciones);
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
                          double.Parse(cmbAnemia.SelectedItem.ToString()) +
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}