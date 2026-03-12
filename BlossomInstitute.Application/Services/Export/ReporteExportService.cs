using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteMarksByCursoAndTerm;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;


namespace BlossomInstitute.Application.Services.Export
{
    public class ReporteExportService : IReporteExportService
    {
        public byte[] ExportMarksByCourseTermToExcel(
            ReporteMarksByCursoAndTermResumenModel resumen,
            List<ReporteMarksByCursoAndTermItemModel> items)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Marks Report");

            var row = 1;

            ws.Cell(row, 1).Value = "Blossom Institute";
            ws.Range(row, 1, row, 8).Merge().Style.Font.SetBold().Font.SetFontSize(16);
            row++;

            ws.Cell(row, 1).Value = "Course";
            ws.Cell(row, 2).Value = resumen.CursoNombre;
            row++;

            ws.Cell(row, 1).Value = "Year";
            ws.Cell(row, 2).Value = resumen.Year;
            ws.Cell(row, 3).Value = "Term";
            ws.Cell(row, 4).Value = resumen.Term;
            row++;

            ws.Cell(row, 1).Value = "From";
            ws.Cell(row, 2).Value = resumen.From.ToString("yyyy-MM-dd");
            ws.Cell(row, 3).Value = "To";
            ws.Cell(row, 4).Value = resumen.To.ToString("yyyy-MM-dd");
            row += 2;

            ws.Cell(row, 1).Value = "Total Students";
            ws.Cell(row, 2).Value = resumen.TotalAlumnos;
            ws.Cell(row, 3).Value = "Students With Marks";
            ws.Cell(row, 4).Value = resumen.AlumnosConNotas;
            row++;

            ws.Cell(row, 1).Value = "Total Quizzes";
            ws.Cell(row, 2).Value = resumen.TotalQuizzes;
            ws.Cell(row, 3).Value = "Quiz Avg";
            ws.Cell(row, 4).Value = resumen.PromedioQuizzesCurso;
            row++;

            ws.Cell(row, 1).Value = "Total Tests";
            ws.Cell(row, 2).Value = resumen.TotalTests;
            ws.Cell(row, 3).Value = "Test Avg";
            ws.Cell(row, 4).Value = resumen.PromedioTestsCurso;
            row++;

            ws.Cell(row, 1).Value = "Total Marks";
            ws.Cell(row, 2).Value = resumen.TotalMarks;
            ws.Cell(row, 3).Value = "General Avg";
            ws.Cell(row, 4).Value = resumen.PromedioGeneralCurso;
            row += 2;

            var headerRow = row;
            ws.Cell(row, 1).Value = "Student";
            ws.Cell(row, 2).Value = "DNI";
            ws.Cell(row, 3).Value = "Email";
            ws.Cell(row, 4).Value = "Quiz Count";
            ws.Cell(row, 5).Value = "Quiz Avg";
            ws.Cell(row, 6).Value = "Test Count";
            ws.Cell(row, 7).Value = "Test Avg";
            ws.Cell(row, 8).Value = "Marks Count";
            ws.Cell(row, 9).Value = "General Avg";

            ws.Range(row, 1, row, 9).Style.Font.SetBold();
            ws.Range(row, 1, row, 9).Style.Fill.BackgroundColor = XLColor.LightGray;
            row++;

            foreach (var item in items)
            {
                ws.Cell(row, 1).Value = $"{item.AlumnoApellido}, {item.AlumnoNombre}";
                ws.Cell(row, 2).Value = item.AlumnoDni;
                ws.Cell(row, 3).Value = item.AlumnoEmail;
                ws.Cell(row, 4).Value = item.QuizCount;
                ws.Cell(row, 5).Value = item.QuizPromedio;
                ws.Cell(row, 6).Value = item.TestCount;
                ws.Cell(row, 7).Value = item.TestPromedio;
                ws.Cell(row, 8).Value = item.MarksCount;
                ws.Cell(row, 9).Value = item.PromedioGeneral;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] ExportMarksByCourseTermToPdf(
            ReporteMarksByCursoAndTermResumenModel resumen,
            List<ReporteMarksByCursoAndTermItemModel> items)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4.Landscape());
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(column =>
                    {
                        column.Item().Text("Blossom Institute").Bold().FontSize(18);
                        column.Item().Text($"Marks Report - {resumen.CursoNombre}");
                        column.Item().Text($"Year {resumen.Year} - Term {resumen.Term} ({resumen.From:yyyy-MM-dd} to {resumen.To:yyyy-MM-dd})");
                    });

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().Text("Total Students").Bold();
                            table.Cell().Text(resumen.TotalAlumnos.ToString());
                            table.Cell().Text("Students With Marks").Bold();
                            table.Cell().Text(resumen.AlumnosConNotas.ToString());

