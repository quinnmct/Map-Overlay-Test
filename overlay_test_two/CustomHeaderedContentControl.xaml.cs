using System.Windows.Controls;

namespace overlay_test_two
{
    public partial class CustomHeaderedContentControl : UserControl
    {
        public CustomHeaderedContentControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return this.title.Text;
            }

            set
            {
                this.title.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message.Text;
            }

            set
            {
                this.message.Text = value;
            }
        }
    }
}