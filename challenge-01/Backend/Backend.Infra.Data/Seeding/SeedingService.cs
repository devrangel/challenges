using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;
using Backend.Infra.Data.Context;
using System;
using System.Linq;

// Classe utilizada somente para development
// Preenche o DB com alguns itens para fazer os testes das rotas

namespace Backend.Infra.Data.Seeding
{
    public class SeedingService
    {
        private readonly ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Users.Any())
            {
                Username username1 = new Username("Usuario Um", "Sobrenome Um");
                Email email1 = new Email("um@um");
                Password pass1 = new Password("12345qwert");
                Role role1 = new Role("staff");
                User user1 = new User(username1, email1, pass1, role1);

                Username username2 = new Username("Usuario Dois", "Sobrenome Dois");
                Email email2 = new Email("dois@dois");
                Password pass2 = new Password("12345asdfg");
                Role role2 = new Role("aluno");
                User user2 = new User(username2, email2, pass2, role2);

                Username username3 = new Username("Usuario Tres", "Sobrenome Tres");
                Email email3 = new Email("tres@tres");
                Password pass3 = new Password("12345zxcvb");
                Role role3 = new Role("aluno");
                User user3 = new User(username3, email3, pass3, role3);

                _context.Users.AddRange(user1, user2, user3);
                _context.SaveChanges();
            }

            if (!_context.Modules.Any())
            {
                Module backend = new Module(new Name(EModuleType.Backend.ToString()),
                    "https://raw.githubusercontent.com/github/explore/93d8a67084f94b2a444e510199a6e7622e5b09a3/topics/dotnet/dotnet.png");
                Module frontend = new Module(new Name(EModuleType.Frontend.ToString()),
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/react/react.png");
                Module devops = new Module(new Name(EModuleType.DevOps.ToString()),
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/docker/docker.png");
                Module mobile  = new Module(new Name(EModuleType.Mobile.ToString()),
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/android/android.png");
                
                _context.Modules.AddRange(mobile, devops, frontend, backend);
                _context.SaveChanges();
            }

            if (!_context.Courses.Any())
            {
                Name name1 = new Name("Fundamentos de C#");
                Description description1 = new Description("Descrição dos fundamentos");
                Course course1 = new Course(
                    name1, 
                    description1, 
                    158, 
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/csharp/csharp.png",
                    (int)EModuleType.Backend,
                    DateTime.Now.AddHours(52));

                Name name2 = new Name(".NET 5.0");
                Description description2 = new Description("Descrição do .NET");
                Course course2 = new Course(
                    name2, 
                    description2, 
                    210,
                    "https://raw.githubusercontent.com/github/explore/93d8a67084f94b2a444e510199a6e7622e5b09a3/topics/dotnet/dotnet.png",
                    (int)EModuleType.Backend, 
                    DateTime.Now.AddHours(3));

                Name name3 = new Name("React");
                Description description3 = new Description("Descrição do React");
                Course course3 = new Course(
                    name3, 
                    description3, 
                    52,
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/react/react.png",
                    (int)EModuleType.Frontend,
                    DateTime.Now.AddHours(35));

                Name name4 = new Name("Vue.js");
                Description description4 = new Description("Descrição do Vue.js");
                Course course4 = new Course(
                    name4, 
                    description4, 
                    96,
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/vue/vue.png",
                    (int)EModuleType.Frontend, 
                    DateTime.Now.AddHours(2));

                Name name5 = new Name("Docker");
                Description description5 = new Description("Descrição do Docker");
                Course course5 = new Course(
                    name5, 
                    description5, 
                    30,
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/docker/docker.png",
                    (int)EModuleType.DevOps, 
                    DateTime.Now.AddHours(28));

                Name name6 = new Name("Android");
                Description description6 = new Description("Descrição do Android");
                Course course6 = new Course(
                    name6, 
                    description6, 
                    48,
                    "https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/android/android.png",
                    (int)EModuleType.Mobile,
                    DateTime.Now.AddHours(64));

                _context.Courses.AddRange(course1, course2, course3, course4, course5, course6);
                _context.SaveChanges();
            }
        }
    }
}
