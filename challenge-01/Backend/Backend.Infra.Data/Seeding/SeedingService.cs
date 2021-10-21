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
                Role role2 = new Role("student");
                User user2 = new User(username2, email2, pass2, role2);

                Username username3 = new Username("Usuario Tres", "Sobrenome Tres");
                Email email3 = new Email("tres@tres");
                Password pass3 = new Password("12345zxcvb");
                Role role3 = new Role("student");
                User user3 = new User(username3, email3, pass3, role3);

                _context.Users.AddRange(user1, user2, user3);
                _context.SaveChanges();
            }

            if (!_context.Modules.Any())
            {
                Module backend = new Module(new Name(EModuleType.Backend.ToString()));
                Module frontend = new Module(new Name(EModuleType.Frontend.ToString()));
                Module devops = new Module(new Name(EModuleType.DevOps.ToString()));
                Module mobile = new Module(new Name(EModuleType.Mobile.ToString()));
                
                _context.Modules.AddRange(mobile, devops, frontend, backend);
                _context.SaveChanges();
            }

            if (!_context.Courses.Any())
            {
                Course course1 = new Course(
                    new Name("Fundamentos de C#"),
                    DateTime.Now.AddHours(52),
                    (int)EModuleType.Backend);

                Course course2 = new Course(
                    new Name(".NET 5.0"),
                    DateTime.Now.AddHours(3),
                    (int)EModuleType.Backend);

                Course course3 = new Course(
                    new Name("React"),
                    DateTime.Now.AddHours(35),
                    (int)EModuleType.Frontend);

                Course course4 = new Course(
                    new Name("Vue.js"),
                    DateTime.Now.AddHours(2),
                    (int)EModuleType.Frontend); 

                Course course5 = new Course(
                    new Name("Docker"),
                    DateTime.Now.AddHours(28),
                    (int)EModuleType.DevOps);

                Course course6 = new Course(
                    new Name("Android"),
                    DateTime.Now.AddHours(64),
                    (int)EModuleType.Mobile);

                _context.Courses.AddRange(course1, course2, course3, course4, course5, course6);
                _context.SaveChanges();
            }
        }
    }
}
