using APAdmin.Application.ClassAttendanceModule.Commands.Register;
using APAdmin.Domain.TeamModule;
using APAdmin.Domain.StudentModule;
using APAdmin.Infra.Database;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APAdmin.Domain.ClassAttendanceModule;

namespace APAdmin.IntegrationTests;

[TestClass]
public class RegisterAttendanceHandlerIntegrationTest :
    IntegrationTestHandler<RegisterClassAttendanceHandler>
{
    [TestMethod]
    public void MyTestMethod()
    {
        var fileName = @"C:\Users\Alexandre Rech\Downloads\meeting_15-04-2024_14-31-09_mex-yvqr-hyq.csv";

        var file = File.ReadAllBytes(fileName);

        var request = new RegisterClassAttendanceRequest(file);

        var handler = new RegisterClassAttendanceHandler(logger, dataContext, classRepository, attendanceRepository);

        var response = handler.Handle(request, CancellationToken.None);
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        //var students = studentRepository.GetAll(includeAttendances: true);

        //foreach (var s in students)
        //{
        //    var presencas = s.GetPresentCount();

        //    var faltas = s.GetAbsentCount();

        //    var presencasAgrupadas = s.GetAttendancesGrouped();

        //    foreach (ClassAttendanceGroupedByWeek groupedByWeek in presencasAgrupadas)
        //    {
        //        var nomeSemana = groupedByWeek.Week;

        //        groupedByWeek.GetPresentCount();

        //        groupedByWeek.GetAbsentCount();
        //    }
        //}



        #region
        Dictionary<string, string> alunos = new Dictionary<string, string>()
        {
            {"Adriano Pereira Ribeiro",         "Adriano Ribeiro" },
            {"Allan Diniz Vieira",              "Allan Diniz Vieira" },
            {"Caio Picinini Pagliosa",          "Caio Pagliosa" },
            {"Chayanne Possamai Della Rech",    "Chayanne Rech" },
            {"Eduardo Tortelli",                "Eduardo Tortelli" },
            {"Enzo Grotto Philippi",            "Enzo Philippi" },
            {"Fabiano Silva Lima",              "Fabiano Lima" },
            {"Gabriel Dos Santos Tavares",      "Gabriel Tavares" },
            {"Gustavo da Costa Fontana",        "Gustavo Fontana" },
            {"Gustavo Santos Pereira ",         "gustavo santos" },
            {"Israel Fantoni",                  "Israel Fantoni" },
            {"João Eduardo Cardoso Padilha",    "Eduardo" },
            {"Jonatam Sturcio Corrêa",          "Jonatam Sturcio" },
            {"Kauã Slaviero",                   "Kauã Slaviero" },
            {"Leandro Teixeira Wolff",          "Leandro Teixeira Wolff" },
            {"Leonardo  Rodrigues",             "Leo Rodrigues" },
            {"Leonardo Dal Lago de Córdova",    "Leonardo Dal Lago" },
            {"Lucas Thiesen dos Passos",        "Lucas Thiesen" },
            {"Luis Eduardo Maia da Silva",      "Luis Eduardo Maia da Silva" },
            {"Luiz Gustavo Hemkemaier Santos",  "luiz gustavo" },
            {"Matheus Couto de Matos",          "Matheus Couto" },
            {"Matheus Jeremias Branco",         "Matheus Jeremias" },
            {"Pablo Fabricio Koerich",          "Pablo Koerich" },
            {"Paulo Sergio Padilha",            "Paulo Sergio Padilha" },
            {"Pedro Theodoro de Haro Goulart",  "Pedro Theodoro de Haro Goulart" },
            {"Rafaela dos Santos Morais ",      "Rafaela Santos" },
            {"Thiago da Silva Culau",           "Thiago Culau" },
            {"Vanessa Furtado Nunes",           "Vanessa Furtado Nunes" }
        };

        var team = Builder<Team>.CreateNew()
            .WithConstructor(() => new Team(2024, "Fullstack"))
            .Persist();

        foreach (var aluno in alunos)
        {
            Builder<Student>.CreateNew()
                .WithConstructor(() => new Student(aluno.Key, aluno.Value, team))
                .Persist();
        }

        #endregion

        string[] files = Directory.GetFiles(@"C:\Users\Alexandre Rech\Downloads\meetings-history-fullstack");

        foreach (var fileName in files)
        {
            var file = File.ReadAllBytes(fileName);

            var request = new RegisterClassAttendanceRequest(file);

            var handler = new RegisterClassAttendanceHandler(logger, dataContext, classRepository, attendanceRepository);

            var response = handler.Handle(request, CancellationToken.None);
        }
    }
}