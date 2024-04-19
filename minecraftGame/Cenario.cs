using System;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do Cenário (imagem de fundo)
	public class Cenario : PictureBox
	{
		public Cenario() //Características do cenário
		{
			Load("Cenarios/fundo.png");
			SizeMode = PictureBoxSizeMode.StretchImage;
			Width = 1440;
			Height = 665;
		}
	}
}