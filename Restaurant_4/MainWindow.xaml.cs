using Restaurant_4.Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant_4
{
    public partial class MainWindow : Window
    {
        private readonly Server _server = new();
        private readonly Cook _cook = new();

        public MainWindow()
        {
            InitializeComponent();

            // 1) Named method subscriber
            _server.TableRequestsReady += _cook.OnTableRequestsReady;

            // 2) Lambda subscriber
            _cook.OrdersProcessed += () =>
            {
                txtResults.Text += "Orders cooked. Ready to serve.\n";
            };
        }

        // Receive order from ONE customer
        private void BtnReceiveRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string customerName = txtCustomerName.Text;

                int chickenQty = int.Parse(txtChicken.Text);
                int eggQty = int.Parse(txtEgg.Text);
                string drinkName = (cmbDrink.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "NoDrink";

                _server.ReceiveRequest(customerName, chickenQty, eggQty, drinkName);

                txtResults.Text += $"Order received from {customerName}.\n";
            }
            catch (Exception ex)
            {
                txtResults.Text += ex.Message + "\n";
            }
        }

        // Send all orders to Cook
        private void BtnSendToCook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _server.SendToCook();
                txtResults.Text += "Orders sent to Cook.\n";
            }
            catch (Exception ex)
            {
                txtResults.Text += ex.Message + "\n";
            }
        }

        // Serve prepared food
        private void BtnServeFood_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = _server.ServeFood();
        }
    }
}
