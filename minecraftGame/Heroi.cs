using System;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do Heroi
	public class Heroi : Personagem
	{
		public Heroi()
		{
			Top = 350; //Localização
		}
		
		//Variáveis
		public int i;
		public bool right = true;
		public string[] pbs = {"Cenarios/cenario1.jpg", "Cenarios/cenario2.jpg", "Cenarios/cenario3.jpg"};
		public string mobName;
		
		//Método W (para cima)
		public void W(PictureBox imagem)
		{
			Top -= speed;
			
			if(Top < 70)
			{
				Top = 600;
				i++;
				
				if(i > 2)
				{
					i = 0;
				}
				
				imagem.Load(pbs[i]);
			}
		}
		
		//Método A (esquerda)
		public void A(PictureBox imagem)
		{
			//Definir imagem do personagem (caso o herói esteja direcionado à direita)
			if(right)
			{
				right = !right;
				switch (mobName)
				{
					case "Allay":
						Load("Personagens/allayEsq.gif");
						break;
						
					case "Abelha":
						Load("Personagens/beeEsq.gif");
						break;
						
					case "Morcego":
						Load("Personagens/batEsq.gif");
						break;
						
					case "Papagaio":
						Load("Personagens/parrotEsq.gif");
						break;
				}
			}
			
			Left -= speed;
			
			if(Left < 0)
			{
				Left = 1350;
				i--;
				
				if(i < 0)
				{
					i = 2;
				}
				
				imagem.Load(pbs[i]);
			}
		}
		
		//Método S (para baixo)
		public void S(PictureBox imagem)
		{
			Top += speed;
			
			if(Top > 620)
			{
				Top = 70;
				i--;
				
				if(i < 0)
				{
					i = 2;
				}
				
				imagem.Load(pbs[i]);
			}
		}
		
		//Método D (direita)
		public void D(PictureBox imagem)
		{
			//Definir imagem do personagem (caso o herói esteja direcionado à esquerda)
			if(!right)
			{
				right = !right;
				switch (mobName)
				{
					case "Allay":
						Load("Personagens/allayDir.gif");
						break;
						
					case "Abelha":
						Load("Personagens/beeDir.gif");
						break;
						
					case "Morcego":
						Load("Personagens/batDir.gif");
						break;
						
					case "Papagaio":
						Load("Personagens/parrotDir.gif");
						break;
				}
			}
			
			Left += speed;
			
			if(Left > 1350)
			{
				Left = -20;
				i++;
				
				if(i > 2)
				{
					i = 0;
				}
				
				imagem.Load(pbs[i]);
			}
		}
	}
}