using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        const int MAX_WRONG_GUESSES = 6;
        const int MAX_LETTERS = 10;
        TextBox[] letters = new TextBox[MAX_LETTERS];
        String secretWord;
        int incorrectGuesses = 0;

        //initialize the set which stores the guessed letters
        HashSet<char> guessedLetters;
        public Form1()
        {
            InitializeComponent();
            //initialize the set which stores the guessed letters
            guessedLetters = new HashSet<char>();
            
            InitTextBoxes();
        }

        void InitTextBoxes()
        {
            letters[0] = textBox1;
            letters[1] = textBox2;
            letters[2] = textBox3;
            letters[3] = textBox4;
            letters[4] = textBox5;
            letters[5] = textBox6;
            letters[6] = textBox7;
            letters[7] = textBox8;
            letters[8] = textBox9;
            letters[9] = textBox10;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }
        void NewGame()
        {
            //Set secretWord to a new secret word.
            secretWord = WordList.WordList.GetWord();
            //secretWord = "coffee";
            //Call SetupTextBoxes()
            SetupTextBoxes();
            //Clear the set of guessed letters(call its
            //Clear() function)
            guessedLetters.Clear();
            //Clear the text box which displays the
            //guessed letters.
            guessedLettersText.Text = "";
            //  Set incorrectGuesses to 0
            incorrectGuesses = 0;
            //Set the image in the big picture box to
            //image1.
            pictureBox1.Image = global::Hangman.Properties.Resources.image1;
        }

        void SetupTextBoxes()
        {
            for (int i = 0; i < MAX_LETTERS; i++)
            {
                if (i < secretWord.Length)
                {
                    letters[i].Visible = true;
                    letters[i].Text = "_";
                }
                else
                {
                    letters[i].Visible = false;
                }
            }
        }


        private void guessButton_Click(object sender, EventArgs e)
        {
            if (!(PlayerWon() || incorrectGuesses > MAX_WRONG_GUESSES))
            {
                HandleGuess();
            }
        }
        void HandleGuess()
        {


            if (guessBox.Text.Length > 0) //make sure something was entered
            {
                char ch = guessBox.Text[0]; //get the 1st character in the text
                                            //see if the player guessed it, if not, see if it's in the word
                                           
                if (guessedLetters.Contains(ch))
                {
                    MessageBox.Show("You've already guessed " + ch + ".");
                }
                else
                {
                    //put the letter in the set of used letters
                    guessedLetters.Add(ch);
                    //append the character to the guessed letters text box
                    guessedLettersText.Text += ch;
                    //now use CheckGuess() to see if the that letter was in the secret word.
                    //hint: if (CheckGuess(ch))
                    if (CheckGuess(ch))
                    {
                        if (PlayerWon())
                        {
                            MessageBox.Show("You win!");
                        }
                    }
                    else
                    {
                        incorrectGuesses++;
                        NextPicture();
                        if (incorrectGuesses > MAX_WRONG_GUESSES)
                        {
                            MessageBox.Show("You lose! the word is " + secretWord);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a letter a-z");
                return;
            }
        }

        bool CheckGuess(char ch)
        {
            bool found = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                //does char i in the word match char i in the word
                if (secretWord[i] == ch)
                {
                    // we found a match!
                    // FOR YOU TO DO: put the ch in letters array at positin i
                    letters[i].Text = "" + ch;
                    // FOR YOU TO DO: set found to true
                    found = true;
                }
            }
            return found;
        }
        //displays the picture of the character in the PictureBox control
        public void NextPicture()
        {
            if (incorrectGuesses == 1)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image2;
            }
            else if (incorrectGuesses == 2)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image3;
            }
            else if (incorrectGuesses == 3)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image4;
            }
            else if (incorrectGuesses == 4)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image5;
            }
            else if (incorrectGuesses == 5)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image6;
            }
            else if (incorrectGuesses == 6)
            {
                pictureBox1.Image = global::Hangman.Properties.Resources.image7;
            }
        }
        private bool PlayerWon()
        {
            //look at each char in the word and see
            //if it has been guessed
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (!guessedLetters.Contains(secretWord[i]))
                {
                    //found a character that hasn't been guessed yet
                    return false;
                }
            }
            return true; //if we reached here, all the characters must have been guessed
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
