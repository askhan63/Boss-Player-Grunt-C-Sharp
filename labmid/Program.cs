public abstract class Character
{
    protected int startHit;
    protected int currentHit;
    protected bool alive=true;
    protected string name;
    protected int health = 100;
   public Character()
    {
        this.alive = true;
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public void setHits(int strt)
    {
        this.startHit = strt;
        this.currentHit = strt;
    }
  
    public void TakeHit(int demage)
    {
        Console.WriteLine(name + " has been hit with " + demage + " demage");
        this.currentHit =this.currentHit- demage;
       
        if (this.currentHit <= 0)
        {
            alive = false;
            Console.WriteLine(name + " has been dead. " );
        }
        else
        {
            Console.WriteLine(name + " had now health of "+Health());
        }
    }
    public int Health()
    {
        int x = ((currentHit)*100) / startHit;
      

        if (x == 100)
        {
            return x;
        }
        else

        {

            x = 100 - x;
            return 100-x;
        }
    }
    public bool IsAlive()
    {
   return alive;
    }
    public void DisplayYourself()
    {
        Console.WriteLine(name + " Health:" + Health());
      
            Console.WriteLine(name + ": ");
            int Hp = Health() / 10;
            for (int i=0; i < 10; i++)
            {
                if (i < Hp)
                    Console.Write("=");
                else
                    Console.Write("-");

            }
        
    }
    public abstract int Attact();
}
public class Boss : Character
{
    int MaxAttact = 10;
    public Boss()
    {
        Name = "Boss";
        setHits(200);
    }


    public override int Attact()
    {
        Random rnd = new Random();
        int val = rnd.Next(0, MaxAttact+1);
        Console.WriteLine(Name + "“ mega attacks you inflicting" + val + " damage");
        return val;
    }
    
}

class Grunt : Character
{
    public static int GruntId = 0;
    public int MaxAttact = 5;
    public Grunt()
    {
        GruntId++;
        Name = "Grant " + GruntId;
        setHits(100);

    }
    public override int Attact()
    {
        Random rnd = new Random();
        int val = rnd.Next(0, MaxAttact + 1);
        Console.WriteLine(Name + "“ mega attacks you inflicting" + val + " damage");
        return val;
    }
}

class Player : Character
{
    public Player()
    {
        Name = "Player 1";
        setHits(100);
    }
    public override int Attact()
    {
        Random rnd = new Random();
        int val = rnd.Next(0, 30 + 1);
        Console.WriteLine(Name + "“ mega attacks you inflicting" + val + " damage");
        return val;
    }
}
class Game : Object
{
    List<Character> BadGays = new List<Character>();
    Player player;
    public int noGrants;
    public Game()
    {
        Random rnd = new Random();
        int val = rnd.Next(1, 2 + 1);
        Console.WriteLine("You’ll be facing " + val + " grunts. ");
        for (int i = 0; i < val; i++)
        {
            BadGays.Add(new Grunt());
        }
        BadGays.Add(new Boss());
        player = new Player();
       
    }
    public bool Win()
    {
        bool check = true;
        foreach (var x in BadGays)
        {
            if(x.IsAlive())
                return false;
        }
        return check;

    }
    public bool Loss()
    {
        return (!player.IsAlive());
    }
    public int ChoseWhoToAttact()
    {
        for (int i = 0; i < BadGays.Count; i++)
        {
            Console.WriteLine(i + ": " + BadGays[i].Name);

        }
        int x = Convert.ToInt32(Console.ReadLine());
        return x;
    }
    public void playRound()
    {
        player.DisplayYourself();
        for (int i = 0; i < BadGays.Count; i++)
        {
            if (BadGays[i].IsAlive())
            {
                player.TakeHit(BadGays[i].Attact());
            }

        }

        if (player.IsAlive())
        {
            int x = ChoseWhoToAttact();
            BadGays[x].TakeHit(player.Attact());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            while ((!myGame.Win()) && (!myGame.Loss()))
            {
                myGame.playRound();
                Console.WriteLine();
            }

        }
    }
}
