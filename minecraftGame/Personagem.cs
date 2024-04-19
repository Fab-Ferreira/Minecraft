using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe Personagem
	public class Personagem : PictureBox
	{
		public Personagem() //Características de Personagem (Inimigo & Herói)
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 100;
			Height = 100;
		}
		
		public int hp = 3, speed = 25, damage = 1; //Variáveis
		public PictureBox Cenario;
	}
}
