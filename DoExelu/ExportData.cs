using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ExcelLibrary.SpreadSheet;


namespace DoExelu
{
    class ExportData
    {


        public void export(List<Data> data,string path)
        {
            Workbook workBook = new Workbook();
            Worksheet workSheet = new Worksheet("sheet1");

            for (int i = 0; i < data.Count; i++)
            {
                workSheet.Cells[i, 0] = new Cell(Int32.Parse(data[i].ID));
                workSheet.Cells[i, 1] = new Cell(data[i].name);
                workSheet.Cells[i, 2] = new Cell(data[i].countryCode);
                workSheet.Cells[i, 3] = new Cell(data[i].district);
                workSheet.Cells[i, 4] = new Cell(Int32.Parse(data[i].population));
            }

            workBook.Worksheets.Add(workSheet);
            workBook.Save(path);

        }
    }
}
