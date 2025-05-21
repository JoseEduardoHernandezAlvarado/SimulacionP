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
        }

        // Parámetros iniciales
        private int a = 23; // Constante multiplicativa
        private int c = 101; // Constante aditiva
        private int m = 1009; // Módulo
        private double umbralNoApta = 0.40; // 40% de condiciones anormales
        private double porcentajeContaminacion = 0.30; // 30% según validación
        private double probAlteracionSi = 0.70; // 70% si agua contaminada
        private double probAlteracionNo = 0.10; // 10% si agua no contaminada

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
            { "Estado de anemia aguda", 0.26 },
            { "Estado en rango normal", 0.61 },
            { "Exceso de glucosa", 0.78 },
            { "Alto grado de alcalinidad", 1.00 }
        };

        // MÓDULO 1: Generación de números pseudoaleatorios
        private List<double> GenerarNumerosPseudoaleatorios(int cantidad, long semilla)
        {
            List<double> numeros = new List<double>();
            int X = (int)(semilla % m); // Asegurarse de que la semilla no sea mayor que m
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
        private (List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)>, int puntosNoApta, string contaminanteGlobal) EvaluarAptitud(List<int> alteraciones, int puntos, int animales, int muestreos)
        {
            List<(int punto, double porcentaje, string aptitud, string contaminante, string condicion, int animalesAfectados, string recomendacion)> resultadosPuntos = new List<(int, double, string, string, string, int, string)>();
            int puntosNoApta = 0;
            Dictionary<string, int> conteoContaminantesGlobal = new Dictionary<string, int>
            {
                { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
            };
            long semilla = DateTime.Now.Ticks;
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(puntos * animales * muestreos * 20, (int)(semilla % m));
            List<double> numerosCondiciones = GenerarNumerosPseudoaleatorios(puntos * animales * muestreos * 20, (int)(semilla % m + 1));

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
                    // Determinar contaminante más frecuente
                    Dictionary<string, int> conteoContaminantesPunto = new Dictionary<string, int>
                    {
                        { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                        { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                        { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
                    };
                    int muestrasPorPunto = animales * muestreos * 20;
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
                    contaminante = conteoContaminantesPunto.OrderByDescending(x => x.Value).First().Key;

                    // Determinar condición sanguínea más frecuente
                    Dictionary<string, int> conteoCondicionesPunto = new Dictionary<string, int>
                    {
                        { "Alto grado de acidez", 0 },
                        { "Estado de anemia aguda", 0 },
                        { "Estado en rango normal", 0 },
                        { "Exceso de glucosa", 0 },
                        { "Alto grado de alcalinidad", 0 }
                    };
                    for (int i = punto * muestrasPorPunto; i < (punto + 1) * muestrasPorPunto; i++)
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
                }
                else
                {
                    contaminante = "-";
                    condicionSanguinea = "-";
                    recomendacion = "Sin acción";
                }

                resultadosPuntos.Add((punto + 1, porcentajeAnormal, aptitud, contaminante, condicionSanguinea, animalesAfectados, recomendacion));
            }

            string contaminanteGlobal = puntosNoApta > 0 ? conteoContaminantesGlobal.OrderByDescending(x => x.Value).First().Key : "";
            return (resultadosPuntos, puntosNoApta, contaminanteGlobal);
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // Leer parámetros dinámicos desde los controles
            int puntos = (int)nudPuntos.Value;
            int animales = (int)nudAnimales.Value;
            int dias = (int)nudDias.Value;
            int muestrasPorDia = (int)nudMuestrasPorDia.Value;
            int muestreos = 3; // Fijo según el documento

            // Calcular totales
            int totalMuestrasAgua = muestrasPorDia * dias * puntos;
            int totalMuestrasSangre = animales * puntos * muestreos;

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

            // Usar la hora del sistema como semilla
            long semilla = DateTime.Now.Ticks;

            int extra = (int)(totalMuestrasAgua * 0.5); // 50% más
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + extra, semilla);
            List<double> numerosSangre = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + extra, semilla + 1);
            List<int> aguaContaminada = SimularCalidadAgua(numerosAgua, totalMuestrasAgua);
            List<int> alteracionesSanguineas = SimularImpactoAnimales(aguaContaminada, numerosSangre, puntos, animales, muestreos);
            var (resultadosPuntos, puntosNoApta, contaminanteGlobal) = EvaluarAptitud(alteracionesSanguineas, puntos, animales, muestreos);

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

            // Agregar conclusión basada en las muestras de sangre
            string conclusion = puntosNoApta > 0 ? "El agua de los mantos freáticos no es apta para el consumo animal. Contaminante principal: " + contaminanteGlobal : "El agua de los mantos freáticos es apta para seguir siendo empleada por los animales.";
            dgvResultados.Rows.Add("Conclusión", "", conclusion, "", "", "", "");
        }
    }
}