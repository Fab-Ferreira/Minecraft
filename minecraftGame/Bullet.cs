using System;
using System.Drawing;
using System.Windows.Forms;

namespace minecraftGame
{
	//Classe do Tiro do Personagem
	public class Bullet : PictureBox
	{
		public Timer relogio = new Timer(), intervalo = new Timer(); //Timers
		public Random rnd = new Random(); //Random
		
		//Classes
		public Inimigo enemy = new Inimigo();
		public Heroi hero;
		public Hearts vida;
		public Hearts coracao;
		public EnemyBullet enemyBullet;
		public Potions pocoes;
		public Cenario imagem;
		public MainForm form;
		
		//Variáveis
		public int bulletSpeed = 10, fases = 1, life = 1, pausa;
		public bool shooting, boss, end, penetration, direction, right;
		
		public Bullet() //Características do tiro do personagem
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Left = -100;
			Width = 50;
			Height = 50;
			
			relogio.Interval = 1;
			relogio.Tick += MovimentarBullet;
			intervalo.Interval = 1000;
			intervalo.Tick += Intervalo;
		}
		
		//Movimento do tiro
		public void MovimentarBullet(object sender, EventArgs e)
		{
			if(direction) //Se o personagem estiver direcionado à direita
			{
				Left += bulletSpeed;
				if(form.personagemChoose.Name == "allay" && right) {Load("Itens/diamondR.png"); right = !right;}
				else if(form.personagemChoose.Name == "bee" && right) {Load("Itens/honeyR.png"); right = !right;}
			}
			else //Se o personagem estiver direcionado à esquerda
			{
				Left -= bulletSpeed;
				if(form.personagemChoose.Name == "allay" && !right) {Load("Itens/diamondL.png"); right = !right;}
				else if(form.personagemChoose.Name == "bee" && !right) {Load("Itens/honeyL.png"); right = !right;}
			}
			
			if(Bounds.IntersectsWith(enemyBullet.Bounds)) //Se encostar no tiro do inimigo
			{
				if(!penetration) //Caso a penetração esteja desativada
				{
					relogio.Stop();
					Left = -500;
					shooting = false;
				}
				enemyBullet.Left = -200;
				enemyBullet.relogio.Stop();
			}
			
			if(Bounds.IntersectsWith(enemy.Bounds)) //Se encostar no inimigo
			{
				life -= hero.damage; //Reduzir HP do inimigo
				relogio.Stop();
				shooting = false;
				
				if(life > 0) //Se o inimigo permanecer vivo
				{
					coracao.Load("Hearts/heart" + life + ".png");
				}
				else if(life <= 0) //Se o inimigo morrer
				{
					enemy.contadorBoss++;
					
					if(enemy.contadorBoss < 5) //Inimigos iniciais
					{
						life = fases;
						enemy.damage = 1;
					}
					else if(enemy.contadorBoss >= 5 && enemy.contadorBoss < 9) //Inimigos medianos
					{
						switch (fases)
						{
							case 1:
								life = 2;
								enemy.Load("Monsters/vex.gif");
								enemy.damage = 1;
								break;
								
							case 2:
								life = 4;
								enemy.Load("Monsters/guardian.gif");
								enemy.Size = new Size(190, 100);
								enemy.damage = 2;
								break;
								
							case 3:
								life = 5;
								enemy.Load("Monsters/witch.png");
								enemy.Size = new Size(98, 225);
								enemy.damage = 2;
								break;
								
							case 4:
								life = 6;
								enemy.Load("Monsters/ghast.gif");
								enemy.Size = new Size(150, 160);
								enemy.damage = 2;
								break;
								
							case 5:
								life = 7;
								enemy.Load("Monsters/skeleton.png");
								enemy.Size = new Size(80, 150);
								enemy.damage = 2;
								break;
						}
					}
					else if(enemy.contadorBoss == 9) //Inimigos chefes
					{
						switch (fases)
						{
							case 1:
								life = 3;
								enemy.Load("Monsters/phantom.gif");
								enemy.Size = new Size(200, 180);
								enemy.damage = 2;
								break;
								
							case 2:
								life = 7;
								enemy.Load("Monsters/elder.gif");
								enemy.Size = new Size(210, 110);
								enemy.damage = 3;
								break;
								
							case 3:
								life = 7;
								enemy.Load("Monsters/evoker.png");
								enemy.Size = new Size(108, 210);
								enemy.damage = 2;
								break;
								
							case 4:
								life = 8;
								enemy.Load("Monsters/wither.png");
								enemy.Size = new Size(150, 150);
								enemy.damage = 3;
								break;
								
							case 5:
								life = 9;
								enemy.Load("Monsters/warden.gif");
								enemy.Size = new Size(120, 190);
								enemy.damage = 3;
								break;
						}
					}
					else if(enemy.contadorBoss == 10) //Caso passe de fase
					{
						form.KeyPreview = false;
						fases++;
						
						//Desativar timers
						enemyBullet.relogio.Stop();
						enemy.relogio.Stop();
						intervalo.Start();
						form.all.Stop();
						pocoes.queda.Stop();
						
						//Remover componentes da tela e mudar o cenário
						pocoes.Top = -75;
						enemyBullet.Left = -200;
						coracao.Left = -200;
						form.painel.Visible = false;
						hero.Left = -100;
						life = 1;
						form.Text = "Carregando...";
						
						if(fases != 7)
						{
							form.rectangle.Visible = true;
							form.title.Visible = true;
							form.tutorial.Load("Components/frase" + rnd.Next(1, 10) + ".png");
						}
						imagem.Load("Cenarios/loading.jpg");
						
						switch (fases)
						{
							//Boss Final (Ender Dragon)
							case 6: boss = true; break;
							
							case 7: //Vitória
								imagem.Load("Cenarios/victoryPB.png"); 
								form.Text = "Vitória!!!";
								intervalo.Stop();
								
								//Botões Restart & Quit
								form.reiniciarBtn.Enabled = true;
								form.reiniciarBtn.Top += 90;
								form.reiniciarBtn.Visible = true;
								form.sairBtn.Enabled = true;
								form.sairBtn.Top += 90;
								form.sairBtn.Visible = true;
								break;
						}
					}
					
					enemy.Left = 1500;
					enemy.Top = rnd.Next(150, 660 - enemy.Height);
					coracao.Load("Hearts/heart" + life + ".png");
				}
				Left = -500;
			}
			
			//Se o tiro do personagem sair da tela
			if(shooting && (Left >= 1400 || Left <= -60))
			{
				relogio.Stop();
				shooting = false;
				Left = -100;
			}
		}
		
