using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TecnoDev.Controller
{
    public class ExcelReader
    {
        public void ExportarDataGridViewAExcel(DataGridView dgv)
        {
            // Crear aplicación Excel
            Excel.Application excelApp = new Excel.Application();
            excelApp.Application.Workbooks.Add(Type.Missing);

            // Añadir las cabeceras de las columnas
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                excelApp.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }

            // Añadir las filas del DataGridView
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    excelApp.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Formato: Ajustar el tamaño de las columnas automáticamente
            excelApp.Columns.AutoFit();

            // Mostrar Excel al usuario
            excelApp.Visible = true;

            // Liberar el objeto de Excel
            liberarObjeto(excelApp);
        }

        private void liberarObjeto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Ocurrió un error al liberar el objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
