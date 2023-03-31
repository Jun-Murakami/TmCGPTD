using System;
using System.Windows.Forms;

namespace TmCGPTD
{
    public partial class Form_DateRange
    {
        public DateTimePicker StartDatePicker
        {
            get
            {
                return DateTimePicker1;
            }
        }

        public DateTimePicker EndDatePicker
        {
            get
            {
                return DateTimePicker2;
            }
        }

        public Form_DateRange()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // OKボタンがクリックされたら、DialogResultをOKに設定し、フォームを閉じる
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            // キャンセルボタンがクリックされたら、DialogResultをキャンセルに設定し、フォームを閉じる
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Form_DateRange_Load(object sender, EventArgs e)
        {

        }


    }
}