		//Intervalo entre uma fase e outra
		public void Intervalo(object sender, EventArgs e)
		{
			if(enemy.contadorBoss == 10)
			{
				pausa++;
				if(pausa == 3)
				{
					//Definir cenários, áudio e inimigos da fase
					switch (fases)
					{
						case 2: 
							hero.pbs[0] = "Cenarios/sea1.png";
							hero.pbs[1] = "Cenarios/sea2.jpg";
							hero.pbs[2] = "Cenarios/sea3.png";
							form.audioOver.Stop();
							form.audioOcean.PlayLooping();
							
							enemy.Load("Monsters/pufferfish.gif");
							enemy.Size = new Size(70, 70);
							break;
							
						case 3:
							hero.pbs[0] = "Cenarios/forest1.png";
							hero.pbs[1] = "Cenarios/forest2.png";
							hero.pbs[2] = "Cenarios/forest3.png";
							form.audioOcean.Stop();
							form.audioForest.PlayLooping();
							
							enemy.Load("Monsters/pillager.png");
							enemy.Size = new Size(150, 200);
							break;
							
						case 4:
							hero.pbs[0] = "Cenarios/nether1.jpg";
							hero.pbs[1] = "Cenarios/nether2.png";
							hero.pbs[2] = "Cenarios/nether3.png";
							form.audioForest.Stop();
							form.audioNether.PlayLooping();
							
							enemy.Load("Monsters/blaze.gif");
							enemy.Size = new Size(65, 130);
							break;
							
						case 5:
							hero.pbs[0] = "Cenarios/caves1.jpg";
							hero.pbs[1] = "Cenarios/caves2.png";
							hero.pbs[2] = "Cenarios/caves3.png";
							form.audioNether.Stop();
							form.audioCave.PlayLooping();
							
							enemy.Load("Monsters/spider.png");
							enemy.Size = new Size(110, 95);
							break;
							
						case 6:
							hero.pbs[0] = "Cenarios/end.jpg";
							hero.pbs[1] = "Cenarios/end.jpg";
							hero.pbs[2] = "Cenarios/end.jpg";
							form.audioCave.Stop();
							form.audioEnd.PlayLooping();
							
							enemy.Load("Monsters/dragon.gif");
							enemy.Size = new Size(250, 250);
							break;
					}
					
					form.rectangle.Visible = false;
					form.title.Visible = false;
					form.painel.Visible = true;
					enemy.contadorBoss = 0;
					hero.Left = 0;
					pausa = 0;
					enemy.damage = 1;
					life = fases;
					
					pocoes.queda.Start();
					enemy.relogio.Start();
					form.all.Start();
					intervalo.Stop();
					
					form.KeyPreview = true;
					
					hero.i = 0;
					imagem.Load(hero.pbs[hero.i]);
					
					//Caso seja a fase do boss
					if(boss)
					{
						//Resetar status do Herói
						hero.damage = 1;
						hero.speed = 25;
						bulletSpeed = 10;
						penetration = false;
						enemyBullet.escudo = false;
				
						enemy.contadorBoss = 9;
						life = 10;
						coracao.Height = 50;
					}
					
					coracao.Load("Hearts/heart" + life + ".png");
				}
			}
		}
	}
}