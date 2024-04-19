using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do Inimigo
	public class Inimigo : Personagem
	{
		public Timer relogio = new Timer();
		public Random rnd = new Random();
		
		//Classes
		public Heroi hero;
		public Hearts coracao;
		public Hearts vida;
		public Cenario imagem;
		public Bullet tiro;
		public EnemyBullet enemyTiro;
		public Potions pocoes;
		public MainForm form;
		
		//Variáveis
		public string enemyMob;
		public int contadorBoss;
		
		public Inimigo() //Características
		{
			Load("Monsters/badBee.gif");
			Width = 120;
			Height = 120;
			Top = 350;
			Left = 1400;
			relogio.Interval = 20;
			relogio.Tick += Movimentar;
		}
		
		//Movimentação do Inimigo (a cada 20 milisegundos)
		public void Movimentar(object sender, EventArgs e)
		{
			coracao.Location = new Point(Left + Width / 2 - (coracao.Width / 2), Top - 50); //Posição do HP do Inimigo
			
			speed = 10;
			Left -= 5;
			
			if(Bounds.IntersectsWith(hero.Bounds)) //Se encostar no herói
			{
				Left = 1500;
				
				if(!enemyTiro.escudo) hero.hp -= damage; //Retirar vida do herói (variando conforme a força do inimigo)
				else enemyTiro.escudo = false;
			}
			
			if(Left < -120) //Se o inimigo passar do limite da tela
			{
				Top = hero.Top + (hero.Height / 2) - (Height / 2);
				Left = 1400;
			}
		}
	}
}