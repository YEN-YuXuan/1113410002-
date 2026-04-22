using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _1113410002
{
    public partial class Form2 : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {
            SetLanguage(Form1.selectedLanguage);

            string[] defaultInterests = { "打球", "釣魚", "打遊戲" };
            checkedListBox1.Items.AddRange(defaultInterests);

            checkedListBox1.CheckOnClick = true;
        }
        private void SetLanguage(int langType)
        {
            if (langType == 1) 
            {
                this.Text = "個人資料輸入系統";
                label1.Text = "姓名：";
                groupBox1.Text = "性別：";
                radioButton1.Text = "男";
                radioButton2.Text = "女";
                label2.Text = "出生年月日：";
                label3.Text = "入職日期：";
                label4.Text = "興趣：";      
                button1.Text = "新增";       

                label5.Text = "國籍：";
                comboBox1.Items.Clear();     
                comboBox1.Items.Add("本國籍"); 
                comboBox1.Items.Add("外國籍");
                comboBox1.SelectedIndex = 0; 

                label6.Text = "通訊地址：";
                label7.Text = "電話號碼：";
                label8.Text = "電子郵件：";
                label9.Text = "備註：";

                label10.Text = "顯示欄位：";
                button2.Text = "檢查並顯示資料"; 
            }
            else if (langType == 2) 
            {
                this.Text = "Personal Info System";
                label1.Text = "Name:";
                groupBox1.Text = "Gender:";
                radioButton1.Text = "Male";
                radioButton2.Text = "Female";
                label2.Text = "Date of Birth:";
                label3.Text = "Hire Date:";
                label4.Text = "Interests:";  
                button1.Text = "Add";         

                label5.Text = "Nationality:";
                comboBox1.Items.Clear();       
                comboBox1.Items.Add("Domestic"); 
                comboBox1.Items.Add("Foreign");
                comboBox1.SelectedIndex = 0;   

                label6.Text = "Address:";
                label7.Text = "Phone Number:";
                label8.Text = "Email:";
                label9.Text = "Notes:";

                label10.Text = "Display Field:";
                button2.Text = "Submit & Show Data"; 
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (!checkedListBox1.Items.Contains(textBox2.Text))
                {
                    checkedListBox1.Items.Add(textBox2.Text, CheckState.Checked);

                    textBox2.Text = "";
                }
                else
                {
                    if (Form1.selectedLanguage == 1)
                    {
                        MessageBox.Show("這個興趣已存在！", "興趣重複", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Form1.selectedLanguage == 2)
                    {
                        MessageBox.Show("This interest already exists!", "Duplicate Interest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                if (Form1.selectedLanguage == 1)
                    MessageBox.Show("請確認姓名、地址、電話、信箱都已填寫。", "資料不完整", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Some text fields are empty!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                if (Form1.selectedLanguage == 1)
                    MessageBox.Show("請選擇性別！", "資料不完整", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Please select your gender!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                if (Form1.selectedLanguage == 1)
                    MessageBox.Show("勾選一項興趣！諾無興趣，請自行填寫'無'", "資料不完整", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Please select at least one interest!If you are not interested, please fill in 'None'", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.Text == "")
            {
                if (Form1.selectedLanguage == 1)
                    MessageBox.Show("請選擇國籍！", "資料不完整", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Please select your nationality!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                if (Form1.selectedLanguage == 1)
                    MessageBox.Show("出生日期錯誤！必須早於入職日期。", "邏輯錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("DOB must be earlier than Hire Date!", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gender = "";
            if (radioButton1.Checked) gender = radioButton1.Text;
            if (radioButton2.Checked) gender = radioButton2.Text;

            string interests = "";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                interests += checkedListBox1.CheckedItems[i].ToString() + " ";
            }

            string resultText = "";
            if (Form1.selectedLanguage == 1)
            {
                resultText += "[完整個人資料]\r\n";
                resultText += "姓名：" + textBox1.Text + "\r\n";
                resultText += "性別：" + gender + "\r\n";
                resultText += "出生年月日：" + dateTimePicker1.Text + "\r\n";
                resultText += "入職日期：" + dateTimePicker2.Text + "\r\n";
                resultText += "興趣：" + interests + "\r\n";
                resultText += "國籍：" + comboBox1.Text + "\r\n";
                resultText += "通訊地址：" + textBox3.Text + "\r\n";
                resultText += "電話號碼：" + textBox4.Text + "\r\n";
                resultText += "電子郵件：" + textBox5.Text + "\r\n";
                resultText += "備註：" + textBox6.Text + "\r\n";
            }
            else
            {
                resultText += "[Personal Data Summary]\r\n";
                resultText += "Name: " + textBox1.Text + "\r\n";
                resultText += "Gender: " + gender + "\r\n";
                resultText += "DOB: " + dateTimePicker1.Text + "\r\n";
                resultText += "Hire Date: " + dateTimePicker2.Text + "\r\n";
                resultText += "Interests: " + interests + "\r\n";
                resultText += "Nationality: " + comboBox1.Text + "\r\n";
                resultText += "Address: " + textBox3.Text + "\r\n";
                resultText += "Phone: " + textBox4.Text + "\r\n";
                resultText += "Email: " + textBox5.Text + "\r\n";
                resultText += "Notes: " + textBox6.Text + "\r\n";
            }

            textBox7.Text = resultText;

        }
        
    }
}
