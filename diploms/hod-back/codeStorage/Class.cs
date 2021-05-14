using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.codeStorage
{
    public class Class
    {
        #region fast solution
        /// 7.2.2
        //var requir = listRequirs.FirstOrDefault(x => x.FgosNum == "7.2.2");
        //float value722 = 0;
        //ws.Cell("B" + activeRow).Value = "п. 7.2.2";
        //ws.Range("C" + activeRow.ToString() + ":E" + activeRow.ToString()).Merge();

        ////ws.Cell("C" + activeRow).Value = requir.Content;
        //ws.Cell("C" + activeRow).Value = requir.FgosPropertyView;
        ////ws.Cell("C" + activeRow).Style.Alignment.SetShrinkToFit();
        //ws.Cell("C" + activeRow).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Justify);

        //ws.Cell("F" + activeRow).Value = $"не менее {requir.SettedValue} {requir.UnitName}";
        //string requirFormula = "=";
        //foreach (var j in this.exList)
        //{
        //    if (j.is722) { requirFormula += $"I{j.RowIndex}+"; value722 += j.Rate; }
        //}
        //if (requirFormula.Last() == '+') { requirFormula = requirFormula.Remove(requirFormula.Length - 1); }
        //else { requirFormula = ""; }

        //ws.Cell("J" + activeRow).FormulaA1 = requirFormula;
        //ws.Cell("G" + activeRow).Value = Math.Round((value722 / sumTotal) * 100);

        //ws.Rows(activeRow, activeRow).AdjustToContents(crutchWidth, crutchWidth);


        /// 7.2.3
        //ws.Row(activeRow).InsertRowsBelow(1);
        //activeRow++;

        //requir = listRequirs.FirstOrDefault(x => x.FgosNum == "7.2.3");
        //float value723 = 0;
        //ws.Cell("B" + activeRow).Value = "п. 7.2.3";
        //ws.Range("C" + activeRow.ToString() + ":E" + activeRow.ToString()).Merge();

        ////ws.Cell("C" + activeRow).Value = requir.Content;
        //ws.Cell("C" + activeRow).Value = requir.FgosPropertyView;
        //ws.Cell("C" + activeRow).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Justify);

        //ws.Cell("F" + activeRow).Value = $"не менее {requir.SettedValue} {requir.UnitName}";
        //requirFormula = "=";
        //foreach (var j in this.exList)
        //{
        //    if (j.is723) { requirFormula += $"I{j.RowIndex}+"; value723 += j.Rate; }
        //}
        //if (requirFormula.Last() == '+') { requirFormula = requirFormula.Remove(requirFormula.Length - 1); }
        //else { requirFormula = ""; }

        //ws.Cell("J" + activeRow).FormulaA1 = requirFormula;
        //ws.Cell("G" + activeRow).Value = Math.Round((value723 / sumTotal) * 100);

        ////ws.Row(activeRow).Style.Alignment.WrapText = false;
        //ws.Rows(activeRow, activeRow).AdjustToContents(crutchWidth, crutchWidth);


        /// 7.2.4
        //ws.Row(activeRow).InsertRowsBelow(1);
        //activeRow++;

        //requir = listRequirs.FirstOrDefault(x => x.FgosNum == "7.2.4");
        //float value724 = 0;
        //ws.Cell("B" + activeRow).Value = "п. 7.2.4";
        //ws.Range("C" + activeRow.ToString() + ":E" + activeRow.ToString()).Merge();

        ////ws.Cell("C" + activeRow).Value = requir.Content;
        //ws.Cell("C" + activeRow).Value = requir.FgosPropertyView;
        ////ws.Cell("C" + activeRow).Style.Font.SetVerticalAlignment(XLFontVerticalTextAlignmentValues.Subscript);
        //ws.Cell("C" + activeRow).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Justify);

        //ws.Cell("F" + activeRow).Value = $"не менее {requir.SettedValue} {requir.UnitName}";
        //requirFormula = "=";
        //foreach (var j in this.exList)
        //{
        //    if (j.is724) { requirFormula += $"I{j.RowIndex}+"; value724 += j.Rate; }
        //}
        //if (requirFormula.Last() == '+') { requirFormula = requirFormula.Remove(requirFormula.Length - 1); }
        //else { requirFormula = ""; }

        //ws.Cell("J" + activeRow).FormulaA1 = requirFormula;
        //ws.Cell("G" + activeRow).Value = Math.Round((value724 / sumTotal) * 100);
        #endregion

    }
}
