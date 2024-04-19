using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do Tiro do Inimigo
	public class EnemyBullet : PictureBox
	{
		public Timer relogio = new Timer(), delay = new Timer(); //Timers
		
		//Classes
		public MainForm form;
		public Inimigo inimigo;
		public Bullet tiro;
		public Heroi hero;
		public Hearts vida;
		public Hearts coracao;
		public Potions pocoes;
		public Cenario imagem;
		
		//Variáveis
		public int bulletSpeed = 15, bulletDamage, pausa;
		public bool escudo;
		
		public EnemyBullet() //Características do tiro do inimigo
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Size = new Size(50, 50);
			Left = -200;
			
			delay.Tick += Delay;
			delay.Interval = 1000;
			
			relogio.Tick += EnemyTiro;
			relogio.Interval = 1;
		}
		
		//Verificar qual imagem do tiro do inimigo deve ser utilizada
		public void Delay(object sender, EventArgs e)
		{
			pausa++;
			if(pausa % 7 == 0)
			{
				if(tiro.fases == 2 && inimigo.contadorBoss >= 5 && inimigo.contadorBoss < 10) //Guardians
				{
					Load("Itens/shulkerProject.png");
					bulletDamage = 1;
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 3 && inimigo.contadorBoss >= 0 && inimigo.contadorBoss < 5) //Pillager
				{
					Load("Itens/arrow.png");
					Size = new Size(60, 18);
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 3 && inimigo.contadorBoss >= 5 && inimigo.contadorBoss < 9) //Witches
				{
					Load("Itens/splashPotion.gif");
					Size = new Size(50, 50);
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 3 && inimigo.contadorBoss == 9) //Evoker
				{
					Load("Itens/evokerFangs.png");
					Size = new Size(100, 60);
					relogio.Start();
					bulletDamage = 2;
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 4 && inimigo.contadorBoss < 9) //Blazes e Ghasts
				{
					Load("Itens/fireball.png");
					Size = new Size(50, 50);
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 4 && inimigo.contadorBoss == 9) //Wither
				{
					Load("Itens/witherSkull.png");
					relogio.Start();
					bulletDamage = 3;
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 5 && inimigo.contadorBoss >= 0 && inimigo.contadorBoss < 5) //Aranhas
				{
					Load("Itens/cobweb.png");
					relogio.Start();
					bulletDamage = 1;
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 5 && inimigo.contadorBoss >= 5 && inimigo.contadorBoss < 9) //Esqueletos
				{
					Load("Itens/arrow.png");
					Size = new Size(60, 18);
					relogio.Start();
					bulletDamage = 2;
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 5 && inimigo.contadorBoss == 9) //Warden
				{
					Load("Itens/shards.png");
					bulletDamage = 3;
					Size = new Size(50, 50);
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else if(tiro.fases == 6 && inimigo.contadorBoss == 9) //Ender Dragon
				{
					Load("Itens/dragonFireball.png");
					Size = new Size(75, 75);
					relogio.Start();
					Location = new Point(inimigo.Left - Width, inimigo.Top + (inimigo.Height / 2) - (Height / 2));
				}
				else //Pausar tiro caso o inimigo não deva atirar
				{
					relogio.Stop();
					Left = -200;
				}
			}
		}
		
		//Método do Tiro do Inimigo
		public void EnemyTiro(object sender, EventArgs e)
		{
			Left -= bulletSpeed; //Movimento
			
			//Caso o tiro do inimigo encoste no personagem
			if(Bounds.IntersectsWith(hero.Bounds))
			{
				relogio.Stop();
				Left = -100;
				
				if(!escudo) hero.hp -= bulletDamage; //Reduzir vida do personagem
				else escudo = false;
			}
		}
	}
}