                            table.Cell().Text("Total Quizzes").Bold();
                            table.Cell().Text(resumen.TotalQuizzes.ToString());
                            table.Cell().Text("Quiz Avg").Bold();
                            table.Cell().Text(resumen.PromedioQuizzesCurso?.ToString("0.00") ?? "-");

                            table.Cell().Text("Total Tests").Bold();
                            table.Cell().Text(resumen.TotalTests.ToString());
                            table.Cell().Text("Test Avg").Bold();
                            table.Cell().Text(resumen.PromedioTestsCurso?.ToString("0.00") ?? "-");

                            table.Cell().Text("Total Marks").Bold();
                            table.Cell().Text(resumen.TotalMarks.ToString());
                            table.Cell().Text("General Avg").Bold();
                            table.Cell().Text(resumen.PromedioGeneralCurso?.ToString("0.00") ?? "-");
                        });

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            void Header(string text) => table.Cell().BorderBottom(1).Padding(4).Text(text).Bold();

                            Header("Student");
                            Header("DNI");
                            Header("Email");
                            Header("Quiz Count");
                            Header("Quiz Avg");
                            Header("Test Count");
                            Header("Test Avg");
                            Header("Marks Count");
                            Header("General Avg");

                            foreach (var item in items)
                            {
                                table.Cell().Padding(4).Text($"{item.AlumnoApellido}, {item.AlumnoNombre}");
                                table.Cell().Padding(4).Text(item.AlumnoDni.ToString());
                                table.Cell().Padding(4).Text(item.AlumnoEmail ?? "-");
                                table.Cell().Padding(4).Text(item.QuizCount.ToString());
                                table.Cell().Padding(4).Text(item.QuizPromedio?.ToString("0.00") ?? "-");
                                table.Cell().Padding(4).Text(item.TestCount.ToString());
                                table.Cell().Padding(4).Text(item.TestPromedio?.ToString("0.00") ?? "-");
                                table.Cell().Padding(4).Text(item.MarksCount.ToString());
                                table.Cell().Padding(4).Text(item.PromedioGeneral?.ToString("0.00") ?? "-");
                            }
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Generated by Blossom Institute - ");
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }

        public byte[] ExportAttendanceByCourseTermToExcel(
            ReporteAttendanceByCursoAndTermResumenModel resumen,
            List<ReporteAttendanceByCursoAndTermItemModel> items)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Attendance Report");

            var row = 1;

            ws.Cell(row, 1).Value = "Blossom Institute";
            ws.Range(row, 1, row, 8).Merge().Style.Font.SetBold().Font.SetFontSize(16);
            row++;

            ws.Cell(row, 1).Value = "Course";
            ws.Cell(row, 2).Value = resumen.CursoNombre;
            row++;

            ws.Cell(row, 1).Value = "Year";
            ws.Cell(row, 2).Value = resumen.Year;
            ws.Cell(row, 3).Value = "Term";
            ws.Cell(row, 4).Value = resumen.Term;
            row++;

            ws.Cell(row, 1).Value = "From";
            ws.Cell(row, 2).Value = resumen.From.ToString("yyyy-MM-dd");
            ws.Cell(row, 3).Value = "To";
            ws.Cell(row, 4).Value = resumen.To.ToString("yyyy-MM-dd");
            row += 2;

            ws.Cell(row, 1).Value = "Total Students";
            ws.Cell(row, 2).Value = resumen.TotalAlumnos;
            ws.Cell(row, 3).Value = "Total Classes";
            ws.Cell(row, 4).Value = resumen.TotalClases;
            row++;

            ws.Cell(row, 1).Value = "Total Present";
            ws.Cell(row, 2).Value = resumen.TotalPresentes;
            ws.Cell(row, 3).Value = "Total Absent";
            ws.Cell(row, 4).Value = resumen.TotalAusentes;
            row++;

            ws.Cell(row, 1).Value = "Course Attendance %";
            ws.Cell(row, 2).Value = resumen.PorcentajeAsistenciaCurso;
            row += 2;

            ws.Cell(row, 1).Value = "Student";
            ws.Cell(row, 2).Value = "DNI";
            ws.Cell(row, 3).Value = "Email";
            ws.Cell(row, 4).Value = "Total Classes";
            ws.Cell(row, 5).Value = "Present";
            ws.Cell(row, 6).Value = "Absent";
            ws.Cell(row, 7).Value = "Attendance %";

            ws.Range(row, 1, row, 7).Style.Font.SetBold();
            ws.Range(row, 1, row, 7).Style.Fill.BackgroundColor = XLColor.LightGray;
            row++;

            foreach (var item in items)
            {
                ws.Cell(row, 1).Value = $"{item.AlumnoApellido}, {item.AlumnoNombre}";
                ws.Cell(row, 2).Value = item.AlumnoDni;
                ws.Cell(row, 3).Value = item.AlumnoEmail;
                ws.Cell(row, 4).Value = item.ClasesTotales;
                ws.Cell(row, 5).Value = item.Presentes;
                ws.Cell(row, 6).Value = item.Ausentes;
                ws.Cell(row, 7).Value = item.PorcentajeAsistencia;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] ExportAttendanceByCourseTermToPdf(
            ReporteAttendanceByCursoAndTermResumenModel resumen,
            List<ReporteAttendanceByCursoAndTermItemModel> items)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4.Landscape());
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(column =>
                    {
                        column.Item().Text("Blossom Institute").Bold().FontSize(18);
                        column.Item().Text($"Attendance Report - {resumen.CursoNombre}");
                        column.Item().Text($"Year {resumen.Year} - Term {resumen.Term} ({resumen.From:yyyy-MM-dd} to {resumen.To:yyyy-MM-dd})");
                    });

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().Text("Total Students").Bold();
                            table.Cell().Text(resumen.TotalAlumnos.ToString());
                            table.Cell().Text("Total Classes").Bold();
                            table.Cell().Text(resumen.TotalClases.ToString());

                            table.Cell().Text("Total Present").Bold();
                            table.Cell().Text(resumen.TotalPresentes.ToString());
                            table.Cell().Text("Total Absent").Bold();
                            table.Cell().Text(resumen.TotalAusentes.ToString());

                            table.Cell().Text("Course Attendance %").Bold();
                            table.Cell().Text(resumen.PorcentajeAsistenciaCurso?.ToString("0.00") ?? "-");
                            table.Cell().Text("");
                            table.Cell().Text("");
                        });

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            void Header(string text) => table.Cell().BorderBottom(1).Padding(4).Text(text).Bold();

                            Header("Student");
                            Header("DNI");
                            Header("Email");
                            Header("Total Classes");
                            Header("Present");
                            Header("Absent");
                            Header("Attendance %");

                            foreach (var item in items)
                            {
                                table.Cell().Padding(4).Text($"{item.AlumnoApellido}, {item.AlumnoNombre}");
                                table.Cell().Padding(4).Text(item.AlumnoDni.ToString());
                                table.Cell().Padding(4).Text(item.AlumnoEmail ?? "-");
                                table.Cell().Padding(4).Text(item.ClasesTotales.ToString());
                                table.Cell().Padding(4).Text(item.Presentes.ToString());
                                table.Cell().Padding(4).Text(item.Ausentes.ToString());
                                table.Cell().Padding(4).Text(item.PorcentajeAsistencia.ToString("0.00"));
                            }
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Generated by Blossom Institute - ");
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }
    }
}
