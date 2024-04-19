using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe das Poções
	public class Potions : PictureBox
	{
		public Timer queda = new Timer(); //Timer
		public Random rnd = new Random(); //Random
		
		//Classes
		public Heroi hero;
		public EnemyBullet enemyTiro;
		public Bullet tiro;
	
		//Variáveis
		public int velocidade = 4, type;
		public bool ativado;
		
		public Potions() //Características das poções
		{
			Size = new Size(50, 50);
			BackColor = Color.Transparent;
			SizeMode = PictureBoxSizeMode.StretchImage;
			Top = -75;
			
			queda.Interval = 1;
			queda.Tick += Queda;
		}
		
		//Movimento de Queda da poção
		public void Queda(object sender, EventArgs e)
		{
			Top += velocidade; //Queda
			
			if(Bounds.IntersectsWith(hero.Bounds)) //Ao encostar no Herói
			{
				ativado = false;
				Top = -100;
				queda.Stop();
				
				if(type == 0) hero.speed = rnd.Next(30, 51); //Aumentar velocidade do personagem
				else if(type == 1) hero.damage = rnd.Next(2, 5); //Aumentar dano do tiro
				else if(type == 2) tiro.bulletSpeed = rnd.Next(15, 31); //Aumentar velocidade do tiro
				else if(type == 3) tiro.penetration = true; //Ativar penetração
				else if(type == 4) enemyTiro.escudo = true; //Ativar escudo
				else if(type == 5) hero.hp--; //Tirar vida do personagem
				else if(type == 6 && hero.hp < 3) hero.hp++; //Aumentar vida do personagem
			}
			
			else if(Top >= 750) //Se ultrapassar o limite da tela
			{
				ativado = false;
				Top = -100;
				queda.Stop();
			}
		}
	}
}