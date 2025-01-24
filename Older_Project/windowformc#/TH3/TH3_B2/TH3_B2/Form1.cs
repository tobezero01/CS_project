using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TH3_B2
{
    public partial class Form1 : Form
    {
        public BaiTapDienTu bt;
        public Form1()
        {
            InitializeComponent();
             
        }

        private void baiDienTu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt = new BaiTapDienTu();
            bt.Debai = "The (1) ____________ had been planned for months, and we were" +
                " all looking forward to it. We decided to go camping in " +
                "the (2) ____________ and enjoy the beauty of nature. As we set up " +
                "our (3) ____________ near the river, we realized we had forgotten to " +
                "bring (4) ____________. Luckily, we found a nearby store and bought " +
                "someIn the evening, we gathered around the(5) ____________ and " +
                "roasted marshmallows while telling(6) ____________ stories. " +
                "The night sky was full of(7) ____________ stars, and it was a perfect" +
                " opportunity for (8) ____________.The next morning, we woke up to " +
                "the sound of(9) ____________ and went for a(10) ____________ hike in " +
                "the woods.";
            bt.Dapan = "The (1) (trip) had been planned for months, and we were all " +
                "looking forward to it. We decided to go camping in the (2) (forest) " +
                "and enjoy the beauty of nature. As we set up our (3) (tents) " +
                "near the river, we realized we had forgotten to bring (4) (matches). " +
                "Luckily, we found a nearby store and bought some.In the evening," +
                " we gathered around the(5) (campfire)and roasted marshmallows" +
                " while telling(6)(spooky) stories.The night sky was " +
                "full of(7) (twinkling)stars, and it was a perfect opportunity for " +
                "(8) (stargazing).The next morning, we woke up to the sound " +
                "of(9) (birds)and went for a(10)(scenic) hike in the woods.";
            List<string> lists = new List<string>();
            lists.Add("trip");
            lists.Add("forest");
            lists.Add("tents");
            lists.Add("matches");
            lists.Add("camfrire");
            lists.Add("spooky");
            lists.Add("twinkling");
            lists.Add("stargazing");
            lists.Add("birds");
            lists.Add("scenic");

            bt.Dapantungcau = lists;
            Form2 f2 = new Form2(bt);
            f2.Show();
        }
       
        private void baiDienTu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }
    }
}
