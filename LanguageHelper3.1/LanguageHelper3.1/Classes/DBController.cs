using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LanguageHelper3._1.Classes
{
    class DBController
    {
        public DBController()
        {

        }

        //---- Method for Filling Supplied DataGrid
        //-- This method fills the supplied DataGrid with all rows from the Translations table
        //- This method performs an inner join on the Hiragana and Translations tables to return 
        //- a list of all Japanese words with translations, those translations, and related Kanji
        //- and Romanji.  If successful, the method returns a boolean value of true, and if not 
        //- successful, returns a value of false.
        public bool FillDataGrid(DataGrid grid)
        {
            bool filled = false;

            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter("(SELECT hiragana.word AS word, translation.kanji AS kanji, hiragana.romanji AS romanji, translation.english AS englishword FROM hiragana "
                                                           + "LEFT JOIN translation ON hiragana.word = translation.hiragana) "
                                                           + "ORDER BY translation.hiragana ASC", con);
                DataTable table = new DataTable();
                adapter.Fill(table);

                grid.ItemsSource = table.DefaultView;

                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return filled;
        }

        //---- Method for Filling Supplied ComboBox with Kanji
        //-- This method selects all Kanji from the Kanji table and fills the selection options
        //- in the supplied ComboBox with that data.  If successful, the method returns a boolean 
        //- value of true, and if not successful, returns a value of false.
        public void FillComboBoxHiragana(ComboBox box)
        {
            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT word FROM hiragana", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "t");
                con.Close();

                box.ItemsSource = ds.Tables["t"].DefaultView;
                box.DisplayMemberPath = ds.Tables["t"].Columns["word"].ToString(); ;
                box.SelectedValuePath = ds.Tables["t"].Columns["word"].ToString(); ;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //---- Method for Filling Supplied ComboBox with Hiragana
        //-- This method selects all Hiragana from the Hiragana table and fills the selection options
        //- in the supplied ComboBox with that data.  If successful, the method returns a boolean 
        //- value of true, and if not successful, returns a value of false.
        public void FillComboBoxKanji(ComboBox box)
        {
            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT symbol FROM kanji", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "t");
                con.Close();

                box.ItemsSource = ds.Tables["t"].DefaultView;
                box.DisplayMemberPath = ds.Tables["t"].Columns["symbol"].ToString(); ;
                box.SelectedValuePath = ds.Tables["t"].Columns["symbol"].ToString(); ;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //---- Method for Filling Supplied ComboBox with English Words
        //-- This method selects all EnglishWords from the EnglishWords table and fills the selection 
        //- options in the supplied ComboBox with that data.  If successful, the method returns a boolean 
        //- value of true, and if not successful, returns a value of false.
        public void FillComboBoxEnglish(ComboBox box)
        {
            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT word FROM english", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "t");
                con.Close();

                box.ItemsSource = ds.Tables["t"].DefaultView;
                box.DisplayMemberPath = ds.Tables["t"].Columns["word"].ToString(); ;
                box.SelectedValuePath = ds.Tables["t"].Columns["word"].ToString(); ;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //---- Method for Filling Supplied ComboBox with English Translations
        //-- This method selects all EnglishWords from the Translations table that are associated with
        //- the given Hiragana field key, and then fills the given ComboBox with that data.If successful,
        //- method returns a boolean value of true, and if not successful, returns a value of false.
        public void FillComboBoxTranslations(ComboBox box, string key)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("SELECT english FROM translation WHERE hiragana=@key");

                SqlParameter keyParam = new SqlParameter("@key", SqlDbType.NVarChar, 50);
                keyParam.Value = key;
                command.Parameters.Add(keyParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "t");
                connection.Close();

                box.ItemsSource = ds.Tables["t"].DefaultView;
                box.DisplayMemberPath = ds.Tables["t"].Columns["english"].ToString(); ;
                box.SelectedValuePath = ds.Tables["t"].Columns["english"].ToString(); ;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //---- Method for Inserting a Row into Hiragana Table
        //-- This method uses the supplied strings newHiragana and newRomanji to insert a new 
        //- row into the Hiragana table, only if a row with the same Hiragana does not already
        //- exist.  If successful, the method returns a boolean value of true, and if not 
        //- successful, returns a value of false.
        public bool InsertHiragana(string newHiragana, string newRomanji)
        {
            bool added = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("IF NOT EXISTS (SELECT * FROM hiragana WHERE word = @Hiragana) INSERT INTO hiragana (word, romanji)"
                                     + " VALUES (@Hiragana, @Romanji)");

                //get the parameters added to command
                SqlParameter hiraganaParam = new SqlParameter("@Hiragana", SqlDbType.NVarChar, 50);
                SqlParameter romanjiParam = new SqlParameter("@Romanji", SqlDbType.NVarChar, 50);
                hiraganaParam.Value = newHiragana;
                romanjiParam.Value = newRomanji;
                command.Parameters.Add(hiraganaParam);
                command.Parameters.Add(romanjiParam);

                //Open connection, insert data, close connection
                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                added = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return added;
        }

        //---- Method for Inserting a Row into Kanji Table
        //-- This method uses the supplied strings newKanji to insert a new row into the Kanji table, 
        //- only if a row with the same Hiragana does not already exist.  If successful, the method 
        //- returns a boolean value of true, and if not successful, returns a value of false.
        public bool InsertKanji(string newKanji)
        {
            bool added = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("IF NOT EXISTS (SELECT * FROM kanji WHERE symbol=@Kanji) INSERT INTO kanji (symbol)"
                                     + " VALUES (@Kanji)");

                //get the parameters added to command
                SqlParameter kanjiParam = new SqlParameter("@Kanji", SqlDbType.NVarChar, 50);
                kanjiParam.Value = newKanji;
                command.Parameters.Add(kanjiParam);

                //Open connection, insert data, close connection
                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                added = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return added;
        }

        //---- Method for Inserting a Row into EnglishWords Table
        //-- This method uses the supplied strings newEnglish to insert a new row into the EnglishWords table, 
        //- only if a row with the same EnglishWord does not already exist.  If successful, the method 
        //- returns a boolean value of true, and if not successful, returns a value of false.
        public bool InsertEnglishWord(string newEnglish)
        {
            bool added = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("IF NOT EXISTS (SELECT * FROM english WHERE word=@English) INSERT INTO english (word)"
                                     + " VALUES (@English)");

                //get the parameters added to command
                SqlParameter englishParam = new SqlParameter("@English", SqlDbType.NVarChar, 50);
                englishParam.Value = newEnglish;
                command.Parameters.Add(englishParam);

                //Open connection, insert data, close connection
                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                added = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return added;
        }

        //---- Method for Inserting a Row into Translation Table
        //-- This method uses the supplied strings newHiragana, newEnglish, and newKanji to insert a
        //- row into the Translations table, only if a row does not exist with the same Englishword and
        //- Hiragana attributes.  Since Kanji is allowed to be null in the table, the string newKanji 
        //- may be null.  Because of this, the string is checked if it is null, and if so a DBNull value
        //- is put into the SQLParameter kanjiParam.  If it is not null, then the string is put in as given.
        //- The method returns a boolean value of true if the insert was successful and false if it was not.
        public bool InsertTranslation(string newHiragana, string newEnglish, string newKanji)
        {
            bool added = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("IF NOT EXISTS (SELECT * FROM translation WHERE english=@English AND hiragana=@Hiragana) INSERT INTO translation"
                                     + " (english, hiragana, kanji) VALUES (@English, @Hiragana, @Kanji)");

                //get the parameters added to command
                SqlParameter englishParam = new SqlParameter("@English", SqlDbType.NVarChar, 50);
                SqlParameter hiraganaParam = new SqlParameter("@Hiragana", SqlDbType.NVarChar, 50);
                SqlParameter kanjiParam = new SqlParameter("@Kanji", SqlDbType.NVarChar, 50);
                englishParam.Value = newEnglish;
                hiraganaParam.Value = newHiragana;

                if (newKanji == null)
                    kanjiParam.Value = DBNull.Value;
                else
                    kanjiParam.Value = newKanji;

                command.Parameters.Add(englishParam);
                command.Parameters.Add(hiraganaParam);
                command.Parameters.Add(kanjiParam);

                //Open connection, insert data, close connection
                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                added = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return added;
        }

        //---- Method for Removing an English Word
        //-- This method removes any row that has the supplied string in the EnglishWord field of the EnglishWords
        //- table, as well as the Translations table.  If successful, the method returns a boolean value of true, 
        //- and if not successful, returns a value of false.
        public bool RemoveEnglishWord(string wordToRemove)
        {
            bool removed = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("DELETE FROM english WHERE word = @English");
                
                SqlParameter englishParam = new SqlParameter("@English", SqlDbType.VarChar, 50);
                englishParam.Value = wordToRemove;
                command.Parameters.Add(englishParam);
                
                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                englishParam = new SqlParameter("@English", SqlDbType.VarChar, 50);
                englishParam.Value = wordToRemove;
                
                command.CommandText = ("DELETE FROM translation WHERE english = @English");

                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                removed = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return removed;
        }

        //---- Method for Removing a Japanese Word
        //-- This method removes any row that has the supplied string in the Hiragana field of the Hiragana
        //- table, as well as the Translations table.  If successful, the method returns a boolean value of 
        //- true, and if not successful, returns a value of false.
        public bool RemoveJapaneseWord(string wordToRemove)
        {
            bool removed = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("DELETE FROM hiragana WHERE word = @Hiragana");

                SqlParameter hiraganaParam = new SqlParameter("@Hiragana", SqlDbType.NVarChar, 50);
                hiraganaParam.Value = wordToRemove;
                command.Parameters.Add(hiraganaParam);

                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();
                
                hiraganaParam = new SqlParameter("@Hiragana", SqlDbType.VarChar, 50);
                hiraganaParam.Value = wordToRemove;
                
                command.CommandText = ("DELETE FROM translation WHERE hiragana = @Hiragana");

                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                removed = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return removed;
        }

        //----Method for Removing a Translation
        //--This method removes any row from the Translation Table that matched the supplied Hiragana and
        //- English word.  If successful, the method returns a boolean value of true, and if not successful,
        //- returns a value of false.
        public bool RemoveTranslation(string keyHiragana, string keyEnglish)
        {
            bool removed = false;

            try
            {
                SqlConnection connection = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = ("DELETE FROM translation WHERE hiragana = @Hiragana AND english = @English");

                SqlParameter hiraganaParam = new SqlParameter("@Hiragana", SqlDbType.NVarChar, 50);
                SqlParameter englishParam = new SqlParameter("@English", SqlDbType.VarChar, 50);
                hiraganaParam.Value = keyHiragana;
                englishParam.Value = keyEnglish;
                command.Parameters.Add(hiraganaParam);
                command.Parameters.Add(englishParam);

                connection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();

                removed = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return removed;
        }

    }
}
