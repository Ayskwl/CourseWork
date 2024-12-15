using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static курсач.ShippingCompany;

namespace курсач
{
    public partial class Form1 : Form
    {
        ShippingCompany shippingCompany = new ShippingCompany();

        public static List<ShippingCompany.Ship> ships = new List<ShippingCompany.Ship>();
        public static List<ShippingCompany.Employee> employees = new List<ShippingCompany.Employee>();
        public static List<ShippingCompany.Client> clients = new List<ShippingCompany.Client>();
        public static List<ShippingCompany.Voyage> voyages { get; set; } = new List<ShippingCompany.Voyage>();
        public static List<ShippingCompany.Route> routes { get; set; } = new List<ShippingCompany.Route>();
        public static List<ShippingCompany.CargoParty> cargoParties { get; set; } = new List<ShippingCompany.CargoParty>();
        public static List<ShippingCompany.CargoType> cargoTypes { get; set; } = new List<ShippingCompany.CargoType>();


        public static void CreateSampleData()
        {

            Ship ship1 = new Ship("IMO9773757", "MSC Tessa", "Panama", 2021, 24000, "Container Ship");
            Ship ship2 = new Ship("IMO9454325", "Ever Given", "Panama", 2018, 20000, "Container Ship");
            ships.AddRange(new[] { ship1, ship2 });


            Employee employee1 = new Employee("1", "Иванов", "Иван", "Иванович", 10, new DateTime(1985, 5, 15), "Captain", ship1);

            Employee employee2 = new Employee("2", "Петров", "Петр", "Петрович", 5, new DateTime(1990, 1, 20), "Navigator", ship1);

            Employee employee3 = new Employee("3", "Сидорова", "Анна", "Сергеевна", 12, new DateTime(1982, 11, 8), "Chief Engineer", ship2);


            employees.AddRange(new[] { employee1, employee2, employee3 });


            Client client1 = new Client("Maersk Line", "Danske Bank", "Esplanaden 50, 1098 Copenhagen K, Denmark", "31196746");
            Client client2 = new Client("MSC", "Credit Suisse", "1201 Geneva, Switzerland", "CH-660-0650003-5");

            clients.AddRange(new[] { client1, client2 });


            Voyage voyage1 = new Voyage("V123", client1, ship1, new DateTime(2024, 3, 15), new DateTime(2024, 4, 10), "Shanghai", "Rotterdam", "On-time arrival expected.");
            Voyage voyage2 = new Voyage("V456", client2, ship2, new DateTime(2024, 4, 5), new DateTime(2024, 5, 2), "Singapore", "Hamburg", "Possible delays due to weather.");
            voyages.AddRange(new[] { voyage1, voyage2 });


            CargoType cargoType1 = new CargoType("CT001","Техника", 150000, 160000, "Boxes");

            CargoType cargoType2 = new CargoType("CT002", "Фрукты", 80000, 85000, "Tons");
            cargoTypes.AddRange(new[] { cargoType1, cargoType2 });


            CargoParty cargoParty1 = new CargoParty("CP789", "DECL4785", voyage1, cargoType1);
            CargoParty cargoParty2 = new CargoParty("CP987", "DECL9625", voyage2, cargoType2);


            cargoParties.AddRange(new[] { cargoParty1, cargoParty2});


            Route route1 = new Route(voyage1, ship1, "Suez Canal");
            Route route2 = new Route(voyage2, ship2, "Strait of Malacca");

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShippingCompany.LoadDataFromXml("shipping_data.xml");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedItem = comboBox1.SelectedItem.ToString();

            DataTable dataTable = new DataTable();

            switch (selectedItem)
            {

                case "Судно":
                    dataTable = CreateShipDataTable();
                    break;

                case "Грузы":
                    dataTable = CreateCargoDataTable();
                    break;

                case "Сотрудники":
                    dataTable = CreateEmployeeDataTable();
                    break;

                case "Рейс":
                    dataTable = CreateVoyageDataTable();

                    break;

                case "Клиенты":
                    dataTable = CreateClientDataTable();
                    break;
                case "Маршруты":
                    dataTable = CreateRouteDataTable();
                    break;
            }

            dataGridView1.DataSource = dataTable; 
            dataGridView1.AutoResizeColumns(); 
        }

        private DataTable CreateClientDataTable()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Название");
            dt.Columns.Add("ИНН");
            dt.Columns.Add("Юр. Адрес");
            dt.Columns.Add("Банк");

