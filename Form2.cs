using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static курсач.ShippingCompany;

namespace курсач
{
    public partial class Form2 : Form
    {
        private ShippingCompany shippingCompany = new ShippingCompany();

        Ship lastAddedShip = null;
        private List<Client> clients;
        private List<Ship> ships;
        private List<Route> routes = new List<Route>();
        private Voyage selectedVoyageForRoute = null;
        private Route currentEditingRoute = null;
        private CargoType currentCargoType = null;
        public Form2(List<Client> clients, List<Ship> ships)
        {
            InitializeComponent();
            comboBox3.HandleCreated += comboBox3_HandleCreated;
            comboBox4.HandleCreated += ComboBox4_HandleCreated;
            this.comboBox3.DropDown += new EventHandler(comboBox3_DropDown);
            this.comboBox4.DropDown += new EventHandler(comboBox4_DropDown);
            this.comboBoxVoyage.DropDown += new EventHandler(comboBoxVoyage_DropDown);
            this.comboBoxShip.DropDown += new EventHandler(comboBoxShip_DropDown);
            this.comboBoxVoyageParty.DropDown += new EventHandler(comboBoxVoyageParty_DropDown);
            this.comboBoxShipParty.DropDown += new EventHandler(comboBoxShipParty_DropDown);
            this.comboBoxEmployeeShip.DropDown += new EventHandler(comboBoxEmployeeShip_DropDown);


            comboBoxVoyage.HandleCreated += ComboBoxVoyage_SelectedIndexChanged; 
            comboBoxShip.HandleCreated += ComboBoxShip_SelectedIndexChanged; 
            comboBoxVoyageParty.HandleCreated += ComboBoxVoyageParty_SelectedIndexChanged; 
            comboBoxShipParty.HandleCreated += ComboBoxShipParty_SelectedIndexChanged;
            comboBoxEmployeeShip.HandleCreated += ComboBoxEmployeeShip_SelectedIndexChanged;

            if (Form1.ships.Count > 0)
            {
                lastAddedShip = Form1.ships[Form1.ships.Count - 1];
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void comboBox3_HandleCreated(object sender, EventArgs e)
        {
            this.comboBox3.SelectedIndexChanged -= comboBox3_SelectedIndexChanged;

            try
            {
                this.comboBox3.DataSource = null;
                this.comboBox3.ResetText();
                this.comboBox3.Items.Clear();

                List<Client> uniqueClients = Form1.clients
                    .GroupBy(c => c.INN)
                    .Select(g => g.First())
                    .ToList();
                if (uniqueClients.Count > 0)
                {
                    uniqueClients.Add(new Client { Name = "Нет данных", INN = "0" });
                }
                this.comboBox3.DataSource = uniqueClients;
                this.comboBox3.DisplayMember = "Name";
                this.comboBox3.ValueMember = "INN";
            }
            finally
            {
                this.comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            }

        }

        private void ComboBox4_HandleCreated(object sender, EventArgs e)
        {
            this.comboBox4.SelectedIndexChanged -= comboBox4_SelectedIndexChanged;

            try
            {
                this.comboBox4.DataSource = null;
                this.comboBox4.ResetText();
                this.comboBox4.Items.Clear();

                List<Ship> uniqueShips = Form1.ships
                    .GroupBy(c => c.RegistrationNumber)
                    .Select(g => g.First())
                    .ToList();

                this.comboBox4.DataSource = uniqueShips;
                this.comboBox4.DisplayMember = "RegistrationNumber";
                this.comboBox4.ValueMember = "RegistrationNumber";
            }
            finally
            {
                this.comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            }
        }
        private void ComboBoxVoyage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxVoyage.SelectedIndexChanged -= comboBox4_SelectedIndexChanged;

            try
            {
                this.comboBoxVoyage.DataSource = null;
                this.comboBoxVoyage.ResetText();
                this.comboBoxVoyage.Items.Clear();

                List<Voyage> uniqueVoyage = Form1.voyages
                    .GroupBy(c => c.VoyageCode)
                    .Select(g => g.First())
                    .ToList();

                this.comboBoxVoyage.DataSource = uniqueVoyage;
                this.comboBoxVoyage.DisplayMember = "VoyageCode";
                this.comboBoxVoyage.ValueMember = "VoyageCode";
            }
            finally
            {
                this.comboBoxVoyage.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            }

        }

        private void ComboBoxShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxShip.SelectedIndexChanged -= comboBox4_SelectedIndexChanged;

            try
            {
                this.comboBoxShip.DataSource = null;
                this.comboBoxShip.ResetText();
                this.comboBoxShip.Items.Clear();

                List<Ship> uniqueShips = Form1.ships
                    .GroupBy(c => c.RegistrationNumber)
                    .Select(g => g.First())
                    .ToList();

                this.comboBoxShip.DataSource = uniqueShips;
                this.comboBoxShip.DisplayMember = "RegistrationNumber";
                this.comboBoxShip.ValueMember = "RegistrationNumber";
            }
            finally
            {
                this.comboBoxShip.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            }

        }
        private void ComboBoxVoyageParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxVoyageParty.SelectedIndexChanged -= comboBoxVoyageParty_SelectedIndexChanged;

