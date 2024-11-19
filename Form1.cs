namespace WinFS_DZ_8_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeMenuStrip();
            InitializeToolStrip();
            InitializeTextBoxes();
        }
        private void InitializeMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem menuOperations = new ToolStripMenuItem("Операції");
            ToolStripMenuItem menuAddition = new ToolStripMenuItem("Додавання");
            ToolStripMenuItem menuSubtraction = new ToolStripMenuItem("Віднімання");
            menuAddition.Click += MenuAddition_Click;
            menuSubtraction.Click += MenuSubtraction_Click;

            menuOperations.DropDownItems.Add(menuAddition);
            menuOperations.DropDownItems.Add(menuSubtraction);

            ToolStripMenuItem menuAdditional = new ToolStripMenuItem("Додатково");
            ToolStripMenuItem menuClear = new ToolStripMenuItem("Очистити форму");
            menuClear.Click += MenuClear_Click;
            menuAdditional.DropDownItems.Add(menuClear);

            ToolStripMenuItem menuExit = new ToolStripMenuItem("Вихід");
            menuExit.Click += (s, ev) => this.Close();

            menuStrip.Items.Add(menuOperations);
            menuStrip.Items.Add(menuAdditional);
            menuStrip.Items.Add(menuExit);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void MenuAddition_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out double num1, out double num2))
                MessageBox.Show($"Результат додавання: {num1 + num2}");
        }

        private void MenuSubtraction_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out double num1, out double num2))
                MessageBox.Show($"Результат віднімання: {num1 - num2}");
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            txtNum1.Clear();
            txtNum2.Clear();
        }

        private bool ValidateInputs(out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;
            if (!double.TryParse(txtNum1.Text, out num1) || !double.TryParse(txtNum2.Text, out num2))
            {
                MessageBox.Show("Некоректне введення чисел!");
                return false;
            }
            return true;
        }
        private void InitializeToolStrip()
        {
            ToolStrip toolStrip = new ToolStrip();

            ToolStripButton btnAddition = new ToolStripButton("Додавання");
            btnAddition.Click += MenuAddition_Click;

            ToolStripButton btnSubtraction = new ToolStripButton("Віднімання");
            btnSubtraction.Click += MenuSubtraction_Click;

            ToolStripButton btnClear = new ToolStripButton("Очистити");
            btnClear.Click += MenuClear_Click;

            toolStrip.Items.Add(btnAddition);
            toolStrip.Items.Add(btnSubtraction);
            toolStrip.Items.Add(btnClear);

            this.Controls.Add(toolStrip);
        }
        private TextBox txtNum1;
        private TextBox txtNum2;

        private void InitializeTextBoxes()
        {
            txtNum1 = new TextBox { Location = new Point(20, 50), Width = 100 };
            txtNum2 = new TextBox { Location = new Point(140, 50), Width = 100 };

            this.Controls.Add(txtNum1);
            this.Controls.Add(txtNum2);
        }
    }
}
