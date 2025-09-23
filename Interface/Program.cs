using BusinessObjects;
using BusinessRules;
using System.Collections;
using Validations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TestProgram;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FireDepartment fireDepartment = new FireDepartment();


            Incident incident1 = new Incident(1, DateTime.Now, "Barcelos", TypeIncidentEnum.Fire, 1, 6);
            Incident incident2 = new Incident(2, DateTime.Now, "Braga", TypeIncidentEnum.Transport, 2, 2);
            Incident incident3 = new Incident(3, DateTime.Now, "Manhente", TypeIncidentEnum.Fire, 3, 4);

            FireFighter fireFighter1 = new FireFighter(1, "David", 20, "5684759845758456", Sex.Masculine, 1);
            FireFighter fireFighter2 = new FireFighter(2, "Marques", 45, "1684759645758459", Sex.Masculine, 1);
            FireFighter fireFighter3 = new FireFighter(3, "Videiras", 25, "1684759645758400", Sex.Masculine, 1);
            FireFighter fireFighter4 = new FireFighter(4, "Gabriele", 25, "1684759645758698", Sex.Masculine, 1);

            fireDepartment.IncidentRules.TryCreateAddIncidents(incident1, Permissions.HIGH);
            fireDepartment.IncidentRules.TryCreateAddIncidents(incident2, Permissions.HIGH);
            fireDepartment.IncidentRules.TryCreateAddIncidents(incident3, Permissions.HIGH);

            fireDepartment.FirefighterRules.TryAddFirefighter(fireFighter1, Permissions.HIGH);
            fireDepartment.FirefighterRules.TryAddFirefighter(fireFighter2, Permissions.HIGH);
            fireDepartment.FirefighterRules.TryAddFirefighter(fireFighter3, Permissions.HIGH);
            fireDepartment.FirefighterRules.TryAddFirefighter(fireFighter4, Permissions.HIGH);


            //int x = fireDepartment.StartProgram("incidents.bin", "firefighters.bin", "historicIncidents.bin", Permissions.HIGH);
            
            int error = 0;
            fireDepartment.IncidentRules.TryGetLocation(-1, Permissions.HIGH, out error);
            fireDepartment.IncidentRules.TryGetPriorityLevel(1, Permissions.LOW, out error);
            fireDepartment.IncidentRules.TryReadListBinaryFile("CONA.BIN", Permissions.HIGH);
            fireDepartment.FirefighterRules.TryGetCC(-1, Permissions.HIGH, out error);

            //int z = fireDepartment.EndProgram("incidents.bin", "firefighters.bin", "historicIncidents.bin", Permissions.HIGH);
        }
    }
}
