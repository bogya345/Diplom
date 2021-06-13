using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClosedXML.Excel;
using System.IO;

using hod_back.DAL;
using hod_back.Model;
using hod_back.misc;
using hod_back.Extentions;

//using hod_back.DAL.Models.Views;
//using hod_back.DAL.Models.Dictionaries;
//using hod_back.DAL.Models.ToParse;

namespace hod_back.Services.Excel
{
    public class Excel_Property
    {
        private UnitOfWork unit;
        //private Group group;

        public string path { get; set; } // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        private string patternPath { get; set; } = @"D:\Unic\Diplom\diploms\hod-back\_Resources\Patterns\ExcelPattern_Property.xlsx";

        //public List<Blocks> blocks { get; set; }
        //public List<string> subs { get; set; }

        private int dir_id { get; set; }
        private Direction Dir { get; set; }

        //private int dep_id { get; set; }
        //private Department Dep { get; set; }

        private List<exTeacher> exList;

        public Excel_Property(string path, Direction dir, UnitOfWork unit)
        {
            this.unit = unit;

            this.path = path;

            //this.dep_id = dep_id;
            //this.Dep = unit.Departments.GetOrDefault(x => x.DepId == dep_id);

            this.dir_id = dir.DirId;
            //this.Dir = unit.Directions.GetOrDefaultWithIncliude(x => x.DirId == dir_id);
            this.Dir = dir;

            //this.group = this.unit.Groups.Get());
            //if (this.group == null)
            //{
            //    throw new Exception();
            //}

            this.exList = new List<exTeacher>();

        }

        public string CreateTempFile()
        {

            //var workbook

            return this.path;
        }