            foreach (var client in clients)
            {
                dt.Rows.Add(
                    client.Name, 
                    client.INN, 
                    client.LegalAddress, 
                    client.Bank
                    );
            }

            return dt;

        }

        private DataTable CreateVoyageDataTable()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Код рейса");
            dt.Columns.Add("Клиент");
            dt.Columns.Add("Судно");
            dt.Columns.Add("Дата отправления");
            dt.Columns.Add("Дата прибытия");
            dt.Columns.Add("Порт отправления");
            dt.Columns.Add("Порт прибытия");
            dt.Columns.Add("Комментарий");


            foreach (var voyage in voyages)
            {

                dt.Rows.Add(
                    voyage.VoyageCode, 
                    voyage.Client.Name, 
                    voyage.Ship.Name, 
                    voyage.DepartureDate, 
                    voyage.ArrivalDate, 
                    voyage.DeparturePort, 
                    voyage.ArrivalPort, 
                    voyage.Comment
                    );
            }

            return dt;
        }

        private DataTable CreateCargoDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Таможенный номер");       
            dt.Columns.Add("Номер декларации");        
            dt.Columns.Add("Код рейса");              
            dt.Columns.Add("Судно");                    
            dt.Columns.Add("Номер груза");
            dt.Columns.Add("Название груза"); 
            dt.Columns.Add("Заявленная стоимость"); 
            dt.Columns.Add("Застрахованная стоимость"); 
            dt.Columns.Add("Единица измерения");       


            foreach (var cargoParty in cargoParties)
            {
                dt.Rows.Add(
                    cargoParty.CustomsNumber,
                    cargoParty.DeclarationNumber,
                    cargoParty.Voyage?.VoyageCode ?? "N/A", 
                    cargoParty.Voyage?.Ship?.Name ?? "N/A",           
                    cargoParty.CargoType?.CargoNumber ?? "N/A",
                    cargoParty.CargoType?.CargoName ?? "N/A", 
                    cargoParty.CargoType?.DeclaredValue.ToString() ?? "N/A",   
                    cargoParty.CargoType?.InsuredValue.ToString() ?? "N/A",    
                    cargoParty.CargoType?.UnitOfMeasurement ?? "N/A"       
                );
            }

            return dt;
        }
        private DataTable CreateEmployeeDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Отчество");
            dt.Columns.Add("Дата рождения");
            dt.Columns.Add("Стаж");
            dt.Columns.Add("Должность");
            dt.Columns.Add("Судно");

            foreach (var employee in employees)
            {
                dt.Rows.Add(
                    employee.ID,
                    employee.LastName, 
                    employee.FirstName, 
                    employee.FatherName, 
                    employee.BirthDate, 
                    employee.WorkExperience, 
                    employee.Position, 
                    employee.AssignedShip?.Name ?? "N/A"
                    );
            }
            return dt;
        }
        private DataTable CreateShipDataTable()
        {

            DataTable dt = new DataTable();


            dt.Columns.Add("Название судна");
            dt.Columns.Add("Регистрационный номер");
            dt.Columns.Add("Порт приписки");
            dt.Columns.Add("Год постройки");
            dt.Columns.Add("Грузоподъемность");
            dt.Columns.Add("Тип судна");


            foreach (var ship in ships)
            {


                dt.Rows.Add(
                    ship.Name, 
                    ship.RegistrationNumber, 
                    ship.HomePort, 
                    ship.YearBuilt, 
                    ship.Capacity, 
                    ship.ShipType
                    );

            }

            return dt;

        }
        private DataTable CreateRouteDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Код рейса");
            dt.Columns.Add("Судно");
            dt.Columns.Add("Промежуточные порты");

            foreach (var route in routes)
            {
                dt.Rows.Add(
                    route.Voyage.VoyageCode, 
                    route.Ship.Name, 
                    route.IntermediatePort
                    );
            }
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (Form1.clients == null || Form1.clients.Count == 0)
            {
                MessageBox.Show("Список клиентов пуст.");
                return;
            }

            if (Form1.ships == null || Form1.ships.Count == 0)
            {
                MessageBox.Show("Список кораблей пуст.");
                return;
            }
            else
            {
                Form2 form2 = new Form2(Form1.clients, Form1.ships);
                form2.Owner = this; 

                form2.ShowDialog(); 
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ShippingCompany.SaveDataToXml("shipping_data.xml");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShippingCompany.SaveDataToXml("shipping_data.xml");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления.");
                return;
            }

            string selectedItem = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Выберите тип объекта для удаления.");
                return;
            }


            try
            {
                switch (selectedItem)
                {
                    case "Судно":
                        DeleteSelectedShip();
                        break;
                    case "Грузы":
                        DeleteSelectedCargo();
                        break;
                    case "Сотрудники":
                        DeleteSelectedEmployee();
                        break;
                    case "Рейс":
                        DeleteSelectedVoyage();
                        break;
                    case "Клиенты":
                        DeleteSelectedClient();
                        break;
                    case "Маршруты":
                        DeleteSelectedRoute();
                        break;
                    default:
                        MessageBox.Show("Неизвестный тип объекта.");
                        break;
                }
                ShippingCompany.SaveDataToXml("shipping_data.xml");
            }
            catch (Exception ex)

            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }

        private void DeleteSelectedShip()
        {
            string registrationNumber = dataGridView1.SelectedRows[0].Cells["Регистрационный номер"].Value.ToString();
            Ship shipToDelete = ships.FirstOrDefault(s => s.RegistrationNumber == registrationNumber);
            if (shipToDelete != null)
            {
                if (employees.Any(emp => emp.AssignedShip == shipToDelete))
                {
                    MessageBox.Show("Нельзя удалить судно, на котором работают сотрудники. Сначала переназначьте сотрудников на другое судно.");
                    return;
                }
                ships.Remove(shipToDelete);
                UpdateDataGridView();
                MessageBox.Show("Судно успешно удалено.");
            }
            else MessageBox.Show("Судно не найдено.");
        }

        private void DeleteSelectedClient()
        {
            string inn = dataGridView1.SelectedRows[0].Cells["ИНН"].Value.ToString();

            Client clientToDelete = clients.FirstOrDefault(c => c.INN == inn);

            if (clientToDelete != null)
            {
                if (voyages.Any(v => v.Client == clientToDelete))
                {
                    MessageBox.Show("Невозможно удалить клиента, связанного с рейсами. Удалите сначала связанные рейсы");

                    return;
                }
                clients.Remove(clientToDelete);
                UpdateDataGridView();
                MessageBox.Show("Клиент успешно удален.");
            }
            else MessageBox.Show("Клиент не найден");
        }
        private void DeleteSelectedCargo()
        {
            string customsNumber = dataGridView1.SelectedRows[0].Cells["Таможенный номер"].Value.ToString();
            CargoParty cargoToDelete = cargoParties.FirstOrDefault(c => c.CustomsNumber == customsNumber);
            if (cargoToDelete != null)
            {
                cargoParties.Remove(cargoToDelete);
                UpdateDataGridView();
                MessageBox.Show("Груз успешно удален.");
            }
            else MessageBox.Show("Груз не найден.");
        }


        private void DeleteSelectedEmployee()
        {
            string lastName = dataGridView1.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            string firstName = dataGridView1.SelectedRows[0].Cells["Имя"].Value.ToString();
            string fatherName = dataGridView1.SelectedRows[0].Cells["Отчество"].Value.ToString();

            Employee employeeToDelete = employees.FirstOrDefault(e => e.LastName == lastName && e.FirstName == firstName && e.FatherName == fatherName);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                UpdateDataGridView();
                MessageBox.Show("Сотрудник успешно удален.");
            }
            else MessageBox.Show("Сотрудник не найден.");
        }

        private void DeleteSelectedVoyage()
        {
            string voyageCode = dataGridView1.SelectedRows[0].Cells["Код рейса"].Value.ToString();

            Voyage voyageToDelete = voyages.FirstOrDefault(v => v.VoyageCode == voyageCode);

            if (voyageToDelete != null)
            {
                cargoParties.RemoveAll(cp => cp.Voyage == voyageToDelete);

                routes.RemoveAll(r => r.Voyage == voyageToDelete);

                voyages.Remove(voyageToDelete);
                UpdateDataGridView();
                MessageBox.Show("Рейс успешно удален.");

            }
            else MessageBox.Show("Рейс не найден");
        }
        private void DeleteSelectedRoute()
        {
            string voyageCode = dataGridView1.SelectedRows[0].Cells["Код рейса"].Value.ToString();

            Route routeToDelete = routes.FirstOrDefault(r => r.Voyage.VoyageCode == voyageCode);

            if (routeToDelete != null)
            {
                routes.Remove(routeToDelete);

                UpdateDataGridView();
                MessageBox.Show("Маршрут успешно удален.");
            }
            else MessageBox.Show("Маршрут не найден");
        }
        private void UpdateDataGridView()
        {
            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);
        }
    }
}
