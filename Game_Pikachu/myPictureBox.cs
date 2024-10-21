using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace StudentManagerSoftWare.MyControls.PicBox
{
    class myPictureBox: PictureBox
    {
        public void setEvent( Panel containContent)
        {
            this.MouseMove += moveMe;
            this.MouseLeave += leaveMe;
            p = new Panel();
            p.Width = 4;
            defaultP();
            p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(237)))));
            this.Controls.Add(p);
        }
        public void setClickAccount(int index, Panel containContent, myPictureBox one, myPictureBox two)
        {
            this.Click += (sender, e) => clickMe(sender, e,index, containContent,one,two);
        }
        public void setClickStatistic(int index, Panel containContent, myPictureBox one)
        {
            this.Click += (sender, e) => clickMeStatistic(sender, e, index, containContent, one);
        }
        private void clickMe(object sender,EventArgs e,int index,Panel p, myPictureBox one, myPictureBox two)
        {
            one.BackColor = System.Drawing.Color.Transparent;
            two.BackColor = System.Drawing.Color.Transparent;
            //index là chỉ số của form tương ứng
            Form f = new Form();
            switch(index)
            {
                case 1:
                    f = new View.Account.layoutAccountInfor(userId);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    break;
                case 2:
                    f = new View.Account.layoutAccountEdit(userId);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    break;
                case 3:
                    f = new View.Account.layoutAccountChangePass(userId);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    break;
            }
            updateP();
            active = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(108)))));

            if (p.Controls.Count != 0)
            {
                p.Controls[0].Dispose();
            }

            p.Controls.Add(f);
            f.Show();
        }
        private void clickMeStatistic(object sender, EventArgs e, int index, Panel p, myPictureBox one)
        {
            one.BackColor = System.Drawing.Color.Transparent;
            //index là chỉ số của form tương ứng
            Form f = new Form();
            switch (index)
            {
                case 1:
                    f = new View.Statistic.layoutStatisticStudent();
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    break;
                case 2:
                    f = new View.Statistic.layoutStatisticPoint();
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    break;
            }
            updateP();
            active = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(108)))));

            if (p.Controls.Count != 0)
            {
                p.Controls[0].Dispose();
            }

            p.Controls.Add(f);
            f.Show();
        }
        private void moveMe(object sender,EventArgs e)
        {
            
            if (this.BackColor==System.Drawing.Color.Transparent)
            {
                updateP();
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(68)))));
                active = false;
            }
        }
        private void leaveMe(object sender,EventArgs e)
        {
            
            if (active==false)
            {
                defaultP();
                this.BackColor = System.Drawing.Color.Transparent;
            }
        }
        private void defaultP()
        {
            p.Height = this.Height - 4;
            p.Location = new System.Drawing.Point(this.Width - 2, 2);
        }
        private void updateP()
        {
            p.Height = this.Height ;
            p.Location = new System.Drawing.Point(this.Width-2, 0);
        }
        private Panel p;
        public bool active=false;
        public int userId;
    }
}
