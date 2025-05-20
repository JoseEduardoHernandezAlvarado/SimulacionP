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
            dgvResultados.Columns.Add("Punto", "Punto de Muestreo");
            dgvResultados.Columns.Add("PorcentajeAlteraciones", "Porcentaje de Alteraciones (%)");
            dgvResultados.Columns.Add("Aptitud", "Aptitud del Agua");
            dgvResultados.Columns.Add("Contaminante", "Contaminante Más Frecuente");
            dgvResultados.Columns["PorcentajeAlteraciones"].DefaultCellStyle.Format = "N2"; // Formato con 2 decimales
        }

        // Parámetros iniciales
        private int a = 23; // Constante multiplicativa
        private int c = 101; // Constante aditiva
        private int m = 1009; // Módulo
        private int totalMuestrasAgua = 1120; // 20 por día x 14 días x 4 puntos
        private int totalMuestrasSangre = 60; // 5 animales x 4 puntos x 3 muestreos
        private double umbralNoApta = 0.40; // 40% de condiciones anormales
        private double porcentajeContaminacion = 0.30; // 30% según validación
        private double probAlteracionSi = 0.70; // 70% si agua contaminada
        private double probAlteracionNo = 0.10; // 10% si agua no contaminada

        // Distribución de contaminantes en agua
        private Dictionary<string, double> contaminantes = new Dictionary<string, double>
        {
            { "Sustancias coloidales", 0.05 },
            { "Exceso de mercurio", 0.15 },
            { "Residuos petroquimicos", 0.40 },
            { "Sulfatos", 0.55 },
            { "Ácido clorhídrico", 0.67 },
            { "Fosfatos", 0.83 },
            { "Óxidos", 1.00 }
        };

        // Distribución de condiciones en sangre
        private Dictionary<string, double> condiciones = new Dictionary<string, double>
        {
            { "Alto grado de acidez", 0.18 },
            { "Estado de anemia aguda", 0.26 },
            { "Estado en rango normal", 0.61 },
            { "Exceso de glucosa", 0.78 },
            { "Alto grado de alcalinidad", 1.00 }
        };

        // MÓDULO 1: Generación de números pseudoaleatorios
        private List<double> GenerarNumerosPseudoaleatorios(int cantidad, int semilla)
        {
            List<double> numeros = new List<double>();
            int X = semilla;
            for (int i = 0; i < cantidad; i++)
            {
                X = (a * X + c) % m;
                double Ri = (double)X / m;
                numeros.Add(Ri);
            }
            return numeros;
        }

        // MÓDULO 2: Simulación de calidad del agua
        private List<int> SimularCalidadAgua(List<double> numeros)
        {
            List<int> aguaContaminada = new List<int>();
            for (int i = 0; i < totalMuestrasAgua; i++)
            {
                if (numeros[i] < porcentajeContaminacion)
                    aguaContaminada.Add(1); // Contaminada
                else
                    aguaContaminada.Add(0); // No contaminada
            }
            MessageBox.Show($"Total contaminados: {aguaContaminada.Count(x => x == 1)} de 1120");
            return aguaContaminada;
        }

        // MÓDULO 3: Simulación de impacto en animales (corregido)
        private List<int> SimularImpactoAnimales(List<int> aguaContaminada, List<double> numerosSangre)
        {
            List<int> alteracionesSanguineas = new List<int>();
            int idxSangre = 0;
            for (int punto = 0; punto < 4; punto++)
            {
                // Calcular porcentaje de agua contaminada por punto (280 muestras)
                int contaminados = aguaContaminada.GetRange(punto * 280, 280).Count(x => x == 1);
                double probContaminacionPunto = (double)contaminados / 280;
                MessageBox.Show($"Punto {punto}: {contaminados} contaminados de 280, Prob: {probContaminacionPunto}");
                for (int muestreo = 0; muestreo < 3; muestreo++)
                {
                    for (int animal = 0; animal < 5; animal++)
                    {
                        double prob = probContaminacionPunto > 0.3 ? probAlteracionSi : probAlteracionNo; // Umbral ajustado a 0.3
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
        private (List<(int punto, double porcentaje, string aptitud, string contaminante)>, int puntosNoApta, string contaminanteGlobal) EvaluarAptitud(List<int> alteraciones)
        {
            List<(int punto, double porcentaje, string aptitud, string contaminante)> resultadosPuntos = new List<(int, double, string, string)>();
            int puntosNoApta = 0;
            Dictionary<string, int> conteoContaminantesGlobal = new Dictionary<string, int>
            {
                { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
            };
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua, int.Parse(txtSemilla.Text));

            for (int punto = 0; punto < 4; punto++)
            {
                int inicio = punto * 15;
                List<int> puntoSangre = alteraciones.GetRange(inicio, 15);
                double porcentajeAnormal = (double)puntoSangre.Count(x => x == 1) / puntoSangre.Count * 100;
                string aptitud = porcentajeAnormal > (umbralNoApta * 100) ? "No Apta" : "Apta";
                string contaminante = "";

                if (aptitud == "No Apta")
                {
                    puntosNoApta++;
                    Dictionary<string, int> conteoContaminantesPunto = new Dictionary<string, int>
                    {
                        { "Sustancias coloidales", 0 }, { "Exceso de mercurio", 0 },
                        { "Residuos petroquimicos", 0 }, { "Sulfatos", 0 },
                        { "Ácido clorhídrico", 0 }, { "Fosfatos", 0 }, { "Óxidos", 0 }
                    };

                    for (int i = punto * 280; i < (punto + 1) * 280; i++)
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
                }

                resultadosPuntos.Add((punto + 1, porcentajeAnormal, aptitud, contaminante));
            }

            string contaminanteGlobal = puntosNoApta > 0 ? conteoContaminantesGlobal.OrderByDescending(x => x.Value).First().Key : "";
            return (resultadosPuntos, puntosNoApta, contaminanteGlobal);
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSemilla.Text, out int semilla) || semilla < 0)
            {
                MessageBox.Show("Ingrese una semilla válida (número entero positivo).");
                return;
            }

            int extra = (int)(totalMuestrasAgua * 0.5); // 50% más
            List<double> numerosAgua = GenerarNumerosPseudoaleatorios(totalMuestrasAgua + extra, semilla);
            List<double> numerosSangre = GenerarNumerosPseudoaleatorios(totalMuestrasSangre + extra, semilla + 1);
            List<int> aguaContaminada = SimularCalidadAgua(numerosAgua);
            List<int> alteracionesSanguineas = SimularImpactoAnimales(aguaContaminada, numerosSangre);
            var (resultadosPuntos, puntosNoApta, contaminanteGlobal) = EvaluarAptitud(alteracionesSanguineas);

            MessageBox.Show($"Puntos no aptos: {puntosNoApta}");

            // Limpiar DataGridView
            dgvResultados.Rows.Clear();

            // Agregar resultados por punto
            foreach (var resultado in resultadosPuntos)
            {
                dgvResultados.Rows.Add(resultado.punto, resultado.porcentaje, resultado.aptitud, resultado.contaminante);
            }

            // Agregar fila de resumen
            string resumenPuntos = $"Total: {puntosNoApta} de 4";
            string resumenContaminante = puntosNoApta > 0 ? contaminanteGlobal : "N/A";
            dgvResultados.Rows.Add("Resumen", "", resumenPuntos, resumenContaminante);
        }
    }
}