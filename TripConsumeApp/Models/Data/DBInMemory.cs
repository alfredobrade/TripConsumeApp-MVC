using System.Security.Cryptography.X509Certificates;

namespace TripConsumeApp.Models.Data
{
    public class DBInMemory
    {
        public List<UserVM> Users()
        {
            return new List<UserVM>
            {
                //new User{Name = "jose", Email = "jose@test.com", Password = "123", Roles = new[] {"Admin"}},
                //new User{Name = "raul", Email = "raul@test.com", Password = "123", Roles = new[] {"Supervisor"}},
                //new User{Name = "pedro", Email = "pedro@test.com", Password = "123", Roles = new[] {"Employee"}},
                //new User{Name = "juan", Email = "juan@test.com", Password = "123", Roles = new[] {"Supervisor", "Employee"}},
                new UserVM{Name = "juan", Email = "juan@test.com", Password = "1234"},
                new UserVM{Name = "juan", Email = "pedro@test.com", Password = "1234"}

            };


        }

        public UserVM ValidateUser(string _email, string _password)//esto va en una clase servicio
        {
            return Users().Where(user => user.Email == _email && user.Password == _password).FirstOrDefault();// aca se debe poner mas logica
            // hay que dar mensajes distintos si NO se encuentra el email o si se encuentra pero la contraseña no coincide
            //ademas, hay que poner logica para si hay null

        }
    }
}
