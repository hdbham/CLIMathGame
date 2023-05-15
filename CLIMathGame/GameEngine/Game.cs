using System;
using System.Threading;
using static System.Console; // helps sanity a lot for console programs :)

namespace CLIMathGame; // notice this syntax (sets for the whole file, then you don't need brackets)

public abstract class Game
{
    // here are the fields: (for Game data - data about the game, for its entire lifetime)


    
    int score = 0;           // always starts at 0.
    bool isOver = false;     // a useful convention is to start any boolean with "is"  (then we can say:  "if(game.isOver){}"  - very easy to read).
    string username;         // set in constructor, because we don't know what it is yet.
    
    private Random random = new Random();

    // constructor
    public Game(string nam){
        
        this.username = nam;

        // operand param - is now just subclasses for each.
        // message param - is now handled in each subclass.
    }


    protected abstract bool Play(); // each subclass will have to implement this method themselves - it is the ONLY thing that differs between each type of game.
    

    private int nextInt() => random.Next(1, 20); // cool syntax for short methods like this :)

    protected virtual Tuple<int, int> GetNumbers() {   
        
        /* 
         *  "protected" means visible to subclasses
         *  "virtual" just means we can override it in a subclass (because DivisionGame will need its own version of this method).
         *  ---
         *  HOWEVER - for now, lets just do it right here (with a type check) to not be overwhelming, lol.
         *  Just notice why it is bad encapsulation to have DivisionGame logic here.
         */
        

        // return variable
        Tuple<int, int> numbersOut;  // "Tuple" is just a pair of variables - often messy, but here it's fine - just don't use it to return two things that should be separate methods.


        // type check
        if(this is DivisionGame){
            // logic to get Division numbers:

            throw new Exception("to do");
            return numbersOut;


        }else{ 
            // logic to get regular numbers:
        
            int firstNumber   = nextInt();
            int secondNumber  = nextInt();
            
            numbersOut = new Tuple<int, int>(firstNumber, secondNumber);
        }

       return numbersOut;
    }

    private void PlayGame(string name)
    {

        ConsoleKeyInfo lastKeystroke;

        //_consoleTimer = new ConsoleTimer(1000);
        //Clear();
        //SetCursorPosition(0, 1);

        while(true) {

            bool didWin = Play(); // because Play() is abstract, we KNOW that EVERY subclass will implement their own version of it.

            if(didWin)
                score ++;
            else
                break;
        }
        
        //Helpers.AddtoHistory(name, score, message.Split(" ")[0]);
    }

        


}


