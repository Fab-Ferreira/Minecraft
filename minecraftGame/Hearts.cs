using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do HP (Personagem & Inimigo)
	public class Hearts : PictureBox
	{
		public Hearts() //Características do HP
		{
			Load("Hearts/heart1.png");
			Size = new Size(25, 25);
			BackColor = Color.Transparent;
			SizeMode = PictureBoxSizeMode.StretchImage;
			Location = new Point(-100, 0);
		}
	}
}
