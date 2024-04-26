using Newtonsoft.Json;

namespace ClientLab5
{
    public partial class Form1 : Form
    {
        private const string Url = "http://localhost:8000/get_price";

        public Form1()
        {
            InitializeComponent();

            // «аполнение ComboBox списком доступных товаров
            cmbProductName.Items.Add("apple");
            cmbProductName.Items.Add("banana");
            cmbProductName.Items.Add("orange");

            // ”становка первого элемента в качестве выбранного по умолчанию
            cmbProductName.SelectedIndex = 0;
        }

        private async void btnGetPrice_Click(object sender, EventArgs e)
        {
            string productName = cmbProductName.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please select a product.");
                return;
            }
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"product_name", productName}
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string requestBody = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(Url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                    if (result.ContainsKey("error"))
                    {
                        MessageBox.Show("Error: " + result["error"]);
                    }
                    else
                    {
                        string product = result["product_name"].ToString();
                        double price = Convert.ToDouble(result["price"]);
                        MessageBox.Show($"Product: {product}\nPrice: {price}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
