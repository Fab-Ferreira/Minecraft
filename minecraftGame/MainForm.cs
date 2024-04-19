using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace minecraftGame
{
	//Classe MainForm
	public partial class MainForm : Form
	{
		//Áudios
		public SoundPlayer audioOver = new SoundPlayer("Audios/overworld.wav");
		public SoundPlayer audioOcean = new SoundPlayer("Audios/ocean.wav");
		public SoundPlayer audioForest = new SoundPlayer("Audios/forest.wav");
		public SoundPlayer audioNether = new SoundPlayer("Audios/nether.wav");
		public SoundPlayer audioCave = new SoundPlayer("Audios/cave.wav");
		public SoundPlayer audioEnd = new SoundPlayer("Audios/end.wav");
		
		//Classes
		Cenario imagem = new Cenario();
		Heroi heroi = new Heroi();
		Inimigo inimigo = new Inimigo();
		Bullet tiro = new Bullet();
		Hearts coracao = new Hearts(); //HP do inimigo
		Hearts vida = new Hearts(); //HP do herói
		Potions pocoes = new Potions();
		EnemyBullet enemyTiro = new EnemyBullet();
		
		//Componentes
		PictureBox[] pauseButtons = new PictureBox[3], btn = new PictureBox[4];
		public Panel painel = new Panel();
		public PictureBox personagemChoose, escudo = new PictureBox(), rectangle = new PictureBox(), tutorial = new PictureBox(), 
		title = new PictureBox(), rectangleIcons = new PictureBox();
		
		//Variáveis
		int delay, timer = 3;
		bool pausado, visivel;
			
		public MainForm() //Características do MainForm & Criação dos botões iniciais
		{
			//Ao iniciar o programa
			InitializeComponent();
			audioOver.PlayLooping();
			Width = 1440;
			Height = 700;
			imagem.Parent = this;
			
			//Configuração dos botões iniciais
			startBtn.Parent = imagem;
			startBtn.Location = new Point(Width / 2 - startBtn.Width / 2, Height / 2 - startBtn.Height / 2);
			creditsBtn.Parent = imagem;
			creditsBtn.Location = new Point(startBtn.Left, startBtn.Top + 100);
			sairBtn.Parent = imagem;
			sairBtn.Location = new Point(creditsBtn.Left, creditsBtn.Top + 100);
			backBtn.Location = new Point(sairBtn.Left, sairBtn.Top);
			backBtn.Enabled = false;
		}
		
		//Ao escolher o Personagem
		public void HeroiChoose(object sender, EventArgs e)
		{
			foreach(PictureBox pb in btn)
			{
				pb.Dispose();
			}
			
			//Título
			title.Load("Components/dica.png");
			title.Size = new Size(291, 123);
			title.SizeMode = PictureBoxSizeMode.StretchImage;
			title.Location = new Point(Width / 2 - (title.Width /2), 30);
			
			//PictureBox de fundo para o tutorial
			rectangle.Parent = imagem;
			rectangle.BackColor = Color.Transparent;
			rectangle.Load("Components/rectangle.png");
			rectangle.Size = new Size(1000, 400);
			rectangle.SizeMode = PictureBoxSizeMode.StretchImage;
			rectangle.Location = new Point(Width / 2 - (rectangle.Width / 2), Height / 2 - 150);
			
			//Tutorial
			tutorial.Parent = rectangle;
			tutorial.Size = new Size(800, 293);
			tutorial.SizeMode = PictureBoxSizeMode.StretchImage;
			tutorial.Load("Components/tutorial.png");
			tutorial.Location = new Point(rectangle.Width / 2 - (tutorial.Width / 2), rectangle.Height / 2 - (tutorial.Height / 2));
			
			Text = "Carregando...";
			imagem.Load("Cenarios/loading.jpg");
			contagem.Start();
			
			personagemChoose = (sender as PictureBox);
		}
		
		//Ao clicar em Iniciar
		void ButtonClick(object sender, EventArgs e)
		{
			creditsBtn.Dispose();
			startBtn.Dispose();
			backBtn.Dispose();
			sairBtn.Enabled = false;
			sairBtn.Visible = false;
			Text = "Escolha o seu personagem.";
			imagem.Load("Cenarios/cenario1.jpg");
			
			//Inserir título
			title.Parent = imagem;
			title.Load("Components/selecaoPersonFrase.png");
			title.BackColor = Color.Transparent;
			title.SizeMode = PictureBoxSizeMode.StretchImage;
			title.Size = new Size(600, 196);
			title.Location = new Point(Width / 2 - (title.Width / 2), 20);
			
			//Criar PictureBoxes (personagens)
			btn[0] = new PictureBox();
			btn[1] = new PictureBox();
			btn[2] = new PictureBox();
			btn[3] = new PictureBox();
			
			btn[0].Name = "allay";
			btn[1].Name = "bee";
			btn[2].Name = "bat";
			btn[3].Name = "parrot";
			
			foreach(PictureBox pb in btn)
			{
				pb.Parent = imagem;
				pb.Click += HeroiChoose;
				pb.BackColor = Color.Transparent;
				pb.Size =  new Size(250, 250);
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.Cursor = Cursors.Hand;
			}

			//Localização das PictureBoxes
			btn[0].Location = new Point((Width / 2) - (btn[0].Width / 2) - 500, Height / 2 - (btn[0].Height / 4));
			btn[1].Location = new Point((Width / 2) - (btn[1].Width / 2) - 160, Height / 2 - (btn[1].Height / 4));
			btn[2].Location = new Point((Width / 2) - (btn[2].Width / 2) + 160, Height / 2 - (btn[2].Height / 4));
			btn[3].Location = new Point((Width / 2) - (btn[3].Width / 2) + 500, Height / 2 - (btn[3].Height / 4));
			
			//Imagens
			btn[0].Load("Personagens/allay.png");
			btn[1].Load("Personagens/bee.png");
			btn[2].Load("Personagens/bat.png");
			btn[3].Load("Personagens/parrot.png");
		}
		
		//Movimentos
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if(!pausado)
			{
				if(e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
				{
					heroi.W(imagem);
				}
				
				else if(e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
				{
					heroi.A(imagem);
				}
				
				else if(e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
				{
					heroi.S(imagem);
				}
				
				else if(e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
				{
					heroi.D(imagem);
				}
				
				if(e.KeyCode == Keys.Space && !tiro.shooting)
				{
					tiro.shooting = true;
					tiro.direction = heroi.right;
					
					if(tiro.direction) tiro.Location = new Point(heroi.Left + heroi.Width, heroi.Top + heroi.Height / 2);
					else tiro.Location = new Point(heroi.Left - heroi.Width / 2, heroi.Top + heroi.Height / 2);
					
					tiro.relogio.Start();
				}
			}
			
			if(e.KeyCode == Keys.Escape) Pause(sender, e);
		}
		
		//Carregamento (Tela de Loading)
		void ContagemTick(object sender, EventArgs e)
		{
			timer--;
			
			if(timer == 0) //Quando o jogo começar
			{
				all.Start();
				contagem.Stop();
				KeyPreview = true;
				title.Visible = false;
				imagem.Load("Cenarios/cenario1.jpg");
				
				//PictureBox de fundo do tutorial
				rectangle.Visible = false;
				rectangle.Load("Components/rectangle1.png");
				rectangle.Height = 300;
				rectangle.Top += 25;
				
				//Tutorial
				tutorial.Height = 200;
				tutorial.Location = new Point(rectangle.Width / 2 - (tutorial.Width /2), rectangle.Height / 2 - (tutorial.Height / 2));
				
				//Painel onde fica a vida do personagem e outros
				painel.Parent = imagem;
				painel.Size = new Size(1440, 100);
				painel.BackColor = Color.Transparent;
				
				//PictureBox para os ícones
				rectangleIcons.Parent = painel;
				rectangleIcons.Load("Components/rectangle.png");
				rectangleIcons.Size = new Size(400, 100);
				rectangleIcons.BackColor = Color.Transparent;
				rectangleIcons.SizeMode = PictureBoxSizeMode.StretchImage;
				rectangleIcons.Location = new Point((painel.Width / 2) - (rectangleIcons.Width / 2), painel.Top);

				//Escudo (Totem)
				escudo.Parent = painel;
				escudo.SizeMode = PictureBoxSizeMode.StretchImage;
				escudo.Size = new Size(75, 75);
				escudo.Location = new Point(1200, painel.Top + 10);
				
				//Label "Paused"
				labelPaused.Location = new Point(Width - labelPaused.Width, Height - labelPaused.Height * 2);
				labelPaused.Parent = imagem;
				labelPaused.BackColor = Color.Transparent;
				
				//Características dos ícones de opções
				pauseButtons[0] = new PictureBox();
				pauseButtons[1] = new PictureBox();
				pauseButtons[2] = new PictureBox();
				
				foreach (PictureBox pbs in pauseButtons)
				{
					pbs.Size = new Size(75, 75);
					pbs.BackColor = Color.Transparent;
					pbs.Parent = rectangleIcons;
					pbs.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				
				pauseButtons[0].Load("Icons/pause.png");
				pauseButtons[1].Load("Icons/restart.png");
				pauseButtons[2].Load("Icons/quit.png");
				
				pauseButtons[0].Click += Pause;
				pauseButtons[1].Click += Restart;
				pauseButtons[2].Click += Quit;
				
				pauseButtons[1].Location = new Point((rectangleIcons.Width / 2) - (pauseButtons[1].Width / 2), rectangleIcons.Top + 10);
				pauseButtons[0].Location = new Point(pauseButtons[1].Left - 120, pauseButtons[1].Top);
				pauseButtons[2].Location = new Point(pauseButtons[1].Left + 120, pauseButtons[1].Top);
				
				//Classe Inimigo
				inimigo.Parent = imagem;
				inimigo.vida = vida;
				inimigo.coracao = coracao;
				inimigo.hero = heroi;
				inimigo.imagem = imagem;
				inimigo.relogio.Enabled = true;
				inimigo.enemyTiro = enemyTiro;
				inimigo.tiro = tiro;
				inimigo.pocoes = pocoes;
				inimigo.form = this;
				
				//Classe Hearts
				coracao.Parent = imagem;
				vida.Parent = painel;
				vida.Location = new Point(20, 10);
				
				//Classe Heroi
				heroi.Parent = imagem;
				
				//Classe Bullet
				tiro.Parent = imagem;
				tiro.imagem = imagem;
				tiro.hero = heroi;
				tiro.enemy = inimigo;
				tiro.vida = vida;
				tiro.coracao = coracao;
				tiro.enemyBullet = enemyTiro;
				tiro.pocoes = pocoes;
				tiro.form = this;
				
				//Classe EnemyBullet
				enemyTiro.Parent = imagem;
				enemyTiro.imagem = imagem;
				enemyTiro.hero = heroi;
				enemyTiro.tiro = tiro;
				enemyTiro.inimigo = inimigo;
				enemyTiro.vida = vida;
				enemyTiro.coracao = coracao;
				enemyTiro.pocoes = pocoes;
				enemyTiro.delay.Start();
				enemyTiro.form = this;
				
				//Classe Potions
				pocoes.hero = heroi;
				pocoes.tiro = tiro;
				pocoes.Parent = imagem;
				pocoes.enemyTiro = enemyTiro;
				
				//Botões Restart e Quit
				reiniciarBtn.Location = new Point(Width / 2 - (reiniciarBtn.Width / 2) - 200, Height / 2 + (reiniciarBtn.Height * 2));
				sairBtn.Location = new Point(Width / 2 - (sairBtn.Width / 2) + 200, Height / 2 + (sairBtn.Height * 2));
				
				//Definir a imagem do herói e do tiro do herói
				switch (personagemChoose.Name)
				{
					case "allay":
						heroi.mobName = "Allay";
						heroi.Load("Personagens/allayDir.gif");
						tiro.Load("Itens/diamondR.png");
						break;
					case "bee":
						heroi.mobName = "Abelha";
						heroi.Load("Personagens/beeDir.gif");
						tiro.Load("Itens/honeyR.png");
						break;
					case "bat":
						heroi.mobName = "Morcego";
						heroi.Load("Personagens/batDir.gif");
						tiro.Load("Itens/bone.png");
						break;
					case "parrot":
						heroi.mobName = "Papagaio";
						heroi.Load("Personagens/parrotDir.gif");
						tiro.Load("Itens/cocoaBeans.png");
						break;
				}
			}
		}
		
		//Opção de pausar o jogo
		public void Pause(object sender, EventArgs e)
		{
			pausado = !pausado;
			
			if(pausado)
			{
				all.Stop();
				enemyTiro.delay.Stop();
				enemyTiro.relogio.Stop();
				inimigo.relogio.Stop();
				tiro.relogio.Stop();
				if(pocoes.ativado) pocoes.queda.Stop();
				pausedTimer.Start();
				pauseButtons[0].Load("Icons/play.png");
				Text = "Paused!";
			}
			else
			{
				all.Start();
				enemyTiro.delay.Start();
				enemyTiro.relogio.Start();
				inimigo.relogio.Start();
				if(tiro.Left > -50) tiro.relogio.Start();
				if(pocoes.ativado) pocoes.queda.Start();
				pausedTimer.Stop();
				labelPaused.Visible = false;
				pauseButtons[0].Load("Icons/pause.png");
			}
		}
		
		//Opções de reiniciar e sair
		public void Restart(object sender, EventArgs e){Application.Restart();}
		public void Quit(object sender, EventArgs e){Application.Exit();}
		
		void Credits(object sender, EventArgs e)
		{
			imagem.Load("Cenarios/credits.png");
			startBtn.Visible = false;
			startBtn.Enabled = false;
			sairBtn.Visible = false;
			sairBtn.Enabled = false;
			creditsBtn.Visible = false;
			creditsBtn.Enabled = false;
			backBtn.Visible = true;
			backBtn.Enabled = true;
		}
		
		void Back(object sender, EventArgs e)
		{
			imagem.Load("Cenarios/fundo.png");
			startBtn.Visible = true;
			startBtn.Enabled = true;
			sairBtn.Visible = true;
			sairBtn.Enabled = true;
			creditsBtn.Visible = true;
			creditsBtn.Enabled = true;
			backBtn.Visible = false;
			backBtn.Enabled = false;
		}
		
		//Verificação a cada 5 milisegundo (Texto do MainForm, HP do Inimigo e do Herói, Iniciar queda de poções, Resetar configurações do Heroi)
		public void AllTick(object sender, EventArgs e)
		{
			delay++;
			
			//Texto do programa
			Text = "Fase " + tiro.fases + "\n    Personagem: " + heroi.mobName + "\n    Vida: " + heroi.hp + 
					"\n    Velocidade: " + heroi.speed + "\n    Dano: " + heroi.damage + "\n    Velocidade do Tiro: " + tiro.bulletSpeed +
					"\n    Penetração: " + tiro.penetration + "\n    Escudo: " + enemyTiro.escudo;
			
			//tamanho da PictureBox do HP do Inimigo
			switch (tiro.life)
			{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					coracao.Size = new Size(25 * tiro.life, 25);
					break;
				
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					coracao.Size = new Size(125, 50);
					break;
			}
			
			//HP do Heroi e o tamanho de sua PictureBox
			if(heroi.hp > 0) {vida.Load("Hearts/heart" + heroi.hp + ".png"); vida.Size = new Size(75 * heroi.hp, 75);}
			
			if(enemyTiro.escudo) escudo.Load("Itens/totemOn.png");
			else escudo.Load("Itens/totemOff.png");
			
			//Definir status padrão do Herói
			if(delay % 1000 == 0)
			{
				heroi.damage = 1;
				heroi.speed = 25;
				tiro.bulletSpeed = 10;
				tiro.penetration = false;
				enemyTiro.escudo = false;
			}
			
			//Exibir poções
			if(!pocoes.ativado && delay % 500 == 0 && !tiro.boss)
			{
				pocoes.ativado = true;
				pocoes.Left = pocoes.rnd.Next(0, 1400);
				pocoes.type = pocoes.rnd.Next(0, 7);
				
				if(pocoes.type == 0) pocoes.Load("Potions/speedP.gif");
				else if(pocoes.type == 1) pocoes.Load("Potions/strengthP.gif");
				else if(pocoes.type == 2) pocoes.Load("Potions/bulletSpeedP.gif");
				else if(pocoes.type == 3) pocoes.Load("Potions/penetrationP.gif");
				else if(pocoes.type == 4) pocoes.Load("Itens/totemOn.png");
				else if(pocoes.type == 5) pocoes.Load("Potions/damageP.gif");
				else pocoes.Load("Potions/regenerationP.gif");
				
				pocoes.queda.Start();
			}
			
			if(heroi.hp <= 0) //Se o personagem morrer
			{
				KeyPreview = false;
				imagem.Load("Cenarios/gameover.jpg");
				Text = "Game Over";
				
				//Excluir componentes
				heroi.Dispose();
				tiro.Dispose();
				inimigo.Dispose();
				pocoes.Dispose();
				enemyTiro.Dispose();
				coracao.Dispose();
				vida.Dispose();
				painel.Dispose();
				
				//Botões Restart & Quit
				reiniciarBtn.Enabled = true;
				reiniciarBtn.Visible = true;
				sairBtn.Enabled = true;
				sairBtn.Visible = true;
				
				//Desativar timers
				inimigo.relogio.Stop();
				tiro.relogio.Stop();
				pocoes.queda.Stop();
				enemyTiro.delay.Stop();
				all.Stop();
				enemyTiro.relogio.Stop();
			}
		}
		
		//Label "Paused" (Caso o jogo esteja pausado, a Label ficará piscando na tela, indicando que está pausado)
		void PausedTimerTick(object sender, EventArgs e)
		{
			visivel = !visivel;
			if(visivel) labelPaused.Visible = true;
			else labelPaused.Visible = false;
		}
	}
}