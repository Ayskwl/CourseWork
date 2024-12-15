using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace курсач
{
    public class ShippingCompany
    {
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Voyage> Voyages { get; set; } = new List<Voyage>();
        public List<CargoParty> CargoParties { get; set; } = new List<CargoParty>();
        public List<CargoType> CargoTypes { get; set; } = new List<CargoType>();
        public List<Route> Routes { get; set; } = new List<Route>();
        public class Employee
        {
            public string ID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string FatherName { get; set; }
            public int WorkExperience { get; set; }
            public DateTime BirthDate { get; set; }
            public string Position { get; set; }
            public Ship AssignedShip { get; set; }

            public Employee() { }
            public Employee(string id, string lastName, string firstName, string fatherName, int workExperience, DateTime birthDate, string position, Ship assignedShip)
            {
                ID = id;
                LastName = lastName;
                FirstName = firstName;
                FatherName = fatherName;
                WorkExperience = workExperience;
                BirthDate = birthDate;
                Position = position;
                AssignedShip = assignedShip;
            }
            private string ValidateName(string value, string fieldName)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{fieldName} не может быть пустым.");
                return value;
            }


            private int ValidateWorkExperience(int value)
            {
                if (value < 0 || value > 60)
                    throw new ArgumentException("Стаж работы должен быть в диапазоне от 0 до 60 лет.");
                return value;
            }

            private DateTime ValidateBirthDate(DateTime value)
            {
                if (value > DateTime.Now || value < DateTime.Now.AddYears(-120))
                    throw new ArgumentException("Дата рождения должна быть реальной.");
                return value;
            }


        }

        public class Client
        {
            public string Name { get; set; }
            public string INN { get; set; }
            public string LegalAddress { get; set; }
            public string Bank { get; set; }
            public string ValidationMessage { get; set; }

            public Client() { }
            public Client(string name, string bank, string legalAddress, string inn)
            {
                Name = name;
                Bank = bank;
                LegalAddress = legalAddress;
                INN = inn;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                Client other = (Client)obj;
                return INN == other.INN;
            }

            public override int GetHashCode()
            {
                return INN != null ? INN.GetHashCode() : 0;
            }

            public bool IsValid()
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    ValidationMessage = "Client name cannot be empty.";  
                    return false;
                }
                if (string.IsNullOrWhiteSpace(INN) || !long.TryParse(INN, out _) || (INN.Length != 10 && INN.Length != 12))
                {
                    ValidationMessage = "INN must be a 10 or 12-digit number.";

                    return false;
                }
                if (string.IsNullOrWhiteSpace(LegalAddress) || LegalAddress.Length < 10 || LegalAddress.Length > 200 || !Regex.IsMatch(LegalAddress, @"^[a-zA-Zа-яА-Я0-9\s,.\-()]+$"))
                {
                    ValidationMessage = "Legal address must be 10-200 characters and contain only valid symbols.";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Bank))

                {
                    ValidationMessage = "Bank name cannot be empty.";
                    return false;
                }
                return true; 
            }
            private string ValidateINN(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ИНН не может быть пустым.");
                if (!long.TryParse(value, out _))
                    throw new ArgumentException("ИНН должен содержать только цифры.");
                if (value.Length != 10 && value.Length != 12)
                    throw new ArgumentException("ИНН должен содержать 10 или 12 цифр.");
                return value;
            }

            private string ValidateLegalAddress(string address)
            {
                if (string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("Юридический адрес не может быть пустым.");

                if (address.Length < 10 || address.Length > 200)
                    throw new ArgumentException("Юридический адрес должен содержать от 10 до 200 символов.");

                string pattern = @"^[a-zA-Zа-яА-Я0-9\s,.\-()]+$";
                if (!Regex.IsMatch(address, pattern))
                    throw new ArgumentException("Юридический адрес содержит недопустимые символы.");

                return address;
            }


        }

        public class Ship
        {
            public string RegistrationNumber { get; set; }
            public string Name { get; set; }
            public string HomePort { get; set; }
            public int YearBuilt { get; set; }
            public int Capacity { get; set; }
            public string ShipType { get; set; }

            public Ship() { }
            public Ship(string registrationNumber, string name, string homePort, int yearBuilt, int capacity, string shipType)
            {
                RegistrationNumber = registrationNumber;
                Name = name;
                HomePort = homePort;
                YearBuilt = yearBuilt;
                Capacity = capacity;
                ShipType = shipType;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                Ship other = (Ship)obj;
                return RegistrationNumber == other.RegistrationNumber;  
            }

            public override int GetHashCode()
            {
                return RegistrationNumber != null ? RegistrationNumber.GetHashCode() : 0; 
            }

            public string ValidationMessage { get; set; }

            public bool IsValid()
            {


                if (string.IsNullOrWhiteSpace(RegistrationNumber) || RegistrationNumber.Length < 5)
                {
                    ValidationMessage = "Registration Number is invalid. It must be at least 5 characters.";

                    return false;
                }
                if (string.IsNullOrWhiteSpace(Name))
                {
                    ValidationMessage = "Name is required";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(HomePort))
                {
                    ValidationMessage = "Home Port is required";
                    return false;
                }
                if (YearBuilt < 1800 || YearBuilt > DateTime.Now.Year)
                {
                    ValidationMessage = "Year Built is invalid";
                    return false;
                }
                if (Capacity <= 0)
                {
                    ValidationMessage = "Capacity must be great than zero";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(ShipType))
                {
                    ValidationMessage = "Ship Type is required";
                    return false;
                }
                return true;
            }
            private string ValidateRegistrationNumber(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Регистрационный номер не может быть пустым.");
                if (value.Length < 5)
                    throw new ArgumentException("Регистрационный номер должен содержать минимум 5 символов.");
                return value;
            }

            private int ValidateYearBuilt(int value)
            {
                if (value < 1800 || value > DateTime.Now.Year)
                    throw new ArgumentException("Год постройки должен быть числом в диапазоне от 1800 до текущего года.");
                return value;
            }

            private int ValidateCapacity(int value)
            {
                if (value <= 0)
                    throw new ArgumentException("Грузоподъемность должна быть положительным числом.");
                if (value > 500000)
                    throw new ArgumentException("Грузоподъемность не может превышать 500000 тонн.");
                return value;
            }

        }

        public class Voyage
        {
            public string VoyageCode { get; set; }
            public Client Client { get; set; }
            public Ship Ship { get; set; }
            public DateTime DepartureDate { get; set; }
            public DateTime ArrivalDate { get; set; }
            public string DeparturePort { get; set; }
            public string ArrivalPort { get; set; }
            public string Comment { get; set; }


            public Voyage() { }

            public Voyage(string voyageCode, Client client, Ship ship, DateTime departureDate, DateTime arrivalDate, string departurePort, string arrivalPort, string comment)
            {

                VoyageCode = voyageCode;
                Client = client;
                Ship = ship;
                DepartureDate = departureDate;
                ArrivalDate = arrivalDate;
                DeparturePort = departurePort;
                ArrivalPort = arrivalPort;
                Comment = comment;

            }

        }

        public class CargoParty
        {
            public string CustomsNumber { get; set; }
            public string DeclarationNumber { get; set; }
            public Voyage Voyage { get; set; }
            public Ship Ship { get; set; }
            public CargoType CargoType { get; set; }  
            public CargoParty() { } 
            public CargoParty(string customsNumber, string declarationNumber, Voyage voyage, CargoType cargoType)
            {
                CustomsNumber = customsNumber;
                DeclarationNumber = declarationNumber;
                Voyage = voyage;
                Ship = Ship;
                CargoType = cargoType;
            }
        }

        public class CargoType
        {
            public string CargoNumber { get; set; }
            public string CargoName { get; set; }
            public double DeclaredValue { get; set; }
            public double InsuredValue { get; set; }
            public string UnitOfMeasurement { get; set; }

            public CargoType() { }

            public CargoType(string cargoNumber,string cargoName, double declaredValue, double insuredValue, string unitOfMeasurement)
            {
                CargoNumber = cargoNumber;
                DeclaredValue = declaredValue;
                InsuredValue = insuredValue;
                UnitOfMeasurement = unitOfMeasurement;
                CargoName = cargoName;
            }
        }

        public class Route
        {
            public Voyage Voyage { get; set; }

            public Ship Ship { get; set; }

            public string IntermediatePort { get; set; }

            public Route() { }

            public Route(Voyage voyage, Ship ship, string intermediatePort)

            {
                Voyage = voyage;

                Ship = ship;
                IntermediatePort = intermediatePort;
            }
            public bool IsValid()
            {
                if (Voyage == null || Ship == null || string.IsNullOrWhiteSpace(IntermediatePort))
                {
                    return false;
                }
                return true;
            }
            public override string ToString()
            {
                return $"{Voyage.VoyageCode}: {IntermediatePort}";
            }
        }
        public static void SaveDataToXml(string filePath)
        {
            ShippingData data = new ShippingData
            {
                Employees = Form1.employees,
                Clients = Form1.clients,
                Ships = Form1.ships,
                Voyages = Form1.voyages,
                CargoTypes = Form1.cargoTypes,
                CargoPartys = Form1.cargoParties,
                Routes = Form1.routes

            };

            XmlSerializer serializer = new XmlSerializer(typeof(ShippingData));

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }

            }
            catch (Exception ex)

            {
                MessageBox.Show($"Error saving data to XML: {ex.Message}");
            }

        }



        public static void LoadDataFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ShippingData));

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    ShippingData data = (ShippingData)serializer.Deserialize(reader);

                    Form1.clients = data.Clients
                        .GroupBy(c => c.INN)  
                        .Select(g => g.First()) 
                        .ToList();

                    Form1.ships = data.Ships
                        .GroupBy(s => s.RegistrationNumber) 
                        .Select(g => g.First())  
                        .ToList();

                    Form1.employees = data.Employees;
                    Form1.voyages = data.Voyages;
                    Form1.cargoTypes = data.CargoTypes;
                    Form1.cargoParties = data.CargoPartys;
                    Form1.routes = data.Routes;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найден.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных из XML: {ex.Message}");
            }
        }



        [XmlRoot("ShippingData")]
        public class ShippingData
        {
            public List<Employee> Employees { get; set; } = new List<Employee>();
            public List<Client> Clients { get; set; } = new List<Client>();
            public List<Ship> Ships { get; set; } = new List<Ship>();
            public List<Voyage> Voyages { get; set; } = new List<Voyage>();
            public List<CargoType> CargoTypes { get; set; } = new List<CargoType>();
            public List<CargoParty> CargoPartys { get; set; } = new List<CargoParty>();
            public List<Route> Routes { get; set; } = new List<Route>();

        }
    }
}