        public string CreateAndFillTempFile()
        {
            var wb = new XLWorkbook(this.patternPath);
            var ws = wb.Worksheet(1); // очное

            //var dir = unit.Directions.GetOrDefault(x => x.DirId == this.dir_id);

            //List<ViewTeacherLoad> data = unit.context.ViewTeacherLoad.Where(x => x.id_group == this.group.id_group && x.id_employee != null).ToList();
            List<TeacherLoadsView> dataLoads = unit.TeacherLoadsViews.GetMany(x => x.DirId == this.dir_id && x.EFormId == 1).ToList();
            //    .Where(x => x.id_group == this.group.id_group && x.id_employee != null).ToList();
            //List<ViewTeacherLoad> data = null;

            var groupData = dataLoads.GroupBy(x => x.EmpId);

            var teachList = groupData.Select(x => x.Key);

            List<TeacherRate> dataRates = unit.TeacherRates.GetMany(x => teachList.Contains(x.EmpId)).ToList();
            List<TeacherSuitability> dataEDs = unit.TeacherSuitabilities.GetMany(x => teachList.Contains(x.EmpId)).ToList();

            List<BlockRec> dataRecs = unit.BlockRecs.GetMany(x => x.AcPlId == this.Dir.AcPlId).ToList();

            int i = 1;
            //int activeCol = 1;
            int activeRow = 9;
            int secondaryRow = activeRow;

            ws.Cell("A" + 3).Value = $"{this.Dir.EBr.EBrCode} {this.Dir.EBr.EBrName}";
            ws.Cell("A" + 4).Value = $"{this.Dir.EForm.EFormName}, год набора " + Dir.StartYear.ToString();

            foreach (var item in groupData)
            {
                exTeacher exT = new exTeacher();
                exT.RowIndex = activeRow;
                exT.Subs = new List<exSubject>();

                var item2 = item.ToList().GroupBy(x => x.SubId);

                ws.Cell("A" + activeRow).Value = i;
                ws.Cell("B" + activeRow).Value = item.ToList()[0].FullName;

                var rate = dataRates.FirstOrDefault(x => x.EmpId == item.Key);
                var eDoc = dataEDs.FirstOrDefault(x => x.EmpId == item.Key);

                ws.Cell("C" + activeRow).Value = string.IsNullOrWhiteSpace(rate.WorkTName) ? "Не указано" : rate.WorkTName;
                //ws.Cell("C" + activeRow).Value = "Штатный";

                string post = $"Должность-{rate.PostName},";
                if (string.IsNullOrWhiteSpace(eDoc.DegShortname))
                {
                    post = "ученная степень отсутствует";
                }
                else
                {
                    if (eDoc.DegId == 1)
                    {
                        post += "ученная степень не указана";
                    }
                    else
                    {
                        post += $"{eDoc.DegShortname}";
                    }
                }
                post += ",";

                if (string.IsNullOrWhiteSpace(eDoc.RankName))
                {
                    post = "ученное звание отсутствует";
                }
                else
                {
                    if (eDoc.DegId == 1)
                    {
                        post += "ученное звание не указано";
                    }
                    else
                    {
                        post += $"{eDoc.RankName}";
                    }
                }
                ws.Cell("D" + activeRow).Value = post;
                exT.DegId = eDoc.DegId;
                exT.RankId = eDoc.RankId;
                exT.IsForeign = (rate.ApplyTId == 2);

                ws.Cell("F" + activeRow).Value = eDoc.DissertCouncil;
                //ws.Cell("G" + activeRow).Value = "";
                ws.Cell("G" + activeRow).Value = "Дополнительное образование (нет данных)";

                // disciplines + hours + rate
                secondaryRow = activeRow;
                foreach (var item3 in item2.ToList())
                {
                    if (item3.Last().InPlan == 0) { continue; }

                    exSubject exS = new exSubject();
                    // E - дисциплина
                    // J - лекции
                    // K - занатия семинарного типа
                    // L - ИЗ
                    // M - АК
                    // H & N - кол-во часов
                    // I & O - доля ставки

                    //ws.Cell("J" + secondaryRow).Value = 0;
                    //ws.Cell("K" + secondaryRow).Value = 0;
                    //ws.Cell("L" + secondaryRow).Value = 0;
                    //ws.Cell("M" + secondaryRow).Value = 0;

                    //float counter = 0;
                    foreach (var tmp in item3)
                    {
                        //if (tmp.InPlan == 0) { continue; }

                        if (string.IsNullOrWhiteSpace(ws.Cell("E" + secondaryRow).Value.ToString()))
                        {
                            ws.Cell("E" + secondaryRow).Value = tmp.SubName;
                        }

                        float? value = 0;
                        string selectedCell = "";

                        //switch (tmp.SubTName.ToLower())
                        switch (tmp.SubTId)
                        {
                            //case "лек":
                            case 1: // лек
                                {
                                    //ws.Cell("J" + secondaryRow).Value =
                                    //    dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Les.ToString();
                                    //counter += dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Les ?? 0;

                                    selectedCell = "J" + secondaryRow;
                                    var old = string.IsNullOrWhiteSpace(ws.Cell(selectedCell).Value.ToString()) ? 0.0 : Convert.ToDouble(ws.Cell(selectedCell).Value);
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Les + (float)old;

                                    break;
                                }

                            //case "лаб":
                            case 2:
                                {
                                    //ws.Cell("K" + secondaryRow).Value = tmp.hours.ToString();

                                    //ws.Cell("K" + secondaryRow).Value =
                                    //    dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Lab.ToString();
                                    //counter += dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Lab ?? 0;

                                    selectedCell = "K" + secondaryRow;
                                    var old = string.IsNullOrWhiteSpace(ws.Cell(selectedCell).Value.ToString()) ? 0.0 : Convert.ToDouble(ws.Cell(selectedCell).Value);
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Lab + (float)old;

                                    break;
                                }
                            //case "пр":
                            case 3:
                                {
                                    //ws.Cell("K" + secondaryRow).Value = (tmp.hours + Convert.ToDouble(ws.Cell("K" + secondaryRow).Value)).ToString();

                                    //ws.Cell("K" + secondaryRow).Value =
                                    //    (
                                    //        dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Pr
                                    //        + Convert.ToDouble(ws.Cell("K" + secondaryRow).Value)
                                    //    ).ToString();
                                    //counter += dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Pr ?? 0;

                                    selectedCell = "K" + secondaryRow;
                                    var old = string.IsNullOrWhiteSpace(ws.Cell(selectedCell).Value.ToString()) ? 0.0 : Convert.ToDouble(ws.Cell(selectedCell).Value);
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Pr + (float)old;

                                    break;
                                }

                            //case "из":
                            case 4:
                                {
                                    //ws.Cell("L" + secondaryRow).Value = tmp.hours.ToString();

                                    //ws.Cell("L" + secondaryRow).Value =
                                    //    dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Iz.ToString();
                                    //counter += dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Iz ?? 0;

                                    selectedCell = "L" + secondaryRow;
                                    var old = string.IsNullOrWhiteSpace(ws.Cell(selectedCell).Value.ToString()) ? 0.0 : Convert.ToDouble(ws.Cell(selectedCell).Value);
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Iz + (float)old;

                                    break;
                                }
                            //case "ак":
                            case 5:
                                {
                                    //ws.Cell("M" + secondaryRow).Value = tmp.hours.ToString();

                                    //ws.Cell("M" + secondaryRow).Value =
                                    //    dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Ak.ToString();
                                    //counter += dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Ak ?? 0;

                                    selectedCell = "M" + secondaryRow;
                                    var old = string.IsNullOrWhiteSpace(ws.Cell(selectedCell).Value.ToString()) ? 0.0 : Convert.ToDouble(ws.Cell(selectedCell).Value);
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Ak + (float)old;

                                    break;
                                }

                        }

                        if (selectedCell != "")
                        {
                            ws.Cell(selectedCell).Value = value ?? 0;
                            //counter += (float)(value ?? 0);
                        }

                        //ws.Cell("I" + secondaryRow).Value = "ставка";
                        //ws.Cell("J" + activeRow).Value = unit.BlockRecs.GetAll().Where(y => y.id_blockRec == item3.ToList().Where(x => x.typeSubject.Contains("ИЗ")).First().blockrecs_id_blockRec).FirstOrDefault().les;
                        //ws.Cell("k" + activeRow).Value = unit.BlockRecs.GetAll().Where(y => y.id_blockRec == item3.ToList().Where(x => x.typeSubject.Contains("ИЗ")).First().blockrecs_id_blockRec).FirstOrDefault().les;
                        //ws.Cell("L" + activeRow).Value = ;
                        //ws.Cell("M" + activeRow).Value = ;
                        //ws.Cell("N" + activeRow).Value = ;
                        //ws.Cell("O" + secondaryRow).Value = "ставка";
                    }

                    //var counter = item3

                    //string countHours = item3.Where(x => x.InPlan == 1
                    //                                    && x.SubTName.ToLower() != "контроль"
                    //                                    && x.SubTName.ToLower() != "ср")
                    //                                    .Sum(x => x.hour)
                    //                                    .ToString();

                    //ws.Cell("H" + secondaryRow).Value = countHours;
                    //ws.Cell("N" + secondaryRow).Value = countHours;



                    double sum = 0;

                    string J_cell = ws.Cell("J" + secondaryRow).Value.ToString();
                    if (string.IsNullOrWhiteSpace(J_cell)) { ws.Cell("J" + secondaryRow).Value = 0; }
                    else { sum += Convert.ToDouble(J_cell); }
                    exS.Les = Convert.ToDouble(ws.Cell("J" + secondaryRow).Value);

                    string K_cell = ws.Cell("K" + secondaryRow).Value.ToString();
                    if (string.IsNullOrWhiteSpace(K_cell)) { ws.Cell("K" + secondaryRow).Value = 0; }
                    else { sum += Convert.ToDouble(K_cell); }
                    exS.LabPr = Convert.ToDouble(ws.Cell("K" + secondaryRow).Value);

                    string L_cell = ws.Cell("L" + secondaryRow).Value.ToString();
                    if (string.IsNullOrWhiteSpace(L_cell)) { ws.Cell("L" + secondaryRow).Value = 0; }
                    else { sum += Convert.ToDouble(L_cell); }
                    exS.Iz = Convert.ToDouble(ws.Cell("L" + secondaryRow).Value);

                    string M_cell = ws.Cell("M" + secondaryRow).Value.ToString();
                    if (string.IsNullOrWhiteSpace(M_cell)) { ws.Cell("M" + secondaryRow).Value = 0; }
                    else { sum += Convert.ToDouble(M_cell); }
                    exS.Ak = Convert.ToDouble(ws.Cell("M" + secondaryRow).Value);

                    //if (string.IsNullOrWhiteSpace(ws.Cell("K" + secondaryRow).Value.ToString()))
                    //{
                    //    ws.Cell("K" + secondaryRow).Value = 0;
                    //}
                    //if (string.IsNullOrWhiteSpace(ws.Cell("L" + secondaryRow).Value.ToString()))
                    //{
                    //    ws.Cell("L" + secondaryRow).Value = 0;
                    //}
                    //if (string.IsNullOrWhiteSpace(ws.Cell("M" + secondaryRow).Value.ToString()))
                    //{
                    //    ws.Cell("M" + secondaryRow).Value = 0;
                    //}

                    //ws.Cell("H" + secondaryRow).Value = counter;
                    //ws.Cell("N" + secondaryRow).Value = counter;

                    ////string formula1 = $"=SUM(J{secondaryRow};K{secondaryRow};L{secondaryRow};M{secondaryRow})";
                    //string formula1 = $"=J{secondaryRow}+K{secondaryRow}+L{secondaryRow}+M{secondaryRow}";
                    //ws.Cells("H" + secondaryRow).FormulaA1 = formula1;

                    //string formula2 = $"=SUM(J{secondaryRow};K{secondaryRow};L{secondaryRow};M{secondaryRow})";
                    string formula2 = $"=J{secondaryRow}+K{secondaryRow}+L{secondaryRow}+M{secondaryRow}";
                    ws.Cell("N" + secondaryRow).FormulaA1 = formula2;

                    //string distictRate = "ставка";  // fsh.StaffCount
                    //float distictRate = rate.StaffCount == null ? 0 : rate.StaffCount.Value;  // fsh.StaffCount 

                    //ws.Cell("I" + secondaryRow).Value = distictRate;
                    //ws.Cell("O" + secondaryRow).Value = distictRate; //--- оказывается не так, нужно (всего / 900)
                    float distictRate = (float)Math.Round((sum / 900), 2);
                    ws.Cell("O" + secondaryRow).Value = distictRate;

                    ws.Row(secondaryRow).InsertRowsBelow(1);
                    secondaryRow++;

                    exT.Subs.Add(exS);
                }

                //exT.is722 = Rules.isFgos_7_2_2(eDoc.DegId, eDoc.RankId);
                //exT.is723 = Rules.isFgos_7_2_3(eDoc.DegId, eDoc.RankId);
                //exT.is724 = Rules.isFgos_7_2_4(eDoc.DegId, eDoc.RankId);

                //double rateSum = 0;
                //for (int j = activeRow; j <= secondaryRow; j++)
                //{
                //    rateSum += string.IsNullOrWhiteSpace(ws.Cell("H" + j).Value.ToString()) 
                //        ? 0 : Convert.ToDouble(ws.Cell("H" + j).Value.ToString());
                //}
                string strRateSum = "=";
                for (int j = activeRow; j <= secondaryRow; j++)
                {
                    strRateSum += $"N{j}+";
                }
                strRateSum = strRateSum.Remove(strRateSum.Length - 1);
                ws.Cell("H" + activeRow).FormulaA1 = strRateSum;

                //double hourSum = 0;
                //for (int j = activeRow; j <= secondaryRow; j++)
                //{
                //    rateSum += string.IsNullOrWhiteSpace(ws.Cell("H" + j).Value.ToString()) 
                //        ? 0 : Convert.ToDouble(ws.Cell("H" + j).Value.ToString());
                //}
                string strHourSum = "=";
                int k = activeRow;
                while (k < secondaryRow)
                {
                    strHourSum += $"O{k}+";
                    k++;
                }
                strHourSum = strHourSum.Remove(strHourSum.Length - 1);
                ws.Cell("I" + activeRow).FormulaA1 = strHourSum;

                //ws.Cell("P" + activeRow).Value = "Причичание";

                //

                ws.Row(secondaryRow).Delete();
                secondaryRow--;

                // merging cells
                ws.Range("A" + activeRow.ToString() + ":A" + secondaryRow.ToString()).Merge();
                ws.Range("B" + activeRow.ToString() + ":B" + secondaryRow.ToString()).Merge();
                ws.Range("C" + activeRow.ToString() + ":C" + secondaryRow.ToString()).Merge();
                ws.Range("D" + activeRow.ToString() + ":D" + secondaryRow.ToString()).Merge();
                ws.Range("F" + activeRow.ToString() + ":F" + secondaryRow.ToString()).Merge();
                ws.Range("G" + activeRow.ToString() + ":G" + secondaryRow.ToString()).Merge();
                ws.Range("H" + activeRow.ToString() + ":H" + secondaryRow.ToString()).Merge();
                ws.Range("I" + activeRow.ToString() + ":I" + secondaryRow.ToString()).Merge();
                //ws.Range("P" + activeRow.ToString() + ":P" + secondaryRow.ToString()).Merge();
                //

                activeRow = secondaryRow;

                ws.Row(activeRow).InsertRowsBelow(1);
                activeRow++;
                i++;

                this.exList.Add(exT);
            }

            string strTotal = "";
            //for (int j = 9; j <= activeRow; j++)
            //{
            //    strTotal += $"I{j}+";
            //}
            foreach (var j in exList)
            {
                strTotal += $"I{j.RowIndex}+";
            }
            strTotal = strTotal.Remove(strTotal.Length - 1);

            //ws.Cell("I" + (activeRow + 1)).Value = "ИТОГ";
            ws.Cell("I" + (activeRow + 1)).FormulaA1 = strTotal;

            ws.Range("A" + 9 + ":P" + (activeRow - 1)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("A" + 9 + ":P" + (activeRow - 1)).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range("A" + 9 + ":P" + (activeRow - 1)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("A" + 9 + ":P" + (activeRow - 1)).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("A" + 9 + ":P" + (activeRow - 1)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Rows(9, activeRow - 1).AdjustToContents(190, 190);


            /// переход к требованиям фгос
            /// 
            activeRow += 5;
            int beginningRow = activeRow;
            double crutchWidth = 140;

            var listRequirs = unit.DirRequirs.GetMany(x => x.DirId == dir_id);
            float sumTotal = exList.Sum(x => x.TotalRate);

            var requirNums = new List<string>() { "7.2.2", "7.2.3", "7.2.4" };

            foreach (var k in requirNums)
            {
                ws.Range("B" + activeRow + ":J" + activeRow).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                var requir = listRequirs.FirstOrDefault(x => x.FgosNum == k);
                float value = 0;
                ws.Cell("B" + activeRow).Value = $"п. {k.NewFgos()}";
                ws.Range("C" + activeRow.ToString() + ":E" + activeRow.ToString()).Merge();

                //ws.Cell("C" + activeRow).Value = requir.Content;
                ws.Cell("C" + activeRow).Value = requir.FgosPropertyView;
                //ws.Cell("C" + activeRow).Style.Alignment.SetShrinkToFit();
                ws.Cell("C" + activeRow).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Justify);

                ws.Cell("F" + activeRow).Value = $"не менее {requir.SettedValue} {requir.UnitName}";
                string requirFormula = "=";
                foreach (var j in this.exList)
                {
                    if (k == "7.2.2" && j.is722_Part) { requirFormula += $"I{j.RowIndex}+"; value += j.TotalRate; }
                    if (k == "7.2.3" && j.is723_Part) { requirFormula += $"I{j.RowIndex}+"; value += j.TotalRate; }
                    if (k == "7.2.4" && j.is724_Part) { requirFormula += $"I{j.RowIndex}+"; value += j.TotalRate; }
                }
                if (requirFormula.Last() == '+') { requirFormula = requirFormula.Remove(requirFormula.Length - 1); }
                else { requirFormula = "0"; }

                ws.Cell("J" + activeRow).FormulaA1 = requirFormula;
                ws.Cell("G" + activeRow).Value = Math.Round((value / sumTotal) * 100);

                ws.Rows(activeRow, activeRow).AdjustToContents(crutchWidth, crutchWidth);

                activeRow++;
            }
            activeRow--;

            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Range("B" + beginningRow + ":J" + activeRow).Style.Font.FontSize = 12;

            ws.Rows(activeRow, activeRow).AdjustToContents(crutchWidth, crutchWidth);

            //ws.Visibility = XLWorksheetVisibility.Visible;

            //wb.SaveAs(@"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\toDownload\property.xlsx");
            //wb.SaveAs(@"D:\Unic\Diplom\@_test_docs\bogya-bin\property.xlsx");
            wb.SaveAs(this.path);

            //return @".\Upload\toDownload\property.xlsx";
            return this.path;
        }

    }
}
