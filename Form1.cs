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

            ToolStripMenuItem menuOperations = new ToolStripMenuItem("��������");
            ToolStripMenuItem menuAddition = new ToolStripMenuItem("���������");
            ToolStripMenuItem menuSubtraction = new ToolStripMenuItem("³�������");
            menuAddition.Click += MenuAddition_Click;
            menuSubtraction.Click += MenuSubtraction_Click;

            menuOperations.DropDownItems.Add(menuAddition);
            menuOperations.DropDownItems.Add(menuSubtraction);

            ToolStripMenuItem menuAdditional = new ToolStripMenuItem("���������");
            ToolStripMenuItem menuClear = new ToolStripMenuItem("�������� �����");
            menuClear.Click += MenuClear_Click;
            menuAdditional.DropDownItems.Add(menuClear);

            ToolStripMenuItem menuExit = new ToolStripMenuItem("�����");
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
                MessageBox.Show($"��������� ���������: {num1 + num2}");
        }

        private void MenuSubtraction_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out double num1, out double num2))
                MessageBox.Show($"��������� ��������: {num1 - num2}");
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
                MessageBox.Show("���������� �������� �����!");
                return false;
            }
            return true;
        }
        private void InitializeToolStrip()
        {
            ToolStrip toolStrip = new ToolStrip();

            ToolStripButton btnAddition = new ToolStripButton("���������");
            btnAddition.Click += MenuAddition_Click;

            ToolStripButton btnSubtraction = new ToolStripButton("³�������");
            btnSubtraction.Click += MenuSubtraction_Click;

            ToolStripButton btnClear = new ToolStripButton("��������");
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