            try
            {
                this.comboBoxVoyageParty.DataSource = null;
                this.comboBoxVoyageParty.ResetText();
                this.comboBoxVoyageParty.Items.Clear();

                List<Voyage> uniqueVoyage = Form1.voyages
                    .GroupBy(c => c.VoyageCode)
                    .Select(g => g.First())
                    .ToList();

                this.comboBoxVoyageParty.DataSource = uniqueVoyage;
                this.comboBoxVoyageParty.DisplayMember = "VoyageCode";
                this.comboBoxVoyageParty.ValueMember = "VoyageCode";
            }
            finally
            {
                this.comboBoxVoyageParty.SelectedIndexChanged += comboBoxVoyageParty_SelectedIndexChanged;
            }

        }

        private void ComboBoxShipParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxShipParty.SelectedIndexChanged -= comboBoxShipParty_SelectedIndexChanged;

            try
            {
                this.comboBoxShipParty.DataSource = null;
                this.comboBoxShipParty.ResetText();
                this.comboBoxShipParty.Items.Clear();

                List<Ship> uniqueShips = Form1.ships
                    .GroupBy(c => c.RegistrationNumber)
                    .Select(g => g.First())
                    .ToList();

                this.comboBoxShipParty.DataSource = uniqueShips;
                this.comboBoxShipParty.DisplayMember = "RegistrationNumber";
                this.comboBoxShipParty.ValueMember = "RegistrationNumber";
            }
            finally
            {
                this.comboBoxShipParty.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            }

        }
        private void ComboBoxEmployeeShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxEmployeeShip.SelectedIndexChanged -= comboBoxEmployeeShip_SelectedIndexChanged;
            try
            {
                this.comboBoxEmployeeShip.DataSource = null;
                this.comboBoxEmployeeShip.ResetText();
                this.comboBoxEmployeeShip.Items.Clear();

                List<Ship> uniqueShips = Form1.ships
                    .GroupBy(c => c.RegistrationNumber)
                    .Select(g => g.First())
                    .ToList();
                
                this.comboBoxEmployeeShip.DataSource = uniqueShips;
                this.comboBoxEmployeeShip.DisplayMember = "RegistrationNumber";
                this.comboBoxEmployeeShip.ValueMember = "RegistrationNumber";
            }
            finally
            {
                this.comboBoxEmployeeShip.SelectedIndexChanged += comboBoxEmployeeShip_SelectedIndexChanged;
            }
        }
        private class ShipComparer : IEqualityComparer<Ship>
        {
            public bool Equals(Ship x, Ship y)
            {
                return x.RegistrationNumber == y.RegistrationNumber;
            }

            public int GetHashCode(Ship obj)

            {
                return obj.RegistrationNumber.GetHashCode();
            }

        }
        private class ClientComparer : IEqualityComparer<Client>
        {
            public bool Equals(Client x, Client y)
            {
                return x.INN == y.INN;
            }

            public int GetHashCode(Client obj)
            {
                return obj.INN.GetHashCode();
            }
        }



        private void textBoxNameShip_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRegNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPortPripiski_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxShipTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxShips.SelectedIndex = -1;
        }
        private void ButtonSaveShip_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxNameShip.Text;
                string registrationNumber = textBoxRegNum.Text;
                string homePort = comboBoxPortPripiski.SelectedItem?.ToString() ?? "";
                string shipType = comboBoxShipTypes.SelectedItem?.ToString() ?? "";

                if (!int.TryParse(textBoxYearBuilt.Text, out int yearBuilt))
                {
                    MessageBox.Show("Invalid Year Built. Please enter a valid number.");
                    return;
                }

                if (!int.TryParse(textBoxLoad.Text, out int capacity))
                {
                    MessageBox.Show("Invalid Capacity. Please enter a valid number.");

                    return;
                }
                Ship existingShip = Form1.ships.FirstOrDefault(s => s.RegistrationNumber == registrationNumber);

                if (existingShip != null)
                {
                    existingShip.Name = name;

                    existingShip.HomePort = homePort;
                    existingShip.YearBuilt = yearBuilt;

                    existingShip.Capacity = capacity;

                    existingShip.ShipType = shipType;

                    MessageBox.Show("Ship updated successfully.");
                }
                else
                {
                    Ship newShip = new Ship(registrationNumber, name, homePort, yearBuilt, capacity, shipType);

                    if (!newShip.IsValid())
                    {
                        MessageBox.Show(newShip.ValidationMessage);
                        return;
                    }
                    Form1.ships.Add(newShip);

                    MessageBox.Show("Ship added successfully.");
                }


                UpdateShipListBox();

                textBoxNameShip.Clear();
                textBoxRegNum.Clear();

                comboBoxPortPripiski.SelectedIndex = -1;
                textBoxYearBuilt.Clear();
                textBoxLoad.Clear();
                comboBoxShipTypes.SelectedIndex = -1;

                ShippingCompany.SaveDataToXml("shipping_data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving ship: {ex.Message}");
            }
        }

        private void UpdateShipListBox()
        {
            listBoxShips.Items.Clear();

            if (Form1.ships.Count > 0)
            {
                Ship lastAddedShip = Form1.ships[Form1.ships.Count - 1]; 

                listBoxShips.Items.Add($"Название судна: {lastAddedShip.Name}");

                listBoxShips.Items.Add($"Регистрационный номер: {lastAddedShip.RegistrationNumber}");
                listBoxShips.Items.Add($"Порт приписки: {lastAddedShip.HomePort}");

                listBoxShips.Items.Add($"Грузоподъемность(т.): {lastAddedShip.Capacity}");

                listBoxShips.Items.Add($"Тип судна: {lastAddedShip.ShipType}");

                listBoxShips.Items.Add($"Год выпуска судна: {lastAddedShip.YearBuilt}");
            }
        }

        private void ButtonChangeShip_Click(object sender, EventArgs e)
        {
            string registrationNumber = textBoxRegNum.Text;

            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                MessageBox.Show("Please enter a registration number.");

                return;
            }

            Ship shipToEdit = Form1.ships.FirstOrDefault(s => s.RegistrationNumber == registrationNumber);


            if (shipToEdit != null)
            {
                textBoxNameShip.Text = shipToEdit.Name;
                comboBoxPortPripiski.SelectedItem = shipToEdit.HomePort;
                textBoxYearBuilt.Text = shipToEdit.YearBuilt.ToString();
                textBoxLoad.Text = shipToEdit.Capacity.ToString();
                comboBoxShipTypes.SelectedItem = shipToEdit.ShipType;
            }
            else
            {
                MessageBox.Show("No ship with that registration number exists in the records.");

                return;
            }
        }

        private void ButtonClearShip_Click(object sender, EventArgs e)
        {
            textBoxNameShip.Clear();
            textBoxRegNum.Clear();

            comboBoxPortPripiski.SelectedIndex = -1;
            textBoxYearBuilt.Clear();
            textBoxLoad.Clear();
            comboBoxShipTypes.SelectedIndex = -1;
        }

        private void tabPageVoyage_Click(object sender, EventArgs e)
        {

        }

        private void textClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClientINN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClientLegalAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClientBank_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textClientName.Text;

                string inn = textClientINN.Text;
                string legalAddress = textClientLegalAddress.Text;
                string bank = textClientBank.Text;

                Client existingClient = Form1.clients.FirstOrDefault(c => c.INN == inn);

                if (existingClient != null)
                {
                    existingClient.Name = name;
                    existingClient.LegalAddress = legalAddress;
                    existingClient.Bank = bank;

                    MessageBox.Show("Client updated successfully.");
                }
                else
                {
                    Client newClient = new Client(name, bank, legalAddress, inn);

                    if (!newClient.IsValid())
                    {
                        MessageBox.Show(newClient.ValidationMessage);
                        return;
                    }

                    Form1.clients.Add(newClient);

                    MessageBox.Show("Client added successfully.");

                }

                ShippingCompany.SaveDataToXml("shipping_data.xml");

                textClientName.Clear();
                textClientINN.Clear();
                textClientLegalAddress.Clear();
                textClientBank.Clear();

            }
            catch (Exception ex)

            {
                MessageBox.Show($"Error saving client: {ex.Message}");
            }
        }

        private void ButtonChangeClient_Click(object sender, EventArgs e)
        {
            try
            {
                string inn = textClientINN.Text;
                if (string.IsNullOrWhiteSpace(inn))
                {
                    MessageBox.Show("Please enter an INN.");
                    return;
                }

                Client clientToEdit = Form1.clients.FirstOrDefault(c => c.INN == inn);

                if (clientToEdit == null)
                {
                    MessageBox.Show("No client found with that INN.");
                    return;
                }

                textClientName.Text = clientToEdit.Name;
                textClientLegalAddress.Text = clientToEdit.LegalAddress;
                textClientBank.Text = clientToEdit.Bank;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading client data: {ex.Message}");
            }
        }
        private void ButtonClearClient_Click(object sender, EventArgs e)
        {
            textClientName.Clear();
            textClientINN.Clear();
            textClientLegalAddress.Clear();
            textClientBank.Clear();
        }
        private void textBoxPasswordVoyage_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPointDeparture_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPointArrivial_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSaveVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                string voyageCode = textBoxPasswordVoyage.Text;
                if (string.IsNullOrWhiteSpace(voyageCode))
                {
                    MessageBox.Show("Please enter a voyage code.");
                    return;
                }

                Client selectedClient = comboBox3.SelectedItem as Client;
                Ship selectedShip = comboBox4.SelectedItem as Ship;

                if (selectedClient == null || selectedShip == null)
                {
                    MessageBox.Show("Please select a valid client and ship.");
                    return;
                }

                string departurePort = textBoxPointDeparture.Text;
                string arrivalPort = textBoxPointArrivial.Text;
                DateTime departureDate = dateTimePicker1.Value;
                DateTime arrivalDate = dateTimePicker2.Value;
                string comment = textBoxComment.Text;

                Voyage existingVoyage = Form1.voyages.FirstOrDefault(v => v.VoyageCode == voyageCode);

                if (existingVoyage != null)
                {
                    existingVoyage.Client = selectedClient;
                    existingVoyage.Ship = selectedShip;
                    existingVoyage.DeparturePort = departurePort;
                    existingVoyage.ArrivalPort = arrivalPort;
                    existingVoyage.DepartureDate = departureDate;
                    existingVoyage.ArrivalDate = arrivalDate;
                    existingVoyage.Comment = comment;

                    MessageBox.Show("Voyage updated successfully.");
                }
                else
                {
                    Voyage newVoyage = new Voyage(voyageCode, selectedClient, selectedShip, departureDate, arrivalDate, departurePort, arrivalPort, comment);
                    Form1.voyages.Add(newVoyage);
                    MessageBox.Show("Voyage added successfully.");
                }

                ShippingCompany.SaveDataToXml("shipping_data.xml");

                ButtonClearVoyage_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving voyage: {ex.Message}");
            }
        }

        private void ButtonChangeVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                string voyageCode = textBoxPasswordVoyage.Text;
                if (string.IsNullOrWhiteSpace(voyageCode))
                {
                    MessageBox.Show("Please enter a voyage code.");
                    return;
                }

                Voyage voyageToEdit = Form1.voyages.FirstOrDefault(v => v.VoyageCode == voyageCode);

                if (voyageToEdit == null)
                {
                    MessageBox.Show("No voyage found with that code.");
                    return;
                }

                textBoxPasswordVoyage.Text = voyageToEdit.VoyageCode;
                comboBox3.SelectedItem = voyageToEdit.Client;
                comboBox4.SelectedItem = voyageToEdit.Ship;
                textBoxPointDeparture.Text = voyageToEdit.DeparturePort;
                textBoxPointArrivial.Text = voyageToEdit.ArrivalPort;
                dateTimePicker1.Value = voyageToEdit.DepartureDate;
                dateTimePicker2.Value = voyageToEdit.ArrivalDate;
                textBoxComment.Text = voyageToEdit.Comment;

                MessageBox.Show("Voyage data loaded for editing.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading voyage data: {ex.Message}");
            }
        }

        private void ButtonClearVoyage_Click(object sender, EventArgs e)
        {
            textBoxPasswordVoyage.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBoxPointDeparture.Clear();
            textBoxPointArrivial.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBoxComment.Clear();
        }
        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox3.DataSource = Form1.clients;
        }
        public void comboBox3_DropDown(object sender, EventArgs e)
        {
            this.comboBox3.DataSource = Form1.clients;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox4.DataSource = Form1.ships;
        }
        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            this.comboBox4.DataSource = Form1.ships;
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxVoyage.DataSource = Form1.voyages;
        }
        public void comboBoxVoyage_DropDown(object sender, EventArgs e)
        {
            this.comboBoxVoyage.DataSource = Form1.voyages;
        }
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxShip.DataSource = Form1.ships;
        }
        public void comboBoxShip_DropDown(object sender, EventArgs e)
        {
            this.comboBoxShip.DataSource = Form1.ships;
        }
        private void comboBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ButtonSaveRoute_Click(object sender, EventArgs e)
        {
            try
            {
                Voyage selectedVoyage = comboBoxVoyage.SelectedItem as Voyage;
                Ship selectedShip = comboBoxShip.SelectedItem as Ship;
                string intermediatePort = comboBoxIntermediatePort.SelectedItem as string;

                if (selectedVoyage == null || selectedShip == null || string.IsNullOrWhiteSpace(intermediatePort))
                {
                    MessageBox.Show("Please select a valid voyage, ship, and intermediate port.");
                    return;
                }

                Route existingRoute = Form1.routes.FirstOrDefault(r => r.Voyage == selectedVoyage);

                if (existingRoute != null)
                {
                    existingRoute.Ship = selectedShip;
                    existingRoute.IntermediatePort = intermediatePort;
                    MessageBox.Show("Route updated successfully.");
                }
                else
                {
                    Route newRoute = new Route(selectedVoyage, selectedShip, intermediatePort);
                    Form1.routes.Add(newRoute);
                    MessageBox.Show("Route added successfully.");
                }

                ShippingCompany.SaveDataToXml("shipping_data.xml");

                ButtonClearRoute_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving route: {ex.Message}");
            }
        }
        private void ButtonChangeRoute_Click(object sender, EventArgs e)
        {
            try
            {
                Voyage selectedVoyage = comboBoxVoyage.SelectedItem as Voyage;
                if (selectedVoyage == null)
                {
                    MessageBox.Show("Please select a valid voyage.");
                    comboBoxShip.SelectedItem = null; 
                    comboBoxIntermediatePort.Text = ""; 
                    return;
                }

                Route routeToDisplay = Form1.routes.FirstOrDefault(r => r.Voyage == selectedVoyage);

                if (routeToDisplay != null)
                {
                    comboBoxShip.SelectedItem = routeToDisplay.Ship; 

                    comboBoxIntermediatePort.Text = routeToDisplay.IntermediatePort;
                }
                else
                {
                    MessageBox.Show("No route found for this voyage.");
                    comboBoxShip.SelectedItem = null;
                    comboBoxIntermediatePort.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void ButtonClearRoute_Click(object sender, EventArgs e)
        {
            comboBoxVoyage.SelectedIndex = -1;
            comboBoxShip.SelectedIndex = -1;
            comboBoxIntermediatePort.SelectedIndex = -1;

        }
        private void UpdateRouteDisplay()
        {

        }
        private void ButtonClearRoute_Click_1(object sender, EventArgs e)
        {
            comboBoxVoyage.SelectedIndex = -1;
            comboBoxShip.SelectedIndex = -1;
            comboBoxIntermediatePort.SelectedIndex = -1;
        }
        private void textBoxCustomsNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxDeclarationNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxVoyageParty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxVoyageParty_DropDown(object sender, EventArgs e)
        {
            this.comboBoxVoyageParty.DataSource = Form1.voyages;
        }
        private void comboBoxShipParty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxShipParty_DropDown(object sender, EventArgs e)
        {
            this.comboBoxShipParty.DataSource = Form1.ships;
        }
        private void textBoxCargoNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxDeclaredValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxUnitOfMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBoxInsuredValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonSaveCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCargoType == null || currentCargoType.CargoNumber != textBoxCargoNumber.Text)
                {
                    currentCargoType = new CargoType(
                        textBoxCargoNumber.Text,
                        textBoxCargoName.Text,
                        double.Parse(textBoxDeclaredValue.Text),
                        double.Parse(textBoxInsuredValue.Text),
                        comboBoxUnitOfMeasurement.SelectedItem?.ToString()
                    );
                    Form1.cargoTypes.Add(currentCargoType);  
                }
                else
                {
                    currentCargoType.DeclaredValue = double.Parse(textBoxDeclaredValue.Text);
                    currentCargoType.InsuredValue = double.Parse(textBoxInsuredValue.Text);
                    currentCargoType.UnitOfMeasurement = comboBoxUnitOfMeasurement.SelectedItem?.ToString();
                }

                Voyage selectedVoyage = comboBoxVoyageParty.SelectedItem as Voyage;
                if (selectedVoyage == null)
                {
                    MessageBox.Show("Please select a voyage.");
                    return;
                }

                Ship selectedShip = selectedVoyage.Ship; 
                CargoParty existingCargoParty = Form1.cargoParties.FirstOrDefault(c =>
                           c.Voyage == selectedVoyage && c.CustomsNumber == textBoxCustomsNumber.Text);


                if (existingCargoParty == null)
                {
                    CargoParty newCargoParty = new CargoParty(
                        textBoxCustomsNumber.Text,
                        textBoxDeclarationNumber.Text,
                        selectedVoyage,
                        currentCargoType 
                    );
                    Form1.cargoParties.Add(newCargoParty);
                }

                else
                {
                    existingCargoParty.CargoType = currentCargoType;
                    existingCargoParty.DeclarationNumber = textBoxDeclarationNumber.Text;
                }

                MessageBox.Show("Cargo information saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cargo: {ex.Message}");
            }
        }

        private void buttonChangeCargo_Click(object sender, EventArgs e)
        {
            try
            {
                Voyage selectedVoyage = comboBoxVoyageParty.SelectedItem as Voyage;

                if (selectedVoyage == null)
                {
                    MessageBox.Show("Please select a voyage.");
                    return;
                }

                CargoParty cargoPartyToDisplay = Form1.cargoParties.FirstOrDefault(r => r.Voyage == selectedVoyage);

                if (cargoPartyToDisplay != null)
                {
                    textBoxCustomsNumber.Text = cargoPartyToDisplay.CustomsNumber;

                    textBoxDeclarationNumber.Text = cargoPartyToDisplay.DeclarationNumber;

                    comboBoxShipParty.SelectedItem = cargoPartyToDisplay.Ship; 
                    currentCargoType = cargoPartyToDisplay.CargoType;

                    textBoxCargoNumber.Text = currentCargoType.CargoNumber;
                    textBoxDeclaredValue.Text = currentCargoType.DeclaredValue.ToString();
                    comboBoxUnitOfMeasurement.SelectedItem = currentCargoType.UnitOfMeasurement;

                    textBoxInsuredValue.Text = currentCargoType.InsuredValue.ToString();
                }
                else
                {
                    MessageBox.Show("No cargo party found for this voyage.");

                    textBoxCustomsNumber.Text = "";

                    textBoxDeclarationNumber.Text = "";

                    comboBoxShipParty.SelectedItem = null;

                    currentCargoType = null;

                    textBoxCargoNumber.Text = "";
                    textBoxDeclaredValue.Text = "";
                    comboBoxUnitOfMeasurement.SelectedItem = null;

                    textBoxInsuredValue.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
        private void buttonClearCargo_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxCargoNumber.Clear();
                textBoxDeclaredValue.Clear();
                textBoxInsuredValue.Clear();
                comboBoxUnitOfMeasurement.SelectedIndex = -1; 

                currentCargoType = null; 

                textBoxCustomsNumber.Clear();
                textBoxDeclarationNumber.Clear();
                comboBoxVoyageParty.SelectedIndex = -1;  
                comboBoxShipParty.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing cargo information: {ex.Message}");
            }
        }
        private void textBoxCargoName_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxEmployeeF_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxEmployeeN_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxEmployeeO_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePickerDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }
        private void textBoxEmployeeWorkExperience_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxEmployeePost_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxEmployeeShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxEmployeeShip_DropDown(object sender, EventArgs e)
        {
            this.comboBoxEmployeeShip.DataSource = Form1.ships;
        }
        private void listBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxEmployee.SelectedIndex = -1;
        }
        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string lastName = textBoxEmployeeF.Text;
                string firstName = textBoxEmployeeN.Text;
                string fatherName = textBoxEmployeeO.Text;
                DateTime birthDate = dateTimePickerDateOfBirth.Value;
                int workExperience;

                if (!int.TryParse(textBoxEmployeeWorkExperience.Text, out workExperience))
                {
                    MessageBox.Show("Некорректный стаж. Введите число.");
                    return;
                }
                string post = textBoxEmployeePost.Text;
                Ship assignedShip = comboBoxEmployeeShip.SelectedItem as Ship;
                string fullName = $"{lastName} {firstName} {fatherName}";
                string id = textBoxEmployeeID.Text;

                Employee existingEmployee = Form1.employees.FirstOrDefault(emp => emp.ID == id);

                if (existingEmployee != null)
                {
                    existingEmployee.LastName = fatherName;
                    existingEmployee.FirstName = firstName;
                    existingEmployee.LastName = lastName;
                    existingEmployee.BirthDate = birthDate;
                    existingEmployee.WorkExperience = workExperience;
                    existingEmployee.Position = post;
                    existingEmployee.AssignedShip = assignedShip;

                    MessageBox.Show("Данные сотрудника обновлены.");
                }
                else
                {
                    Employee newEmployee = new Employee(id, lastName, firstName, fatherName, workExperience, birthDate, post, assignedShip);

                    if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && assignedShip != null)
                    {
                        Form1.employees.Add(newEmployee);
                        MessageBox.Show("Сотрудник добавлен.");           
                    }
                    else
                    {
                        MessageBox.Show("Заполните все обязательные поля (Фамилия, Имя, Судно).");
                    }
                }
                ShippingCompany.SaveDataToXml("shipping_data.xml");
                ClearEmployeeFields();
                UpdateEmployeeListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных сотрудника: {ex.Message}");
            }
        }
        private void buttonChangeEmployee_Click(object sender, EventArgs e)
        {
            string id = textBoxEmployeeID.Text;
            Employee employeeToEdit = Form1.employees.FirstOrDefault(emp => emp.ID == id);
            if (employeeToEdit != null)
            {
                textBoxEmployeeF.Text = employeeToEdit.LastName;  
                textBoxEmployeeN.Text = employeeToEdit.FirstName;  
                textBoxEmployeeO.Text = employeeToEdit.FatherName;  
                dateTimePickerDateOfBirth.Value = employeeToEdit.BirthDate;
                textBoxEmployeeWorkExperience.Text = employeeToEdit.WorkExperience.ToString();
                textBoxEmployeePost.Text = employeeToEdit.Position;
                comboBoxEmployeeShip.SelectedItem = employeeToEdit.AssignedShip;
            }
            else
            {
                MessageBox.Show("Сотрудник не найден.");
            }
        }
        private void buttonClearEmployee_Click(object sender, EventArgs e)
        {
            ClearEmployeeFields();
        }
        private void textBoxEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearEmployeeFields()
        {
            textBoxEmployeeID.Clear();
            textBoxEmployeeF.Clear();
            textBoxEmployeeN.Clear();
            textBoxEmployeeO.Clear();
            dateTimePickerDateOfBirth.Value = DateTime.Now;
            textBoxEmployeeWorkExperience.Clear();
            textBoxEmployeePost.Clear();
            comboBoxEmployeeShip.SelectedIndex = -1;
        }
        private void UpdateEmployeeListBox()
        {
            listBoxEmployee.Items.Clear();

            if (Form1.employees.Count > 0)
            {
                Employee lastAddedEmployee = Form1.employees[Form1.employees.Count - 1];
                string fullName = $"{lastAddedEmployee.LastName} {lastAddedEmployee.FirstName} {lastAddedEmployee.FatherName}";

                listBoxEmployee.Items.Add($"Год выпуска судна: {lastAddedEmployee.ID}");
                listBoxEmployee.Items.Add($"Имя сотрудника: {fullName}");
                listBoxEmployee.Items.Add($"Дата рождения: {lastAddedEmployee.BirthDate}");
                listBoxEmployee.Items.Add($"Стаж: {lastAddedEmployee.WorkExperience}");
                listBoxEmployee.Items.Add($"Должность: {lastAddedEmployee.Position}");
                listBoxEmployee.Items.Add($"Код судна: {lastAddedEmployee.AssignedShip.RegistrationNumber}");
            }
        }

        private void tabPageShip_Click(object sender, EventArgs e)
        {

        }
    }
}
